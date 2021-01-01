#nullable disable
namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;

    public sealed partial class EnumerableConverterFactory
    {
        private sealed class SameTypeLinkedListProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new SameTypeLinkedListProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return typeof(SameTypeLinkedListFromEnumerable<>);
            }
        }

        private sealed class OtherTypeLinkedListProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new OtherTypeLinkedListProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return sourceEnumerableType switch
                {
                    SourceEnumerableType.Array => typeof(OtherTypeLinkedListFromArrayConverter<,>),
                    SourceEnumerableType.List => typeof(OtherTypeLinkedListFromListConverter<,>),
                    _ => typeof(OtherTypeLinkedListFromEnumerableConverter<,>)
                };
            }
        }

        //--------------------------------------------------------------------------------
        // Same type
        //--------------------------------------------------------------------------------

        private sealed class SameTypeLinkedListFromEnumerable<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                return new LinkedList<TDestination>((IEnumerable<TDestination>)source);
            }
        }

        //--------------------------------------------------------------------------------
        // Other type
        //--------------------------------------------------------------------------------

        private sealed class OtherTypeLinkedListFromArrayConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeLinkedListFromArrayConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var arraySource = (TSource[])source;
                var collection = new LinkedList<TDestination>();
                for (var i = 0; i < arraySource.Length; i++)
                {
                    collection.AddLast((TDestination)converter(arraySource[i]));
                }

                return collection;
            }
        }

        private sealed class OtherTypeLinkedListFromListConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeLinkedListFromListConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var listSource = (IList<TSource>)source;
                var collection = new LinkedList<TDestination>();
                for (var i = 0; i < listSource.Count; i++)
                {
                    collection.AddLast((TDestination)converter(listSource[i]));
                }

                return collection;
            }
        }

        private sealed class OtherTypeLinkedListFromEnumerableConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeLinkedListFromEnumerableConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var collection = new LinkedList<TDestination>();
                foreach (var value in (IEnumerable<TSource>)source)
                {
                    collection.AddLast((TDestination)converter(value));
                }

                return collection;
            }
        }
    }
}
