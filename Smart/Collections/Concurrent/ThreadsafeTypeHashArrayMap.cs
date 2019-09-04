namespace Smart.Collections.Concurrent
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    public sealed class ThreadsafeTypeHashArrayMap<TValue> : IEnumerable<KeyValuePair<Type, TValue>>
    {
        private static readonly Node[] EmptyNodes = Array.Empty<Node>();

        private readonly object sync = new object();

        private readonly IHashArrayMapStrategy strategy;

        private Table table;

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        public ThreadsafeTypeHashArrayMap(int initialSize = 64, double factor = 1.5)
            : this(new GrowthHashArrayMapStrategy(initialSize, factor))
        {
        }

        public ThreadsafeTypeHashArrayMap(IHashArrayMapStrategy strategy)
        {
            this.strategy = strategy;
            table = CreateInitialTable();
        }

        //--------------------------------------------------------------------------------
        // Private
        //--------------------------------------------------------------------------------

        private static uint CalculateSize(int count)
        {
            uint size = 0;

            for (var i = 1L; i < count; i *= 2)
            {
                size = (size << 1) + 1;
            }

            return size + 1;
        }

        private static int CalculateDepth(Node[][] nodes)
        {
            var depth = 0;
            for (var i = 0; i < nodes.Length; i++)
            {
                depth = Math.Max(nodes[i].Length, depth);
            }

            return depth;
        }

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

        private static Node[] AddNode(Node[] nodes, Node addNode)
        {
            if (nodes is null)
            {
                return new[] { addNode };
            }

            var newNodes = new Node[nodes.Length + 1];
            Array.Copy(nodes, 0, newNodes, 0, nodes.Length);
            newNodes[nodes.Length] = addNode;

            return newNodes;
        }

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

        private static void FillEmptyIfNull(Node[][] nodes)
        {
            for (var i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] is null)
                {
                    nodes[i] = EmptyNodes;
                }
            }
        }

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetValueInternal(Table targetTable, Type key, out TValue value)
        {
            var index = key.GetHashCode() & targetTable.HashMask;
            var array = targetTable.Nodes[index];
            for (var i = 0; i < array.Length; i++)
            {
                var node = array[i];
                if (node.Key == key)
                {
                    value = node.Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        //--------------------------------------------------------------------------------
        // Public
        //--------------------------------------------------------------------------------

        public int Count => table.Count;

        public int Depth => table.Depth;

        public void Clear()
        {
            lock (sync)
            {
                var newTable = CreateInitialTable();
                Interlocked.MemoryBarrier();
                table = newTable;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Performance")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(Type key, out TValue value)
        {
            return TryGetValueInternal(table, key, out value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Performance")]
        public TValue AddIfNotExist(Type key, TValue value)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValueInternal(table, key, out var currentValue))
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Performance")]
        public TValue AddIfNotExist(Type key, Func<Type, TValue> valueFactory)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValueInternal(table, key, out var currentValue))
                {
                    return currentValue;
                }

                var value = valueFactory(key);

                // Check if added by recursive
                if (TryGetValueInternal(table, key, out currentValue))
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

        //--------------------------------------------------------------------------------
        // IEnumerable
        //--------------------------------------------------------------------------------

        public IEnumerator<KeyValuePair<Type, TValue>> GetEnumerator()
        {
            var nodes = table.Nodes;

            for (var i = 0; i < nodes.Length; i++)
            {
                for (var j = 0; j < nodes[i].Length; j++)
                {
                    var node = nodes[i][j];
                    yield return new KeyValuePair<Type, TValue>(node.Key, node.Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //--------------------------------------------------------------------------------
        // Helper
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsKey(Type key)
        {
            return TryGetValue(key, out _);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue GetValueOrDefault(Type key, TValue defaultValue = default)
        {
            return TryGetValue(key, out var value) ? value : defaultValue;
        }

        //--------------------------------------------------------------------------------
        // Inner
        //--------------------------------------------------------------------------------

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Performance")]
        private sealed class Node
        {
            public readonly Type Key;

            public readonly TValue Value;

            public Node(Type key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Performance")]
        private sealed class Table
        {
            public readonly int HashMask;

            public readonly Node[][] Nodes;

            public readonly int Count;

            public readonly int Depth;

            public Table(int hashMask, Node[][] nodes, int count, int depth)
            {
                HashMask = hashMask;
                Nodes = nodes;
                Count = count;
                Depth = depth;
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
