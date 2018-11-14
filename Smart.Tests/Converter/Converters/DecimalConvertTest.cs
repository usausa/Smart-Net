namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class DecimalConvertTest
    {
        //--------------------------------------------------------------------------------
        // DecimalTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void DecimalToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Decimal.Zero, typeof(byte)));
            Assert.Equal((byte)1, converter.Convert(Decimal.One, typeof(byte)));
            Assert.Equal(default(byte), converter.Convert(Decimal.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Decimal.Zero, typeof(byte?)));
            Assert.Equal((byte)1, converter.Convert(Decimal.One, typeof(byte?)));
            Assert.Equal(default(byte?), converter.Convert(Decimal.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Decimal.Zero, typeof(sbyte)));
            Assert.Equal((sbyte)1, converter.Convert(Decimal.One, typeof(sbyte)));
            Assert.Equal(default(sbyte), converter.Convert(Decimal.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Decimal.Zero, typeof(sbyte?)));
            Assert.Equal((sbyte)1, converter.Convert(Decimal.One, typeof(sbyte?)));
            Assert.Equal(default(sbyte?), converter.Convert(Decimal.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Decimal.Zero, typeof(short)));
            Assert.Equal((short)1, converter.Convert(Decimal.One, typeof(short)));
            Assert.Equal(default(short), converter.Convert(Decimal.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Decimal.Zero, typeof(short?)));
            Assert.Equal((short)1, converter.Convert(Decimal.One, typeof(short?)));
            Assert.Equal(default(short?), converter.Convert(Decimal.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Decimal.Zero, typeof(ushort)));
            Assert.Equal((ushort)1, converter.Convert(Decimal.One, typeof(ushort)));
            Assert.Equal(default(ushort), converter.Convert(Decimal.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Decimal.Zero, typeof(ushort?)));
            Assert.Equal((ushort)1, converter.Convert(Decimal.One, typeof(ushort?)));
            Assert.Equal(default(ushort?), converter.Convert(Decimal.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(Decimal.Zero, typeof(int)));
            Assert.Equal(1, converter.Convert(Decimal.One, typeof(int)));
            Assert.Equal(default(int), converter.Convert(Decimal.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(Decimal.Zero, typeof(int?)));
            Assert.Equal(1, converter.Convert(Decimal.One, typeof(int?)));
            Assert.Equal(default(int?), converter.Convert(Decimal.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Decimal.Zero, typeof(uint)));
            Assert.Equal(1U, converter.Convert(Decimal.One, typeof(uint)));
            Assert.Equal(default(uint), converter.Convert(Decimal.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Decimal.Zero, typeof(uint?)));
            Assert.Equal(1U, converter.Convert(Decimal.One, typeof(uint?)));
            Assert.Equal(default(uint?), converter.Convert(Decimal.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(Decimal.Zero, typeof(long)));
            Assert.Equal(1L, converter.Convert(Decimal.One, typeof(long)));
            Assert.Equal(default(long), converter.Convert(Decimal.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(Decimal.Zero, typeof(long?)));
            Assert.Equal(1L, converter.Convert(Decimal.One, typeof(long?)));
            Assert.Equal(default(long?), converter.Convert(Decimal.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(Decimal.Zero, typeof(ulong)));
            Assert.Equal(1UL, converter.Convert(Decimal.One, typeof(ulong)));
            Assert.Equal(default(ulong), converter.Convert(Decimal.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(Decimal.Zero, typeof(ulong?)));
            Assert.Equal(1UL, converter.Convert(Decimal.One, typeof(ulong?)));
            Assert.Equal(default(ulong?), converter.Convert(Decimal.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Decimal.Zero, typeof(char)));
            Assert.Equal((char)1, converter.Convert(Decimal.One, typeof(char)));
            Assert.Equal(default(char), converter.Convert(Decimal.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Decimal.Zero, typeof(char?)));
            Assert.Equal((char)1, converter.Convert(Decimal.One, typeof(char?)));
            Assert.Equal(default(char?), converter.Convert(Decimal.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(Decimal.Zero, typeof(double)));
            Assert.Equal(1d, converter.Convert(Decimal.One, typeof(double)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(Decimal.Zero, typeof(double?)));
            Assert.Equal(1d, converter.Convert(Decimal.One, typeof(double?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(Decimal.Zero, typeof(float)));
            Assert.Equal(1f, converter.Convert(Decimal.One, typeof(float)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(Decimal.Zero, typeof(float?)));
            Assert.Equal(1f, converter.Convert(Decimal.One, typeof(float?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DecimalToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("-79228162514264337593543950335", converter.Convert(Decimal.MinValue, typeof(string)));
            Assert.Equal("79228162514264337593543950335", converter.Convert(Decimal.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        //--------------------------------------------------------------------------------
        // ToDecimal
        //--------------------------------------------------------------------------------

        [Fact]
        public void ByteToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(Byte.MinValue, typeof(decimal)));
            Assert.Equal(255m, converter.Convert(Byte.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void ByteToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(Byte.MinValue, typeof(decimal?)));
            Assert.Equal(255m, converter.Convert(Byte.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void SByteToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128m, converter.Convert(SByte.MinValue, typeof(decimal)));
            Assert.Equal(127m, converter.Convert(SByte.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void SByteToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128m, converter.Convert(SByte.MinValue, typeof(decimal?)));
            Assert.Equal(127m, converter.Convert(SByte.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void ShortToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768m, converter.Convert(Int16.MinValue, typeof(decimal)));
            Assert.Equal(32767m, converter.Convert(Int16.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void ShortToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768m, converter.Convert(Int16.MinValue, typeof(decimal?)));
            Assert.Equal(32767m, converter.Convert(Int16.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void UShortToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(UInt16.MinValue, typeof(decimal)));
            Assert.Equal(65535m, converter.Convert(UInt16.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void UShortToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(UInt16.MinValue, typeof(decimal?)));
            Assert.Equal(65535m, converter.Convert(UInt16.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void IntToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648m, converter.Convert(Int32.MinValue, typeof(decimal)));
            Assert.Equal(2147483647m, converter.Convert(Int32.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void IntToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648m, converter.Convert(Int32.MinValue, typeof(decimal?)));
            Assert.Equal(2147483647m, converter.Convert(Int32.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void UIntToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(UInt32.MinValue, typeof(decimal)));
            Assert.Equal(4294967295m, converter.Convert(UInt32.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void UIntToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(UInt32.MinValue, typeof(decimal?)));
            Assert.Equal(4294967295m, converter.Convert(UInt32.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void LongToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-9223372036854775808m, converter.Convert(Int64.MinValue, typeof(decimal)));
            Assert.Equal(9223372036854775807m, converter.Convert(Int64.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void LongToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-9223372036854775808m, converter.Convert(Int64.MinValue, typeof(decimal?)));
            Assert.Equal(9223372036854775807m, converter.Convert(Int64.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void ULongToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(UInt64.MinValue, typeof(decimal)));
            Assert.Equal(18446744073709551615m, converter.Convert(UInt64.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void ULongToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(UInt64.MinValue, typeof(decimal?)));
            Assert.Equal(18446744073709551615m, converter.Convert(UInt64.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void CharToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(Char.MinValue, typeof(decimal)));
            Assert.Equal(65535m, converter.Convert(Char.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void CharToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(Char.MinValue, typeof(decimal?)));
            Assert.Equal(65535m, converter.Convert(Char.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DoubleToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(decimal), converter.Convert(Double.MinValue, typeof(decimal)));
            Assert.Equal(default(decimal), converter.Convert(Double.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(decimal?), converter.Convert(Double.MinValue, typeof(decimal?)));
            Assert.Equal(default(decimal?), converter.Convert(Double.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void FloatToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(decimal), converter.Convert(Single.MinValue, typeof(decimal)));
            Assert.Equal(default(decimal), converter.Convert(Single.MaxValue, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void FloatToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(decimal?), converter.Convert(Single.MinValue, typeof(decimal?)));
            Assert.Equal(default(decimal?), converter.Convert(Single.MaxValue, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void StringToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Decimal.Zero, converter.Convert("0", typeof(decimal)));
            Assert.Equal(Decimal.One, converter.Convert("1", typeof(decimal)));
            Assert.Equal(default(decimal), converter.Convert(string.Empty, typeof(decimal)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }

        [Fact]
        public void StringToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Decimal.Zero, converter.Convert("0", typeof(decimal?)));
            Assert.Equal(Decimal.One, converter.Convert("1", typeof(decimal?)));
            Assert.Null(converter.Convert(string.Empty, typeof(decimal?)));
            Assert.True(converter.UsedOnly<DecimalConverterFactory>());
        }
    }
}
