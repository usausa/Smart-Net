namespace Smart.Converter.Converters
{
    using System.Collections.Generic;
    using System.Linq;

    using Smart.Converter.Types;

    using Xunit;

    public class EnumerableConverterFactoryToQueueTest
    {
        [Fact]
        public void ArrayToSameElementQueue()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (Queue<int>)converter.Convert(source, typeof(Queue<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ArrayToOtherElementQueue()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (Queue<string>)converter.Convert(source, typeof(Queue<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void ListToSameElementQueue()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (Queue<int>)converter.Convert(source, typeof(Queue<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ListToOtherElementQueue()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (Queue<string>)converter.Convert(source, typeof(Queue<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void CollectionToSameElementQueue()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (Queue<int>)converter.Convert(source, typeof(Queue<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void CollectionToOtherElementQueue()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (Queue<string>)converter.Convert(source, typeof(Queue<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void EnumerableToSameElementQueue()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (Queue<int>)converter.Convert(source, typeof(Queue<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void EnumerableToOtherElementQueue()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (Queue<string>)converter.Convert(source, typeof(Queue<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }
    }
}
