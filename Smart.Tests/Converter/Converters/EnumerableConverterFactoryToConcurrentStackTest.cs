namespace Smart.Converter.Converters
{
    using System.Collections.Concurrent;
    using System.Linq;

    using Smart.Converter.Types;

    using Xunit;

    public class EnumerableConverterFactoryToConcurrentStackTest
    {
        [Fact]
        public void ArrayToSameElementConcurrentStack()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (ConcurrentStack<int>)converter.Convert(source, typeof(ConcurrentStack<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ArrayToOtherElementConcurrentStack()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (ConcurrentStack<string>)converter.Convert(source, typeof(ConcurrentStack<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void ListToSameElementConcurrentStack()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (ConcurrentStack<int>)converter.Convert(source, typeof(ConcurrentStack<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ListToOtherElementConcurrentStack()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (ConcurrentStack<string>)converter.Convert(source, typeof(ConcurrentStack<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void CollectionToSameElementConcurrentStack()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (ConcurrentStack<int>)converter.Convert(source, typeof(ConcurrentStack<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void CollectionToOtherElementConcurrentStack()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (ConcurrentStack<string>)converter.Convert(source, typeof(ConcurrentStack<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void EnumerableToSameElementConcurrentStack()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (ConcurrentStack<int>)converter.Convert(source, typeof(ConcurrentStack<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void EnumerableToOtherElementConcurrentStack()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (ConcurrentStack<string>)converter.Convert(source, typeof(ConcurrentStack<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }
    }
}
