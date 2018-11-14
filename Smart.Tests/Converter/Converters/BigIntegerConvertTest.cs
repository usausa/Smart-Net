namespace Smart.Converter.Converters
{
    using System;
    using System.Numerics;

    using Xunit;

    public class BigIntegerConvertTest
    {
        private static readonly BigInteger Overflow = BigInteger.Add(new BigInteger(Decimal.MaxValue), 1);

        //--------------------------------------------------------------------------------
        // BigIntegerTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void BigIntegerToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(BigInteger.Zero, typeof(byte)));
            Assert.Equal((byte)1, converter.Convert(BigInteger.One, typeof(byte)));
            Assert.Equal(default(byte), converter.Convert(Overflow, typeof(byte)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(BigInteger.Zero, typeof(byte?)));
            Assert.Equal((byte)1, converter.Convert(BigInteger.One, typeof(byte?)));
            Assert.Equal(default(byte?), converter.Convert(Overflow, typeof(byte?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(BigInteger.Zero, typeof(sbyte)));
            Assert.Equal((sbyte)1, converter.Convert(BigInteger.One, typeof(sbyte)));
            Assert.Equal(default(sbyte), converter.Convert(Overflow, typeof(sbyte)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(BigInteger.Zero, typeof(sbyte?)));
            Assert.Equal((sbyte)1, converter.Convert(BigInteger.One, typeof(sbyte?)));
            Assert.Equal(default(sbyte?), converter.Convert(Overflow, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(BigInteger.Zero, typeof(short)));
            Assert.Equal((short)1, converter.Convert(BigInteger.One, typeof(short)));
            Assert.Equal(default(short), converter.Convert(Overflow, typeof(short)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(BigInteger.Zero, typeof(short?)));
            Assert.Equal((short)1, converter.Convert(BigInteger.One, typeof(short?)));
            Assert.Equal(default(short?), converter.Convert(Overflow, typeof(short?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(BigInteger.Zero, typeof(ushort)));
            Assert.Equal((ushort)1, converter.Convert(BigInteger.One, typeof(ushort)));
            Assert.Equal(default(ushort), converter.Convert(Overflow, typeof(ushort)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(BigInteger.Zero, typeof(ushort?)));
            Assert.Equal((ushort)1, converter.Convert(BigInteger.One, typeof(ushort?)));
            Assert.Equal(default(ushort?), converter.Convert(Overflow, typeof(ushort?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(BigInteger.Zero, typeof(int)));
            Assert.Equal(1, converter.Convert(BigInteger.One, typeof(int)));
            Assert.Equal(default(int), converter.Convert(Overflow, typeof(int)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(BigInteger.Zero, typeof(int?)));
            Assert.Equal(1, converter.Convert(BigInteger.One, typeof(int?)));
            Assert.Equal(default(int?), converter.Convert(Overflow, typeof(int?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(BigInteger.Zero, typeof(uint)));
            Assert.Equal(1U, converter.Convert(BigInteger.One, typeof(uint)));
            Assert.Equal(default(uint), converter.Convert(Overflow, typeof(uint)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(BigInteger.Zero, typeof(uint?)));
            Assert.Equal(1U, converter.Convert(BigInteger.One, typeof(uint?)));
            Assert.Equal(default(uint?), converter.Convert(Overflow, typeof(uint?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(BigInteger.Zero, typeof(long)));
            Assert.Equal(1L, converter.Convert(BigInteger.One, typeof(long)));
            Assert.Equal(default(long), converter.Convert(Overflow, typeof(long)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(BigInteger.Zero, typeof(long?)));
            Assert.Equal(1L, converter.Convert(BigInteger.One, typeof(long?)));
            Assert.Equal(default(long?), converter.Convert(Overflow, typeof(long?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(BigInteger.Zero, typeof(ulong)));
            Assert.Equal(1UL, converter.Convert(BigInteger.One, typeof(ulong)));
            Assert.Equal(default(ulong), converter.Convert(Overflow, typeof(ulong)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(BigInteger.Zero, typeof(ulong?)));
            Assert.Equal(1UL, converter.Convert(BigInteger.One, typeof(ulong?)));
            Assert.Equal(default(ulong?), converter.Convert(Overflow, typeof(ulong?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(BigInteger.Zero, typeof(char)));
            Assert.Equal((char)1, converter.Convert(BigInteger.One, typeof(char)));
            Assert.Equal(default(char), converter.Convert(Overflow, typeof(char)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(BigInteger.Zero, typeof(char?)));
            Assert.Equal((char)1, converter.Convert(BigInteger.One, typeof(char?)));
            Assert.Equal(default(char?), converter.Convert(Overflow, typeof(char?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(BigInteger.Zero, typeof(double)));
            Assert.Equal(1d, converter.Convert(BigInteger.One, typeof(double)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(BigInteger.Zero, typeof(double?)));
            Assert.Equal(1d, converter.Convert(BigInteger.One, typeof(double?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(BigInteger.Zero, typeof(float)));
            Assert.Equal(1f, converter.Convert(BigInteger.One, typeof(float)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(BigInteger.Zero, typeof(float?)));
            Assert.Equal(1f, converter.Convert(BigInteger.One, typeof(float?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(BigInteger.Zero, typeof(decimal)));
            Assert.Equal(1m, converter.Convert(BigInteger.One, typeof(decimal)));
            Assert.Equal(default(decimal), converter.Convert(Overflow, typeof(decimal)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(BigInteger.Zero, typeof(decimal?)));
            Assert.Equal(1m, converter.Convert(BigInteger.One, typeof(decimal?)));
            Assert.Equal(default(decimal?), converter.Convert(Overflow, typeof(decimal?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void BigIntegerToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("0", converter.Convert(BigInteger.Zero, typeof(string)));
            Assert.Equal("79228162514264337593543950336", converter.Convert(Overflow, typeof(string)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        //--------------------------------------------------------------------------------
        // ToBigInteger
        //--------------------------------------------------------------------------------

        [Fact]
        public void ByteToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(Byte.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(255), converter.Convert(Byte.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void ByteToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(Byte.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(255), converter.Convert(Byte.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void SByteToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-128), converter.Convert(SByte.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(127), converter.Convert(SByte.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void SByteToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-128), converter.Convert(SByte.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(127), converter.Convert(SByte.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void ShortToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-32768), converter.Convert(Int16.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(32767), converter.Convert(Int16.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void ShortToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-32768), converter.Convert(Int16.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(32767), converter.Convert(Int16.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void UShortToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(UInt16.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(65535), converter.Convert(UInt16.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void UShortToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(UInt16.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(65535), converter.Convert(UInt16.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void IntToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-2147483648), converter.Convert(Int32.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(2147483647), converter.Convert(Int32.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void IntToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-2147483648), converter.Convert(Int32.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(2147483647), converter.Convert(Int32.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void UIntToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(UInt32.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(4294967295), converter.Convert(UInt32.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void UIntToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(UInt32.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(4294967295), converter.Convert(UInt32.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void LongToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-9223372036854775808), converter.Convert(Int64.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(9223372036854775807), converter.Convert(Int64.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void LongToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-9223372036854775808), converter.Convert(Int64.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(9223372036854775807), converter.Convert(Int64.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void ULongToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(UInt64.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(18446744073709551615), converter.Convert(UInt64.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void ULongToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(UInt64.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(18446744073709551615), converter.Convert(UInt64.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void CharToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(Char.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(65535), converter.Convert(Char.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void CharToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(0), converter.Convert(Char.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(65535), converter.Convert(Char.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void DoubleToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(Double.MinValue), converter.Convert(Double.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(Double.MaxValue), converter.Convert(Double.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(Double.MinValue), converter.Convert(Double.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(Double.MaxValue), converter.Convert(Double.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void FloatToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(Single.MinValue), converter.Convert(Single.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(Single.MaxValue), converter.Convert(Single.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void FloatToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(Single.MinValue), converter.Convert(Single.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(Single.MaxValue), converter.Convert(Single.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void DecimalToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-79228162514264337593543950335m), converter.Convert(Decimal.MinValue, typeof(BigInteger)));
            Assert.Equal(new BigInteger(79228162514264337593543950335m), converter.Convert(Decimal.MaxValue, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new BigInteger(-79228162514264337593543950335m), converter.Convert(Decimal.MinValue, typeof(BigInteger?)));
            Assert.Equal(new BigInteger(79228162514264337593543950335m), converter.Convert(Decimal.MaxValue, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void StringToBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(BigInteger.Zero, converter.Convert("0", typeof(BigInteger)));
            Assert.Equal(BigInteger.One, converter.Convert("1", typeof(BigInteger)));
            Assert.Equal(default(BigInteger), converter.Convert(string.Empty, typeof(BigInteger)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }

        [Fact]
        public void StringToNullableBigInteger()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(BigInteger.Zero, converter.Convert("0", typeof(BigInteger?)));
            Assert.Equal(BigInteger.One, converter.Convert("1", typeof(BigInteger?)));
            Assert.Null(converter.Convert(string.Empty, typeof(BigInteger?)));
            Assert.True(converter.UsedOnly<BigIntegerConverterFactory>());
        }
    }
}
