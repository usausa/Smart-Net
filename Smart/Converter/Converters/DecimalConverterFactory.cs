namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "Ignore")]
    public sealed class DecimalConverterFactory : IConverterFactory
    {
        private static readonly Dictionary<Tuple<Type, Type>, Func<object, object>> Converters = new()
        {
            // From decimal
            { Tuple.Create(typeof(Decimal), typeof(byte)), x => { try { return Decimal.ToByte((decimal)x); } catch (OverflowException) { return default(byte); } } },
            { Tuple.Create(typeof(Decimal), typeof(byte?)), x => { try { return Decimal.ToByte((decimal)x); } catch (OverflowException) { return default(byte?); } } },
            { Tuple.Create(typeof(Decimal), typeof(sbyte)), x => { try { return Decimal.ToSByte((decimal)x); } catch (OverflowException) { return default(sbyte); } } },
            { Tuple.Create(typeof(Decimal), typeof(sbyte?)), x => { try { return Decimal.ToSByte((decimal)x); } catch (OverflowException) { return default(sbyte?); } } },
            { Tuple.Create(typeof(Decimal), typeof(short)), x => { try { return Decimal.ToInt16((decimal)x); } catch (OverflowException) { return default(short); } } },
            { Tuple.Create(typeof(Decimal), typeof(short?)), x => { try { return Decimal.ToInt16((decimal)x); } catch (OverflowException) { return default(short?); } } },
            { Tuple.Create(typeof(Decimal), typeof(ushort)), x => { try { return Decimal.ToUInt16((decimal)x); } catch (OverflowException) { return default(ushort); } } },
            { Tuple.Create(typeof(Decimal), typeof(ushort?)), x => { try { return Decimal.ToUInt16((decimal)x); } catch (OverflowException) { return default(ushort?); } } },
            { Tuple.Create(typeof(Decimal), typeof(int)), x => { try { return Decimal.ToInt32((decimal)x); } catch (OverflowException) { return default(int); } } },
            { Tuple.Create(typeof(Decimal), typeof(int?)), x => { try { return Decimal.ToInt32((decimal)x); } catch (OverflowException) { return default(int?); } } },
            { Tuple.Create(typeof(Decimal), typeof(uint)), x => { try { return Decimal.ToUInt32((decimal)x); } catch (OverflowException) { return default(uint); } } },
            { Tuple.Create(typeof(Decimal), typeof(uint?)), x => { try { return Decimal.ToUInt32((decimal)x); } catch (OverflowException) { return default(uint?); } } },
            { Tuple.Create(typeof(Decimal), typeof(long)), x => { try { return Decimal.ToInt64((decimal)x); } catch (OverflowException) { return default(long); } } },
            { Tuple.Create(typeof(Decimal), typeof(long?)), x => { try { return Decimal.ToInt64((decimal)x); } catch (OverflowException) { return default(long?); } } },
            { Tuple.Create(typeof(Decimal), typeof(ulong)), x => { try { return Decimal.ToUInt64((decimal)x); } catch (OverflowException) { return default(ulong); } } },
            { Tuple.Create(typeof(Decimal), typeof(ulong?)), x => { try { return Decimal.ToUInt64((decimal)x); } catch (OverflowException) { return default(ulong?); } } },
            { Tuple.Create(typeof(Decimal), typeof(char)), x => { try { return (char)Decimal.ToUInt16((decimal)x); } catch (OverflowException) { return default(char); } } },
            { Tuple.Create(typeof(Decimal), typeof(char?)), x => { try { return (char)Decimal.ToUInt16((decimal)x); } catch (OverflowException) { return default(char?); } } },
            { Tuple.Create(typeof(Decimal), typeof(double)), x => { try { return Decimal.ToDouble((decimal)x); } catch (OverflowException) { return default(double); } } },
            { Tuple.Create(typeof(Decimal), typeof(double?)), x => { try { return Decimal.ToDouble((decimal)x); } catch (OverflowException) { return default(double?); } } },
            { Tuple.Create(typeof(Decimal), typeof(float)), x => { try { return Decimal.ToSingle((decimal)x); } catch (OverflowException) { return default(float); } } },
            { Tuple.Create(typeof(Decimal), typeof(float?)), x => { try { return Decimal.ToSingle((decimal)x); } catch (OverflowException) { return default(float?); } } },
            { Tuple.Create(typeof(Decimal), typeof(string)), x => ((decimal)x).ToString() },
            // To Decimal
            { Tuple.Create(typeof(byte), typeof(Decimal)), x => new Decimal((byte)x) },
            { Tuple.Create(typeof(sbyte), typeof(Decimal)), x => new Decimal((sbyte)x) },
            { Tuple.Create(typeof(short), typeof(Decimal)), x => new Decimal((short)x) },
            { Tuple.Create(typeof(ushort), typeof(Decimal)), x => new Decimal((ushort)x) },
            { Tuple.Create(typeof(int), typeof(Decimal)), x => new Decimal((int)x) },
            { Tuple.Create(typeof(uint), typeof(Decimal)), x => new Decimal((uint)x) },
            { Tuple.Create(typeof(long), typeof(Decimal)), x => new Decimal((long)x) },
            { Tuple.Create(typeof(ulong), typeof(Decimal)), x => new Decimal((ulong)x) },
            { Tuple.Create(typeof(char), typeof(Decimal)), x => new Decimal((char)x) },
            { Tuple.Create(typeof(double), typeof(Decimal)), x => { try { return new Decimal((double)x); } catch (OverflowException) { return default(decimal); } } },
            { Tuple.Create(typeof(float), typeof(Decimal)), x => { try { return new Decimal((float)x); } catch (OverflowException) { return default(decimal); } } },
            { Tuple.Create(typeof(string), typeof(Decimal)), x => Decimal.TryParse((string)x, out var result) ? result : default },
            // To Decimal?
            { Tuple.Create(typeof(byte), typeof(Decimal?)), x => new Decimal((byte)x) },
            { Tuple.Create(typeof(sbyte), typeof(Decimal?)), x => new Decimal((sbyte)x) },
            { Tuple.Create(typeof(short), typeof(Decimal?)), x => new Decimal((short)x) },
            { Tuple.Create(typeof(ushort), typeof(Decimal?)), x => new Decimal((ushort)x) },
            { Tuple.Create(typeof(int), typeof(Decimal?)), x => new Decimal((int)x) },
            { Tuple.Create(typeof(uint), typeof(Decimal?)), x => new Decimal((uint)x) },
            { Tuple.Create(typeof(long), typeof(Decimal?)), x => new Decimal((long)x) },
            { Tuple.Create(typeof(ulong), typeof(Decimal?)), x => new Decimal((ulong)x) },
            { Tuple.Create(typeof(char), typeof(Decimal?)), x => new Decimal((char)x) },
            { Tuple.Create(typeof(double), typeof(Decimal?)), x => { try { return new Decimal((double)x); } catch (OverflowException) { return default(decimal?); } } },
            { Tuple.Create(typeof(float), typeof(Decimal?)), x => { try { return new Decimal((float)x); } catch (OverflowException) { return default(decimal?); } } },
            { Tuple.Create(typeof(string), typeof(Decimal?)), x => Decimal.TryParse((string)x, out var result) ? result : default(decimal?) }
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
