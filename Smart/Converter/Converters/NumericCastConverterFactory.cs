namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;

    public sealed class NumericCastConverterFactory : IConverterFactory
    {
        private static readonly Dictionary<Tuple<Type, Type>, Func<object, object>> Converters = new Dictionary<Tuple<Type, Type>, Func<object, object>>
        {
            // byte
            { Tuple.Create(typeof(byte), typeof(sbyte)), x => (sbyte)(byte)x },
            { Tuple.Create(typeof(byte), typeof(short)), x => (short)(byte)x },
            { Tuple.Create(typeof(byte), typeof(ushort)), x => (ushort)(byte)x },
            { Tuple.Create(typeof(byte), typeof(int)), x => (int)(byte)x },
            { Tuple.Create(typeof(byte), typeof(uint)), x => (uint)(byte)x },
            { Tuple.Create(typeof(byte), typeof(long)), x => (long)(byte)x },
            { Tuple.Create(typeof(byte), typeof(ulong)), x => (ulong)(byte)x },
            { Tuple.Create(typeof(byte), typeof(char)), x => (char)(byte)x },
            { Tuple.Create(typeof(byte), typeof(double)), x => (double)(byte)x },
            { Tuple.Create(typeof(byte), typeof(float)), x => (float)(byte)x },
            // sbyte
            { Tuple.Create(typeof(sbyte), typeof(byte)), x => (byte)(sbyte)x },
            { Tuple.Create(typeof(sbyte), typeof(short)), x => (short)(sbyte)x },
            { Tuple.Create(typeof(sbyte), typeof(ushort)), x => (ushort)(sbyte)x },
            { Tuple.Create(typeof(sbyte), typeof(int)), x => (int)(sbyte)x },
            { Tuple.Create(typeof(sbyte), typeof(uint)), x => (uint)(sbyte)x },
            { Tuple.Create(typeof(sbyte), typeof(long)), x => (long)(sbyte)x },
            { Tuple.Create(typeof(sbyte), typeof(ulong)), x => (ulong)(sbyte)x },
            { Tuple.Create(typeof(sbyte), typeof(char)), x => (char)(sbyte)x },
            { Tuple.Create(typeof(sbyte), typeof(double)), x => (double)(sbyte)x },
            { Tuple.Create(typeof(sbyte), typeof(float)), x => (float)(sbyte)x },
            // short
            { Tuple.Create(typeof(short), typeof(byte)), x => (byte)(short)x },
            { Tuple.Create(typeof(short), typeof(sbyte)), x => (sbyte)(short)x },
            { Tuple.Create(typeof(short), typeof(ushort)), x => (ushort)(short)x },
            { Tuple.Create(typeof(short), typeof(int)), x => (int)(short)x },
            { Tuple.Create(typeof(short), typeof(uint)), x => (uint)(short)x },
            { Tuple.Create(typeof(short), typeof(long)), x => (long)(short)x },
            { Tuple.Create(typeof(short), typeof(ulong)), x => (ulong)(short)x },
            { Tuple.Create(typeof(short), typeof(char)), x => (char)(short)x },
            { Tuple.Create(typeof(short), typeof(double)), x => (double)(short)x },
            { Tuple.Create(typeof(short), typeof(float)), x => (float)(short)x },
            // ushort
            { Tuple.Create(typeof(ushort), typeof(byte)), x => (byte)(ushort)x },
            { Tuple.Create(typeof(ushort), typeof(sbyte)), x => (sbyte)(ushort)x },
            { Tuple.Create(typeof(ushort), typeof(short)), x => (short)(ushort)x },
            { Tuple.Create(typeof(ushort), typeof(int)), x => (int)(ushort)x },
            { Tuple.Create(typeof(ushort), typeof(uint)), x => (uint)(ushort)x },
            { Tuple.Create(typeof(ushort), typeof(long)), x => (long)(ushort)x },
            { Tuple.Create(typeof(ushort), typeof(ulong)), x => (ulong)(ushort)x },
            { Tuple.Create(typeof(ushort), typeof(char)), x => (char)(ushort)x },
            { Tuple.Create(typeof(ushort), typeof(double)), x => (double)(ushort)x },
            { Tuple.Create(typeof(ushort), typeof(float)), x => (float)(ushort)x },
            // int
            { Tuple.Create(typeof(int), typeof(byte)), x => (byte)(int)x },
            { Tuple.Create(typeof(int), typeof(sbyte)), x => (sbyte)(int)x },
            { Tuple.Create(typeof(int), typeof(short)), x => (short)(int)x },
            { Tuple.Create(typeof(int), typeof(ushort)), x => (ushort)(int)x },
            { Tuple.Create(typeof(int), typeof(uint)), x => (uint)(int)x },
            { Tuple.Create(typeof(int), typeof(long)), x => (long)(int)x },
            { Tuple.Create(typeof(int), typeof(ulong)), x => (ulong)(int)x },
            { Tuple.Create(typeof(int), typeof(char)), x => (char)(int)x },
            { Tuple.Create(typeof(int), typeof(double)), x => (double)(int)x },
            { Tuple.Create(typeof(int), typeof(float)), x => (float)(int)x },
            // uint
            { Tuple.Create(typeof(uint), typeof(byte)), x => (byte)(uint)x },
            { Tuple.Create(typeof(uint), typeof(sbyte)), x => (sbyte)(uint)x },
            { Tuple.Create(typeof(uint), typeof(short)), x => (short)(uint)x },
            { Tuple.Create(typeof(uint), typeof(ushort)), x => (ushort)(uint)x },
            { Tuple.Create(typeof(uint), typeof(int)), x => (int)(uint)x },
            { Tuple.Create(typeof(uint), typeof(long)), x => (long)(uint)x },
            { Tuple.Create(typeof(uint), typeof(ulong)), x => (ulong)(uint)x },
            { Tuple.Create(typeof(uint), typeof(char)), x => (char)(uint)x },
            { Tuple.Create(typeof(uint), typeof(double)), x => (double)(uint)x },
            { Tuple.Create(typeof(uint), typeof(float)), x => (float)(uint)x },
            // long
            { Tuple.Create(typeof(long), typeof(byte)), x => (byte)(long)x },
            { Tuple.Create(typeof(long), typeof(sbyte)), x => (sbyte)(long)x },
            { Tuple.Create(typeof(long), typeof(short)), x => (short)(long)x },
            { Tuple.Create(typeof(long), typeof(ushort)), x => (ushort)(long)x },
            { Tuple.Create(typeof(long), typeof(int)), x => (int)(long)x },
            { Tuple.Create(typeof(long), typeof(uint)), x => (uint)(long)x },
            { Tuple.Create(typeof(long), typeof(ulong)), x => (ulong)(long)x },
            { Tuple.Create(typeof(long), typeof(char)), x => (char)(long)x },
            { Tuple.Create(typeof(long), typeof(double)), x => (double)(long)x },
            { Tuple.Create(typeof(long), typeof(float)), x => (float)(long)x },
            // ulong
            { Tuple.Create(typeof(ulong), typeof(byte)), x => (byte)(ulong)x },
            { Tuple.Create(typeof(ulong), typeof(sbyte)), x => (sbyte)(ulong)x },
            { Tuple.Create(typeof(ulong), typeof(short)), x => (short)(ulong)x },
            { Tuple.Create(typeof(ulong), typeof(ushort)), x => (ushort)(ulong)x },
            { Tuple.Create(typeof(ulong), typeof(int)), x => (int)(ulong)x },
            { Tuple.Create(typeof(ulong), typeof(uint)), x => (uint)(ulong)x },
            { Tuple.Create(typeof(ulong), typeof(long)), x => (long)(ulong)x },
            { Tuple.Create(typeof(ulong), typeof(char)), x => (char)(ulong)x },
            { Tuple.Create(typeof(ulong), typeof(double)), x => (double)(ulong)x },
            { Tuple.Create(typeof(ulong), typeof(float)), x => (float)(ulong)x },
            // char
            { Tuple.Create(typeof(char), typeof(byte)), x => (byte)(char)x },
            { Tuple.Create(typeof(char), typeof(sbyte)), x => (sbyte)(char)x },
            { Tuple.Create(typeof(char), typeof(short)), x => (short)(char)x },
            { Tuple.Create(typeof(char), typeof(ushort)), x => (ushort)(char)x },
            { Tuple.Create(typeof(char), typeof(int)), x => (int)(char)x },
            { Tuple.Create(typeof(char), typeof(uint)), x => (uint)(char)x },
            { Tuple.Create(typeof(char), typeof(long)), x => (long)(char)x },
            { Tuple.Create(typeof(char), typeof(ulong)), x => (ulong)(char)x },
            { Tuple.Create(typeof(char), typeof(double)), x => (double)(char)x },
            { Tuple.Create(typeof(char), typeof(float)), x => (float)(char)x },
            // double
            { Tuple.Create(typeof(double), typeof(byte)), x => (byte)(double)x },
            { Tuple.Create(typeof(double), typeof(sbyte)), x => (sbyte)(double)x },
            { Tuple.Create(typeof(double), typeof(short)), x => (short)(double)x },
            { Tuple.Create(typeof(double), typeof(ushort)), x => (ushort)(double)x },
            { Tuple.Create(typeof(double), typeof(int)), x => (int)(double)x },
            { Tuple.Create(typeof(double), typeof(uint)), x => (uint)(double)x },
            { Tuple.Create(typeof(double), typeof(long)), x => (long)(double)x },
            { Tuple.Create(typeof(double), typeof(ulong)), x => (ulong)(double)x },
            { Tuple.Create(typeof(double), typeof(char)), x => (char)(double)x },
            { Tuple.Create(typeof(double), typeof(float)), x => (float)(double)x },
            // float
            { Tuple.Create(typeof(float), typeof(byte)), x => (byte)(float)x },
            { Tuple.Create(typeof(float), typeof(sbyte)), x => (sbyte)(float)x },
            { Tuple.Create(typeof(float), typeof(short)), x => (short)(float)x },
            { Tuple.Create(typeof(float), typeof(ushort)), x => (ushort)(float)x },
            { Tuple.Create(typeof(float), typeof(int)), x => (int)(float)x },
            { Tuple.Create(typeof(float), typeof(uint)), x => (uint)(float)x },
            { Tuple.Create(typeof(float), typeof(long)), x => (long)(float)x },
            { Tuple.Create(typeof(float), typeof(ulong)), x => (ulong)(float)x },
            { Tuple.Create(typeof(float), typeof(char)), x => (char)(float)x },
            { Tuple.Create(typeof(float), typeof(double)), x => (double)(float)x },
        };

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            if (sourceType.IsValueType && targetType.IsValueType)
            {
                var key = Tuple.Create(sourceType, targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType);
                if (Converters.TryGetValue(key, out var converter))
                {
                    return converter;
                }
            }

            return null;
        }
    }
}
