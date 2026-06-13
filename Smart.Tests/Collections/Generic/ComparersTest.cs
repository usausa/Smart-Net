namespace Smart.Collections.Generic;

public sealed class ComparersTest
{
    //--------------------------------------------------------------------------------
    // ChainComparer
    //--------------------------------------------------------------------------------

    [Fact]
    public void ChainComparerUsesFirstDifferentResult()
    {
        var c = Comparers.Chain(
            Comparer<string>.Create(static (x, y) => string.Compare(x, y, StringComparison.Ordinal)),
            Comparer<string>.Create(static (x, y) => y.Length - x.Length));

        // First comparer: "abc" < "xyz" → negative
        Assert.True(c.Compare("abc", "xyz") < 0);
    }

    [Fact]
    public void ChainComparerFallsToSecondWhenFirstIsEqual()
    {
        // First comparer: sort by first char; second: descending length
        var firstChar = Comparer<string>.Create(static (x, y) => x[0] - y[0]);
        var descLength = Comparer<string>.Create(static (x, y) => y.Length - x.Length);
        var chain = Comparers.Chain(firstChar, descLength);

        // Both start with 'a'; "abc".Length=3 > "ab".Length=2 → descLength: "abc" > "ab" → negative (desc)
        Assert.True(chain.Compare("abc", "ab") < 0);
    }

    [Fact]
    public void ChainComparerReturnsZeroWhenAllEqual()
    {
        var c = Comparers.Chain(
            Comparer<int>.Default,
            Comparer<int>.Default);

        Assert.Equal(0, c.Compare(5, 5));
    }

    [Fact]
    public void ChainComparerEmptyReturnsZero()
    {
        var c = Comparers.Chain<int>();
        Assert.Equal(0, c.Compare(1, 2));
    }

    //--------------------------------------------------------------------------------
    // ComparisonComparer
    //--------------------------------------------------------------------------------

    [Fact]
    public void ComparisonComparerDelegatesToComparison()
    {
        var c = Comparers.Comparison<int>(static (x, y) => x - y);

        Assert.True(c.Compare(1, 2) < 0);
        Assert.Equal(0, c.Compare(3, 3));
        Assert.True(c.Compare(5, 4) > 0);
    }

    [Fact]
    public void ComparisonComparerCanSortList()
    {
        var list = new List<int> { 3, 1, 4, 1, 5 };
        list.Sort(Comparers.Comparison<int>(static (x, y) => x - y));
        Assert.Equal(new[] { 1, 1, 3, 4, 5 }, list);
    }

    //--------------------------------------------------------------------------------
    // DelegateComparer
    //--------------------------------------------------------------------------------

    [Fact]
    public void DelegateComparerDelegatesToFunc()
    {
        var c = Comparers.Delegate<int>(static (x, y) => y - x); // reverse order

        Assert.True(c.Compare(1, 2) > 0);
        Assert.Equal(0, c.Compare(3, 3));
        Assert.True(c.Compare(5, 4) < 0);
    }

    [Fact]
    public void DelegateComparerCanSortDescending()
    {
        var list = new List<int> { 3, 1, 4, 1, 5 };
        list.Sort(Comparers.Delegate<int>(static (x, y) => y - x));
        Assert.Equal(new[] { 5, 4, 3, 1, 1 }, list);
    }

    //--------------------------------------------------------------------------------
    // DelegateEqualityComparer
    //--------------------------------------------------------------------------------

    [Fact]
    public void DelegateEqualityComparerEquals()
    {
        var c = Comparers.DelegateEquality<string>(
            static (x, y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase),
            static x => x.ToUpperInvariant().GetHashCode(StringComparison.Ordinal));

        Assert.True(c.Equals("Hello", "hello"));
        Assert.False(c.Equals("Hello", "world"));
    }

    [Fact]
    public void DelegateEqualityComparerGetHashCodeIsConsistent()
    {
        var c = Comparers.DelegateEquality<int>(
            static (x, y) => x == y,
            static x => x.GetHashCode());

        Assert.Equal(c.GetHashCode(42), c.GetHashCode(42));
        Assert.NotEqual(c.GetHashCode(1), c.GetHashCode(2));
    }

    [Fact]
    public void DelegateEqualityComparerEqualObjectsHaveSameHashCode()
    {
        // Per IEqualityComparer<T> contract: if Equals(x,y) == true, then GetHashCode(x) == GetHashCode(y)
        var c = Comparers.DelegateEquality<string>(
            static (x, y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase),
            static x => x.ToUpperInvariant().GetHashCode(StringComparison.Ordinal));

        Assert.Equal(c.GetHashCode("Hello"), c.GetHashCode("hello"));
    }

    //--------------------------------------------------------------------------------
    // ProjectionComparer
    //--------------------------------------------------------------------------------

