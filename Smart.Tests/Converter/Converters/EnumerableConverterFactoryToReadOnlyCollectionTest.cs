namespace Smart.Converter.Converters
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using Xunit;

    public class EnumerableConverterFactoryToReadOnlyCollectionTest
    {
        [Fact]
        public void ArrayToSameElementReadOnlyCollection()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (ReadOnlyCollection<int>)converter.Convert(source, typeof(ReadOnlyCollection<int>));
            Assert.Equal(2, destination.Count);
            Assert.Equal(0, destination[0]);
            Assert.Equal(1, destination[1]);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ArrayToOtherElementReadOnlyCollection()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (ReadOnlyCollection<string>)converter.Convert(source, typeof(ReadOnlyCollection<string>));
            Assert.Equal(2, destination.Count);
            Assert.Equal("0", destination[0]);
            Assert.Equal("1", destination[1]);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void ListToSameElementReadOnlyCollection()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (ReadOnlyCollection<int>)converter.Convert(source, typeof(ReadOnlyCollection<int>));
            Assert.Equal(2, destination.Count);
            Assert.Equal(0, destination[0]);
            Assert.Equal(1, destination[1]);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ListToOtherElementReadOnlyCollection()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (ReadOnlyCollection<string>)converter.Convert(source, typeof(ReadOnlyCollection<string>));
            Assert.Equal(2, destination.Count);
            Assert.Equal("0", destination[0]);
            Assert.Equal("1", destination[1]);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void CollectionToSameElementReadOnlyCollection()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (ReadOnlyCollection<int>)converter.Convert(source, typeof(ReadOnlyCollection<int>));
            Assert.Equal(2, destination.Count);
            Assert.Equal(0, destination[0]);
            Assert.Equal(1, destination[1]);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void CollectionToOtherElementReadOnlyCollection()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (ReadOnlyCollection<string>)converter.Convert(source, typeof(ReadOnlyCollection<string>));
            Assert.Equal(2, destination.Count);
            Assert.Equal("0", destination[0]);
            Assert.Equal("1", destination[1]);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void EnumerableToSameElementReadOnlyCollection()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (ReadOnlyCollection<int>)converter.Convert(source, typeof(ReadOnlyCollection<int>));
            Assert.Equal(2, destination.Count);
            Assert.Equal(0, destination[0]);
            Assert.Equal(1, destination[1]);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void EnumerableToOtherElementReadOnlyCollection()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (ReadOnlyCollection<string>)converter.Convert(source, typeof(ReadOnlyCollection<string>));
            Assert.Equal(2, destination.Count);
            Assert.Equal("0", destination[0]);
            Assert.Equal("1", destination[1]);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }
    }
}
