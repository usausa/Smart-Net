namespace Smart.Converter.Converters
{
    using System.Collections.Concurrent;
    using System.Linq;

    using Smart.Converter.Types;

    using Xunit;

    public class EnumerableConverterFactoryToConcurrentQueueTest
    {
        [Fact]
        public void ArrayToSameElementConcurrentQueue()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (ConcurrentQueue<int>)converter.Convert(source, typeof(ConcurrentQueue<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ArrayToOtherElementConcurrentQueue()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (ConcurrentQueue<string>)converter.Convert(source, typeof(ConcurrentQueue<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void ListToSameElementConcurrentQueue()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (ConcurrentQueue<int>)converter.Convert(source, typeof(ConcurrentQueue<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ListToOtherElementConcurrentQueue()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (ConcurrentQueue<string>)converter.Convert(source, typeof(ConcurrentQueue<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void CollectionToSameElementConcurrentQueue()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (ConcurrentQueue<int>)converter.Convert(source, typeof(ConcurrentQueue<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void CollectionToOtherElementConcurrentQueue()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (ConcurrentQueue<string>)converter.Convert(source, typeof(ConcurrentQueue<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void EnumerableToSameElementConcurrentQueue()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (ConcurrentQueue<int>)converter.Convert(source, typeof(ConcurrentQueue<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void EnumerableToOtherElementConcurrentQueue()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (ConcurrentQueue<string>)converter.Convert(source, typeof(ConcurrentQueue<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }
    }
}
