namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConverterFactoryFromShortTest
    {
        [Fact]
        public void ShortToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Int16.MinValue, typeof(byte)));
            Assert.Equal((byte)255, converter.Convert(Int16.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Int16.MinValue, typeof(byte?)));
            Assert.Equal((byte)255, converter.Convert(Int16.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Int16.MinValue, typeof(sbyte)));
            Assert.Equal((sbyte)-1, converter.Convert(Int16.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Int16.MinValue, typeof(sbyte?)));
            Assert.Equal((sbyte)-1, converter.Convert(Int16.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)32768, converter.Convert(Int16.MinValue, typeof(ushort)));
            Assert.Equal((ushort)32767, converter.Convert(Int16.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)32768, converter.Convert(Int16.MinValue, typeof(ushort?)));
            Assert.Equal((ushort)32767, converter.Convert(Int16.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768, converter.Convert(Int16.MinValue, typeof(int)));
            Assert.Equal(32767, converter.Convert(Int16.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768, converter.Convert(Int16.MinValue, typeof(int?)));
            Assert.Equal(32767, converter.Convert(Int16.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(4294934528U, converter.Convert(Int16.MinValue, typeof(uint)));
            Assert.Equal(32767U, converter.Convert(Int16.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(4294934528U, converter.Convert(Int16.MinValue, typeof(uint?)));
            Assert.Equal(32767U, converter.Convert(Int16.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768L, converter.Convert(Int16.MinValue, typeof(long)));
            Assert.Equal(32767L, converter.Convert(Int16.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768L, converter.Convert(Int16.MinValue, typeof(long?)));
            Assert.Equal(32767L, converter.Convert(Int16.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(18446744073709518848UL, converter.Convert(Int16.MinValue, typeof(ulong)));
            Assert.Equal(32767UL, converter.Convert(Int16.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(18446744073709518848UL, converter.Convert(Int16.MinValue, typeof(ulong?)));
            Assert.Equal(32767UL, converter.Convert(Int16.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)32768, converter.Convert(Int16.MinValue, typeof(char)));
            Assert.Equal((char)32767, converter.Convert(Int16.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)32768, converter.Convert(Int16.MinValue, typeof(char?)));
            Assert.Equal((char)32767, converter.Convert(Int16.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768d, converter.Convert(Int16.MinValue, typeof(double)));
            Assert.Equal(32767d, converter.Convert(Int16.MaxValue, typeof(double)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768d, converter.Convert(Int16.MinValue, typeof(double?)));
            Assert.Equal(32767d, converter.Convert(Int16.MaxValue, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768f, converter.Convert(Int16.MinValue, typeof(float)));
            Assert.Equal(32767f, converter.Convert(Int16.MaxValue, typeof(float)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void ShortToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-32768f, converter.Convert(Int16.MinValue, typeof(float?)));
            Assert.Equal(32767f, converter.Convert(Int16.MaxValue, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }
    }
}
