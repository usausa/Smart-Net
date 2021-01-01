#nullable disable
namespace Smart.Converter
{
    using System;

    public interface IObjectConverter
    {
        bool CanConvert<T>(object value);

        bool CanConvert(object value, Type targetType);

        bool CanConvert(Type sourceType, Type targetType);

        T Convert<T>(object value);

        object Convert(object value, Type targetType);

        Func<object, object> CreateConverter(Type sourceType, Type targetType);
    }
}