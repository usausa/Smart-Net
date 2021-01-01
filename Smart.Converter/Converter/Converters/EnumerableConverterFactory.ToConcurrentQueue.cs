#nullable disable
namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public sealed partial class EnumerableConverterFactory
    {
        private sealed class SameTypeConcurrentQueueProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new SameTypeConcurrentQueueProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return typeof(SameTypeConcurrentQueueFromEnumerableConverter<>);
            }
        }

        private sealed class OtherTypeConcurrentQueueProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new OtherTypeConcurrentQueueProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return sourceEnumerableType switch
                {
                    SourceEnumerableType.Array => typeof(OtherTypeConcurrentQueueFromArrayConverter<,>),
                    SourceEnumerableType.List => typeof(OtherTypeConcurrentQueueFromListConverter<,>),
                    SourceEnumerableType.Collection => typeof(OtherTypeConcurrentQueueFromCollectionConverter<,>),
                    _ => typeof(OtherTypeConcurrentQueueFromEnumerableConverter<,>)
                };
            }
        }

        //--------------------------------------------------------------------------------
        // Same type
        //--------------------------------------------------------------------------------

        private sealed class SameTypeConcurrentQueueFromEnumerableConverter<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                return new ConcurrentQueue<TDestination>((IEnumerable<TDestination>)source);
            }
        }

        //--------------------------------------------------------------------------------
        // Other type
        //--------------------------------------------------------------------------------

        private sealed class OtherTypeConcurrentQueueFromArrayConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeConcurrentQueueFromArrayConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ConcurrentQueue<TDestination>(new ArrayConvertList<TSource, TDestination>((TSource[])source, converter));
            }
        }

        private sealed class OtherTypeConcurrentQueueFromListConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeConcurrentQueueFromListConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ConcurrentQueue<TDestination>(new ListConvertList<TSource, TDestination>((IList<TSource>)source, converter));
            }
        }

        private sealed class OtherTypeConcurrentQueueFromCollectionConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeConcurrentQueueFromCollectionConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ConcurrentQueue<TDestination>(new CollectionConvertCollection<TSource, TDestination>((ICollection<TSource>)source, converter));
            }
        }

        private sealed class OtherTypeConcurrentQueueFromEnumerableConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeConcurrentQueueFromEnumerableConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ConcurrentQueue<TDestination>(new EnumerableConvertEnumerable<TSource, TDestination>((IEnumerable<TSource>)source, converter));
            }
        }
    }
}
