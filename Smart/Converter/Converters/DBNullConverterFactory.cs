#nullable disable
namespace Smart.Converter.Converters
{
    using System;

    public sealed class DBNullConverterFactory : IConverterFactory
    {
        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            if (sourceType == typeof(DBNull))
            {
                var defaultValue = targetType.GetDefaultValue();
                return _ => defaultValue;
            }

            return null;
        }
    }
}
