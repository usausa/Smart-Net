namespace Smart.Converter
{
    using System;

    public sealed class TestConverterFactory : IConverterFactory
    {
        public IConverterFactory Factory { get; }

        public bool Used { get; set; }

        public TestConverterFactory(IConverterFactory factory)
        {
            Factory = factory;
        }

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            var converter = Factory.GetConverter(context, sourceType, targetType);
            if (converter is not null)
            {
                Used = true;
            }

            return converter;
        }
    }
}
