namespace Smart.Converter
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    [DebuggerDisplay("{" + nameof(Diagnostics) + "}")]
    public sealed class TypePairHashArray
    {
        private const int InitialSize = 256;

        private const int Factor = 3;

        private static readonly Node EmptyNode = new Node(typeof(EmptyKey), typeof(EmptyKey), default);

        private readonly object sync = new object();

        private Node[] nodes;

        private int depth;

        private int count;

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        public TypePairHashArray()
        {
            nodes = CreateInitialTable();
        }

        //--------------------------------------------------------------------------------
        // Private
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CalculateHash(Type sourceType, Type targetType)
        {
            unchecked
            {
                return sourceType.GetHashCode() ^ (targetType.GetHashCode() * 397);
            }
        }

        private static int CalculateDepth(Node node)
        {
            var length = 0;

            do
            {
                length++;
                node = node.Next;
            }
            while (node != null);

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

        private static int CalculateSize(int requestSize)
        {
            uint size = 0;

            for (var i = 1L; i < requestSize; i *= 2)
            {
                size = (size << 1) + 1;
            }

            return (int)(size + 1);
        }

        private static Node[] CreateInitialTable()
        {
            var newNodes = new Node[InitialSize];

            for (var i = 0; i < newNodes.Length; i++)
            {
                newNodes[i] = EmptyNode;
            }

            return newNodes;
        }

        private static Node FindLastNode(Node node)
        {
            while (node.Next != null)
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

                    UpdateLink(ref nodes[CalculateHash(node.SourceType, node.TargetType) & (nodes.Length - 1)], node);

                    node = next;
                }
                while (node != null);
            }
        }

        private void AddNode(Node node)
        {
            var requestSize = Math.Max(InitialSize, (count + 1) * Factor);
            var size = CalculateSize(requestSize);
            if (size > nodes.Length)
            {
                var newNodes = new Node[size];
                for (var i = 0; i < newNodes.Length; i++)
                {
                    newNodes[i] = EmptyNode;
                }

                RelocateNodes(newNodes, nodes);

                UpdateLink(ref newNodes[CalculateHash(node.SourceType, node.TargetType) & (newNodes.Length - 1)], node);

                Interlocked.MemoryBarrier();

                nodes = newNodes;
                depth = CalculateDepth(newNodes);
                count++;
            }
            else
            {
                Interlocked.MemoryBarrier();

                UpdateLink(ref nodes[CalculateHash(node.SourceType, node.TargetType) & (nodes.Length - 1)], node);

                depth = Math.Max(CalculateDepth(nodes[CalculateHash(node.SourceType, node.TargetType) & (nodes.Length - 1)]), depth);
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
                depth = 0;
                count = 0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(Type sourceType, Type targetType, out Func<object, object> converter)
        {
            var temp = nodes;
            var node = temp[CalculateHash(sourceType, targetType) & (temp.Length - 1)];
            do
            {
                if ((node.SourceType == sourceType) && (node.TargetType == targetType))
                {
                    converter = node.Converter;
                    return true;
                }
                node = node.Next;
            }
            while (node != null);

            converter = default;
            return false;
        }

        public Func<object, object> AddIfNotExist(Type sourceType, Type targetType, Func<Type, Type, Func<object, object>> valueFactory)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValue(sourceType, targetType, out var currentValue))
                {
                    return currentValue;
                }

                var value = valueFactory(sourceType, targetType);

                // Check if added by recursive
                if (TryGetValue(sourceType, targetType, out currentValue))
                {
                    return currentValue;
                }

                AddNode(new Node(sourceType, targetType, value));

                return value;
            }
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
            public readonly Type SourceType;

            public readonly Type TargetType;

            public readonly Func<object, object> Converter;

            public Node Next;

            public Node(Type sourceType, Type targetType, Func<object, object> converter)
            {
                SourceType = sourceType;
                TargetType = targetType;
                Converter = converter;
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
