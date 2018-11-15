namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConverterFactoryFromFloatTest
    {
        [Fact]
        public void FloatToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Single.MinValue, typeof(byte)));
            Assert.Equal((byte)0, converter.Convert(Single.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Single.MinValue, typeof(byte?)));
            Assert.Equal((byte)0, converter.Convert(Single.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Single.MinValue, typeof(sbyte)));
            Assert.Equal((sbyte)0, converter.Convert(Single.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Single.MinValue, typeof(sbyte?)));
            Assert.Equal((sbyte)0, converter.Convert(Single.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Single.MinValue, typeof(short)));
            Assert.Equal((short)0, converter.Convert(Single.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Single.MinValue, typeof(short?)));
            Assert.Equal((short)0, converter.Convert(Single.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Single.MinValue, typeof(ushort)));
            Assert.Equal((ushort)0, converter.Convert(Single.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Single.MinValue, typeof(ushort?)));
            Assert.Equal((ushort)0, converter.Convert(Single.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648, converter.Convert(Single.MinValue, typeof(int)));
            Assert.Equal(-2147483648, converter.Convert(Single.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648, converter.Convert(Single.MinValue, typeof(int?)));
            Assert.Equal(-2147483648, converter.Convert(Single.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Single.MinValue, typeof(uint)));
            Assert.Equal(0U, converter.Convert(Single.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Single.MinValue, typeof(uint?)));
            Assert.Equal(0U, converter.Convert(Single.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-9223372036854775808L, converter.Convert(Single.MinValue, typeof(long)));
            Assert.Equal(-9223372036854775808L, converter.Convert(Single.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-9223372036854775808L, converter.Convert(Single.MinValue, typeof(long?)));
            Assert.Equal(-9223372036854775808L, converter.Convert(Single.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(9223372036854775808UL, converter.Convert(Single.MinValue, typeof(ulong)));
            Assert.Equal(0UL, converter.Convert(Single.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(9223372036854775808UL, converter.Convert(Single.MinValue, typeof(ulong?)));
            Assert.Equal(0UL, converter.Convert(Single.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Single.MinValue, typeof(char)));
            Assert.Equal((char)0, converter.Convert(Single.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Single.MinValue, typeof(char?)));
            Assert.Equal((char)0, converter.Convert(Single.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((double)Single.MinValue, converter.Convert(Single.MinValue, typeof(double)));
            Assert.Equal((double)Single.MaxValue, converter.Convert(Single.MaxValue, typeof(double)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void FloatToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((double)Single.MinValue, converter.Convert(Single.MinValue, typeof(double?)));
            Assert.Equal((double)Single.MaxValue, converter.Convert(Single.MaxValue, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }
    }
}
