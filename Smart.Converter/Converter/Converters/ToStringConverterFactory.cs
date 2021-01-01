#nullable disable
namespace Smart.Converter.Converters
{
    using System;

    public sealed class ToStringConverterFactory : IConverterFactory
    {
        private static readonly Func<object, object> Converter = source => source.ToString();

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            return targetType == typeof(string) ? Converter : null;
        }
    }
}
