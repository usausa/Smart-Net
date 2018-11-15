namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConverterFactoryFromUShortTest
    {
        [Fact]
        public void UShortToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(UInt16.MinValue, typeof(byte)));
            Assert.Equal((byte)255, converter.Convert(UInt16.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(UInt16.MinValue, typeof(byte?)));
            Assert.Equal((byte)255, converter.Convert(UInt16.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(UInt16.MinValue, typeof(sbyte)));
            Assert.Equal((sbyte)-1, converter.Convert(UInt16.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(UInt16.MinValue, typeof(sbyte?)));
            Assert.Equal((sbyte)-1, converter.Convert(UInt16.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(UInt16.MinValue, typeof(short)));
            Assert.Equal((short)-1, converter.Convert(UInt16.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(UInt16.MinValue, typeof(short?)));
            Assert.Equal((short)-1, converter.Convert(UInt16.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(UInt16.MinValue, typeof(int)));
            Assert.Equal(65535, converter.Convert(UInt16.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(UInt16.MinValue, typeof(int?)));
            Assert.Equal(65535, converter.Convert(UInt16.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(UInt16.MinValue, typeof(uint)));
            Assert.Equal(65535U, converter.Convert(UInt16.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(UInt16.MinValue, typeof(uint?)));
            Assert.Equal(65535U, converter.Convert(UInt16.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(UInt16.MinValue, typeof(long)));
            Assert.Equal(65535L, converter.Convert(UInt16.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(UInt16.MinValue, typeof(long?)));
            Assert.Equal(65535L, converter.Convert(UInt16.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(UInt16.MinValue, typeof(ulong)));
            Assert.Equal(65535UL, converter.Convert(UInt16.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(UInt16.MinValue, typeof(ulong?)));
            Assert.Equal(65535UL, converter.Convert(UInt16.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(UInt16.MinValue, typeof(char)));
            Assert.Equal((char)65535, converter.Convert(UInt16.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(UInt16.MinValue, typeof(char?)));
            Assert.Equal((char)65535, converter.Convert(UInt16.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(UInt16.MinValue, typeof(double)));
            Assert.Equal(65535d, converter.Convert(UInt16.MaxValue, typeof(double)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(UInt16.MinValue, typeof(double?)));
            Assert.Equal(65535d, converter.Convert(UInt16.MaxValue, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(UInt16.MinValue, typeof(float)));
            Assert.Equal(65535f, converter.Convert(UInt16.MaxValue, typeof(float)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UShortToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(UInt16.MinValue, typeof(float?)));
            Assert.Equal(65535f, converter.Convert(UInt16.MaxValue, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }
    }
}
