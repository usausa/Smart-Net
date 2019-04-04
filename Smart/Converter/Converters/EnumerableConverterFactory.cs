namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Ignore")]
    public sealed partial class EnumerableConverterFactory : IConverterFactory
    {
        private enum SourceEnumerableType
        {
            Nothing,
            Array,
            Enumerable,
            Collection,
            List
        }

        private interface IEnumerableConverterProvider
        {
            Type GetConverterType(SourceEnumerableType sourceEnumerableType);
        }

        private sealed class ProviderPair
        {
            public IEnumerableConverterProvider SameTypeProvider { get; }

            public IEnumerableConverterProvider OtherTypeProvider { get; }

            public ProviderPair(IEnumerableConverterProvider sameTypeProvider, IEnumerableConverterProvider otherTypeProvider)
            {
                SameTypeProvider = sameTypeProvider;
                OtherTypeProvider = otherTypeProvider;
            }
        }

        private static readonly Dictionary<Type, ProviderPair> Providers = new Dictionary<Type, ProviderPair>
        {
            { typeof(IEnumerable<>), new ProviderPair(SameTypeListProvider.Default, OtherTypeListProvider.Default) },
            { typeof(ICollection<>), new ProviderPair(SameTypeListProvider.Default, OtherTypeListProvider.Default) },
            { typeof(IList<>), new ProviderPair(SameTypeListProvider.Default, OtherTypeListProvider.Default) },
            { typeof(List<>), new ProviderPair(SameTypeListProvider.Default, OtherTypeListProvider.Default) },
            { typeof(ISet<>), new ProviderPair(SameTypeHashSetProvider.Default, OtherTypeHashSetProvider.Default) },
            { typeof(HashSet<>), new ProviderPair(SameTypeHashSetProvider.Default, OtherTypeHashSetProvider.Default) },
            { typeof(IReadOnlyCollection<>), new ProviderPair(SameTypeReadOnlyCollectionProvider.Default, OtherTypeReadOnlyCollectionProvider.Default) },
            { typeof(IReadOnlyList<>), new ProviderPair(SameTypeReadOnlyCollectionProvider.Default, OtherTypeReadOnlyCollectionProvider.Default) },
            { typeof(ReadOnlyCollection<>), new ProviderPair(SameTypeReadOnlyCollectionProvider.Default, OtherTypeReadOnlyCollectionProvider.Default) },
            { typeof(LinkedList<>), new ProviderPair(SameTypeLinkedListProvider.Default, OtherTypeLinkedListProvider.Default) },
            { typeof(Queue<>), new ProviderPair(SameTypeQueueProvider.Default, OtherTypeQueueProvider.Default) },
            { typeof(Stack<>), new ProviderPair(SameTypeStackProvider.Default, OtherTypeStackProvider.Default) },
            { typeof(ObservableCollection<>), new ProviderPair(SameTypeObservableCollectionProvider.Default, OtherTypeObservableCollectionProvider.Default) },
            { typeof(ReadOnlyObservableCollection<>), new ProviderPair(SameTypeReadOnlyObservableCollectionProvider.Default, OtherTypeReadOnlyObservableCollectionProvider.Default) },
            { typeof(ConcurrentQueue<>), new ProviderPair(SameTypeConcurrentQueueProvider.Default, OtherTypeConcurrentQueueProvider.Default) },
            { typeof(ConcurrentStack<>), new ProviderPair(SameTypeConcurrentStackProvider.Default, OtherTypeConcurrentStackProvider.Default) },
            { typeof(ConcurrentBag<>), new ProviderPair(SameTypeConcurrentBagProvider.Default, OtherTypeConcurrentBagProvider.Default) }
        };

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            // To Array
            if (targetType.IsArray)
            {
                var targetElementType = targetType.GetElementType();
                var sourceElementType = ResolveEnumerableType(sourceType, out var enumerableType);
                if (sourceElementType != null)
                {
                    if (sourceElementType == targetElementType)
                    {
                        // IE<T> to T[]
                        return ((IConverter)Activator.CreateInstance(
                            SameTypeArrayProvider.Default.GetConverterType(enumerableType).MakeGenericType(targetElementType))).Convert;
                    }

                    var converter = context.CreateConverter(sourceElementType, targetElementType);
                    if (converter != null)
                    {
                        // IE<T1> to T2[]
                        return ((IConverter)Activator.CreateInstance(
                            OtherTypeArrayProvider.Default.GetConverterType(enumerableType).MakeGenericType(sourceElementType, targetElementType),
                            converter)).Convert;
                    }
                }

                return null;
            }

            // To IE<T>
            if (targetType.IsGenericType &&
                Providers.TryGetValue(targetType.GetGenericTypeDefinition(), out var providerPair))
            {
                var targetElementType = targetType.GenericTypeArguments[0];
                var sourceElementType = ResolveEnumerableType(sourceType, out var enumerableType);
                if (sourceElementType != null)
                {
                    if (sourceElementType == targetElementType)
                    {
                        // IE<T> to IE<T>
                        return ((IConverter)Activator.CreateInstance(
                            providerPair.SameTypeProvider.GetConverterType(enumerableType).MakeGenericType(targetElementType))).Convert;
                    }

                    var converter = context.CreateConverter(sourceElementType, targetElementType);
                    if (converter != null)
                    {
                        // IE<T1> to IE<T2>
                        return ((IConverter)Activator.CreateInstance(
                            providerPair.OtherTypeProvider.GetConverterType(enumerableType).MakeGenericType(sourceElementType, targetElementType),
                            converter)).Convert;
                    }
                }

                return null;
            }

            return null;
        }

        //--------------------------------------------------------------------------------
        // Helper
        //--------------------------------------------------------------------------------

        private static Type ResolveEnumerableType(Type type, out SourceEnumerableType sourceEnumerableType)
        {
            if (type.IsArray)
            {
                sourceEnumerableType = SourceEnumerableType.Array;
                return type.GetElementType();
            }

            var interfaceType = type.GetInterfaces()
                .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>));
            if (interfaceType != null)
            {
                sourceEnumerableType = SourceEnumerableType.List;
                return interfaceType.GenericTypeArguments[0];
            }

            interfaceType = type.GetInterfaces()
                .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (interfaceType != null)
            {
                sourceEnumerableType = SourceEnumerableType.Collection;
                return interfaceType.GenericTypeArguments[0];
            }

            interfaceType = type.GetInterfaces()
                .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (interfaceType != null)
            {
                sourceEnumerableType = SourceEnumerableType.Enumerable;
                return interfaceType.GenericTypeArguments[0];
            }

            sourceEnumerableType = SourceEnumerableType.Nothing;
            return null;
        }
    }
}
