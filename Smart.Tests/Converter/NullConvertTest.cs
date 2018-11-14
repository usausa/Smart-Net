namespace Smart.Converter
{
    using System;

    using Smart.Converter.Types;

    using Xunit;

    public class NullConvertTest
    {
        [Fact]
        public void NullToBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.False((bool)converter.Convert(null, typeof(bool)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableBoolean()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(bool?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(byte), converter.Convert(null, typeof(byte)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(byte?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(sbyte), converter.Convert(null, typeof(sbyte)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(sbyte?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(short), converter.Convert(null, typeof(short)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(short?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(ushort), converter.Convert(null, typeof(ushort)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(ushort?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(int), converter.Convert(null, typeof(int)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(int?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(uint), converter.Convert(null, typeof(uint)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableUInt()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(uint?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(long), converter.Convert(null, typeof(long)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(long?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(ulong), converter.Convert(null, typeof(ulong)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(ulong?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(char), converter.Convert(null, typeof(char)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(char?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(double), converter.Convert(null, typeof(double)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableDouble()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(double?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(float), converter.Convert(null, typeof(float)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableFloat()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(float?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(decimal), converter.Convert(null, typeof(decimal)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableDecimal()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(decimal?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToString()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(string)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToDateTime()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(DateTime), converter.Convert(null, typeof(DateTime)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableDateTime()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(DateTime?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToDateTimeOffset()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(DateTimeOffset), converter.Convert(null, typeof(DateTimeOffset)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableDateTimeOffset()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(DateTimeOffset?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(TestEnum), converter.Convert(null, typeof(TestEnum)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(TestEnum?)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToStruct()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(default(TestStruct), converter.Convert(null, typeof(TestStruct)));
            Assert.True(converter.NotUsed());
        }

        [Fact]
        public void NullToNullableStruct()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(null, typeof(TestStruct?)));
            Assert.True(converter.NotUsed());
        }
    }
}
