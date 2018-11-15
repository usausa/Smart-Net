namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class DBNullConverterFactoryTest
    {
        [Fact]
        public void DBNullToString()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(DBNull.Value, typeof(string)));
            Assert.True(converter.UsedOnly<DBNullConverterFactory>());
        }

        [Fact]
        public void DBNullToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(DBNull.Value, typeof(int)));
            Assert.True(converter.UsedOnly<DBNullConverterFactory>());
        }

        [Fact]
        public void DBNullToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Null(converter.Convert(DBNull.Value, typeof(int?)));
            Assert.True(converter.UsedOnly<DBNullConverterFactory>());
        }
    }
}
