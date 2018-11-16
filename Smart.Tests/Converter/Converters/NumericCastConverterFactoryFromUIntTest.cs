namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericCastConverterFactoryFromUIntTest
    {
        [Fact]
        public void UIntToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(UInt32.MinValue, typeof(byte)));
            Assert.Equal((byte)255, converter.Convert(UInt32.MaxValue, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(UInt32.MinValue, typeof(byte?)));
            Assert.Equal((byte)255, converter.Convert(UInt32.MaxValue, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(UInt32.MinValue, typeof(sbyte)));
            Assert.Equal((sbyte)-1, converter.Convert(UInt32.MaxValue, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(UInt32.MinValue, typeof(sbyte?)));
            Assert.Equal((sbyte)-1, converter.Convert(UInt32.MaxValue, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(UInt32.MinValue, typeof(short)));
            Assert.Equal((short)-1, converter.Convert(UInt32.MaxValue, typeof(short)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(UInt32.MinValue, typeof(short?)));
            Assert.Equal((short)-1, converter.Convert(UInt32.MaxValue, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(UInt32.MinValue, typeof(ushort)));
            Assert.Equal((ushort)65535, converter.Convert(UInt32.MaxValue, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(UInt32.MinValue, typeof(ushort?)));
            Assert.Equal((ushort)65535, converter.Convert(UInt32.MaxValue, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(UInt32.MinValue, typeof(int)));
            Assert.Equal(-1, converter.Convert(UInt32.MaxValue, typeof(int)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(UInt32.MinValue, typeof(int?)));
            Assert.Equal(-1, converter.Convert(UInt32.MaxValue, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(UInt32.MinValue, typeof(long)));
            Assert.Equal(4294967295L, converter.Convert(UInt32.MaxValue, typeof(long)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(UInt32.MinValue, typeof(long?)));
            Assert.Equal(4294967295L, converter.Convert(UInt32.MaxValue, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(UInt32.MinValue, typeof(ulong)));
            Assert.Equal(4294967295UL, converter.Convert(UInt32.MaxValue, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(UInt32.MinValue, typeof(ulong?)));
            Assert.Equal(4294967295UL, converter.Convert(UInt32.MaxValue, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(UInt32.MinValue, typeof(char)));
            Assert.Equal((char)65535, converter.Convert(UInt32.MaxValue, typeof(char)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(UInt32.MinValue, typeof(char?)));
            Assert.Equal((char)65535, converter.Convert(UInt32.MaxValue, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(UInt32.MinValue, typeof(double)));
            Assert.Equal(4294967295d, converter.Convert(UInt32.MaxValue, typeof(double)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0d, converter.Convert(UInt32.MinValue, typeof(double?)));
            Assert.Equal(4294967295d, converter.Convert(UInt32.MaxValue, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(UInt32.MinValue, typeof(float)));
            Assert.Equal(4294967295f, converter.Convert(UInt32.MaxValue, typeof(float)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }

        [Fact]
        public void UIntToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0f, converter.Convert(UInt32.MinValue, typeof(float?)));
            Assert.Equal(4294967295f, converter.Convert(UInt32.MaxValue, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericCastConverterFactory>());
        }
    }
}
