namespace Smart.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Smart.Converter.Converters;

    public class MatchingObjectConverter : IObjectConverter
    {
        private readonly IList<MatchingConverterFactoryWrapper> factories;

        private readonly ObjectConverter converter;

        public MatchingObjectConverter()
        {
            factories = DefaultObjectFactories.Create()
                .Select(x => new MatchingConverterFactoryWrapper(x))
                .ToList();
            converter = new ObjectConverter();
            converter.SetFactories(factories.Cast<IConverterFactory>().ToList());
        }

        public IConverterFactory FindMatchngFactory()
        {
            return factories.FirstOrDefault(x => x.Match)?.Factory;
        }

        public T Convert<T>(object value)
        {
            return converter.Convert<T>(value);
        }

        public object Convert(object value, Type targetType)
        {
            return converter.Convert(value, targetType);
        }
    }
}