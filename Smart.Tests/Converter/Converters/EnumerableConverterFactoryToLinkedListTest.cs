namespace Smart.Converter.Converters
{
    using System.Collections.Generic;
    using System.Linq;

    using Smart.Converter.Types;

    using Xunit;

    public class EnumerableConverterFactoryToLinkedListTest
    {
        [Fact]
        public void ArrayToSameElementLinkedList()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (LinkedList<int>)converter.Convert(source, typeof(LinkedList<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ArrayToOtherElementLinkedList()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (LinkedList<string>)converter.Convert(source, typeof(LinkedList<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void LinkedListToSameElementLinkedList()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (LinkedList<int>)converter.Convert(source, typeof(LinkedList<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void LinkedListToOtherElementLinkedList()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (LinkedList<string>)converter.Convert(source, typeof(LinkedList<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void CollectionToSameElementLinkedList()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (LinkedList<int>)converter.Convert(source, typeof(LinkedList<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void CollectionToOtherElementLinkedList()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (LinkedList<string>)converter.Convert(source, typeof(LinkedList<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void EnumerableToSameElementLinkedList()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (LinkedList<int>)converter.Convert(source, typeof(LinkedList<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void EnumerableToOtherElementLinkedList()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (LinkedList<string>)converter.Convert(source, typeof(LinkedList<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }
    }
}
