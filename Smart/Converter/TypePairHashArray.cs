namespace Smart.Converter
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    public sealed class TypePairHashArray
    {
        private const int InitialSize = 256;

        private const double Factor = 2;

        private static readonly Node[] EmptyNodes = Array.Empty<Node>();

        private readonly object sync = new object();

        private Table table;

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        public TypePairHashArray()
        {
            table = CreateInitialTable();
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

        private static uint CalculateSize(int count)
        {
            uint size = 0;

            for (var i = 1L; i < count; i *= 2)
            {
                size = (size << 1) + 1;
            }

            return size + 1;
        }

        private static Table CreateInitialTable()
        {
            var mask = InitialSize - 1;
            var nodes = new Node[InitialSize][];

            for (var i = 0; i < nodes.Length; i++)
            {
                nodes[i] = EmptyNodes;
            }

            return new Table(mask, nodes, 0);
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
                    var relocateIndex = CalculateHash(node.SourceType, node.TargetType) & mask;
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

        private static Table CreateAddTable(Table oldTable, Node node)
        {
            var requestSize = Math.Max(InitialSize, (int)Math.Ceiling((oldTable.Count + 1) * Factor));

            var size = CalculateSize(requestSize);
            var mask = (int)(size - 1);
            var newNodes = new Node[size][];

            RelocateNodes(newNodes, oldTable.Nodes, mask);

            var index = CalculateHash(node.SourceType, node.TargetType) & mask;
            newNodes[index] = AddNode(newNodes[index], node);

            FillEmptyIfNull(newNodes);

            return new Table(mask, newNodes, oldTable.Count + 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetValueInternal(Table targetTable, Type sourceType, Type targetType, out Func<object, object> value)
        {
            var index = CalculateHash(sourceType, targetType) & targetTable.HashMask;
            var array = targetTable.Nodes[index];
            for (var i = 0; i < array.Length; i++)
            {
                var node = array[i];
                if ((node.SourceType == sourceType) && (node.TargetType == targetType))
                {
                    value = node.Converter;
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

        public void Clear()
        {
            lock (sync)
            {
                var newTable = CreateInitialTable();
                Interlocked.MemoryBarrier();
                table = newTable;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(Type sourceType, Type targetType, out Func<object, object> converter)
        {
            return TryGetValueInternal(table, sourceType, targetType, out converter);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Performance")]
        public Func<object, object> AddIfNotExist(Type sourceType, Type targetType, Func<Type, Type, Func<object, object>> valueFactory)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValueInternal(table, sourceType, targetType, out var currentValue))
                {
                    return currentValue;
                }

                var value = valueFactory(sourceType, targetType);

                // Check if added by recursive
                if (TryGetValueInternal(table, sourceType, targetType, out currentValue))
                {
                    return currentValue;
                }

                // Rebuild
                var newTable = CreateAddTable(table, new Node(sourceType, targetType, value));
                Interlocked.MemoryBarrier();
                table = newTable;

                return value;
            }
        }

        //--------------------------------------------------------------------------------
        // Inner
        //--------------------------------------------------------------------------------

        private class Node
        {
            public Type SourceType { get; }

            public Type TargetType { get; }

            public Func<object, object> Converter { get; }

            public Node(Type sourceType, Type targetType, Func<object, object> converter)
            {
                SourceType = sourceType;
                TargetType = targetType;
                Converter = converter;
            }
        }

        private class Table
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
    }
}
