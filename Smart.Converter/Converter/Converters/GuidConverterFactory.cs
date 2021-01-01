#nullable disable
namespace Smart.Converter.Converters
{
    using System;

    public sealed class GuidConverterFactory : IConverterFactory
    {
        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            if ((sourceType == typeof(Guid)) && (targetType == typeof(string)))
            {
                return source => ((Guid)source).ToString();
            }

            if (sourceType == typeof(string))
            {
                if (targetType == typeof(Guid))
                {
                    return source => Guid.TryParse((string)source, out var result) ? result : default;
                }

                if (targetType == typeof(Guid?))
                {
                    return source => Guid.TryParse((string)source, out var result) ? result : (Guid?)null;
                }
            }

            return null;
        }
    }
}
