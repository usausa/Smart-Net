namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class NumericParseConvertTest
    {
        [Fact]
        public void StringToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Byte.MinValue, converter.Convert(Byte.MinValue.ToString(), typeof(byte)));
            Assert.Equal(Byte.MaxValue, converter.Convert(Byte.MaxValue.ToString(), typeof(byte)));
            Assert.Equal(default(byte), converter.Convert(string.Empty, typeof(byte)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Byte.MinValue, converter.Convert(Byte.MinValue.ToString(), typeof(byte?)));
            Assert.Equal(Byte.MaxValue, converter.Convert(Byte.MaxValue.ToString(), typeof(byte?)));
            Assert.Null(converter.Convert(string.Empty, typeof(byte?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(SByte.MinValue, converter.Convert(SByte.MinValue.ToString(), typeof(sbyte)));
            Assert.Equal(SByte.MaxValue, converter.Convert(SByte.MaxValue.ToString(), typeof(sbyte)));
            Assert.Equal(default(sbyte), converter.Convert(string.Empty, typeof(sbyte)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(SByte.MinValue, converter.Convert(SByte.MinValue.ToString(), typeof(sbyte?)));
            Assert.Equal(SByte.MaxValue, converter.Convert(SByte.MaxValue.ToString(), typeof(sbyte?)));
            Assert.Null(converter.Convert(string.Empty, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int16.MinValue, converter.Convert(Int16.MinValue.ToString(), typeof(short)));
            Assert.Equal(Int16.MaxValue, converter.Convert(Int16.MaxValue.ToString(), typeof(short)));
            Assert.Equal(default(short), converter.Convert(string.Empty, typeof(short)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int16.MinValue, converter.Convert(Int16.MinValue.ToString(), typeof(short?)));
            Assert.Equal(Int16.MaxValue, converter.Convert(Int16.MaxValue.ToString(), typeof(short?)));
            Assert.Null(converter.Convert(string.Empty, typeof(short?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt16.MinValue, converter.Convert(UInt16.MinValue.ToString(), typeof(ushort)));
            Assert.Equal(UInt16.MaxValue, converter.Convert(UInt16.MaxValue.ToString(), typeof(ushort)));
            Assert.Equal(default(ushort), converter.Convert(string.Empty, typeof(ushort)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt16.MinValue, converter.Convert(UInt16.MinValue.ToString(), typeof(ushort?)));
            Assert.Equal(UInt16.MaxValue, converter.Convert(UInt16.MaxValue.ToString(), typeof(ushort?)));
            Assert.Null(converter.Convert(string.Empty, typeof(ushort?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int32.MinValue, converter.Convert(Int32.MinValue.ToString(), typeof(int)));
            Assert.Equal(Int32.MaxValue, converter.Convert(Int32.MaxValue.ToString(), typeof(int)));
            Assert.Equal(default(int), converter.Convert(string.Empty, typeof(int)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int32.MinValue, converter.Convert(Int32.MinValue.ToString(), typeof(int?)));
            Assert.Equal(Int32.MaxValue, converter.Convert(Int32.MaxValue.ToString(), typeof(int?)));
            Assert.Null(converter.Convert(string.Empty, typeof(int?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt32.MinValue, converter.Convert(UInt32.MinValue.ToString(), typeof(uint)));
            Assert.Equal(UInt32.MaxValue, converter.Convert(UInt32.MaxValue.ToString(), typeof(uint)));
            Assert.Equal(default(uint), converter.Convert(string.Empty, typeof(uint)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt32.MinValue, converter.Convert(UInt32.MinValue.ToString(), typeof(uint?)));
            Assert.Equal(UInt32.MaxValue, converter.Convert(UInt32.MaxValue.ToString(), typeof(uint?)));
            Assert.Null(converter.Convert(string.Empty, typeof(uint?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int64.MinValue, converter.Convert(Int64.MinValue.ToString(), typeof(long)));
            Assert.Equal(Int64.MaxValue, converter.Convert(Int64.MaxValue.ToString(), typeof(long)));
            Assert.Equal(default(long), converter.Convert(string.Empty, typeof(long)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int64.MinValue, converter.Convert(Int64.MinValue.ToString(), typeof(long?)));
            Assert.Equal(Int64.MaxValue, converter.Convert(Int64.MaxValue.ToString(), typeof(long?)));
            Assert.Null(converter.Convert(string.Empty, typeof(long?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt64.MinValue, converter.Convert(UInt64.MinValue.ToString(), typeof(ulong)));
            Assert.Equal(UInt64.MaxValue, converter.Convert(UInt64.MaxValue.ToString(), typeof(ulong)));
            Assert.Equal(default(ulong), converter.Convert(string.Empty, typeof(ulong)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt64.MinValue, converter.Convert(UInt64.MinValue.ToString(), typeof(ulong?)));
            Assert.Equal(UInt64.MaxValue, converter.Convert(UInt64.MaxValue.ToString(), typeof(ulong?)));
            Assert.Null(converter.Convert(string.Empty, typeof(ulong?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Char.MinValue, converter.Convert(Char.MinValue.ToString(), typeof(char)));
            Assert.Equal(Char.MaxValue, converter.Convert(Char.MaxValue.ToString(), typeof(char)));
            Assert.Equal(default(char), converter.Convert(string.Empty, typeof(char)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Char.MinValue, converter.Convert(Char.MinValue.ToString(), typeof(char?)));
            Assert.Equal(Char.MaxValue, converter.Convert(Char.MaxValue.ToString(), typeof(char?)));
            Assert.Null(converter.Convert(string.Empty, typeof(char?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Double.MinValue, converter.Convert(Double.MinValue.ToString("R"), typeof(double)));
            Assert.Equal(Double.MaxValue, converter.Convert(Double.MaxValue.ToString("R"), typeof(double)));
            Assert.Equal(default(double), converter.Convert(string.Empty, typeof(double)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Double.MinValue, converter.Convert(Double.MinValue.ToString("R"), typeof(double?)));
            Assert.Equal(Double.MaxValue, converter.Convert(Double.MaxValue.ToString("R"), typeof(double?)));
            Assert.Null(converter.Convert(string.Empty, typeof(double?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Single.MinValue, converter.Convert(Single.MinValue.ToString("R"), typeof(float)));
            Assert.Equal(Single.MaxValue, converter.Convert(Single.MaxValue.ToString("R"), typeof(float)));
            Assert.Equal(default(float), converter.Convert(string.Empty, typeof(float)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }

        [Fact]
        public void StringToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Single.MinValue, converter.Convert(Single.MinValue.ToString("R"), typeof(float?)));
            Assert.Equal(Single.MaxValue, converter.Convert(Single.MaxValue.ToString("R"), typeof(float?)));
            Assert.Null(converter.Convert(string.Empty, typeof(float?)));
            Assert.True(converter.UsedOnly<NumericParseConverterFactory>());
        }
    }
}
