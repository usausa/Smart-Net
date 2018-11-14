namespace Smart.Converter.Converters
{
    using Xunit;

    public class BooleanConvertTest
    {
        //--------------------------------------------------------------------------------
        // BooleanTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void BooleanToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(false, typeof(byte)));
            Assert.Equal((byte)1, converter.Convert(true, typeof(byte)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(false, typeof(byte?)));
            Assert.Equal((byte)1, converter.Convert(true, typeof(byte?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(false, typeof(sbyte)));
            Assert.Equal((sbyte)1, converter.Convert(true, typeof(sbyte)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(false, typeof(sbyte?)));
            Assert.Equal((sbyte)1, converter.Convert(true, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(false, typeof(short)));
            Assert.Equal((short)1, converter.Convert(true, typeof(short)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(false, typeof(short?)));
            Assert.Equal((short)1, converter.Convert(true, typeof(short?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(false, typeof(ushort)));
            Assert.Equal((ushort)1, converter.Convert(true, typeof(ushort)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(false, typeof(ushort?)));
            Assert.Equal((ushort)1, converter.Convert(true, typeof(ushort?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(false, typeof(int)));
            Assert.Equal(1, converter.Convert(true, typeof(int)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(false, typeof(int?)));
            Assert.Equal(1, converter.Convert(true, typeof(int?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(false, typeof(uint)));
            Assert.Equal(1U, converter.Convert(true, typeof(uint)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(false, typeof(uint?)));
            Assert.Equal(1U, converter.Convert(true, typeof(uint?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(false, typeof(long)));
            Assert.Equal(1L, converter.Convert(true, typeof(long)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(false, typeof(long?)));
            Assert.Equal(1L, converter.Convert(true, typeof(long?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(false, typeof(ulong)));
            Assert.Equal(1UL, converter.Convert(true, typeof(ulong)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(false, typeof(ulong?)));
            Assert.Equal(1UL, converter.Convert(true, typeof(ulong?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(false, typeof(char)));
            Assert.Equal((char)1, converter.Convert(true, typeof(char)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(false, typeof(char?)));
            Assert.Equal((char)1, converter.Convert(true, typeof(char?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(false, typeof(double)));
            Assert.Equal(1d, converter.Convert(true, typeof(double)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(false, typeof(double?)));
            Assert.Equal(1d, converter.Convert(true, typeof(double?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(false, typeof(float)));
            Assert.Equal(1f, converter.Convert(true, typeof(float)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(false, typeof(float?)));
            Assert.Equal(1f, converter.Convert(true, typeof(float?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(false, typeof(decimal)));
            Assert.Equal(1m, converter.Convert(true, typeof(decimal)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BooleanToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0m, converter.Convert(false, typeof(decimal?)));
            Assert.Equal(1m, converter.Convert(true, typeof(decimal?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void BoolToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("False", converter.Convert(false, typeof(string)));
            Assert.Equal("True", converter.Convert(true, typeof(string)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        //--------------------------------------------------------------------------------
        // ToBoolean
        //--------------------------------------------------------------------------------

        [Fact]
        public void ByteToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((byte)0, typeof(bool)));
            Assert.True((bool)converter.Convert((byte)1, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void ByteToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((byte)0, typeof(bool?)));
            Assert.True((bool)converter.Convert((byte)1, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void SByteToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((sbyte)0, typeof(bool)));
            Assert.True((bool)converter.Convert((sbyte)1, typeof(bool)));
            Assert.True((bool)converter.Convert((sbyte)-1, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void SByteToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((sbyte)0, typeof(bool?)));
            Assert.True((bool)converter.Convert((sbyte)1, typeof(bool?)));
            Assert.True((bool)converter.Convert((sbyte)-1, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void ShortToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((short)0, typeof(bool)));
            Assert.True((bool)converter.Convert((short)1, typeof(bool)));
            Assert.True((bool)converter.Convert((short)-1, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void ShortToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((short)0, typeof(bool?)));
            Assert.True((bool)converter.Convert((short)1, typeof(bool?)));
            Assert.True((bool)converter.Convert((short)-1, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void UShortToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((ushort)0, typeof(bool)));
            Assert.True((bool)converter.Convert((ushort)1, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void UShortToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((ushort)0, typeof(bool?)));
            Assert.True((bool)converter.Convert((ushort)1, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void IntToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0, typeof(bool)));
            Assert.True((bool)converter.Convert(1, typeof(bool)));
            Assert.True((bool)converter.Convert(-1, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void IntToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0, typeof(bool?)));
            Assert.True((bool)converter.Convert(1, typeof(bool?)));
            Assert.True((bool)converter.Convert(-1, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void UIntToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0U, typeof(bool)));
            Assert.True((bool)converter.Convert(1U, typeof(bool)));
            Assert.True((bool)converter.Convert(-1U, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void UIntToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0U, typeof(bool?)));
            Assert.True((bool)converter.Convert(1U, typeof(bool?)));
            Assert.True((bool)converter.Convert(-1U, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void LongToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0L, typeof(bool)));
            Assert.True((bool)converter.Convert(1L, typeof(bool)));
            Assert.True((bool)converter.Convert(-1L, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void LongToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0L, typeof(bool?)));
            Assert.True((bool)converter.Convert(1L, typeof(bool?)));
            Assert.True((bool)converter.Convert(-1L, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void ULongToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0UL, typeof(bool)));
            Assert.True((bool)converter.Convert(1UL, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void ULongToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0UL, typeof(bool?)));
            Assert.True((bool)converter.Convert(1UL, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void CharToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((char)0, typeof(bool)));
            Assert.True((bool)converter.Convert((char)1, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void CharToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert((char)0, typeof(bool?)));
            Assert.True((bool)converter.Convert((char)1, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void DoubleToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0d, typeof(bool)));
            Assert.True((bool)converter.Convert(1d, typeof(bool)));
            Assert.True((bool)converter.Convert(-1d, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0d, typeof(bool?)));
            Assert.True((bool)converter.Convert(1d, typeof(bool?)));
            Assert.True((bool)converter.Convert(-1d, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void FloatToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0f, typeof(bool)));
            Assert.True((bool)converter.Convert(1f, typeof(bool)));
            Assert.True((bool)converter.Convert(-1f, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void FloatToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0f, typeof(bool?)));
            Assert.True((bool)converter.Convert(1f, typeof(bool?)));
            Assert.True((bool)converter.Convert(-1f, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void DecimalToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0m, typeof(bool)));
            Assert.True((bool)converter.Convert(1m, typeof(bool)));
            Assert.True((bool)converter.Convert(-1m, typeof(bool)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void DecimalToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(0m, typeof(bool?)));
            Assert.True((bool)converter.Convert(1m, typeof(bool?)));
            Assert.True((bool)converter.Convert(-1m, typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }

        [Fact]
        public void StringToBool()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert("False", typeof(bool?)));
            Assert.True((bool)converter.Convert("True", typeof(bool?)));
            Assert.True(converter.UsedOnly<BooleanConverterFactory>());
        }
    }
}
