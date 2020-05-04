namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Ignore")]
    public sealed class EnumConverterFactory : IConverterFactory
    {
        private static readonly HashSet<Type> UnderlyingTypes = new HashSet<Type>
        {
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(char),
        };

        private static readonly Dictionary<Tuple<Type, Type>, Func<object, object>> CastOperators = new Dictionary<Tuple<Type, Type>, Func<object, object>>
        {
            // byte
            { Tuple.Create(typeof(byte), typeof(byte)), source => (byte)source },
            { Tuple.Create(typeof(byte), typeof(sbyte)), source => (sbyte)(byte)source },
            { Tuple.Create(typeof(byte), typeof(short)), source => (short)(byte)source },
            { Tuple.Create(typeof(byte), typeof(ushort)), source => (ushort)(byte)source },
            { Tuple.Create(typeof(byte), typeof(int)), source => (int)(byte)source },
            { Tuple.Create(typeof(byte), typeof(uint)), source => (uint)(byte)source },
            { Tuple.Create(typeof(byte), typeof(long)), source => (long)(byte)source },
            { Tuple.Create(typeof(byte), typeof(ulong)), source => (ulong)(byte)source },
            { Tuple.Create(typeof(byte), typeof(char)), source => (char)(byte)source },
            // sbyte
            { Tuple.Create(typeof(sbyte), typeof(byte)), source => (byte)(sbyte)source },
            { Tuple.Create(typeof(sbyte), typeof(sbyte)), source => (sbyte)source },
            { Tuple.Create(typeof(sbyte), typeof(short)), source => (short)(sbyte)source },
            { Tuple.Create(typeof(sbyte), typeof(ushort)), source => (ushort)(sbyte)source },
            { Tuple.Create(typeof(sbyte), typeof(int)), source => (int)(sbyte)source },
            { Tuple.Create(typeof(sbyte), typeof(uint)), source => (uint)(sbyte)source },
            { Tuple.Create(typeof(sbyte), typeof(long)), source => (long)(sbyte)source },
            { Tuple.Create(typeof(sbyte), typeof(ulong)), source => (ulong)(sbyte)source },
            { Tuple.Create(typeof(sbyte), typeof(char)), source => (char)(sbyte)source },
            // short
            { Tuple.Create(typeof(short), typeof(byte)), source => (byte)(short)source },
            { Tuple.Create(typeof(short), typeof(sbyte)), source => (sbyte)(short)source },
            { Tuple.Create(typeof(short), typeof(short)), source => (short)source },
            { Tuple.Create(typeof(short), typeof(ushort)), source => (ushort)(short)source },
            { Tuple.Create(typeof(short), typeof(int)), source => (int)(short)source },
            { Tuple.Create(typeof(short), typeof(uint)), source => (uint)(short)source },
            { Tuple.Create(typeof(short), typeof(long)), source => (long)(short)source },
            { Tuple.Create(typeof(short), typeof(ulong)), source => (ulong)(short)source },
            { Tuple.Create(typeof(short), typeof(char)), source => (char)(short)source },
            // ushort
            { Tuple.Create(typeof(ushort), typeof(byte)), source => (byte)(ushort)source },
            { Tuple.Create(typeof(ushort), typeof(sbyte)), source => (sbyte)(ushort)source },
            { Tuple.Create(typeof(ushort), typeof(short)), source => (short)(ushort)source },
            { Tuple.Create(typeof(ushort), typeof(ushort)), source => (ushort)source },
            { Tuple.Create(typeof(ushort), typeof(int)), source => (int)(ushort)source },
            { Tuple.Create(typeof(ushort), typeof(uint)), source => (uint)(ushort)source },
            { Tuple.Create(typeof(ushort), typeof(long)), source => (long)(ushort)source },
            { Tuple.Create(typeof(ushort), typeof(ulong)), source => (ulong)(ushort)source },
            { Tuple.Create(typeof(ushort), typeof(char)), source => (char)(ushort)source },
            // int
            { Tuple.Create(typeof(int), typeof(byte)), source => (byte)(int)source },
            { Tuple.Create(typeof(int), typeof(sbyte)), source => (sbyte)(int)source },
            { Tuple.Create(typeof(int), typeof(short)), source => (short)(int)source },
            { Tuple.Create(typeof(int), typeof(ushort)), source => (ushort)(int)source },
            { Tuple.Create(typeof(int), typeof(int)), source => (int)source },
            { Tuple.Create(typeof(int), typeof(uint)), source => (uint)(int)source },
            { Tuple.Create(typeof(int), typeof(long)), source => (long)(int)source },
            { Tuple.Create(typeof(int), typeof(ulong)), source => (ulong)(int)source },
            { Tuple.Create(typeof(int), typeof(char)), source => (char)(int)source },
            // uint
            { Tuple.Create(typeof(uint), typeof(byte)), source => (byte)(uint)source },
            { Tuple.Create(typeof(uint), typeof(sbyte)), source => (sbyte)(uint)source },
            { Tuple.Create(typeof(uint), typeof(short)), source => (short)(uint)source },
            { Tuple.Create(typeof(uint), typeof(ushort)), source => (ushort)(uint)source },
            { Tuple.Create(typeof(uint), typeof(int)), source => (int)(uint)source },
            { Tuple.Create(typeof(uint), typeof(uint)), source => (uint)source },
            { Tuple.Create(typeof(uint), typeof(long)), source => (long)(uint)source },
            { Tuple.Create(typeof(uint), typeof(ulong)), source => (ulong)(uint)source },
            { Tuple.Create(typeof(uint), typeof(char)), source => (char)(uint)source },
            // long
            { Tuple.Create(typeof(long), typeof(byte)), source => (byte)(long)source },
            { Tuple.Create(typeof(long), typeof(sbyte)), source => (sbyte)(long)source },
            { Tuple.Create(typeof(long), typeof(short)), source => (short)(long)source },
            { Tuple.Create(typeof(long), typeof(ushort)), source => (ushort)(long)source },
            { Tuple.Create(typeof(long), typeof(int)), source => (int)(long)source },
            { Tuple.Create(typeof(long), typeof(uint)), source => (uint)(long)source },
            { Tuple.Create(typeof(long), typeof(long)), source => (long)source },
            { Tuple.Create(typeof(long), typeof(ulong)), source => (ulong)(long)source },
            { Tuple.Create(typeof(long), typeof(char)), source => (char)(long)source },
            // ulong
            { Tuple.Create(typeof(ulong), typeof(byte)), source => (byte)(ulong)source },
            { Tuple.Create(typeof(ulong), typeof(sbyte)), source => (sbyte)(ulong)source },
            { Tuple.Create(typeof(ulong), typeof(short)), source => (short)(ulong)source },
            { Tuple.Create(typeof(ulong), typeof(ushort)), source => (ushort)(ulong)source },
            { Tuple.Create(typeof(ulong), typeof(int)), source => (int)(ulong)source },
            { Tuple.Create(typeof(ulong), typeof(uint)), source => (uint)(ulong)source },
            { Tuple.Create(typeof(ulong), typeof(long)), source => (long)(ulong)source },
            { Tuple.Create(typeof(ulong), typeof(ulong)), source => (ulong)source },
            { Tuple.Create(typeof(ulong), typeof(char)), source => (char)(ulong)source },
        };

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            var sourceEnumType = sourceType.GetEnumType();
            var targetEnumType = targetType.GetEnumType();

            if ((sourceEnumType != null) && (targetEnumType != null))
            {
                // Enum to Enum
                return source => Enum.ToObject(targetEnumType, source);
            }

            if (targetEnumType != null)
            {
                // !Enum to Enum

                // String to Enum
                if (sourceType == typeof(string))
                {
                    return ((IConverter)Activator.CreateInstance(typeof(StringToEnumConverter<>).MakeGenericType(targetEnumType))).Convert;
                }

                // Assignable
                if (UnderlyingTypes.Contains(sourceType))
                {
                    var targetUnderlyingType = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;
                    return source => Enum.ToObject(targetUnderlyingType, source);
                }

                return null;
            }

            if (sourceEnumType != null)
            {
                // Enum to !Enum

                // Enum to String
                if (targetType == typeof(string))
                {
                    return ((IConverter)Activator.CreateInstance(typeof(EnumToStringConverter<>).MakeGenericType(sourceEnumType))).Convert;
                }

                // Enum to Numeric
                var sourceUnderlyingType = Enum.GetUnderlyingType(sourceType);
                var targetUnderlyingType = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;
                if (CastOperators.TryGetValue(Tuple.Create(sourceUnderlyingType, targetUnderlyingType), out var converter))
                {
                    return converter;
                }

                return null;
            }

            return null;
        }

        private sealed class EnumToStringConverter<T> : IConverter
            where T : struct, Enum
        {
            public object Convert(object source)
            {
                return Enums<T>.GetName((T)source);
            }
        }

        private sealed class StringToEnumConverter<T> : IConverter
            where T : struct, Enum
        {
            public object Convert(object source)
            {
                return Enums<T>.TryParseValue((string)source, out var value) ? value : default;
            }
        }
    }
}