    [Fact]
    public void ProjectionComparerOrdersByKey()
    {
        var c = Comparers.Projection<string, int>(static s => s.Length);

        Assert.True(c.Compare("ab", "abc") < 0);    // 2 < 3
        Assert.Equal(0, c.Compare("ab", "cd"));     // 2 == 2
        Assert.True(c.Compare("abcd", "abc") > 0);  // 4 > 3
    }

    [Fact]
    public void ProjectionComparerNullBothReturnsZero()
    {
        var c = Comparers.Projection<string?, int>(static s => s!.Length);
        Assert.Equal(0, c.Compare(null, null));
    }

    [Fact]
    public void ProjectionComparerNullLessThanNonNull()
    {
        var c = Comparers.Projection<string?, int>(static s => s!.Length);
        Assert.True(c.Compare(null, "a") < 0);
    }

    [Fact]
    public void ProjectionComparerNonNullGreaterThanNull()
    {
        var c = Comparers.Projection<string?, int>(static s => s!.Length);
        Assert.True(c.Compare("a", null) > 0);
    }

    [Fact]
    public void ProjectionComparerCanSortList()
    {
        var list = new List<string> { "banana", "kiwi", "fig", "apple" };
        list.Sort(Comparers.Projection<string, int>(static s => s.Length));
        // Lengths: 6, 4, 3, 5 → fig(3), kiwi(4), apple(5), banana(6)
        Assert.Equal(["fig", "kiwi", "apple", "banana"], list);
    }

    [Fact]
    public void ProjectionComparerWithCustomComparerOverload()
    {
        var c = new ProjectionComparer<string, int>(
            static s => s.Length,
            Comparer<int>.Create(static (x, y) => y - x)); // descending

        Assert.True(c.Compare("abc", "ab") < 0); // 3 vs 2 descending: 3 comes first → negative
    }

    //--------------------------------------------------------------------------------
    // ProjectionEqualityComparer
    //--------------------------------------------------------------------------------

    [Fact]
    public void ProjectionEqualityComparerEqualsOnKeyEquality()
    {
        var c = Comparers.ProjectionEquality<string, int>(static s => s.Length);

        Assert.True(c.Equals("ab", "cd"));   // same length
        Assert.False(c.Equals("ab", "abc")); // different length
    }

    [Fact]
    public void ProjectionEqualityComparerNullBothAreEqual()
    {
        var c = Comparers.ProjectionEquality<string?, int>(static s => s!.Length);
        Assert.True(c.Equals(null, null));
    }

    [Fact]
    public void ProjectionEqualityComparerNullVsNonNullNotEqual()
    {
        var c = Comparers.ProjectionEquality<string?, int>(static s => s!.Length);
        Assert.False(c.Equals(null, "a"));
        Assert.False(c.Equals("a", null));
    }

    [Fact]
    public void ProjectionEqualityComparerGetHashCodeConsistentWithEquality()
    {
        var c = Comparers.ProjectionEquality<string, int>(static s => s.Length);

        // If two objects are equal, their hash codes must match
        Assert.True(c.Equals("ab", "xy"));
        Assert.Equal(c.GetHashCode("ab"), c.GetHashCode("xy"));
    }

    [Fact]
    public void ProjectionEqualityComparerWithCustomComparerOverload()
    {
        var c = new ProjectionEqualityComparer<string, string>(
            static s => s.ToUpperInvariant(),
            StringComparer.Ordinal);

        Assert.True(c.Equals("hello", "HELLO"));
    }

    //--------------------------------------------------------------------------------
    // ReverseComparer
    //--------------------------------------------------------------------------------

    [Fact]
    public void ReverseComparerInvertsOrder()
    {
        var original = Comparer<int>.Default;
        var reversed = original.Reverse();

        Assert.True(reversed.Compare(1, 2) > 0);   // 1 > 2 in reversed order
        Assert.Equal(0, reversed.Compare(3, 3));
        Assert.True(reversed.Compare(5, 4) < 0);   // 5 < 4 in reversed order
    }

    [Fact]
    public void ReverseComparerCanSortDescending()
    {
        var list = new List<int> { 3, 1, 4, 1, 5 };
        list.Sort(Comparer<int>.Default.Reverse());
        Assert.Equal(new[] { 5, 4, 3, 1, 1 }, list);
    }

    [Fact]
    public void DoubleReverseReturnOriginal()
    {
        var original = Comparer<int>.Default;
        var reversed = original.Reverse();
        var doubleReversed = reversed.Reverse();

        // The library's Reverse extension un-wraps a ReverseComparer<T> and returns the original
        Assert.Same(original, doubleReversed);
    }

    [Fact]
    public void ReverseComparerExposeOriginalComparer()
    {
        var original = Comparer<int>.Default;
        var reversed = (ReverseComparer<int>)original.Reverse();

        Assert.Same(original, reversed.OriginalComparer);
    }
}
