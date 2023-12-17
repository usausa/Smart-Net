namespace Smart.Linq;

using Xunit;

public sealed class OptimizedEnumerableTest
{
    //--------------------------------------------------------------------------------
    // All
    //--------------------------------------------------------------------------------

    [Fact]
    public void TestAllSpan()
    {
        var source = new Span<int>([1, 2, 3, 4, 5]);
        Assert.False(source.All(static x => x >= 3));
        Assert.True(source[2..5].All(static x => x >= 3));
        Assert.True(source[2..].All(static x => x >= 3));
        Assert.False(source[2..5].All(static x => x < 5));
    }

    [Fact]
    public void TestAllArray()
    {
        var source = new[] { 1, 2, 3, 4, 5 };
        Assert.False(source.All(static x => x >= 3));
        Assert.True(source.All(2, 3, static x => x >= 3));
        Assert.True(source.All(2, 5, static x => x >= 3));
        Assert.False(source.All(2, 3, static x => x < 5));
    }

    [Fact]
    public void TestAllList()
    {
        var source = new List<int>(new[] { 1, 2, 3, 4, 5 });
        Assert.False(source.All(static x => x >= 3));
        Assert.True(source.All(2, 3, static x => x >= 3));
        Assert.True(source.All(2, 5, static x => x >= 3));
        Assert.False(source.All(2, 3, static x => x < 5));
    }

    //--------------------------------------------------------------------------------
    // Any
    //--------------------------------------------------------------------------------

    [Fact]
    public void TestAnySpan()
    {
        var source = new Span<int>([1, 2, 3, 4, 5]);
        Assert.True(source.Any(static x => x >= 3));
        Assert.True(source[2..5].Any(static x => x >= 3));
        Assert.True(source[2..].Any(static x => x >= 3));
        Assert.False(source[2..5].Any(static x => x < 3));
    }

    [Fact]
    public void TestAnyArray()
    {
        var source = new[] { 1, 2, 3, 4, 5 };
        Assert.True(source.Any(static x => x >= 3));
        Assert.True(source.Any(2, 3, static x => x >= 3));
        Assert.True(source.Any(2, 5, static x => x >= 3));
        Assert.False(source.Any(2, 3, static x => x < 3));
    }

    [Fact]
    public void TestAnyList()
    {
        var source = new List<int>(new[] { 1, 2, 3, 4, 5 });
        Assert.True(source.Any(static x => x >= 3));
        Assert.True(source.Any(2, 3, static x => x >= 3));
        Assert.True(source.Any(2, 5, static x => x >= 3));
        Assert.False(source.Any(2, 3, static x => x < 3));
    }
}
