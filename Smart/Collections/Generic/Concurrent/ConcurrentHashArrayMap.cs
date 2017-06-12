namespace Smart.Collections.Generic.Concurrent
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    public class ConcurrentHashArrayMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private static readonly Node[] EmptyNodes = new Node[0];

        private readonly object sync = new object();

        private readonly IHashArrayMapStrategy strategy;

        private Table table;

        // TODO Add (max)depth to table

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
        private Table CreateInitialTable()
        {
            var size = CalculateSize(strategy.CalcInitialSize());
            var mask = (int)(size - 1);

            var nodes = new Node[size][];

            for (var i = 0; i < nodes.Length; i++)
            {
                nodes[i] = EmptyNodes;
            }

            return new Table(mask, nodes, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldTable"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Table CreateAddTable(Table oldTable, TKey key, TValue value)
        {
            var hashCode = key.GetHashCode();
            var addIndex = hashCode & oldTable.HashMask;
            var requestSize = strategy.CalcRequestSize(new AddResizeContext(oldTable.Nodes.Length, oldTable.Count));

            if (requestSize <= oldTable.Nodes.Length)
            {
                var nodes = new Node[oldTable.Nodes.Length][];

                for (var i = 0; i < oldTable.Nodes.Length; i++)
                {
                    var oldLength = oldTable.Nodes[i].Length;
                    var newLength = oldLength + (i == addIndex ? 1 : 0);
                    if (newLength > 0)
                    {
                        nodes[i] = new Node[newLength];
                        if (oldLength > 0)
                        {
                            Array.Copy(oldTable.Nodes[i], 0, nodes[i], 0, oldLength);
                        }
                    }
                    else
                    {
                        nodes[i] = EmptyNodes;
                    }
                }

                nodes[addIndex][nodes[addIndex].Length - 1] = new Node(key, value);

                return new Table(oldTable.HashMask, nodes, oldTable.Count + 1);
            }
            else
            {
                var size = CalculateSize(requestSize);
                var mask = (int)(size - 1);
                addIndex = hashCode & mask;

                var nodes = new Node[size][];

                for (var i = 0; i < oldTable.Nodes.Length; i++)
                {
                    for (var j = 0; j < oldTable.Nodes[i].Length; j++)
                    {
                        var node = oldTable.Nodes[i][j];
                        var relocateIndex = node.Key.GetHashCode() & mask;
                        nodes[relocateIndex] = AddNode(nodes[relocateIndex], node);
                    }
                }

                nodes[addIndex] = AddNode(nodes[addIndex], new Node(key, value));

                for (var i = 0; i < nodes.Length; i++)
                {
                    if (nodes[i] == null)
                    {
                        nodes[i] = EmptyNodes;
                    }
                }

                return new Table(mask, nodes, oldTable.Count + 1);
            }
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

        public void Clear()
        {
            lock (sync)
            {
                var newTable = CreateInitialTable();
                Interlocked.Exchange(ref table, newTable);
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
                var newTable = CreateAddTable(table, key, value);
                Interlocked.Exchange(ref table, newTable);

                return value;
            }
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
                var newTable = CreateAddTable(table, key, value);
                Interlocked.Exchange(ref table, newTable);

                return value;
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

        internal class Node
        {
            public TKey Key { get; }

            public TValue Value { get; }

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        internal class Table
        {
            public int HashMask { get; }

            public Node[][] Nodes { get; }

            public int Count { get; }

            public Table(int hashMask, Node[][] nodes, int count)
            {
                HashMask = hashMask;
                Nodes = nodes;
                Count = count;
            }
        }

        private class AddResizeContext : IHashArrayMapResizeContext
        {
            public int Width { get; }

            public int Growth => 1;

            public int Count { get; }

            public AddResizeContext(int width, int count)
            {
                Width = width;
                Count = count;
            }
        }
    }
}
