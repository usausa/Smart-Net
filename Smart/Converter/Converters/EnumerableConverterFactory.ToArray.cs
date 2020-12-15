#nullable disable
namespace Smart.Converter.Converters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Ignore")]
    public sealed partial class EnumerableConverterFactory
    {
        private sealed class SameTypeArrayProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new SameTypeArrayProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return sourceEnumerableType switch
                {
                    SourceEnumerableType.Array => throw new NotSupportedException(),
                    SourceEnumerableType.List => typeof(SameTypeArrayFromCollectionConverter<>),
                    SourceEnumerableType.Collection => typeof(SameTypeArrayFromCollectionConverter<>),
                    _ => typeof(SameTypeArrayFromEnumerableConverter<>)
                };
            }
        }

        private sealed class OtherTypeArrayProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new OtherTypeArrayProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return sourceEnumerableType switch
                {
                    SourceEnumerableType.Array => typeof(OtherTypeArrayFromArrayConverter<,>),
                    SourceEnumerableType.List => typeof(OtherTypeArrayFromListConverter<,>),
                    SourceEnumerableType.Collection => typeof(OtherTypeArrayFromCollectionConverter<,>),
                    _ => typeof(OtherTypeArrayFromEnumerableConverter<,>)
                };
            }
        }

        //--------------------------------------------------------------------------------
        // Same type
        //--------------------------------------------------------------------------------

        private sealed class SameTypeArrayFromCollectionConverter<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                var sourceCollection = (ICollection<TDestination>)source;
                var array = new TDestination[sourceCollection.Count];
                sourceCollection.CopyTo(array, 0);

                return array;
            }
        }

        private sealed class SameTypeArrayFromEnumerableConverter<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                var buffer = new ArrayBuffer<TDestination>(0);
                foreach (var value in (IEnumerable)source)
                {
                    buffer.Add((TDestination)value);
                }

                return buffer.ToArray();
            }
        }

        //--------------------------------------------------------------------------------
        // Builder to other type Array from Collection
        //--------------------------------------------------------------------------------

        public sealed class OtherTypeArrayFromArrayConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeArrayFromArrayConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var sourceArray = (TSource[])source;
                var array = new TDestination[sourceArray.Length];
                for (var i = 0; i < sourceArray.Length; i++)
                {
                    array[i] = (TDestination)converter(sourceArray[i]);
                }

                return array;
            }
        }

        private sealed class OtherTypeArrayFromListConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeArrayFromListConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var sourceList = (IList<TSource>)source;
                var array = new TDestination[sourceList.Count];
                for (var i = 0; i < sourceList.Count; i++)
                {
                    array[i] = (TDestination)converter(sourceList[i]);
                }

                return array;
            }
        }

        private sealed class OtherTypeArrayFromCollectionConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeArrayFromCollectionConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var sourceCollection = (ICollection<TSource>)source;
                var array = new TDestination[sourceCollection.Count];
                var index = 0;
                foreach (var value in sourceCollection)
                {
                    array[index] = (TDestination)converter(value);
                    index++;
                }

                return array;
            }
        }

        private sealed class OtherTypeArrayFromEnumerableConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeArrayFromEnumerableConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var buffer = new ArrayBuffer<TDestination>(0);
                foreach (var value in (IEnumerable<TSource>)source)
                {
                    buffer.Add((TDestination)converter(value));
                }

                return buffer.ToArray();
            }
        }
    }
}
