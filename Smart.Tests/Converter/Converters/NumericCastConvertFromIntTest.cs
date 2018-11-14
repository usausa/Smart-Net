namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConvertFromIntTest
    {
        [Fact]
        public void IntToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Int32.MinValue, typeof(byte)));
            Assert.Equal((byte)255, converter.Convert(Int32.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Int32.MinValue, typeof(byte?)));
            Assert.Equal((byte)255, converter.Convert(Int32.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Int32.MinValue, typeof(sbyte)));
            Assert.Equal((sbyte)-1, converter.Convert(Int32.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Int32.MinValue, typeof(sbyte?)));
            Assert.Equal((sbyte)-1, converter.Convert(Int32.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Int32.MinValue, typeof(short)));
            Assert.Equal((short)-1, converter.Convert(Int32.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Int32.MinValue, typeof(short?)));
            Assert.Equal((short)-1, converter.Convert(Int32.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Int32.MinValue, typeof(ushort)));
            Assert.Equal((ushort)65535, converter.Convert(Int32.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Int32.MinValue, typeof(ushort?)));
            Assert.Equal((ushort)65535, converter.Convert(Int32.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(2147483648U, converter.Convert(Int32.MinValue, typeof(uint)));
            Assert.Equal(2147483647U, converter.Convert(Int32.MaxValue, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(2147483648U, converter.Convert(Int32.MinValue, typeof(uint?)));
            Assert.Equal(2147483647U, converter.Convert(Int32.MaxValue, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648L, converter.Convert(Int32.MinValue, typeof(long)));
            Assert.Equal(2147483647L, converter.Convert(Int32.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648L, converter.Convert(Int32.MinValue, typeof(long?)));
            Assert.Equal(2147483647L, converter.Convert(Int32.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(18446744071562067968UL, converter.Convert(Int32.MinValue, typeof(ulong)));
            Assert.Equal(2147483647UL, converter.Convert(Int32.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(18446744071562067968UL, converter.Convert(Int32.MinValue, typeof(ulong?)));
            Assert.Equal(2147483647UL, converter.Convert(Int32.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Int32.MinValue, typeof(char)));
            Assert.Equal((char)65535, converter.Convert(Int32.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Int32.MinValue, typeof(char?)));
            Assert.Equal((char)65535, converter.Convert(Int32.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648d, converter.Convert(Int32.MinValue, typeof(double)));
            Assert.Equal(2147483647d, converter.Convert(Int32.MaxValue, typeof(double)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648d, converter.Convert(Int32.MinValue, typeof(double?)));
            Assert.Equal(2147483647d, converter.Convert(Int32.MaxValue, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648f, converter.Convert(Int32.MinValue, typeof(float)));
            Assert.Equal(2147483647f, converter.Convert(Int32.MaxValue, typeof(float)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void IntToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(-2147483648f, converter.Convert(Int32.MinValue, typeof(float?)));
            Assert.Equal(2147483647f, converter.Convert(Int32.MaxValue, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }
    }
}
