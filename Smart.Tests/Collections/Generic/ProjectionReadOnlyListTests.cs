namespace Smart.Collections.Generic;

public sealed class ProjectionReadOnlyListTests
{
    [Fact]
    public void ProjectionMapsElements()
    {
        var source = new List<int> { 1, 2, 3 };
        var list = new ProjectionReadOnlyList<int, int>(source, static x => x * 2);

        Assert.Equal(3, list.Count);
        Assert.Equal(4, list[1]);
        Assert.Equal([2, 4, 6], list);
    }

    [Fact]
    public void ProjectionIsLazy()
    {
        var source = new List<int> { 1 };
        var list = new ProjectionReadOnlyList<int, int>(source, static x => x * 2);

        source.Add(2);

        Assert.Equal(2, list.Count);
        Assert.Equal([2, 4], list);
    }

    [Fact]
    public void ProjectionEmpty()
    {
        var list = new ProjectionReadOnlyList<int, string>([], static x => x.ToString(System.Globalization.CultureInfo.InvariantCulture));

        Assert.Empty(list);
    }

    [Fact]
    public void AsProjectionCreatesProjection()
    {
        var source = new List<int> { 1, 2, 3 };
        var list = source.AsProjection(static x => x.ToString(System.Globalization.CultureInfo.InvariantCulture));

        Assert.Equal(["1", "2", "3"], list);
    }
}
