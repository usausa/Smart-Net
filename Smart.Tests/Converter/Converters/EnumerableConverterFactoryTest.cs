namespace Smart.Converter.Converters
{
    using System.Collections.Generic;

    using Smart.Converter.Types;

    using Xunit;

    public class EnumerableConverterFactoryTest
    {
        [Fact]
        public void CanNotConvertToArray()
        {
            var converter = new TestObjectConverter();
            Assert.False(converter.CanConvert(typeof(StructType), typeof(int[])));
        }

        [Fact]
        public void CanNotConvertToList()
        {
            var converter = new TestObjectConverter();
            Assert.False(converter.CanConvert(typeof(StructType), typeof(List<int>)));
        }

        [Fact]
        public void CanNotConvertFromArray()
        {
            var converter = new TestObjectConverter();
            Assert.False(converter.CanConvert(typeof(int[]), typeof(StructType)));
        }

        [Fact]
        public void CanNotConvertFromList()
        {
            var converter = new TestObjectConverter();
            Assert.False(converter.CanConvert(typeof(List<int>), typeof(StructType)));
        }
    }
}
