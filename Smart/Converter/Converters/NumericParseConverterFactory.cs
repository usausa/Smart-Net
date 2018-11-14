namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;

    public sealed class NumericParseConverterFactory : IConverterFactory
    {
        private static readonly Dictionary<Type, Func<object, object>> Converters = new Dictionary<Type, Func<object, object>>
        {
            { typeof(byte), x => Byte.TryParse((string)x, out var result) ? result : default },
            { typeof(byte?), x => Byte.TryParse((string)x, out var result) ? result : default(byte?) },
            { typeof(sbyte), x => SByte.TryParse((string)x, out var result) ? result : default },
            { typeof(sbyte?), x => SByte.TryParse((string)x, out var result) ? result : default(sbyte?) },
            { typeof(short), x => Int16.TryParse((string)x, out var result) ? result : default },
            { typeof(short?), x => Int16.TryParse((string)x, out var result) ? result : default(short?) },
            { typeof(ushort), x => UInt16.TryParse((string)x, out var result) ? result : default },
            { typeof(ushort?), x => UInt16.TryParse((string)x, out var result) ? result : default(ushort?) },
            { typeof(int), x => Int32.TryParse((string)x, out var result) ? result : default },
            { typeof(int?), x => Int32.TryParse((string)x, out var result) ? result : default(int?) },
            { typeof(uint), x => UInt32.TryParse((string)x, out var result) ? result : default },
            { typeof(uint?), x => UInt32.TryParse((string)x, out var result) ? result : default(uint?) },
            { typeof(long), x => Int64.TryParse((string)x, out var result) ? result : default },
            { typeof(long?), x => Int64.TryParse((string)x, out var result) ? result : default(long?) },
            { typeof(ulong), x => UInt64.TryParse((string)x, out var result) ? result : default },
            { typeof(ulong?), x => UInt64.TryParse((string)x, out var result) ? result : default(ulong?) },
            { typeof(char), x => Char.TryParse((string)x, out var result) ? result : default },
            { typeof(char?), x => Char.TryParse((string)x, out var result) ? result : default(char?) },
            { typeof(double), x => Double.TryParse((string)x, out var result) ? result : default },
            { typeof(double?), x => Double.TryParse((string)x, out var result) ? result : default(double?) },
            { typeof(float), x => Single.TryParse((string)x, out var result) ? result : default },
            { typeof(float?), x => Single.TryParse((string)x, out var result) ? result : default(float?) },
        };

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            if ((sourceType == typeof(string)) &&
                Converters.TryGetValue(targetType, out var converter))
            {
                return converter;
            }

            return null;
        }
    }
}
