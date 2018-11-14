namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;

    public sealed class BooleanConverterFactory : IConverterFactory
    {
        private static readonly Dictionary<Type, Func<object, object>> FromBooleanConverters = new Dictionary<Type, Func<object, object>>
        {
            { typeof(byte), x => (bool)x ? (byte)1 : (byte)0 },
            { typeof(sbyte), x => (bool)x ? (sbyte)1 : (sbyte)0 },
            { typeof(short), x => (bool)x ? (short)1 : (short)0 },
            { typeof(ushort), x => (bool)x ? (ushort)1 : (ushort)0 },
            { typeof(int), x => (bool)x ? 1 : 0 },
            { typeof(uint), x => (bool)x ? 1U : 0U },
            { typeof(long), x => (bool)x ? 1L : 0L },
            { typeof(ulong), x => (bool)x ? 1UL : 0UL },
            { typeof(char), x => (bool)x ? (char)1 : (char)0 },
            { typeof(double), x => (bool)x ? 1.0d : 0.0d },
            { typeof(float), x => (bool)x ? 1.0f : 0.0f },
            { typeof(decimal), x => (bool)x ? Decimal.One : Decimal.Zero },
        };

        // ReSharper disable CompareOfFloatsByEqualityOperator
        // ReSharper disable RedundantTypeSpecificationInDefaultExpression
        private static readonly Dictionary<Type, Func<object, object>> ToBooleanConverters = new Dictionary<Type, Func<object, object>>
        {
            { typeof(byte), x => (byte)x != default(byte) },
            { typeof(sbyte), x => (sbyte)x != default(sbyte) },
            { typeof(short), x => (short)x != default(short) },
            { typeof(ushort), x => (ushort)x != default(ushort) },
            { typeof(int), x => (int)x != default(int) },
            { typeof(uint), x => (uint)x != default(uint) },
            { typeof(long), x => (long)x != default(long) },
            { typeof(ulong), x => (ulong)x != default(ulong) },
            { typeof(char), x => (char)x != default(char) },
            { typeof(double), x => (double)x != default(double) },
            { typeof(float), x => (float)x != default(float) },
            { typeof(decimal), x => (decimal)x != default(decimal) }
        };
        // ReSharper restore RedundantTypeSpecificationInDefaultExpression
        // ReSharper restore CompareOfFloatsByEqualityOperator

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            if (sourceType == typeof(bool))
            {
                if (targetType.IsValueType)
                {
                    var type = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;
                    if (FromBooleanConverters.TryGetValue(type, out var converter))
                    {
                        return converter;
                    }
                }

                if (targetType == typeof(string))
                {
                    return x => ((bool)x).ToString();
                }
            }
            else if ((targetType == typeof(bool)) || (targetType == typeof(bool?)))
            {
                if (sourceType.IsValueType)
                {
                    var type = sourceType.IsNullableType() ? Nullable.GetUnderlyingType(sourceType) : sourceType;
                    if (ToBooleanConverters.TryGetValue(type, out var converter))
                    {
                        return converter;
                    }
                }

                if (sourceType == typeof(string))
                {
                    return x => Boolean.TryParse((string)x, out var result) ? (object)result : null;
                }
            }

            return null;
        }
    }
}
