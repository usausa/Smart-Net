namespace Smart.Collections.Concurrent
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    public sealed class ConcurrentHashArrayMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private static readonly Node[] EmptyNodes = new Node[0];

        private readonly object sync = new object();

        private readonly IHashArrayMapStrategy strategy;

        private Table table;

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="initialSize"></param>
        /// <param name="factor"></param>
        public ConcurrentHashArrayMap(int initialSize = 32, double factor = 1.0)
            : this(new GrowthHashArrayMapStrategy(initialSize, factor))
        {
        }

        public ConcurrentHashArrayMap(IHashArrayMapStrategy strategy)
        {
            this.strategy = strategy;
            table = CreateInitialTable();
        }

        //--------------------------------------------------------------------------------
        // Private
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private static uint CalculateSize(int count)
        {
            uint size = 0;

            for (var i = 1L; i < count; i *= 2)
            {
                size = (size << 1) + 1;
            }

            return size + 1;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private static int CalculateDepth(Node[][] nodes)
        {
            var depth = 0;
            for (var i = 0; i < nodes.Length; i++)
            {
                depth = Math.Max(nodes[i].Length, depth);
            }

            return depth;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private Table CreateInitialTable()
        {
            var size = CalculateSize(strategy.CalculateInitialSize());
            var mask = (int)(size - 1);

            var nodes = new Node[size][];

            for (var i = 0; i < nodes.Length; i++)
            {
                nodes[i] = EmptyNodes;
            }

            return new Table(mask, nodes, 0, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="addNode"></param>
        /// <returns></returns>
        private static Node[] AddNode(Node[] nodes, Node addNode)
        {
            if (nodes == null)
            {
                return new[] { addNode };
            }

            var newNodes = new Node[nodes.Length + 1];
            Array.Copy(nodes, 0, newNodes, 0, nodes.Length);
            newNodes[nodes.Length] = addNode;

            return newNodes;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="oldNodes"></param>
        /// <param name="mask"></param>
        private static void RelocateNodes(Node[][] nodes, Node[][] oldNodes, int mask)
        {
            for (var i = 0; i < oldNodes.Length; i++)
            {
                for (var j = 0; j < oldNodes[i].Length; j++)
                {
                    var node = oldNodes[i][j];
                    var relocateIndex = node.Key.GetHashCode() & mask;
                    nodes[relocateIndex] = AddNode(nodes[relocateIndex], node);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nodes"></param>
        private static void FillEmptyIfNull(Node[][] nodes)
        {
            for (var i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] == null)
                {
                    nodes[i] = EmptyNodes;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldTable"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private Table CreateAddTable(Table oldTable, Node node)
        {
            var requestSize = strategy.CalculateRequestSize(new AddResizeContext(oldTable.Nodes.Length, oldTable.Depth, oldTable.Count, 1));

            var size = CalculateSize(requestSize);
            var mask = (int)(size - 1);
            var newNodes = new Node[size][];

            RelocateNodes(newNodes, oldTable.Nodes, mask);

            var index = node.Key.GetHashCode() & mask;
            newNodes[index] = AddNode(newNodes[index], node);

            FillEmptyIfNull(newNodes);

            return new Table(mask, newNodes, oldTable.Count + 1, CalculateDepth(newNodes));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldTable"></param>
        /// <param name="addNodes"></param>
        /// <returns></returns>
        private Table CreateAddRangeTable(Table oldTable, ICollection<Node> addNodes)
        {
            var requestSize = strategy.CalculateRequestSize(new AddResizeContext(oldTable.Nodes.Length, oldTable.Depth, oldTable.Count, addNodes.Count));

            var size = CalculateSize(requestSize);
            var mask = (int)(size - 1);
            var newNodes = new Node[size][];

            RelocateNodes(newNodes, oldTable.Nodes, mask);

            foreach (var node in addNodes)
            {
                var index = node.Key.GetHashCode() & mask;
                newNodes[index] = AddNode(newNodes[index], node);
            }

            FillEmptyIfNull(newNodes);

            return new Table(mask, newNodes, oldTable.Count + addNodes.Count, CalculateDepth(newNodes));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="table"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetValueInternal(Table table, TKey key, out TValue value)
        {
            var index = key.GetHashCode() & table.HashMask;
            var array = table.Nodes[index];
            for (var i = 0; i < array.Length; i++)
            {
                if (ReferenceEquals(array[i].Key, key) || array[i].Key.Equals(key))
                {
                    value = array[i].Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }

        //--------------------------------------------------------------------------------
        // Public
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        public int Count => table.Count;

        /// <summary>
        ///
        /// </summary>
        public int Depth => table.Depth;

        /// <summary>
        ///
        /// </summary>
        public void Clear()
        {
            lock (sync)
            {
                var newTable = CreateInitialTable();
                Interlocked.MemoryBarrier();
                table = newTable;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(TKey key, out TValue value)
        {
            return TryGetValueInternal(table, key, out value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public TValue AddIfNotExist(TKey key, TValue value)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValueInternal(table, key, out TValue currentValue))
                {
                    return currentValue;
                }

                // Rebuild
                var newTable = CreateAddTable(table, new Node(key, value));
                Interlocked.MemoryBarrier();
                table = newTable;

                return value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueFactory"></param>
        /// <returns></returns>
        public TValue AddIfNotExist(TKey key, Func<TKey, TValue> valueFactory)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValueInternal(table, key, out TValue currentValue))
                {
                    return currentValue;
                }

                // Rebuild
                var value = valueFactory(key);
                var newTable = CreateAddTable(table, new Node(key, value));
                Interlocked.MemoryBarrier();
                table = newTable;

                return value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public int AddRangeIfNotExist(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            lock (sync)
            {
                var nodes = pairs
                    .Distinct(new KeyValuePairEqualityComparer())
                    .Where(x => !TryGetValueInternal(table, x.Key, out TValue _))
                    .Select(x => new Node(x.Key, x.Value))
                    .ToList();

                // Rebuild
                var newTable = CreateAddRangeTable(table, nodes);
                Interlocked.MemoryBarrier();
                table = newTable;

                return nodes.Count;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="valueFactory"></param>
        /// <returns></returns>
        public int AddRangeIfNotExist(IEnumerable<TKey> keys, Func<TKey, TValue> valueFactory)
        {
            lock (sync)
            {
                var nodes = keys
                    .Distinct(new KeyEqualityComparer())
                    .Where(x => !TryGetValueInternal(table, x, out TValue _))
                    .Select(x => new Node(x, valueFactory(x)))
                    .ToList();

                // Rebuild
                var newTable = CreateAddRangeTable(table, nodes);
                Interlocked.MemoryBarrier();
                table = newTable;

                return nodes.Count;
            }
        }

        //--------------------------------------------------------------------------------
        // IEnumerable
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            var nodes = table.Nodes;

            for (var i = 0; i < nodes.Length; i++)
            {
                for (var j = 0; j < nodes[i].Length; j++)
                {
                    var node = nodes[i][j];
                    yield return new KeyValuePair<TKey, TValue>(node.Key, node.Value);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //--------------------------------------------------------------------------------
        // Helper
        //--------------------------------------------------------------------------------

        public TValue this[TKey key]
        {
            get
            {
                if (!TryGetValue(key, out TValue value))
                {
                    throw new KeyNotFoundException();
                }

                return value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsKey(TKey key)
        {
            return TryGetValue(key, out TValue _);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue GetValueOrDefault(TKey key, TValue defaultValue = default(TValue))
        {
            return TryGetValue(key, out TValue value) ? value : defaultValue;
        }

        //--------------------------------------------------------------------------------
        // Inner
        //--------------------------------------------------------------------------------

        private class Node
        {
            public TKey Key { get; }

            public TValue Value { get; }

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        private class Table
        {
            public int HashMask { get; }

            public Node[][] Nodes { get; }

            public int Count { get; }

            public int Depth { get; }

            public Table(int hashMask, Node[][] nodes, int count, int depth)
            {
                HashMask = hashMask;
                Nodes = nodes;
                Count = count;
                Depth = depth;
            }
        }

        private sealed class KeyValuePairEqualityComparer : IEqualityComparer<KeyValuePair<TKey, TValue>>
        {
            public bool Equals(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
            {
                return ReferenceEquals(x.Key, y.Key) || x.Key.Equals(y.Key);
            }

            public int GetHashCode(KeyValuePair<TKey, TValue> obj)
            {
                return obj.Key.GetHashCode();
            }
        }

        private sealed class KeyEqualityComparer : IEqualityComparer<TKey>
        {
            public bool Equals(TKey x, TKey y)
            {
                return ReferenceEquals(x, y) || x.Equals(y);
            }

            public int GetHashCode(TKey obj)
            {
                return obj.GetHashCode();
            }
        }

        private sealed class AddResizeContext : IHashArrayMapResizeContext
        {
            public int Width { get; }

            public int Depth { get; }

            public int Count { get; }

            public int Growth { get; }

            public AddResizeContext(int width, int depth, int count, int growth)
            {
                Width = width;
                Count = count;
                Depth = depth;
                Growth = growth;
            }
        }
    }
}
