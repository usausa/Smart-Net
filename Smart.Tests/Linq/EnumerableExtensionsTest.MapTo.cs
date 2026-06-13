namespace Smart.Linq;

using System.Collections.ObjectModel;

public sealed class EnumerableExtensionsMapToTest
{
    //--------------------------------------------------------------------------------
    // MapToArray — Span<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToArraySpanBasic()
    {
        Span<int> source = [1, 2, 3];
        var result = source.MapToArray(static x => x * 2);

        Assert.Equal(new[] { 2, 4, 6 }, result);
    }

    [Fact]
    public void MapToArraySpanEmpty()
    {
        Span<int> source = [];
        var result = source.MapToArray(static x => x * 2);

        Assert.Empty(result);
    }

    //--------------------------------------------------------------------------------
    // MapToArray — ReadOnlySpan<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToArrayReadOnlySpanBasic()
    {
        ReadOnlySpan<int> source = [1, 2, 3];
        var result = source.MapToArray(static x => x.ToString(System.Globalization.CultureInfo.InvariantCulture));

        Assert.Equal(["1", "2", "3"], result);
    }

    [Fact]
    public void MapToArrayReadOnlySpanEmpty()
    {
        ReadOnlySpan<int> source = [];
        var result = source.MapToArray(static x => x.ToString(System.Globalization.CultureInfo.InvariantCulture));

        Assert.Empty(result);
    }

    //--------------------------------------------------------------------------------
    // MapToArray — array overloads
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToArrayFromArray()
    {
        var source = new[] { 1, 2, 3 };
        var result = source.MapToArray(static x => x * 10);

        Assert.Equal(new[] { 10, 20, 30 }, result);
    }

