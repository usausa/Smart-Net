namespace Smart.Linq;

public sealed class EnumerableExtensionsBatchTest
{
    //--------------------------------------------------------------------------------
    // Batch<T>
    //--------------------------------------------------------------------------------

    [Fact]
    public void BatchEmptySourceYieldsNoBatches()
    {
        var result = Enumerable.Empty<int>().Batch(3).ToList();

        Assert.Empty(result);
    }

    [Fact]
    public void BatchSingleElementYieldsOneBatch()
    {
        var result = new[] { 42 }.Batch(5).ToList();

        Assert.Single(result);
        Assert.Equal([42], result[0]);
    }

    [Fact]
    public void BatchExactSizeYieldsOneBatch()
    {
        var result = new[] { 1, 2, 3 }.Batch(3).ToList();

        Assert.Single(result);
        Assert.Equal(new[] { 1, 2, 3 }, result[0]);
    }

    [Fact]
    public void BatchMultipleFullBatches()
    {
        var result = new[] { 1, 2, 3, 4, 5, 6 }.Batch(2).ToList();

        Assert.Equal(3, result.Count);
        Assert.Equal(new[] { 1, 2 }, result[0]);
        Assert.Equal(new[] { 3, 4 }, result[1]);
        Assert.Equal(new[] { 5, 6 }, result[2]);
    }

    [Fact]
    public void BatchWithRemainder()
    {
        var result = new[] { 1, 2, 3, 4, 5 }.Batch(3).ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 1, 2, 3 }, result[0]);
        Assert.Equal(new[] { 4, 5 }, result[1]);
    }

    [Fact]
    public void BatchSizeOfOneYieldsOnePerElement()
    {
        var result = new[] { 10, 20, 30 }.Batch(1).ToList();

        Assert.Equal(3, result.Count);
        Assert.Equal(new[] { 10 }, result[0]);
        Assert.Equal(new[] { 20 }, result[1]);
        Assert.Equal(new[] { 30 }, result[2]);
    }

    [Fact]
    public void BatchSizeLargerThanSourceYieldsSingleBatch()
    {
        var result = new[] { 1, 2 }.Batch(10).ToList();

        Assert.Single(result);
        Assert.Equal(new[] { 1, 2 }, result[0]);
    }

    [Fact]
    public void BatchLastChunkIsTrimmedToActualCount()
    {
        var result = new[] { 1, 2, 3, 4, 5 }.Batch(3).ToList();

        Assert.Equal(2, result[1].Length); // remainder is 2, not 3
    }

    [Fact]
    public void BatchIsLazyNoSideEffectsBeforeEnumeration()
    {
        var counter = 0;

        IEnumerable<int> Produce()
        {
            counter++;
            yield return 1;
            yield return 2;
        }

        var query = Produce().Batch(2);

        Assert.Equal(0, counter); // iterator not yet started

        var batches = query.ToList();
        Assert.NotEmpty(batches);
        Assert.True(counter > 0);
    }

    //--------------------------------------------------------------------------------
    // Batch<TSource, TResult> (with selector)
    //--------------------------------------------------------------------------------

    [Fact]
    public void BatchWithSelectorEmptySourceYieldsNoBatches()
    {
        var result = Enumerable.Empty<int>().Batch(3, static x => x * 2).ToList();

        Assert.Empty(result);
    }

    [Fact]
    public void BatchWithSelectorTransformsElements()
    {
        var result = new[] { 1, 2, 3, 4 }.Batch(2, static x => x * 10).ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 10, 20 }, result[0]);
        Assert.Equal(new[] { 30, 40 }, result[1]);
    }

    [Fact]
    public void BatchWithSelectorRemainder()
    {
        var result = new[] { 1, 2, 3, 4, 5 }.Batch(2, static x => x.ToString(System.Globalization.CultureInfo.InvariantCulture)).ToList();

        Assert.Equal(3, result.Count);
        Assert.Equal(["1", "2"], result[0]);
        Assert.Equal(["3", "4"], result[1]);
        Assert.Equal(["5"], result[2]);
    }
}
