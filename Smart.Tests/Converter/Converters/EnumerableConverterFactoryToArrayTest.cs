namespace Smart.Converter.Converters
{
    using System.Collections.Generic;
    using System.Linq;

    using Smart.Converter.Types;

    using Xunit;

    public class EnumerableConverterFactoryToArrayTest
    {
        // MEMO same array type is not converted

        [Fact]
        public void ArrayToOtherElementArray()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (string[])converter.Convert(source, typeof(string[]));
            Assert.Equal(2, destination.Length);
            Assert.Equal("0", destination[0]);
            Assert.Equal("1", destination[1]);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void ListToSameElementArray()
        {
            var converter = new TestObjectConverter();
            var source = new List<int> { 0, 1 };
            var destination = (int[])converter.Convert(source, typeof(int[]));
            Assert.Equal(2, destination.Length);
            Assert.Equal(0, destination[0]);
            Assert.Equal(1, destination[1]);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ListToOtherElementArray()
        {
            var converter = new TestObjectConverter();
            var source = new List<int> { 0, 1 };
            var destination = (string[])converter.Convert(source, typeof(string[]));
            Assert.Equal(2, destination.Length);
            Assert.Equal("0", destination[0]);
            Assert.Equal("1", destination[1]);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void CollectionToSameElementArray()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (int[])converter.Convert(source, typeof(int[]));
            Assert.Equal(2, destination.Length);
            Assert.Equal(0, destination[0]);
            Assert.Equal(1, destination[1]);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void CollectionToOtherElementArray()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (string[])converter.Convert(source, typeof(string[]));
            Assert.Equal(2, destination.Length);
            Assert.Equal("0", destination[0]);
            Assert.Equal("1", destination[1]);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void EnumerableToSameElementArray()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (int[])converter.Convert(source, typeof(int[]));
            Assert.Equal(2, destination.Length);
            Assert.Equal(0, destination[0]);
            Assert.Equal(1, destination[1]);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void EnumerableToOtherElementArray()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (string[])converter.Convert(source, typeof(string[]));
            Assert.Equal(2, destination.Length);
            Assert.Equal("0", destination[0]);
            Assert.Equal("1", destination[1]);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }
    }
}
