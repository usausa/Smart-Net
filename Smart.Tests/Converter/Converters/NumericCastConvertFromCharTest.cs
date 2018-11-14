namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConvertFromCharTest
    {
        [Fact]
        public void CharToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Char.MinValue, typeof(byte)));
            Assert.Equal((byte)255, converter.Convert(Char.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Char.MinValue, typeof(byte?)));
            Assert.Equal((byte)255, converter.Convert(Char.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Char.MinValue, typeof(sbyte)));
            Assert.Equal((sbyte)-1, converter.Convert(Char.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Char.MinValue, typeof(sbyte?)));
            Assert.Equal((sbyte)-1, converter.Convert(Char.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Char.MinValue, typeof(short)));
            Assert.Equal((short)-1, converter.Convert(Char.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Char.MinValue, typeof(short?)));
            Assert.Equal((short)-1, converter.Convert(Char.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Char.MinValue, typeof(ushort)));
            Assert.Equal((ushort)65535, converter.Convert(Char.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Char.MinValue, typeof(ushort?)));
            Assert.Equal((ushort)65535, converter.Convert(Char.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(Char.MinValue, typeof(int)));
            Assert.Equal(65535, converter.Convert(Char.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(Char.MinValue, typeof(int?)));
            Assert.Equal(65535, converter.Convert(Char.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Char.MinValue, typeof(uint)));
            Assert.Equal(65535U, converter.Convert(Char.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Char.MinValue, typeof(uint?)));
            Assert.Equal(65535U, converter.Convert(Char.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(Char.MinValue, typeof(long)));
            Assert.Equal(65535L, converter.Convert(Char.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(Char.MinValue, typeof(long?)));
            Assert.Equal(65535L, converter.Convert(Char.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(Char.MinValue, typeof(ulong)));
            Assert.Equal(65535UL, converter.Convert(Char.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(Char.MinValue, typeof(ulong?)));
            Assert.Equal(65535UL, converter.Convert(Char.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(Char.MinValue, typeof(double)));
            Assert.Equal(65535d, converter.Convert(Char.MaxValue, typeof(double)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(Char.MinValue, typeof(double?)));
            Assert.Equal(65535d, converter.Convert(Char.MaxValue, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(Char.MinValue, typeof(float)));
            Assert.Equal(65535f, converter.Convert(Char.MaxValue, typeof(float)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void CharToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(Char.MinValue, typeof(float?)));
            Assert.Equal(65535f, converter.Convert(Char.MaxValue, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }
    }
}
