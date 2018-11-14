namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public sealed partial class EnumerableConverterFactory
    {
        private sealed class SameTypeReadOnlyCollectionProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new SameTypeReadOnlyCollectionProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                switch (sourceEnumerableType)
                {
                    case SourceEnumerableType.Array:
                    case SourceEnumerableType.List:
                        return typeof(SameTypeReadOnlyCollectionFromListConverter<>);
                    default:
                        return typeof(SameTypeReadOnlyCollectionFromEnumerableConverter<>);
                }
            }
        }

        private sealed class OtherTypeReadOnlyCollectionProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new OtherTypeReadOnlyCollectionProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                switch (sourceEnumerableType)
                {
                    case SourceEnumerableType.Array:
                        return typeof(OtherTypeReadOnlyCollectionFromArrayConverter<,>);
                    case SourceEnumerableType.List:
                        return typeof(OtherTypeReadOnlyCollectionFromListConverter<,>);
                    case SourceEnumerableType.Collection:
                        return typeof(OtherTypeReadOnlyCollectionFromCollectionConverter<,>);
                    default:
                        return typeof(OtherTypeReadOnlyCollectionFromEnumerableConverter<,>);
                }
            }
        }

        //--------------------------------------------------------------------------------
        // Same type
        //--------------------------------------------------------------------------------

        private sealed class SameTypeReadOnlyCollectionFromListConverter<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                return new ReadOnlyCollection<TDestination>((IList<TDestination>)source);
            }
        }

        private sealed class SameTypeReadOnlyCollectionFromEnumerableConverter<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                return new ReadOnlyCollection<TDestination>(((IEnumerable<TDestination>)source).ToList());
            }
        }

        //--------------------------------------------------------------------------------
        // Other type
        //--------------------------------------------------------------------------------

        private sealed class OtherTypeReadOnlyCollectionFromArrayConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeReadOnlyCollectionFromArrayConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ReadOnlyCollection<TDestination>(new ArrayConvertList<TSource, TDestination>((TSource[])source, converter));
            }
        }

        private sealed class OtherTypeReadOnlyCollectionFromListConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeReadOnlyCollectionFromListConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ReadOnlyCollection<TDestination>(new ListConvertList<TSource, TDestination>((IList<TSource>)source, converter));
            }
        }

        private sealed class OtherTypeReadOnlyCollectionFromCollectionConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeReadOnlyCollectionFromCollectionConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var sourceCollection = (ICollection<TSource>)source;
                var list = new List<TDestination>(sourceCollection.Count);
                foreach (var value in sourceCollection)
                {
                    list.Add((TDestination)converter(value));
                }

                return new ReadOnlyCollection<TDestination>(list);
            }
        }

        private sealed class OtherTypeReadOnlyCollectionFromEnumerableConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeReadOnlyCollectionFromEnumerableConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var list = new List<TDestination>();
                foreach (var value in (IEnumerable<TSource>)source)
                {
                    list.Add((TDestination)converter(value));
                }

                return new ReadOnlyCollection<TDestination>(list);
            }
        }
    }
}
