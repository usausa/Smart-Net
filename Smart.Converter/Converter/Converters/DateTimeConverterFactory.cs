#nullable disable
namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Ignore")]
    public sealed class DateTimeConverterFactory : IConverterFactory
    {
        private static readonly Dictionary<Type, Func<object, object>> DateTimeToTickConverter = new()
        {
            { typeof(byte), source => (byte)((DateTime)source).Ticks },
            { typeof(sbyte), source => (sbyte)((DateTime)source).Ticks },
            { typeof(short), source => (short)((DateTime)source).Ticks },
            { typeof(ushort), source => (ushort)((DateTime)source).Ticks },
            { typeof(int), source => (int)((DateTime)source).Ticks },
            { typeof(uint), source => (uint)((DateTime)source).Ticks },
            { typeof(long), source => ((DateTime)source).Ticks },
            { typeof(ulong), source => (ulong)((DateTime)source).Ticks },
            { typeof(char), source => (char)((DateTime)source).Ticks },
            { typeof(double), source => (double)((DateTime)source).Ticks },
            { typeof(float), source => (float)((DateTime)source).Ticks },
            { typeof(decimal), source => (decimal)((DateTime)source).Ticks }
        };

        private static readonly Dictionary<Type, Func<object, object>> DateTimeOffsetToTickConverter = new()
        {
            { typeof(byte), source => (byte)((DateTimeOffset)source).Ticks },
            { typeof(sbyte), source => (sbyte)((DateTimeOffset)source).Ticks },
            { typeof(short), source => (short)((DateTimeOffset)source).Ticks },
            { typeof(ushort), source => (ushort)((DateTimeOffset)source).Ticks },
            { typeof(int), source => (int)((DateTimeOffset)source).Ticks },
            { typeof(uint), source => (uint)((DateTimeOffset)source).Ticks },
            { typeof(long), source => ((DateTimeOffset)source).Ticks },
            { typeof(ulong), source => (ulong)((DateTimeOffset)source).Ticks },
            { typeof(char), source => (char)((DateTimeOffset)source).Ticks },
            { typeof(double), source => (double)((DateTimeOffset)source).Ticks },
            { typeof(float), source => (float)((DateTimeOffset)source).Ticks },
            { typeof(decimal), source => (decimal)((DateTimeOffset)source).Ticks }
        };

        private static readonly Dictionary<Type, Func<object, object>> TimeSpanToTickConverter = new()
        {
            { typeof(byte), source => (byte)((TimeSpan)source).Ticks },
            { typeof(sbyte), source => (sbyte)((TimeSpan)source).Ticks },
            { typeof(short), source => (short)((TimeSpan)source).Ticks },
            { typeof(ushort), source => (ushort)((TimeSpan)source).Ticks },
            { typeof(int), source => (int)((TimeSpan)source).Ticks },
            { typeof(uint), source => (uint)((TimeSpan)source).Ticks },
            { typeof(long), source => ((TimeSpan)source).Ticks },
            { typeof(ulong), source => (ulong)((TimeSpan)source).Ticks },
            { typeof(char), source => (char)((TimeSpan)source).Ticks },
            { typeof(double), source => (double)((TimeSpan)source).Ticks },
            { typeof(float), source => (float)((TimeSpan)source).Ticks },
            { typeof(decimal), source => (decimal)((TimeSpan)source).Ticks }
        };

        private static readonly Dictionary<Type, Func<object, object>> DateTimeFromTickConverter = new()
        {
            { typeof(byte), source => { try { return new DateTime((byte)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(sbyte), source => { try { return new DateTime((sbyte)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(short), source => { try { return new DateTime((short)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(ushort), source => { try { return new DateTime((ushort)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(int), source => { try { return new DateTime((int)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(uint), source => { try { return new DateTime((uint)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(long), source => { try { return new DateTime((long)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(ulong), source => { try { return new DateTime((long)(ulong)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(char), source => { try { return new DateTime((char)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(double), source => { try { return new DateTime((long)(double)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(float), source => { try { return new DateTime((long)(float)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } },
            { typeof(decimal), source => { try { return new DateTime((long)(decimal)source); } catch (ArgumentOutOfRangeException) { return default(DateTime); } } }
        };

        private static readonly Dictionary<Type, Func<object, object>> NullableDateTimeFromTickConverter = new()
        {
            { typeof(byte), source => { try { return new DateTime((byte)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(sbyte), source => { try { return new DateTime((sbyte)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(short), source => { try { return new DateTime((short)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(ushort), source => { try { return new DateTime((ushort)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(int), source => { try { return new DateTime((int)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(uint), source => { try { return new DateTime((uint)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(long), source => { try { return new DateTime((long)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(ulong), source => { try { return new DateTime((long)(ulong)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(char), source => { try { return new DateTime((char)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(double), source => { try { return new DateTime((long)(double)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(float), source => { try { return new DateTime((long)(float)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } },
            { typeof(decimal), source => { try { return new DateTime((long)(decimal)source); } catch (ArgumentOutOfRangeException) { return default(DateTime?); } } }
        };

        private static readonly Dictionary<Type, Func<object, object>> DateTimeOffsetFromTickConverter = new()
        {
            { typeof(byte), source => { try { return new DateTimeOffset(new DateTime((byte)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(sbyte), source => { try { return new DateTimeOffset(new DateTime((sbyte)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(short), source => { try { return new DateTimeOffset(new DateTime((short)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(ushort), source => { try { return new DateTimeOffset(new DateTime((ushort)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(int), source => { try { return new DateTimeOffset(new DateTime((int)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(uint), source => { try { return new DateTimeOffset(new DateTime((uint)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(long), source => { try { return new DateTimeOffset(new DateTime((long)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(ulong), source => { try { return new DateTimeOffset(new DateTime((long)(ulong)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(char), source => { try { return new DateTimeOffset(new DateTime((char)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(double), source => { try { return new DateTimeOffset(new DateTime((long)(double)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(float), source => { try { return new DateTimeOffset(new DateTime((long)(float)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } },
            { typeof(decimal), source => { try { return new DateTimeOffset(new DateTime((long)(decimal)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset); } } }
        };

        private static readonly Dictionary<Type, Func<object, object>> NullableDateTimeOffsetFromTickConverter = new()
        {
            { typeof(byte), source => { try { return new DateTimeOffset(new DateTime((byte)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(sbyte), source => { try { return new DateTimeOffset(new DateTime((sbyte)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(short), source => { try { return new DateTimeOffset(new DateTime((short)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(ushort), source => { try { return new DateTimeOffset(new DateTime((ushort)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(int), source => { try { return new DateTimeOffset(new DateTime((int)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(uint), source => { try { return new DateTimeOffset(new DateTime((uint)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(long), source => { try { return new DateTimeOffset(new DateTime((long)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(ulong), source => { try { return new DateTimeOffset(new DateTime((long)(ulong)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(char), source => { try { return new DateTimeOffset(new DateTime((char)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(double), source => { try { return new DateTimeOffset(new DateTime((long)(double)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(float), source => { try { return new DateTimeOffset(new DateTime((long)(float)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } },
            { typeof(decimal), source => { try { return new DateTimeOffset(new DateTime((long)(decimal)source)); } catch (ArgumentOutOfRangeException) { return default(DateTimeOffset?); } } }
        };

        private static readonly Dictionary<Type, Func<object, object>> TimeSpanFromTickConverter = new()
        {
            { typeof(byte), source => { try { return new TimeSpan((byte)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(sbyte), source => { try { return new TimeSpan((sbyte)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(short), source => { try { return new TimeSpan((short)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(ushort), source => { try { return new TimeSpan((ushort)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(int), source => { try { return new TimeSpan((int)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(uint), source => { try { return new TimeSpan((uint)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(long), source => { try { return new TimeSpan((long)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(ulong), source => { try { return new TimeSpan((long)(ulong)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(char), source => { try { return new TimeSpan((char)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(double), source => { try { return new TimeSpan((long)(double)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(float), source => { try { return new TimeSpan((long)(float)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } },
            { typeof(decimal), source => { try { return new TimeSpan((long)(decimal)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan); } } }
        };

        private static readonly Dictionary<Type, Func<object, object>> NullableTimeSpanFromTickConverter = new()
        {
            { typeof(byte), source => { try { return new TimeSpan((byte)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(sbyte), source => { try { return new TimeSpan((sbyte)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(short), source => { try { return new TimeSpan((short)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(ushort), source => { try { return new TimeSpan((ushort)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(int), source => { try { return new TimeSpan((int)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(uint), source => { try { return new TimeSpan((uint)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(long), source => { try { return new TimeSpan((long)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(ulong), source => { try { return new TimeSpan((long)(ulong)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(char), source => { try { return new TimeSpan((char)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(double), source => { try { return new TimeSpan((long)(double)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(float), source => { try { return new TimeSpan((long)(float)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } },
            { typeof(decimal), source => { try { return new TimeSpan((long)(decimal)source); } catch (ArgumentOutOfRangeException) { return default(TimeSpan?); } } }
        };

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            // From DateTime
            if (sourceType == typeof(DateTime))
            {
                // DateTime to String
                if (targetType == typeof(string))
                {
                    return source => ((DateTime)source).ToString();
                }

                var underlyingTargetType = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;

                // DateTime to DateTimeOffset(Nullable)
                if (underlyingTargetType == typeof(DateTimeOffset))
                {
                    var defaultValue = targetType.IsNullableType() ? null : (object)default(DateTimeOffset);
                    return source =>
                    {
                        try
                        {
                            return new DateTimeOffset((DateTime)source);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            return defaultValue;
                        }
                    };
                }

                // DateTime to numeric
                if (DateTimeToTickConverter.TryGetValue(underlyingTargetType, out var converter))
                {
                    return converter;
                }

                return null;
            }

            // From DateTimeOffset
            if (sourceType == typeof(DateTimeOffset))
            {
                // DateTimeOffset to String
                if (targetType == typeof(string))
                {
                    return source => ((DateTimeOffset)source).ToString();
                }

                var underlyingTargetType = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;

                // DateTimeOffset to DateTime(Nullable)
                if (underlyingTargetType == typeof(DateTime))
                {
                    return source => ((DateTimeOffset)source).DateTime;
                }

                // DateTimeOffset to numeric
                if (DateTimeOffsetToTickConverter.TryGetValue(underlyingTargetType, out var converter))
                {
                    return converter;
                }

                return null;
            }

            // From TimeSpan
            if (sourceType == typeof(TimeSpan))
            {
                // TimeSpan to String
                if (targetType == typeof(string))
                {
                    return source => ((TimeSpan)source).ToString();
                }

                var underlyingTargetType = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;

                // TimeSpan to numeric
                if (TimeSpanToTickConverter.TryGetValue(underlyingTargetType, out var converter))
                {
                    return converter;
                }

                return null;
            }

            // From string
            if (sourceType == typeof(string))
            {
                var underlyingTargetType = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;

                // String to DateTime(Nullable)
                if (underlyingTargetType == typeof(DateTime))
                {
                    var defaultValue = targetType.IsNullableType() ? null : (object)default(DateTime);
                    return source => DateTime.TryParse((string)source, out var result) ? result : defaultValue;
                }

                // String to DateTimeOffset(Nullable)
                if (underlyingTargetType == typeof(DateTimeOffset))
                {
                    var defaultValue = targetType.IsNullableType() ? null : (object)default(DateTimeOffset);
                    return source => DateTimeOffset.TryParse((string)source, out var result) ? result : defaultValue;
                }

                // String to TimeSpan(Nullable)
                if (underlyingTargetType == typeof(TimeSpan))
                {
                    var defaultValue = targetType.IsNullableType() ? null : (object)default(TimeSpan);
                    return source => TimeSpan.TryParse((string)source, out var result) ? result : defaultValue;
                }

                return null;
            }

            // From Numeric to DateTime
            if (targetType == typeof(DateTime))
            {
                return DateTimeFromTickConverter.TryGetValue(sourceType, out var converter) ? converter : null;
            }

            // From Numeric to DateTime?
            if (targetType == typeof(DateTime?))
            {
                return NullableDateTimeFromTickConverter.TryGetValue(sourceType, out var converter) ? converter : null;
            }

            // From Numeric to DateTimeOffset
            if (targetType == typeof(DateTimeOffset))
            {
                return DateTimeOffsetFromTickConverter.TryGetValue(sourceType, out var converter) ? converter : null;
            }

            // From Numeric to DateTime?
            if (targetType == typeof(DateTimeOffset?))
            {
                return NullableDateTimeOffsetFromTickConverter.TryGetValue(sourceType, out var converter) ? converter : null;
            }

            // From Numeric to TimeSpan
            if (targetType == typeof(TimeSpan))
            {
                return TimeSpanFromTickConverter.TryGetValue(sourceType, out var converter) ? converter : null;
            }

            // From Numeric to TimeSpan?
            if (targetType == typeof(TimeSpan?))
            {
                return NullableTimeSpanFromTickConverter.TryGetValue(sourceType, out var converter) ? converter : null;
            }

            return null;
        }
    }
}
