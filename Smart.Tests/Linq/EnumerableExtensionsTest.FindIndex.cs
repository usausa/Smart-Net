namespace Smart.Linq;

using System.Collections.Generic;

public sealed class EnumerableExtensionsFindIndexTest
{
    //--------------------------------------------------------------------------------
    // FindIndex — Span<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindIndexSpanNotFound()
    {
        Span<int> span = [1, 2, 3];
        Assert.Equal(-1, span.FindIndex(static x => x == 99));
    }

    [Fact]
    public void FindIndexSpanFirstMatch()
    {
        Span<int> span = [10, 20, 30];
        Assert.Equal(0, span.FindIndex(static x => x == 10));
    }

    [Fact]
    public void FindIndexSpanLastMatch()
    {
        Span<int> span = [10, 20, 30];
        Assert.Equal(2, span.FindIndex(static x => x == 30));
    }

    [Fact]
    public void FindIndexSpanEmptyReturnsMinusOne()
    {
        Span<int> span = [];
        Assert.Equal(-1, span.FindIndex(static x => x == 1));
    }

    //--------------------------------------------------------------------------------
    // FindIndex — ReadOnlySpan<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindIndexReadOnlySpanNotFound()
    {
        ReadOnlySpan<int> span = [1, 2, 3];
        Assert.Equal(-1, span.FindIndex(static x => x == 0));
    }

    [Fact]
    public void FindIndexReadOnlySpanFirstMatch()
    {
        ReadOnlySpan<string> span = ["a", "b", "c"];
        Assert.Equal(0, span.FindIndex(static s => s == "a"));
    }

    [Fact]
    public void FindIndexReadOnlySpanLastMatch()
    {
        ReadOnlySpan<string> span = ["a", "b", "c"];
        Assert.Equal(2, span.FindIndex(static s => s == "c"));
    }

    //--------------------------------------------------------------------------------
    // FindIndex — array overloads
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindIndexArrayNotFound()
    {
        var arr = new[] { 1, 2, 3 };
        Assert.Equal(-1, arr.FindIndex(static x => x == 99));
    }

    [Fact]
    public void FindIndexArrayFirstMatch()
    {
        var arr = new[] { 10, 20, 30 };
        Assert.Equal(0, arr.FindIndex(static x => x == 10));
    }

    [Fact]
    public void FindIndexArrayLastMatch()
    {
        var arr = new[] { 10, 20, 30 };
        Assert.Equal(2, arr.FindIndex(static x => x == 30));
    }

    [Fact]
    public void FindIndexArrayWithStartLength()
    {
        var arr = new[] { 1, 2, 3, 4, 5 };
        Assert.Equal(2, arr.FindIndex(1, 3, static x => x == 3));
    }

    [Fact]
    public void FindIndexArrayWithStartLengthNotFound()
    {
        var arr = new[] { 1, 2, 3, 4, 5 };
        Assert.Equal(-1, arr.FindIndex(1, 3, static x => x == 5));
    }

    //--------------------------------------------------------------------------------
    // FindIndex — IList<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindIndexIListNotFound()
    {
        IList<int> list = [1, 2, 3];
        Assert.Equal(-1, list.FindIndex(static x => x == 0));
    }

    [Fact]
    public void FindIndexIListFirstMatch()
    {
        IList<int> list = [10, 20, 30];
        Assert.Equal(0, list.FindIndex(static x => x == 10));
    }

    [Fact]
    public void FindIndexIListLastMatch()
    {
        IList<int> list = [10, 20, 30];
        Assert.Equal(2, list.FindIndex(static x => x == 30));
    }

    [Fact]
    public void FindIndexIListWithStartLength()
    {
        IList<int> list = [1, 2, 3, 4, 5];
        Assert.Equal(2, list.FindIndex(1, 3, static x => x == 3));
    }

    //--------------------------------------------------------------------------------
    // FindIndex — IReadOnlyList<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindIndexIReadOnlyListNotFound()
    {
        IReadOnlyList<int> list = new[] { 1, 2, 3 };
        Assert.Equal(-1, list.FindIndex(static x => x == 0));
    }

    [Fact]
    public void FindIndexIReadOnlyListFirstMatch()
    {
        IReadOnlyList<int> list = new[] { 10, 20, 30 };
        Assert.Equal(0, list.FindIndex(static x => x == 10));
    }

    [Fact]
    public void FindIndexIReadOnlyListLastMatch()
    {
        IReadOnlyList<int> list = new[] { 10, 20, 30 };
        Assert.Equal(2, list.FindIndex(static x => x == 30));
    }

    [Fact]
    public void FindIndexIReadOnlyListWithStartLength()
    {
        IReadOnlyList<int> list = new[] { 1, 2, 3, 4, 5 };
        Assert.Equal(2, list.FindIndex(1, 3, static x => x == 3));
    }

    //--------------------------------------------------------------------------------
    // FindIndex with state — Span<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindIndexWithStateSpan()
    {
        Span<int> span = [1, 2, 3, 4];
        Assert.Equal(2, span.FindIndex(3, static (x, state) => x == state));
    }

