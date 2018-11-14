namespace Smart.Converter.Converters
{
    using System;

    public sealed class AssignableConverterFactory : IConverterFactory
    {
        private static readonly Func<object, object> Converter = source => source;

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            return targetType.IsAssignableFrom(sourceType) ? Converter : null;
        }
    }
}
