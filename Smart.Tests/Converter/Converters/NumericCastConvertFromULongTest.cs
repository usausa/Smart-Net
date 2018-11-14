namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConvertFromULongTest
    {
        [Fact]
        public void ULongToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(UInt64.MinValue, typeof(byte)));
            Assert.Equal((byte)255, converter.Convert(UInt64.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(UInt64.MinValue, typeof(byte?)));
            Assert.Equal((byte)255, converter.Convert(UInt64.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(UInt64.MinValue, typeof(sbyte)));
            Assert.Equal((sbyte)-1, converter.Convert(UInt64.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(UInt64.MinValue, typeof(sbyte?)));
            Assert.Equal((sbyte)-1, converter.Convert(UInt64.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(UInt64.MinValue, typeof(short)));
            Assert.Equal((short)-1, converter.Convert(UInt64.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(UInt64.MinValue, typeof(short?)));
            Assert.Equal((short)-1, converter.Convert(UInt64.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(UInt64.MinValue, typeof(ushort)));
            Assert.Equal((ushort)65535, converter.Convert(UInt64.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(UInt64.MinValue, typeof(ushort?)));
            Assert.Equal((ushort)65535, converter.Convert(UInt64.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(UInt64.MinValue, typeof(int)));
            Assert.Equal(-1, converter.Convert(UInt64.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(UInt64.MinValue, typeof(int?)));
            Assert.Equal(-1, converter.Convert(UInt64.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(UInt64.MinValue, typeof(uint)));
            Assert.Equal(4294967295U, converter.Convert(UInt64.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0U, converter.Convert(UInt64.MinValue, typeof(uint?)));
            Assert.Equal(4294967295U, converter.Convert(UInt64.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(UInt64.MinValue, typeof(long)));
            Assert.Equal(-1L, converter.Convert(UInt64.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(UInt64.MinValue, typeof(long?)));
            Assert.Equal(-1L, converter.Convert(UInt64.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(UInt64.MinValue, typeof(char)));
            Assert.Equal((char)65535, converter.Convert(UInt64.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(UInt64.MinValue, typeof(char?)));
            Assert.Equal((char)65535, converter.Convert(UInt64.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(UInt64.MinValue, typeof(double)));
            Assert.Equal(18446744073709551615d, converter.Convert(UInt64.MaxValue, typeof(double)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(UInt64.MinValue, typeof(double?)));
            Assert.Equal(18446744073709551615d, converter.Convert(UInt64.MaxValue, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(UInt64.MinValue, typeof(float)));
            Assert.Equal(18446744073709551615f, converter.Convert(UInt64.MaxValue, typeof(float)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ULongToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(UInt64.MinValue, typeof(float?)));
            Assert.Equal(18446744073709551615f, converter.Convert(UInt64.MaxValue, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }
    }
}
