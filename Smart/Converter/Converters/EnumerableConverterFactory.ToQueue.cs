namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;

    public sealed partial class EnumerableConverterFactory
    {
        private sealed class SameTypeQueueProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new SameTypeQueueProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return typeof(SameTypeQueueFromEnumerableConverter<>);
            }
        }

        private sealed class OtherTypeQueueProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new OtherTypeQueueProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                switch (sourceEnumerableType)
                {
                    case SourceEnumerableType.Array:
                        return typeof(OtherTypeQueueFromArrayConverter<,>);
                    case SourceEnumerableType.List:
                        return typeof(OtherTypeQueueFromListConverter<,>);
                    case SourceEnumerableType.Collection:
                        return typeof(OtherTypeQueueFromCollectionConverter<,>);
                    default:
                        return typeof(OtherTypeQueueFromEnumerableConverter<,>);
                }
            }
        }

        //--------------------------------------------------------------------------------
        // Same type
        //--------------------------------------------------------------------------------

        private sealed class SameTypeQueueFromEnumerableConverter<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                return new Queue<TDestination>((IEnumerable<TDestination>)source);
            }
        }

        //--------------------------------------------------------------------------------
        // Other type
        //--------------------------------------------------------------------------------

        private sealed class OtherTypeQueueFromArrayConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeQueueFromArrayConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new Queue<TDestination>(new ArrayConvertList<TSource, TDestination>((TSource[])source, converter));
            }
        }

        private sealed class OtherTypeQueueFromListConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeQueueFromListConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new Queue<TDestination>(new ListConvertList<TSource, TDestination>((IList<TSource>)source, converter));
            }
        }

        private sealed class OtherTypeQueueFromCollectionConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeQueueFromCollectionConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new Queue<TDestination>(new CollectionConvertCollection<TSource, TDestination>((ICollection<TSource>)source, converter));
            }
        }

        private sealed class OtherTypeQueueFromEnumerableConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeQueueFromEnumerableConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var collection = new Queue<TDestination>();
                foreach (var value in (IEnumerable<TSource>)source)
                {
                    collection.Enqueue((TDestination)converter(value));
                }

                return collection;
            }
        }
    }
}