    [Fact]
    public void MapToArrayFromArrayStartLength()
    {
        var source = new[] { 1, 2, 3, 4, 5 };
        var result = source.MapToArray(1, 3, static x => x);

        Assert.Equal(new[] { 2, 3, 4 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToArray — List<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToArrayFromList()
    {
        var source = new List<int> { 1, 2, 3 };
        var result = source.MapToArray(static x => x + 100);

        Assert.Equal(new[] { 101, 102, 103 }, result);
    }

    [Fact]
    public void MapToArrayFromListStartLength()
    {
        var source = new List<int> { 1, 2, 3, 4, 5 };
        var result = source.MapToArray(1, 3, static x => x);

        Assert.Equal(new[] { 2, 3, 4 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToArray — ObservableCollection<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToArrayFromObservableCollection()
    {
        var source = new ObservableCollection<int> { 10, 20, 30 };
        var result = source.MapToArray(static x => x / 10);

        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    [Fact]
    public void MapToArrayFromObservableCollectionStartLength()
    {
        var source = new ObservableCollection<int> { 10, 20, 30, 40, 50 };
        var result = source.MapToArray(1, 3, static x => x);

        Assert.Equal(new[] { 20, 30, 40 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToArray — IList<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToArrayFromIList()
    {
        IList<int> source = [5, 6, 7];
        var result = source.MapToArray(static x => x - 5);

        Assert.Equal(new[] { 0, 1, 2 }, result);
    }

    [Fact]
    public void MapToArrayFromIListStartLength()
    {
        IList<int> source = [1, 2, 3, 4, 5];
        var result = source.MapToArray(2, 2, static x => x);

        Assert.Equal(new[] { 3, 4 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToArray with state — Span<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToArrayWithStateSpan()
    {
        Span<int> source = [1, 2, 3];
        var result = source.MapToArray(10, static (x, state) => x + state);

        Assert.Equal(new[] { 11, 12, 13 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToArray with state — ReadOnlySpan<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToArrayWithStateReadOnlySpan()
    {
        ReadOnlySpan<int> source = [1, 2, 3];
        var result = source.MapToArray("prefix", static (x, state) => $"{state}{x}");

        Assert.Equal(["prefix1", "prefix2", "prefix3"], result);
    }

    //--------------------------------------------------------------------------------
    // MapToArray with state — array overloads
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToArrayWithStateArray()
    {
        var source = new[] { 1, 2, 3 };
        var result = source.MapToArray(100, static (x, state) => x + state);

        Assert.Equal(new[] { 101, 102, 103 }, result);
    }

    [Fact]
    public void MapToArrayWithStateArrayStartLength()
    {
        var source = new[] { 1, 2, 3, 4, 5 };
        var result = source.MapToArray(1, 3, 10, static (x, state) => x + state);

        Assert.Equal(new[] { 12, 13, 14 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToList — Span<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToListSpanBasic()
    {
        Span<int> source = [1, 2, 3];
        var result = source.MapToList(static x => x * 2);

        Assert.Equal(new[] { 2, 4, 6 }, result);
    }

    [Fact]
    public void MapToListSpanEmpty()
    {
        Span<int> source = [];
        var result = source.MapToList(static x => x * 2);

        Assert.Empty(result);
    }

    //--------------------------------------------------------------------------------
    // MapToList — ReadOnlySpan<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToListReadOnlySpanBasic()
    {
        ReadOnlySpan<int> source = [1, 2, 3];
        var result = source.MapToList(static x => x.ToString(System.Globalization.CultureInfo.InvariantCulture));

        Assert.Equal(["1", "2", "3"], result);
    }

    //--------------------------------------------------------------------------------
    // MapToList — array overloads
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToListFromArray()
    {
        var source = new[] { 1, 2, 3 };
        var result = source.MapToList(static x => x * 10);

        Assert.IsType<List<int>>(result);
        Assert.Equal(new[] { 10, 20, 30 }, result);
    }

    [Fact]
    public void MapToListFromArrayStartLength()
    {
        var source = new[] { 1, 2, 3, 4, 5 };
        var result = source.MapToList(1, 3, static x => x);

        Assert.Equal(new[] { 2, 3, 4 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToList — List<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToListFromList()
    {
        var source = new List<int> { 4, 5, 6 };
        var result = source.MapToList(static x => x - 3);

        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    [Fact]
    public void MapToListFromListStartLength()
    {
        var source = new List<int> { 1, 2, 3, 4, 5 };
        var result = source.MapToList(2, 2, static x => x);

        Assert.Equal(new[] { 3, 4 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToList — ObservableCollection<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToListFromObservableCollection()
    {
        var source = new ObservableCollection<string> { "a", "b", "c" };
        var result = source.MapToList(static x => x.ToUpperInvariant());

        Assert.Equal(["A", "B", "C"], result);
    }

    [Fact]
    public void MapToListFromObservableCollectionStartLength()
    {
        var source = new ObservableCollection<int> { 10, 20, 30, 40 };
        var result = source.MapToList(1, 2, static x => x);

        Assert.Equal(new[] { 20, 30 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToList — IList<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToListFromIList()
    {
        IList<int> source = [1, 2, 3];
        var result = source.MapToList(static x => x * 100);

        Assert.Equal(new[] { 100, 200, 300 }, result);
    }

    [Fact]
    public void MapToListFromIListStartLength()
    {
        IList<int> source = [1, 2, 3, 4, 5];
        var result = source.MapToList(0, 3, static x => x);

        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    //--------------------------------------------------------------------------------
    // MapToList with state — spot checks
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapToListWithStateSpan()
    {
        Span<int> source = [1, 2, 3];
        var result = source.MapToList(5, static (x, state) => x + state);

        Assert.Equal(new[] { 6, 7, 8 }, result);
    }

    [Fact]
    public void MapToListWithStateArray()
    {
        var source = new[] { 1, 2, 3 };
        var result = source.MapToList("!", static (x, state) => $"{x}{state}");

        Assert.Equal(["1!", "2!", "3!"], result);
    }

    [Fact]
    public void MapToListWithStateIList()
    {
        IList<int> source = [10, 20, 30];
        var result = source.MapToList(-10, static (x, state) => x + state);

        Assert.Equal(new[] { 0, 10, 20 }, result);
    }
}
