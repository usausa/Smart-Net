namespace Smart.Converter.Converters
{
    using System;

    internal interface IConverterBuilder
    {
        Func<object, object> Build();
    }
}
