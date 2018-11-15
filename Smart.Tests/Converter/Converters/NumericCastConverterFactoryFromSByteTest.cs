namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConverterFactoryFromSByteTest
    {
        //--------------------------------------------------------------------------------
        // SByteTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void SByteToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)128, converter.Convert(SByte.MinValue, typeof(byte)));
            Assert.Equal((byte)127, converter.Convert(SByte.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)128, converter.Convert(SByte.MinValue, typeof(byte?)));
            Assert.Equal((byte)127, converter.Convert(SByte.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)-128, converter.Convert(SByte.MinValue, typeof(short)));
            Assert.Equal((short)127, converter.Convert(SByte.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)-128, converter.Convert(SByte.MinValue, typeof(short?)));
            Assert.Equal((short)127, converter.Convert(SByte.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)65408, converter.Convert(SByte.MinValue, typeof(ushort)));
            Assert.Equal((ushort)127, converter.Convert(SByte.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)65408, converter.Convert(SByte.MinValue, typeof(ushort?)));
            Assert.Equal((ushort)127, converter.Convert(SByte.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128, converter.Convert(SByte.MinValue, typeof(int)));
            Assert.Equal(127, converter.Convert(SByte.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128, converter.Convert(SByte.MinValue, typeof(int?)));
            Assert.Equal(127, converter.Convert(SByte.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(4294967168U, converter.Convert(SByte.MinValue, typeof(uint)));
            Assert.Equal(127U, converter.Convert(SByte.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(4294967168U, converter.Convert(SByte.MinValue, typeof(uint?)));
            Assert.Equal(127U, converter.Convert(SByte.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128L, converter.Convert(SByte.MinValue, typeof(long)));
            Assert.Equal(127L, converter.Convert(SByte.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128L, converter.Convert(SByte.MinValue, typeof(long?)));
            Assert.Equal(127L, converter.Convert(SByte.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(18446744073709551488UL, converter.Convert(SByte.MinValue, typeof(ulong)));
            Assert.Equal(127UL, converter.Convert(SByte.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(18446744073709551488UL, converter.Convert(SByte.MinValue, typeof(ulong?)));
            Assert.Equal(127UL, converter.Convert(SByte.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)65408, converter.Convert(SByte.MinValue, typeof(char)));
            Assert.Equal((char)127, converter.Convert(SByte.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)65408, converter.Convert(SByte.MinValue, typeof(char?)));
            Assert.Equal((char)127, converter.Convert(SByte.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128d, converter.Convert(SByte.MinValue, typeof(double)));
            Assert.Equal(127d, converter.Convert(SByte.MaxValue, typeof(double)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128d, converter.Convert(SByte.MinValue, typeof(double?)));
            Assert.Equal(127d, converter.Convert(SByte.MaxValue, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128f, converter.Convert(SByte.MinValue, typeof(float)));
            Assert.Equal(127f, converter.Convert(SByte.MaxValue, typeof(float)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void SByteToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-128f, converter.Convert(SByte.MinValue, typeof(float?)));
            Assert.Equal(127f, converter.Convert(SByte.MaxValue, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }
    }
}
