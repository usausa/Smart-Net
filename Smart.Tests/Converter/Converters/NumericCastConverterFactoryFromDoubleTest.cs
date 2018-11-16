namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConverterFactoryFromDoubleTest
    {
        [Fact]
        public void DoubleToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Double.MinValue, typeof(byte)));
            Assert.Equal((byte)0, converter.Convert(Double.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Double.MinValue, typeof(byte?)));
            Assert.Equal((byte)0, converter.Convert(Double.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Double.MinValue, typeof(sbyte)));
            Assert.Equal((sbyte)0, converter.Convert(Double.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Double.MinValue, typeof(sbyte?)));
            Assert.Equal((sbyte)0, converter.Convert(Double.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Double.MinValue, typeof(short)));
            Assert.Equal((short)0, converter.Convert(Double.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Double.MinValue, typeof(short?)));
            Assert.Equal((short)0, converter.Convert(Double.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Double.MinValue, typeof(ushort)));
            Assert.Equal((ushort)0, converter.Convert(Double.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Double.MinValue, typeof(ushort?)));
            Assert.Equal((ushort)0, converter.Convert(Double.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648, converter.Convert(Double.MinValue, typeof(int)));
            Assert.Equal(-2147483648, converter.Convert(Double.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648, converter.Convert(Double.MinValue, typeof(int?)));
            Assert.Equal(-2147483648, converter.Convert(Double.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Double.MinValue, typeof(uint)));
            Assert.Equal(0U, converter.Convert(Double.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Double.MinValue, typeof(uint?)));
            Assert.Equal(0U, converter.Convert(Double.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-9223372036854775808L, converter.Convert(Double.MinValue, typeof(long)));
            Assert.Equal(-9223372036854775808L, converter.Convert(Double.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-9223372036854775808L, converter.Convert(Double.MinValue, typeof(long?)));
            Assert.Equal(-9223372036854775808L, converter.Convert(Double.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(9223372036854775808UL, converter.Convert(Double.MinValue, typeof(ulong)));
            Assert.Equal(0UL, converter.Convert(Double.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(9223372036854775808UL, converter.Convert(Double.MinValue, typeof(ulong?)));
            Assert.Equal(0UL, converter.Convert(Double.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Double.MinValue, typeof(char)));
            Assert.Equal((char)0, converter.Convert(Double.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Double.MinValue, typeof(char?)));
            Assert.Equal((char)0, converter.Convert(Double.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Single.NegativeInfinity, converter.Convert(Double.MinValue, typeof(float)));
            Assert.Equal(Single.PositiveInfinity, converter.Convert(Double.MaxValue, typeof(float)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void DoubleToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Single.NegativeInfinity, converter.Convert(Double.MinValue, typeof(float?)));
            Assert.Equal(Single.PositiveInfinity, converter.Convert(Double.MaxValue, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }
    }
}
