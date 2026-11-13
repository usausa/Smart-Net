namespace Smart.IO;

public sealed class PooledBufferWriterTests
{
    //--------------------------------------------------------------------------------
    // Grow
    //--------------------------------------------------------------------------------

    [Fact]
    public void GetSpanGrowsAndKeepsWrittenData()
    {
        using var writer = new PooledBufferWriter<byte>(16);
        var initialCapacity = writer.Capacity;

        var expected = new List<byte>();
        for (var i = 0; i < 100; i++)
        {
            var span = writer.GetSpan(10);
            for (var j = 0; j < 10; j++)
            {
                span[j] = (byte)expected.Count;
                expected.Add((byte)expected.Count);
            }

            writer.Advance(10);
        }

        Assert.True(writer.Capacity > initialCapacity);
        Assert.Equal(1000, writer.WrittenCount);
        Assert.Equal(expected.ToArray(), writer.WrittenSpan.ToArray());
    }

    [Fact]
    public void GetMemoryGrowsAndKeepsWrittenData()
    {
        using var writer = new PooledBufferWriter<int>(4);

        for (var i = 0; i < 100; i++)
        {
            writer.GetMemory(1).Span[0] = i;
            writer.Advance(1);
        }

        Assert.Equal(100, writer.WrittenCount);
        Assert.Equal(Enumerable.Range(0, 100).ToArray(), writer.WrittenMemory.ToArray());
    }
}
