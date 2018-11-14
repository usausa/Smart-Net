namespace Smart.Converter.Converters
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using Smart.Converter.Types;

    using Xunit;

    public class EnumerableConvertToReadOnlyObservableCollectionTest
    {
        [Fact]
        public void ArrayToSameElementReadOnlyObservableCollection()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (ReadOnlyObservableCollection<int>)converter.Convert(source, typeof(ReadOnlyObservableCollection<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ArrayToOtherElementReadOnlyObservableCollection()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 };
            var destination = (ReadOnlyObservableCollection<string>)converter.Convert(source, typeof(ReadOnlyObservableCollection<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void ListToSameElementReadOnlyObservableCollection()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (ReadOnlyObservableCollection<int>)converter.Convert(source, typeof(ReadOnlyObservableCollection<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void ListToOtherElementReadOnlyObservableCollection()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperList<int>(new[] { 0, 1 });
            var destination = (ReadOnlyObservableCollection<string>)converter.Convert(source, typeof(ReadOnlyObservableCollection<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void CollectionToSameElementReadOnlyObservableCollection()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (ReadOnlyObservableCollection<int>)converter.Convert(source, typeof(ReadOnlyObservableCollection<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void CollectionToOtherElementReadOnlyObservableCollection()
        {
            var converter = new TestObjectConverter();
            var source = new WrapperCollection<int>(new[] { 0, 1 });
            var destination = (ReadOnlyObservableCollection<string>)converter.Convert(source, typeof(ReadOnlyObservableCollection<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void EnumerableToSameElementReadOnlyObservableCollection()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (ReadOnlyObservableCollection<int>)converter.Convert(source, typeof(ReadOnlyObservableCollection<int>));
            Assert.Equal(2, destination.Count);
            Assert.Contains(0, destination);
            Assert.Contains(1, destination);
            Assert.True(converter.UsedOnly<EnumerableConverterFactory>());
        }

        [Fact]
        public void EnumerableToOtherElementReadOnlyObservableCollection()
        {
            var converter = new TestObjectConverter();
            var source = new[] { 0, 1 }.Select(x => x);
            var destination = (ReadOnlyObservableCollection<string>)converter.Convert(source, typeof(ReadOnlyObservableCollection<string>));
            Assert.Equal(2, destination.Count);
            Assert.Contains("0", destination);
            Assert.Contains("1", destination);
            Assert.True(converter.UsedIn(typeof(EnumerableConverterFactory), typeof(ToStringConverterFactory)));
        }
    }
}
