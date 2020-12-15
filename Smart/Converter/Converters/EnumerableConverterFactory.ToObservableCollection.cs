#nullable disable
namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public sealed partial class EnumerableConverterFactory
    {
        private sealed class SameTypeObservableCollectionProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new SameTypeObservableCollectionProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return typeof(SameTypeObservableCollectionFromEnumerableConverter<>);
            }
        }

        private sealed class OtherTypeObservableCollectionProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new OtherTypeObservableCollectionProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return sourceEnumerableType switch
                {
                    SourceEnumerableType.Array => typeof(OtherTypeObservableCollectionFromArrayConverter<,>),
                    SourceEnumerableType.List => typeof(OtherTypeObservableCollectionFromListConverter<,>),
                    SourceEnumerableType.Collection => typeof(OtherTypeObservableCollectionFromCollectionConverter<,>),
                    _ => typeof(OtherTypeObservableCollectionFromEnumerableConverter<,>)
                };
            }
        }

        //--------------------------------------------------------------------------------
        // Same type
        //--------------------------------------------------------------------------------

        private sealed class SameTypeObservableCollectionFromEnumerableConverter<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                return new ObservableCollection<TDestination>((IEnumerable<TDestination>)source);
            }
        }

        //--------------------------------------------------------------------------------
        // Other type
        //--------------------------------------------------------------------------------

        private sealed class OtherTypeObservableCollectionFromArrayConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeObservableCollectionFromArrayConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ObservableCollection<TDestination>(new ArrayConvertList<TSource, TDestination>((TSource[])source, converter));
            }
        }

        private sealed class OtherTypeObservableCollectionFromListConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeObservableCollectionFromListConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ObservableCollection<TDestination>(new ListConvertList<TSource, TDestination>((IList<TSource>)source, converter));
            }
        }

        private sealed class OtherTypeObservableCollectionFromCollectionConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeObservableCollectionFromCollectionConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ObservableCollection<TDestination>(new CollectionConvertCollection<TSource, TDestination>((ICollection<TSource>)source, converter));
            }
        }

        private sealed class OtherTypeObservableCollectionFromEnumerableConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeObservableCollectionFromEnumerableConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ObservableCollection<TDestination>(new EnumerableConvertEnumerable<TSource, TDestination>((IEnumerable<TSource>)source, converter));
            }
        }
    }
}
