namespace Smart.Linq;

using System.Collections;

public sealed class EnumerableExtensionsStateTests
{
    [Fact]
    public void AnyWithStateOnListUsesIndexer()
    {
        var list = new IndexOnlyList<int>(Enumerable.Range(1, 3));
        Assert.True(list.Any(1, static (x, s) => x == s));
        Assert.True(list.Any(3, static (x, s) => x == s));
        Assert.False(list.Any(9, static (x, s) => x == s));
        Assert.False(new IndexOnlyList<int>([]).Any(1, static (x, s) => x == s));
    }

    [Fact]
    public void AllWithStateOnListUsesIndexer()
    {
        var list = new IndexOnlyList<int>(Enumerable.Range(1, 3));
        Assert.True(list.All(0, static (x, s) => x > s));
        Assert.False(list.All(1, static (x, s) => x > s));
        Assert.False(list.All(3, static (x, s) => x < s));
        Assert.True(new IndexOnlyList<int>([]).All(1, static (x, s) => x == s));
    }

    [Fact]
    public void CountWithStateOnListUsesIndexer()
    {
        var list = new IndexOnlyList<int>(Enumerable.Range(1, 4));
        Assert.Equal(4, list.Count(1, static (x, s) => x % s == 0));
        Assert.Equal(2, list.Count(2, static (x, s) => x % s == 0));
        Assert.Equal(0, list.Count(9, static (x, s) => x == s));
    }

    [Fact]
    public void FirstWithStateOnListUsesIndexer()
    {
        var list = new IndexOnlyList<int>(Enumerable.Range(1, 4));
        Assert.Equal(1, list.First(0, static (x, s) => x > s));
        Assert.Equal(3, list.First(2, static (x, s) => x > s));
        Assert.Throws<InvalidOperationException>(() => list.First(9, static (x, s) => x > s));
    }

    [Fact]
    public void FirstOrDefaultWithStateOnListUsesIndexer()
    {
        string[] values = ["a", new('b', 1), new('b', 1)];
        var list = new IndexOnlyList<string>(values);
        Assert.Same(values[0], list.FirstOrDefault("a", static (x, s) => x == s));
        Assert.Same(values[1], list.FirstOrDefault("b", static (x, s) => x == s));
        Assert.Null(list.FirstOrDefault("z", static (x, s) => x == s));
    }

    [Fact]
    public void WithStateOnSequence()
    {
        Assert.True(Sequence(3).Any(1, static (x, s) => x == s));
        Assert.True(Sequence(3).Any(3, static (x, s) => x == s));
        Assert.False(Sequence(3).Any(9, static (x, s) => x == s));
        Assert.True(Sequence(3).All(0, static (x, s) => x > s));
        Assert.False(Sequence(3).All(1, static (x, s) => x > s));
        Assert.Equal(4, Sequence(4).Count(1, static (x, s) => x % s == 0));
        Assert.Equal(2, Sequence(4).Count(2, static (x, s) => x % s == 0));
        Assert.Equal(1, Sequence(4).First(0, static (x, s) => x > s));
        Assert.Equal(3, Sequence(4).First(2, static (x, s) => x > s));
        Assert.Throws<InvalidOperationException>(() => Sequence(2).First(9, static (x, s) => x > s));
        Assert.Equal(1, Sequence(4).FirstOrDefault(0, static (x, s) => x > s));
        Assert.Equal(3, Sequence(4).FirstOrDefault(2, static (x, s) => x > s));
        Assert.Equal(0, Sequence(2).FirstOrDefault(9, static (x, s) => x > s));
    }

    private static IEnumerable<int> Sequence(int count)
    {
        for (var i = 1; i <= count; i++)
        {
            yield return i;
        }
    }

    private sealed class IndexOnlyList<T>(IEnumerable<T> values) : IList<T>
    {
        private readonly List<T> items = [.. values];

        public int Count => items.Count;

        public bool IsReadOnly => true;

        public T this[int index]
        {
            get => items[index];
            set => throw new NotSupportedException();
        }

        public IEnumerator<T> GetEnumerator() => throw new NotSupportedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int IndexOf(T item) => items.IndexOf(item);

        public bool Contains(T item) => items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);

        public void Add(T item) => throw new NotSupportedException();

        public void Insert(int index, T item) => throw new NotSupportedException();

        public bool Remove(T item) => throw new NotSupportedException();

        public void RemoveAt(int index) => throw new NotSupportedException();

        public void Clear() => throw new NotSupportedException();
    }
}
