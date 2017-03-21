namespace Smart.Converter
{
    using System;

    public class MatchingConverterFactoryWrapper : IConverterFactory
    {
        public IConverterFactory Factory { get; }

        public bool Match { get; private set; }

        public MatchingConverterFactoryWrapper(IConverterFactory factory)
        {
            Factory = factory;
        }

        public Func<TypePair, object, object> GetConverter(TypePair typePair)
        {
            var converter = Factory.GetConverter(typePair);
            if (converter != null)
            {
                Match = true;
            }

            return converter;
        }
    }
}
