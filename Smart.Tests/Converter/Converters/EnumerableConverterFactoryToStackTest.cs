namespace Smart.Converter.Converters
{
    using System.Collections.Generic;
    using System.Linq;

    using Smart.Converter.Types;

    using Xunit;

    public class EnumerableConverterFactoryToStackTest
    {
        [Fact]
        public void ArrayToSameElementStack()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (Stack<int>)converter.Convert(source, typeof(Stack<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ArrayToOtherElementStack()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (Stack<string>)converter.Convert(source, typeof(Stack<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void ListToSameElementStack()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (Stack<int>)converter.Convert(source, typeof(Stack<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ListToOtherElementStack()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (Stack<string>)converter.Convert(source, typeof(Stack<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void CollectionToSameElementStack()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (Stack<int>)converter.Convert(source, typeof(Stack<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void CollectionToOtherElementStack()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (Stack<string>)converter.Convert(source, typeof(Stack<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void EnumerableToSameElementStack()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (Stack<int>)converter.Convert(source, typeof(Stack<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void EnumerableToOtherElementStack()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (Stack<string>)converter.Convert(source, typeof(Stack<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }
    }
}
