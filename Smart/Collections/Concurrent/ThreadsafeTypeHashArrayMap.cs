namespace Smart.Collections.Concurrent
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Threading;

    [DebuggerDisplay("{" + nameof(Diagnostics) + "}")]
    public sealed class ThreadsafeTypeHashArrayMap<TValue> : IEnumerable<KeyValuePair<Type, TValue?>>
    {
        private static readonly Node EmptyNode = new(typeof(EmptyKey), default);

        private readonly object sync = new();

        private readonly IHashArrayMapStrategy strategy;

        private Node[] nodes;

        private int depth;

        private int count;

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        public ThreadsafeTypeHashArrayMap(int initialSize = 64, double factor = 3.0)
            : this(new GrowthHashArrayMapStrategy(initialSize, factor))
        {
        }

        public ThreadsafeTypeHashArrayMap(IHashArrayMapStrategy strategy)
        {
            this.strategy = strategy;
            nodes = CreateInitialTable();
        }

        //--------------------------------------------------------------------------------
        // Private
        //--------------------------------------------------------------------------------

        private static int CalculateSize(int requestSize)
        {
            uint size = 0;

            for (var i = 1L; i < requestSize; i *= 2)
            {
                size = (size << 1) + 1;
            }

            return (int)(size + 1);
        }

        private static int CalculateCount(Node[] targetNodes)
        {
            var count = 0;
            for (var i = 0; i < targetNodes.Length; i++)
            {
                var node = targetNodes[i];
                if (node != EmptyNode)
                {
                    do
                    {
                        count++;
                        node = node.Next;
                    }
                    while (node is not null);
                }
            }

            return count;
        }

        private static int CalculateDepth(Node node)
        {
            var length = 1;
            var next = node.Next;
            while (next is not null)
            {
                length++;
                next = next.Next;
            }

            return length;
        }

        private static int CalculateDepth(Node[] targetNodes)
        {
            var depth = 0;

            for (var i = 0; i < targetNodes.Length; i++)
            {
                var node = targetNodes[i];
                if (node != EmptyNode)
                {
                    depth = Math.Max(CalculateDepth(node), depth);
                }
            }

            return depth;
        }

        private Node[] CreateInitialTable()
        {
            var size = CalculateSize(strategy.CalculateInitialSize());
            var newNodes = new Node[size];

            for (var i = 0; i < newNodes.Length; i++)
            {
                newNodes[i] = EmptyNode;
            }

            return newNodes;
        }

        private static Node FindLastNode(Node node)
        {
            while (node.Next is not null)
            {
                node = node.Next;
            }

            return node;
        }

        private static void UpdateLink(ref Node node, Node addNode)
        {
            if (node == EmptyNode)
            {
                node = addNode;
            }
            else
            {
                var last = FindLastNode(node);
                last.Next = addNode;
            }
        }

        private static void RelocateNodes(Node[] nodes, Node[] oldNodes)
        {
            for (var i = 0; i < oldNodes.Length; i++)
            {
                var node = oldNodes[i];
                if (node == EmptyNode)
                {
                    continue;
                }

                do
                {
                    var next = node.Next;
                    node.Next = null;

                    UpdateLink(ref nodes[node.Key.GetHashCode() & (nodes.Length - 1)], node);

                    node = next;
                }
                while (node is not null);
            }
        }

        private void AddNode(Node node)
        {
            var requestSize = strategy.CalculateRequestSize(new AddResizeContext(nodes.Length, depth, count, 1));
            var size = CalculateSize(requestSize);
            if (size > nodes.Length)
            {
                var newNodes = new Node[size];
                for (var i = 0; i < newNodes.Length; i++)
                {
                    newNodes[i] = EmptyNode;
                }

                RelocateNodes(newNodes, nodes);

                UpdateLink(ref newNodes[node.Key.GetHashCode() & (newNodes.Length - 1)], node);

                Interlocked.MemoryBarrier();

                nodes = newNodes;
                depth = CalculateDepth(newNodes);
                count = CalculateCount(newNodes);
            }
            else
            {
                Interlocked.MemoryBarrier();

                UpdateLink(ref nodes[node.Key.GetHashCode() & (nodes.Length - 1)], node);

                depth = Math.Max(CalculateDepth(nodes[node.Key.GetHashCode() & (nodes.Length - 1)]), depth);
                count++;
            }
        }

        //--------------------------------------------------------------------------------
        // Public
        //--------------------------------------------------------------------------------

        public DiagnosticsInfo Diagnostics
        {
            get
            {
                lock (sync)
                {
                    return new DiagnosticsInfo(nodes.Length, depth, count);
                }
            }
        }

        public void Clear()
        {
            lock (sync)
            {
                var newNodes = CreateInitialTable();

                Interlocked.MemoryBarrier();

                nodes = newNodes;
                count = 0;
                depth = 0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(Type key, [NotNullWhen(true)] out TValue? value)
        {
            var temp = nodes;
            var node = temp[key.GetHashCode() & (temp.Length - 1)];
            do
            {
                if (node.Key == key)
                {
                    value = node.Value;
                    return true;
                }
                node = node.Next;
            }
            while (node is not null);

            value = default;
            return false;
        }

        public TValue? AddIfNotExist(Type key, TValue? value)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValue(key, out var currentValue))
                {
                    return currentValue;
                }

                AddNode(new Node(key, value));

                return value;
            }
        }

        public TValue AddIfNotExist(Type key, Func<Type, TValue?> valueFactory)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValue(key, out var currentValue))
                {
                    return currentValue;
                }

                var value = valueFactory(key);

                // Check if added by recursive
                if (TryGetValue(key, out currentValue))
                {
                    return currentValue;
                }

                AddNode(new Node(key, value));

                return value;
            }
        }

        //--------------------------------------------------------------------------------
        // IEnumerable
        //--------------------------------------------------------------------------------

        public IEnumerator<KeyValuePair<Type, TValue?>> GetEnumerator()
        {
            var copy = nodes;

            for (var i = 0; i < copy.Length; i++)
            {
                var node = copy[i];
                if (node != EmptyNode)
                {
                    do
                    {
                        yield return new KeyValuePair<Type, TValue?>(node.Key, node.Value);
                        node = node.Next;
                    }
                    while (node is not null);
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
        public TValue? GetValueOrDefault(Type key, TValue? defaultValue = default)
        {
            return TryGetValue(key, out var value) ? value : defaultValue;
        }

        //--------------------------------------------------------------------------------
        // Inner
        //--------------------------------------------------------------------------------

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Framework only")]
        private sealed class EmptyKey
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Performance")]
        private sealed class Node
        {
            public readonly Type Key;

            public readonly TValue? Value;

            public Node? Next;

            public Node(Type key, TValue? value)
            {
                Key = key;
                Value = value;
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
                Depth = depth;
                Count = count;
                Growth = growth;
            }
        }

        //--------------------------------------------------------------------------------
        // Diagnostics
        //--------------------------------------------------------------------------------

        public sealed class DiagnosticsInfo
        {
            public int Width { get; }

            public int Depth { get; }

            public int Count { get; }

            public DiagnosticsInfo(int width, int depth, int count)
            {
                Width = width;
                Depth = depth;
                Count = count;
            }

            public override string ToString() => $"Count={Count}, Width={Width}, Depth={Depth}";
        }
    }
}
