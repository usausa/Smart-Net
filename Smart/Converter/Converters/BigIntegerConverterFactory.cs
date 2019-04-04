namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Ignore")]
    public sealed class BigIntegerConverterFactory : IConverterFactory
    {
        private static readonly Dictionary<Tuple<Type, Type>, Func<object, object>> Converters = new Dictionary<Tuple<Type, Type>, Func<object, object>>
        {
            // From decimal
            { Tuple.Create(typeof(BigInteger), typeof(byte)), x => { try { return (byte)(BigInteger)x; } catch (OverflowException) { return default(byte); } } },
            { Tuple.Create(typeof(BigInteger), typeof(byte?)), x => { try { return (byte)(BigInteger)x; } catch (OverflowException) { return default(byte?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(sbyte)), x => { try { return (sbyte)(BigInteger)x; } catch (OverflowException) { return default(sbyte); } } },
            { Tuple.Create(typeof(BigInteger), typeof(sbyte?)), x => { try { return (sbyte)(BigInteger)x; } catch (OverflowException) { return default(sbyte?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(short)), x => { try { return (short)(BigInteger)x; } catch (OverflowException) { return default(short); } } },
            { Tuple.Create(typeof(BigInteger), typeof(short?)), x => { try { return (short)(BigInteger)x; } catch (OverflowException) { return default(short?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(ushort)), x => { try { return (ushort)(BigInteger)x; } catch (OverflowException) { return default(ushort); } } },
            { Tuple.Create(typeof(BigInteger), typeof(ushort?)), x => { try { return (ushort)(BigInteger)x; } catch (OverflowException) { return default(ushort?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(int)), x => { try { return (int)(BigInteger)x; } catch (OverflowException) { return default(int); } } },
            { Tuple.Create(typeof(BigInteger), typeof(int?)), x => { try { return (int)(BigInteger)x; } catch (OverflowException) { return default(int?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(uint)), x => { try { return (uint)(BigInteger)x; } catch (OverflowException) { return default(uint); } } },
            { Tuple.Create(typeof(BigInteger), typeof(uint?)), x => { try { return (uint)(BigInteger)x; } catch (OverflowException) { return default(uint?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(long)), x => { try { return (long)(BigInteger)x; } catch (OverflowException) { return default(long); } } },
            { Tuple.Create(typeof(BigInteger), typeof(long?)), x => { try { return (long)(BigInteger)x; } catch (OverflowException) { return default(long?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(ulong)), x => { try { return (ulong)(BigInteger)x; } catch (OverflowException) { return default(ulong); } } },
            { Tuple.Create(typeof(BigInteger), typeof(ulong?)), x => { try { return (ulong)(BigInteger)x; } catch (OverflowException) { return default(ulong?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(char)), x => { try { return (char)(BigInteger)x; } catch (OverflowException) { return default(char); } } },
            { Tuple.Create(typeof(BigInteger), typeof(char?)), x => { try { return (char)(BigInteger)x; } catch (OverflowException) { return default(char?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(float)), x => { try { return (float)(BigInteger)x; } catch (OverflowException) { return default(float); } } },
            { Tuple.Create(typeof(BigInteger), typeof(float?)), x => { try { return (float)(BigInteger)x; } catch (OverflowException) { return default(float?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(double)), x => { try { return (double)(BigInteger)x; } catch (OverflowException) { return default(double); } } },
            { Tuple.Create(typeof(BigInteger), typeof(double?)), x => { try { return (double)(BigInteger)x; } catch (OverflowException) { return default(double?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(decimal)), x => { try { return (decimal)(BigInteger)x; } catch (OverflowException) { return default(decimal); } } },
            { Tuple.Create(typeof(BigInteger), typeof(decimal?)), x => { try { return (decimal)(BigInteger)x; } catch (OverflowException) { return default(decimal?); } } },
            { Tuple.Create(typeof(BigInteger), typeof(string)), x => ((BigInteger)x).ToString() },
            // To BigInteger
            { Tuple.Create(typeof(byte), typeof(BigInteger)), x => new BigInteger((byte)x) },
            { Tuple.Create(typeof(sbyte), typeof(BigInteger)), x => new BigInteger((sbyte)x) },
            { Tuple.Create(typeof(short), typeof(BigInteger)), x => new BigInteger((short)x) },
            { Tuple.Create(typeof(ushort), typeof(BigInteger)), x => new BigInteger((ushort)x) },
            { Tuple.Create(typeof(int), typeof(BigInteger)), x => new BigInteger((int)x) },
            { Tuple.Create(typeof(uint), typeof(BigInteger)), x => new BigInteger((uint)x) },
            { Tuple.Create(typeof(long), typeof(BigInteger)), x => new BigInteger((long)x) },
            { Tuple.Create(typeof(ulong), typeof(BigInteger)), x => new BigInteger((ulong)x) },
            { Tuple.Create(typeof(char), typeof(BigInteger)), x => new BigInteger((char)x) },
            { Tuple.Create(typeof(double), typeof(BigInteger)), x => { try { return new BigInteger((double)x); } catch (OverflowException) { return default(BigInteger); } } },
            { Tuple.Create(typeof(float), typeof(BigInteger)), x => { try { return new BigInteger((float)x); } catch (OverflowException) { return default(BigInteger); } } },
            { Tuple.Create(typeof(decimal), typeof(BigInteger)), x => { try { return new BigInteger((decimal)x); } catch (OverflowException) { return default(BigInteger); } } },
            { Tuple.Create(typeof(string), typeof(BigInteger)), x => BigInteger.TryParse((string)x, out var result) ? result : default },
            // To BigInteger?
            { Tuple.Create(typeof(byte), typeof(BigInteger?)), x => new BigInteger((byte)x) },
            { Tuple.Create(typeof(sbyte), typeof(BigInteger?)), x => new BigInteger((sbyte)x) },
            { Tuple.Create(typeof(short), typeof(BigInteger?)), x => new BigInteger((short)x) },
            { Tuple.Create(typeof(ushort), typeof(BigInteger?)), x => new BigInteger((ushort)x) },
            { Tuple.Create(typeof(int), typeof(BigInteger?)), x => new BigInteger((int)x) },
            { Tuple.Create(typeof(uint), typeof(BigInteger?)), x => new BigInteger((uint)x) },
            { Tuple.Create(typeof(long), typeof(BigInteger?)), x => new BigInteger((long)x) },
            { Tuple.Create(typeof(ulong), typeof(BigInteger?)), x => new BigInteger((ulong)x) },
            { Tuple.Create(typeof(char), typeof(BigInteger?)), x => new BigInteger((char)x) },
            { Tuple.Create(typeof(double), typeof(BigInteger?)), x => { try { return new BigInteger((double)x); } catch (OverflowException) { return default(BigInteger?); } } },
            { Tuple.Create(typeof(float), typeof(BigInteger?)), x => { try { return new BigInteger((float)x); } catch (OverflowException) { return default(BigInteger?); } } },
            { Tuple.Create(typeof(decimal), typeof(BigInteger?)), x => { try { return new BigInteger((decimal)x); } catch (OverflowException) { return default(BigInteger?); } } },
            { Tuple.Create(typeof(string), typeof(BigInteger?)), x => BigInteger.TryParse((string)x, out var result) ? result : default(BigInteger?) }
        };

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            var key = Tuple.Create(sourceType, targetType);
            if (Converters.TryGetValue(key, out var converter))
            {
                return converter;
            }

            return null;
        }
    }
}
