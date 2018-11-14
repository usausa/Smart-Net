namespace Smart.Converter
{
    using System;

    using Smart.Converter.Types;

    using Xunit;

    public class SameConvertTest
    {
        [Fact]
        public void BooleanToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.True((bool)converter.Convert(true, typeof(bool)));
            Assert.False((bool)converter.Convert(false, typeof(bool)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void BooleanToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.True((bool)converter.Convert(true, typeof(bool?)));
            Assert.False((bool)converter.Convert(false, typeof(bool?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void ByteToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Byte.MinValue, converter.Convert(Byte.MinValue, typeof(byte)));
            Assert.Equal(Byte.MaxValue, converter.Convert(Byte.MaxValue, typeof(byte)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void ByteToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Byte.MinValue, converter.Convert(Byte.MinValue, typeof(byte?)));
            Assert.Equal(Byte.MaxValue, converter.Convert(Byte.MaxValue, typeof(byte?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void SByteToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(SByte.MinValue, converter.Convert(SByte.MinValue, typeof(sbyte)));
            Assert.Equal(SByte.MaxValue, converter.Convert(SByte.MaxValue, typeof(sbyte)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void SByteToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(SByte.MinValue, converter.Convert(SByte.MinValue, typeof(sbyte?)));
            Assert.Equal(SByte.MaxValue, converter.Convert(SByte.MaxValue, typeof(sbyte?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void ShortToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int16.MinValue, converter.Convert(Int16.MinValue, typeof(short)));
            Assert.Equal(Int16.MaxValue, converter.Convert(Int16.MaxValue, typeof(short)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void ShortToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int16.MinValue, converter.Convert(Int16.MinValue, typeof(short?)));
            Assert.Equal(Int16.MaxValue, converter.Convert(Int16.MaxValue, typeof(short?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void UShortToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt16.MinValue, converter.Convert(UInt16.MinValue, typeof(ushort)));
            Assert.Equal(UInt16.MaxValue, converter.Convert(UInt16.MaxValue, typeof(ushort)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void UShortToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt16.MinValue, converter.Convert(UInt16.MinValue, typeof(ushort?)));
            Assert.Equal(UInt16.MaxValue, converter.Convert(UInt16.MaxValue, typeof(ushort?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void IntToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int32.MinValue, converter.Convert(Int32.MinValue, typeof(int)));
            Assert.Equal(Int32.MaxValue, converter.Convert(Int32.MaxValue, typeof(int)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void IntToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int32.MinValue, converter.Convert(Int32.MinValue, typeof(int?)));
            Assert.Equal(Int32.MaxValue, converter.Convert(Int32.MaxValue, typeof(int?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void UIntToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt32.MinValue, converter.Convert(UInt32.MinValue, typeof(uint)));
            Assert.Equal(UInt32.MaxValue, converter.Convert(UInt32.MaxValue, typeof(uint)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void UIntToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt32.MinValue, converter.Convert(UInt32.MinValue, typeof(uint?)));
            Assert.Equal(UInt32.MaxValue, converter.Convert(UInt32.MaxValue, typeof(uint?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void LongToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int64.MinValue, converter.Convert(Int64.MinValue, typeof(long)));
            Assert.Equal(Int64.MaxValue, converter.Convert(Int64.MaxValue, typeof(long)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void LongToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Int64.MinValue, converter.Convert(Int64.MinValue, typeof(long?)));
            Assert.Equal(Int64.MaxValue, converter.Convert(Int64.MaxValue, typeof(long?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void ULongToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt64.MinValue, converter.Convert(UInt64.MinValue, typeof(ulong)));
            Assert.Equal(UInt64.MaxValue, converter.Convert(UInt64.MaxValue, typeof(ulong)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void ULongToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(UInt64.MinValue, converter.Convert(UInt64.MinValue, typeof(ulong?)));
            Assert.Equal(UInt64.MaxValue, converter.Convert(UInt64.MaxValue, typeof(ulong?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void CharToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Char.MinValue, converter.Convert(Char.MinValue, typeof(char)));
            Assert.Equal(Char.MaxValue, converter.Convert(Char.MaxValue, typeof(char)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void CharToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Char.MinValue, converter.Convert(Char.MinValue, typeof(char?)));
            Assert.Equal(Char.MaxValue, converter.Convert(Char.MaxValue, typeof(char?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void DoubleToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Double.MinValue, converter.Convert(Double.MinValue, typeof(double)));
            Assert.Equal(Double.MaxValue, converter.Convert(Double.MaxValue, typeof(double)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void DoubleToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Double.MinValue, converter.Convert(Double.MinValue, typeof(double?)));
            Assert.Equal(Double.MaxValue, converter.Convert(Double.MaxValue, typeof(double?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void FloatToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Single.MinValue, converter.Convert(Single.MinValue, typeof(float)));
            Assert.Equal(Single.MaxValue, converter.Convert(Single.MaxValue, typeof(float)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void FloatToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Single.MinValue, converter.Convert(Single.MinValue, typeof(float?)));
            Assert.Equal(Single.MaxValue, converter.Convert(Single.MaxValue, typeof(float?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void DecimalToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Decimal.MinValue, converter.Convert(Decimal.MinValue, typeof(decimal)));
            Assert.Equal(Decimal.MaxValue, converter.Convert(Decimal.MaxValue, typeof(decimal)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void DecimalToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Decimal.MinValue, converter.Convert(Decimal.MinValue, typeof(decimal?)));
            Assert.Equal(Decimal.MaxValue, converter.Convert(Decimal.MaxValue, typeof(decimal?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void StringToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(string.Empty, converter.Convert(string.Empty, typeof(string)));
            Assert.Equal("abc", converter.Convert("abc", typeof(string)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void DateTimeToDateTime()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new DateTime(2000, 1, 1), converter.Convert(new DateTime(2000, 1, 1), typeof(DateTime)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void DateTimeToNullableDateTime()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new DateTime(2000, 1, 1), converter.Convert(new DateTime(2000, 1, 1), typeof(DateTime?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void DateTimeOffsetToDateTimeOffset()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new DateTimeOffset(new DateTime(2000, 1, 1)), converter.Convert(new DateTimeOffset(new DateTime(2000, 1, 1)), typeof(DateTimeOffset)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void DateTimeOffsetToNullableDateTimeOffset()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(new DateTimeOffset(new DateTime(2000, 1, 1)), converter.Convert(new DateTimeOffset(new DateTime(2000, 1, 1)), typeof(DateTimeOffset?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void EnumToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(TestEnum.One, converter.Convert(TestEnum.One, typeof(TestEnum)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void EnumToNullableEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(TestEnum.One, converter.Convert(TestEnum.One, typeof(TestEnum?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void StructToStruct()
        {
            var converter = new TestObjectConverter();
            var source = new TestStruct { X = 1, Y = 2 };
            var target = (TestStruct)converter.Convert(source, typeof(TestStruct));
            Assert.Equal(1, target.X);
            Assert.Equal(2, target.Y);
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void StructToNullableStruct()
        {
            var converter = new TestObjectConverter();
            var source = new TestStruct { X = 1, Y = 2 };
            var target = (TestStruct)converter.Convert(source, typeof(TestStruct?));
            Assert.Equal(1, target.X);
            Assert.Equal(2, target.Y);
            Assert.True(converter.NotUsed());
        }
    }
}