    [Fact]
    public void FindIndexWithStateSpanNotFound()
    {
        Span<int> span = [1, 2, 3];
        Assert.Equal(-1, span.FindIndex(99, static (x, state) => x == state));
    }

    //--------------------------------------------------------------------------------
    // FindIndex with state — array overloads
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindIndexWithStateArray()
    {
        var arr = new[] { 1, 2, 3, 4 };
        Assert.Equal(2, arr.FindIndex(3, static (x, state) => x == state));
    }

    [Fact]
    public void FindIndexWithStateArrayStartLength()
    {
        var arr = new[] { 1, 2, 3, 4, 5 };
        Assert.Equal(3, arr.FindIndex(1, 3, 4, static (x, state) => x == state));
    }

    //--------------------------------------------------------------------------------
    // FindLastIndex — Span<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindLastIndexSpanNotFound()
    {
        Span<int> span = [1, 2, 3];
        Assert.Equal(-1, span.FindLastIndex(static x => x == 99));
    }

    [Fact]
    public void FindLastIndexSpanFirstMatch()
    {
        Span<int> span = [10, 20, 30];
        Assert.Equal(0, span.FindLastIndex(static x => x == 10));
    }

    [Fact]
    public void FindLastIndexSpanLastMatch()
    {
        Span<int> span = [10, 20, 30];
        Assert.Equal(2, span.FindLastIndex(static x => x == 30));
    }

    [Fact]
    public void FindLastIndexSpanReturnsLastDuplicate()
    {
        Span<int> span = [1, 2, 1, 3, 1];
        Assert.Equal(4, span.FindLastIndex(static x => x == 1));
    }

    //--------------------------------------------------------------------------------
    // FindLastIndex — ReadOnlySpan<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindLastIndexReadOnlySpanReturnsLastDuplicate()
    {
        ReadOnlySpan<int> span = [5, 3, 5, 1];
        Assert.Equal(2, span.FindLastIndex(static x => x == 5));
    }

    //--------------------------------------------------------------------------------
    // FindLastIndex — array overloads
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindLastIndexArrayNotFound()
    {
        var arr = new[] { 1, 2, 3 };
        Assert.Equal(-1, arr.FindLastIndex(static x => x == 0));
    }

    [Fact]
    public void FindLastIndexArrayWithStartLength()
    {
        var arr = new[] { 1, 2, 3, 2, 1 };
        Assert.Equal(3, arr.FindLastIndex(2, 3, static x => x == 2));
    }

    //--------------------------------------------------------------------------------
    // FindLastIndex — IList<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindLastIndexIListReturnsLastDuplicate()
    {
        IList<int> list = [1, 2, 1, 3];
        Assert.Equal(2, list.FindLastIndex(static x => x == 1));
    }

    [Fact]
    public void FindLastIndexIListWithStartLength()
    {
        IList<int> list = [1, 2, 3, 2, 1];
        Assert.Equal(3, list.FindLastIndex(2, 3, static x => x == 2));
    }

    //--------------------------------------------------------------------------------
    // FindLastIndex — IReadOnlyList<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindLastIndexIReadOnlyListReturnsLastDuplicate()
    {
        IReadOnlyList<int> list = new[] { 3, 2, 3 };
        Assert.Equal(2, list.FindLastIndex(static x => x == 3));
    }

    [Fact]
    public void FindLastIndexIReadOnlyListWithStartLength()
    {
        IReadOnlyList<int> list = new[] { 1, 2, 3, 2, 1 };
        Assert.Equal(3, list.FindLastIndex(2, 3, static x => x == 2));
    }

    //--------------------------------------------------------------------------------
    // FindLastIndex with state
    //--------------------------------------------------------------------------------

    [Fact]
    public void FindLastIndexWithStateSpan()
    {
        Span<int> span = [1, 2, 1, 3, 1];
        Assert.Equal(4, span.FindLastIndex(1, static (x, state) => x == state));
    }

    [Fact]
    public void FindLastIndexWithStateArray()
    {
        var arr = new[] { 1, 2, 1, 3, 1 };
        Assert.Equal(4, arr.FindLastIndex(1, static (x, state) => x == state));
    }

    [Fact]
    public void FindLastIndexWithStateIList()
    {
        IList<int> list = [1, 2, 1, 3, 1];
        Assert.Equal(4, list.FindLastIndex(1, static (x, state) => x == state));
    }

    [Fact]
    public void FindLastIndexWithStateIListStartLength()
    {
        IList<int> list = [1, 2, 1, 3, 1];
        // Range: start=0, length=3 → indices 0,1,2 → values 1,2,1 — last 1 is at index 2
        Assert.Equal(2, list.FindLastIndex(0, 3, 1, static (x, state) => x == state));
    }

    [Fact]
    public void FindLastIndexWithStateIReadOnlyList()
    {
        IReadOnlyList<int> list = new[] { 1, 2, 1, 3, 1 };
        Assert.Equal(4, list.FindLastIndex(1, static (x, state) => x == state));
    }
}
