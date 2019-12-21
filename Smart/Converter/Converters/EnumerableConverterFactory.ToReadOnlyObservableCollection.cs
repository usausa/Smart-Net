namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public sealed partial class EnumerableConverterFactory
    {
        private sealed class SameTypeReadOnlyObservableCollectionProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new SameTypeReadOnlyObservableCollectionProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return typeof(SameTypeReadOnlyObservableCollectionFromEnumerableConverter<>);
            }
        }

        private sealed class OtherTypeReadOnlyObservableCollectionProvider : IEnumerableConverterProvider
        {
            public static IEnumerableConverterProvider Default { get; } = new OtherTypeReadOnlyObservableCollectionProvider();

            public Type GetConverterType(SourceEnumerableType sourceEnumerableType)
            {
                return sourceEnumerableType switch
                {
                    SourceEnumerableType.Array => typeof(OtherTypeReadOnlyObservableCollectionFromArrayConverter<,>),
                    SourceEnumerableType.List => typeof(OtherTypeReadOnlyObservableCollectionFromListConverter<,>),
                    SourceEnumerableType.Collection => typeof(OtherTypeReadOnlyObservableCollectionFromCollectionConverter<,>),
                    _ => typeof(OtherTypeReadOnlyObservableCollectionFromEnumerableConverter<,>)
                };
            }
        }

        //--------------------------------------------------------------------------------
        // Same type
        //--------------------------------------------------------------------------------

        private sealed class SameTypeReadOnlyObservableCollectionFromEnumerableConverter<TDestination> : IConverter
        {
            public object Convert(object source)
            {
                return new ReadOnlyObservableCollection<TDestination>(new ObservableCollection<TDestination>((IEnumerable<TDestination>)source));
            }
        }

        //--------------------------------------------------------------------------------
        // Other type
        //--------------------------------------------------------------------------------

        private sealed class OtherTypeReadOnlyObservableCollectionFromArrayConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeReadOnlyObservableCollectionFromArrayConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ReadOnlyObservableCollection<TDestination>(new ObservableCollection<TDestination>(new ArrayConvertList<TSource, TDestination>((TSource[])source, converter)));
            }
        }

        private sealed class OtherTypeReadOnlyObservableCollectionFromListConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeReadOnlyObservableCollectionFromListConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ReadOnlyObservableCollection<TDestination>(new ObservableCollection<TDestination>(new ListConvertList<TSource, TDestination>((IList<TSource>)source, converter)));
            }
        }

        private sealed class OtherTypeReadOnlyObservableCollectionFromCollectionConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeReadOnlyObservableCollectionFromCollectionConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ReadOnlyObservableCollection<TDestination>(new ObservableCollection<TDestination>(new CollectionConvertCollection<TSource, TDestination>((ICollection<TSource>)source, converter)));
            }
        }

        private sealed class OtherTypeReadOnlyObservableCollectionFromEnumerableConverter<TSource, TDestination> : IConverter
        {
            private readonly Func<object, object> converter;

            public OtherTypeReadOnlyObservableCollectionFromEnumerableConverter(Func<object, object> converter)
            {
                this.converter = converter;
            }

            public object Convert(object source)
            {
                return new ReadOnlyObservableCollection<TDestination>(new ObservableCollection<TDestination>(new EnumerableConvertEnumerable<TSource, TDestination>((IEnumerable<TSource>)source, converter)));
            }
        }
    }
}
