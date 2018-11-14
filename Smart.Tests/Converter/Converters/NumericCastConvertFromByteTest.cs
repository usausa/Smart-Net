namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConvertFromByteTest
    {
        [Fact]
        public void ByteToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Byte.MinValue, typeof(sbyte)));
            Assert.Equal((sbyte)-1, converter.Convert(Byte.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Byte.MinValue, typeof(sbyte?)));
            Assert.Equal((sbyte)-1, converter.Convert(Byte.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Byte.MinValue, typeof(short)));
            Assert.Equal((short)255, converter.Convert(Byte.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Byte.MinValue, typeof(short?)));
            Assert.Equal((short)255, converter.Convert(Byte.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Byte.MinValue, typeof(ushort)));
            Assert.Equal((ushort)255, converter.Convert(Byte.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Byte.MinValue, typeof(ushort?)));
            Assert.Equal((ushort)255, converter.Convert(Byte.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(Byte.MinValue, typeof(int)));
            Assert.Equal(255, converter.Convert(Byte.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(Byte.MinValue, typeof(int?)));
            Assert.Equal(255, converter.Convert(Byte.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Byte.MinValue, typeof(uint)));
            Assert.Equal(255U, converter.Convert(Byte.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(Byte.MinValue, typeof(uint?)));
            Assert.Equal(255U, converter.Convert(Byte.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(Byte.MinValue, typeof(long)));
            Assert.Equal(255L, converter.Convert(Byte.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(Byte.MinValue, typeof(long?)));
            Assert.Equal(255L, converter.Convert(Byte.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(Byte.MinValue, typeof(ulong)));
            Assert.Equal(255UL, converter.Convert(Byte.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(Byte.MinValue, typeof(ulong?)));
            Assert.Equal(255UL, converter.Convert(Byte.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Byte.MinValue, typeof(char)));
            Assert.Equal((char)255, converter.Convert(Byte.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Byte.MinValue, typeof(char?)));
            Assert.Equal((char)255, converter.Convert(Byte.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(Byte.MinValue, typeof(double)));
            Assert.Equal(255d, converter.Convert(Byte.MaxValue, typeof(double)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(Byte.MinValue, typeof(double?)));
            Assert.Equal(255d, converter.Convert(Byte.MaxValue, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(Byte.MinValue, typeof(float)));
            Assert.Equal(255f, converter.Convert(Byte.MaxValue, typeof(float)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ByteToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(Byte.MinValue, typeof(float?)));
            Assert.Equal(255f, converter.Convert(Byte.MaxValue, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        //[Fact]
        //public void ByteToDecimal()
        //{
        //    var converter = new TestObjectConverter();
        //    Assert.Equal(0m, converter.Convert(Byte.MinValue, typeof(decimal)));
        //    Assert.Equal(255m, converter.Convert(Byte.MaxValue, typeof(decimal)));
        //    Assert.True(converter.UsedOnly<NumericConverterFactory>());
        //}

        //[Fact]
        //public void ByteToNullableDecimal()
        //{
        //    var converter = new TestObjectConverter();
        //    Assert.Equal(0m, converter.Convert(Byte.MinValue, typeof(decimal?)));
        //    Assert.Equal(255m, converter.Convert(Byte.MaxValue, typeof(decimal?)));
        //    Assert.True(converter.UsedOnly<NumericConverterFactory>());
        //}
    }
}
