#nullable disable
namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;

    public sealed partial class EnumerableConverterFactory
    {
        private sealed class SameTypeHashSetProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new SameTypeHashSetProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return typeof(SameTypeHashSetFromEnumerableConverter<>);
            }
        }

        private sealed class OtherTypeHashSetProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new OtherTypeHashSetProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return typeof(OtherTypeHashSetFromEnumerableConverter<,>);
            }
        }

        //--------------------------------------------------------------------------------
        // Same type
        //--------------------------------------------------------------------------------

        private sealed class SameTypeHashSetFromEnumerableConverter<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                return new HashSet<TDestination>((IEnumerable<TDestination>)source);
            }
        }

        //--------------------------------------------------------------------------------
        // Other type
        //--------------------------------------------------------------------------------

        private sealed class OtherTypeHashSetFromEnumerableConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeHashSetFromEnumerableConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                var collection = new HashSet<TDestination>();
                foreach (var value in (IEnumerable<TSource>)source)
                {
                    collection.Add((TDestination)converter(value));
                }

                return collection;
            }
        }
    }
}
