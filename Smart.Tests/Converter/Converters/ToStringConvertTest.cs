namespace Smart.Converter.Converters
{
    using System;

    using Smart.Converter.Types;

    using Xunit;

    public class ToStringConvertTest
    {
        [Fact]
        public void ByteToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("0", converter.Convert(Byte.MinValue, typeof(string)));
            Assert.Equal("255", converter.Convert(Byte.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void SByteToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("-128", converter.Convert(SByte.MinValue, typeof(string)));
            Assert.Equal("127", converter.Convert(SByte.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void ShortToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("-32768", converter.Convert(Int16.MinValue, typeof(string)));
            Assert.Equal("32767", converter.Convert(Int16.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void UShortToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("0", converter.Convert(UInt16.MinValue, typeof(string)));
            Assert.Equal("65535", converter.Convert(UInt16.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void IntToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("-2147483648", converter.Convert(Int32.MinValue, typeof(string)));
            Assert.Equal("2147483647", converter.Convert(Int32.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void UIntToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("0", converter.Convert(UInt32.MinValue, typeof(string)));
            Assert.Equal("4294967295", converter.Convert(UInt32.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void LongToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("-9223372036854775808", converter.Convert(Int64.MinValue, typeof(string)));
            Assert.Equal("9223372036854775807", converter.Convert(Int64.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void ULongToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("0", converter.Convert(UInt64.MinValue, typeof(string)));
            Assert.Equal("18446744073709551615", converter.Convert(UInt64.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void CharToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("1", converter.Convert('1', typeof(string)));
            Assert.Equal("A", converter.Convert('A', typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void DoubleToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("-1.79769313486232E+308", converter.Convert(Double.MinValue, typeof(string)));
            Assert.Equal("1.79769313486232E+308", converter.Convert(Double.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void FloatToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("-3.402823E+38", converter.Convert(Single.MinValue, typeof(string)));
            Assert.Equal("3.402823E+38", converter.Convert(Single.MaxValue, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }

        [Fact]
        public void StructToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("(1,2)", converter.Convert(new TestStruct { X = 1, Y = 2 }, typeof(string)));
            Assert.True(converter.UsedOnly<ToStringConverterFactory>());
        }
    }
}
