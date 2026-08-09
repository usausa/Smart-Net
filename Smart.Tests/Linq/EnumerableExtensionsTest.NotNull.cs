namespace Smart.Linq;

public sealed class EnumerableExtensionsNotNullTest
{
    private static IEnumerable<T> Lazy<T>(IEnumerable<T> source)
    {
        foreach (var value in source)
        {
            yield return value;
        }
    }

    //--------------------------------------------------------------------------------
    // WhereNotNull : struct
    //--------------------------------------------------------------------------------

    [Fact]
    public void WhereNotNullStructFromArray()
    {
        int?[] source = [1, null, 2, null, 3];

        Assert.Equal([1, 2, 3], source.WhereNotNull());
    }

    [Fact]
    public void WhereNotNullStructFromList()
    {
        var source = new List<int?> { 1, null, 2, null, 3 };

        Assert.Equal([1, 2, 3], source.WhereNotNull());
    }

    [Fact]
    public void WhereNotNullStructFromEnumerable()
    {
        var source = Lazy<int?>([1, null, 2, null, 3]);

        Assert.Equal([1, 2, 3], source.WhereNotNull());
    }

    [Fact]
    public void WhereNotNullStructAllNull()
    {
        int?[] array = [null, null];
        var list = new List<int?> { null, null };

        Assert.Empty(array.WhereNotNull());
        Assert.Empty(list.WhereNotNull());
        Assert.Empty(Lazy<int?>([null, null]).WhereNotNull());
    }

    [Fact]
    public void WhereNotNullStructEmpty()
    {
        Assert.Empty(Array.Empty<int?>().WhereNotNull());
        Assert.Empty(new List<int?>().WhereNotNull());
    }

    [Fact]
    public void WhereNotNullStructDefaultValueIsPreserved()
    {
        // default(int) は null ではないので保持される
        int?[] array = [0, null, 0];
        var list = new List<int?> { 0, null, 0 };

        Assert.Equal([0, 0], array.WhereNotNull());
        Assert.Equal([0, 0], list.WhereNotNull());
    }

    //--------------------------------------------------------------------------------
    // WhereNotNull : class
    //--------------------------------------------------------------------------------

    [Fact]
    public void WhereNotNullClass()
    {
        string?[] source = ["a", null, "b"];

        Assert.Equal(["a", "b"], source.WhereNotNull());
    }

    //--------------------------------------------------------------------------------
    // SelectNotNull : struct
    //--------------------------------------------------------------------------------

    [Fact]
    public void SelectNotNullStructFromArray()
    {
        int[] source = [1, 2, 3, 4];

        Assert.Equal([2, 4], source.SelectNotNull(static x => (x % 2) == 0 ? (int?)x : null));
    }

    [Fact]
    public void SelectNotNullStructFromList()
    {
        var source = new List<int> { 1, 2, 3, 4 };

        Assert.Equal([2, 4], source.SelectNotNull(static x => (x % 2) == 0 ? (int?)x : null));
    }

    [Fact]
    public void SelectNotNullStructFromEnumerable()
    {
        var source = Lazy([1, 2, 3, 4]);

        Assert.Equal([2, 4], source.SelectNotNull(static x => (x % 2) == 0 ? (int?)x : null));
    }

    //--------------------------------------------------------------------------------
    // SelectNotNull : class
    //--------------------------------------------------------------------------------

    [Fact]
    public void SelectNotNullClass()
    {
        int[] source = [1, 2, 3, 4];

        Assert.Equal(["2", "4"], source.SelectNotNull(static x => (x % 2) == 0 ? x.ToString(System.Globalization.CultureInfo.InvariantCulture) : null));
    }

    //--------------------------------------------------------------------------------
    // イテレータの契約
    //--------------------------------------------------------------------------------

    private static List<T> Materialize<T>(IEnumerable<T> source)
    {
        var result = new List<T>();
        using var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            result.Add(enumerator.Current);
        }

        return result;
    }

    // ReSharper disable PossibleMultipleEnumeration
    [Fact]
    public void EnumerableCanBeEnumeratedTwice()
    {
        int?[] array = [1, null, 2];
        var list = new List<int?> { 1, null, 2 };

        var fromArray = array.WhereNotNull();
        Assert.Equal([1, 2], Materialize(fromArray));
        Assert.Equal([1, 2], Materialize(fromArray));

        var fromList = list.WhereNotNull();
        Assert.Equal([1, 2], Materialize(fromList));
        Assert.Equal([1, 2], Materialize(fromList));
    }
    // ReSharper restore PossibleMultipleEnumeration

    // ReSharper disable PossibleMultipleEnumeration
#pragma warning disable CA1851
    [Fact]
    public void NestedEnumerationIsIndependent()
    {
        var list = new List<int?> { 1, 2 };
        var source = list.WhereNotNull();

        var pairs = new List<(int, int)>();
        foreach (var x in source)
        {
            foreach (var y in source)
            {
                pairs.Add((x, y));
            }
        }

        Assert.Equal([(1, 1), (1, 2), (2, 1), (2, 2)], pairs);
    }
#pragma warning restore CA1851
    // ReSharper restore PossibleMultipleEnumeration

    [Fact]
    public void ExecutionIsDeferred()
    {
        var called = false;

        var source = new List<int> { 1 }.SelectNotNull(int? (x) =>
        {
            called = true;
            return x;
        });

        Assert.False(called);

        _ = source.ToList();

        Assert.True(called);
    }

    [Fact]
    public void ListModificationDuringEnumerationThrows()
    {
        var list = new List<int?> { 1, 2, 3 };

        Assert.Throws<InvalidOperationException>(() =>
        {
            foreach (var value in list.WhereNotNull())
            {
                list.Add(value);
            }
        });
    }

    [Fact]
    public void ResetIsNotSupported()
    {
        var list = new List<int?> { 1 };
        using var enumerator = list.WhereNotNull().GetEnumerator();

        Assert.Throws<NotSupportedException>(enumerator.Reset);
    }
}
