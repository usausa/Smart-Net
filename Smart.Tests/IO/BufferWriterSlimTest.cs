namespace Smart.IO;

public sealed class BufferWriterSlimTest
{
    //--------------------------------------------------------------------------------
    // Initial state
    //--------------------------------------------------------------------------------

    [Fact]
    public void InitialStateIsEmpty()
    {
        Span<byte> initial = stackalloc byte[16];
        var writer = new BufferWriterSlim<byte>(initial);

        Assert.Equal(0, writer.WrittenCount);
        Assert.Equal(16, writer.FreeCapacity);
        Assert.Equal(0, writer.WrittenSpan.Length);

        writer.Dispose();
    }

    //--------------------------------------------------------------------------------
    // Write(T value)
    //--------------------------------------------------------------------------------

    [Fact]
    public void WriteSingleValues()
    {
        Span<byte> initial = stackalloc byte[4];
        var writer = new BufferWriterSlim<byte>(initial);

        writer.Write(1);
        writer.Write(2);
        writer.Write(3);

        Assert.Equal(3, writer.WrittenCount);
        Assert.Equal(new byte[] { 1, 2, 3 }, writer.WrittenSpan.ToArray());

        writer.Dispose();
    }

    [Fact]
    public void WriteSingleValueBeyondInitialCapacityGrows()
    {
        Span<byte> initial = stackalloc byte[2];
        var writer = new BufferWriterSlim<byte>(initial);

        writer.Write(1);
        writer.Write(2);
        // This exceeds initial capacity — internal growth must occur
        writer.Write(3);

        Assert.Equal(3, writer.WrittenCount);
        Assert.Equal(new byte[] { 1, 2, 3 }, writer.WrittenSpan.ToArray());

        writer.Dispose();
    }

    //--------------------------------------------------------------------------------
    // Write(ReadOnlySpan<T>)
    //--------------------------------------------------------------------------------

    [Fact]
    public void WriteSpanFitsInInitialBuffer()
    {
        Span<byte> initial = stackalloc byte[8];
        var writer = new BufferWriterSlim<byte>(initial);

        ReadOnlySpan<byte> src = [10, 20, 30];
        writer.Write(src);

        Assert.Equal(3, writer.WrittenCount);
        Assert.Equal(new byte[] { 10, 20, 30 }, writer.WrittenSpan.ToArray());

        writer.Dispose();
    }

    [Fact]
    public void WriteSpanExceedsInitialCapacityGrows()
    {
        Span<byte> initial = stackalloc byte[4];
        var writer = new BufferWriterSlim<byte>(initial);

        ReadOnlySpan<byte> src = [1, 2, 3, 4, 5, 6, 7, 8];
        writer.Write(src);

        Assert.Equal(8, writer.WrittenCount);
        Assert.Equal(src.ToArray(), writer.WrittenSpan.ToArray());

        writer.Dispose();
    }

    //--------------------------------------------------------------------------------
    // GetSpan / Advance
    //--------------------------------------------------------------------------------

    [Fact]
    public void GetSpanDefaultHintReturnsAtLeastOne()
    {
        Span<byte> initial = stackalloc byte[8];
        var writer = new BufferWriterSlim<byte>(initial);

        var span = writer.GetSpan();
        Assert.True(span.Length >= 1);

        writer.Dispose();
    }

    [Fact]
    public void GetSpanWithHintReturnsSufficientSize()
    {
        Span<byte> initial = stackalloc byte[8];
        var writer = new BufferWriterSlim<byte>(initial);

        var span = writer.GetSpan(6);
        Assert.True(span.Length >= 6);

        writer.Dispose();
    }

    [Fact]
    public void GetSpanAndAdvanceProducesCorrectData()
    {
        Span<byte> initial = stackalloc byte[8];
        var writer = new BufferWriterSlim<byte>(initial);

        var span = writer.GetSpan(3);
        span[0] = 7;
        span[1] = 8;
        span[2] = 9;
        writer.Advance(3);

        Assert.Equal(3, writer.WrittenCount);
        Assert.Equal(new byte[] { 7, 8, 9 }, writer.WrittenSpan.ToArray());

        writer.Dispose();
    }

    [Fact]
    public void GetSpanRequiresSizeGrowsBuffer()
    {
        Span<byte> initial = stackalloc byte[4];
        var writer = new BufferWriterSlim<byte>(initial);

        // Request more than the initial capacity
        var span = writer.GetSpan(16);
        Assert.True(span.Length >= 16);

        for (var i = 0; i < 16; i++)
        {
            span[i] = (byte)i;
        }

        writer.Advance(16);

        Assert.Equal(16, writer.WrittenCount);

        var expected = new byte[16];
        for (var i = 0; i < 16; i++)
        {
            expected[i] = (byte)i;
        }

        Assert.Equal(expected, writer.WrittenSpan.ToArray());

        writer.Dispose();
    }

    [Fact]
    public void MultipleGetSpanAdvanceCyclesAreConsistent()
    {
        Span<byte> initial = stackalloc byte[4];
        var writer = new BufferWriterSlim<byte>(initial);

        for (var chunk = 0; chunk < 5; chunk++)
        {
            var span = writer.GetSpan(2);
            span[0] = (byte)(chunk * 2);
            span[1] = (byte)((chunk * 2) + 1);
            writer.Advance(2);
        }

        Assert.Equal(10, writer.WrittenCount);

        var expected = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Assert.Equal(expected, writer.WrittenSpan.ToArray());

        writer.Dispose();
    }

    //--------------------------------------------------------------------------------
    // Clear
    //--------------------------------------------------------------------------------

    [Fact]
    public void ClearResetsWrittenCount()
    {
        Span<byte> initial = stackalloc byte[8];
        var writer = new BufferWriterSlim<byte>(initial);

        writer.Write(1);
        writer.Write(2);
        writer.Clear();

        Assert.Equal(0, writer.WrittenCount);
        Assert.Equal(0, writer.WrittenSpan.Length);

        // Writer is still usable after Clear
        writer.Write(99);
        Assert.Equal(1, writer.WrittenCount);
        Assert.Equal(99, writer.WrittenSpan[0]);

        writer.Dispose();
    }

    //--------------------------------------------------------------------------------
    // Dispose
    //--------------------------------------------------------------------------------

    [Fact]
    public void DisposeReturnsBorrowedArray()
    {
        // Force heap allocation by using a zero-length initial buffer
        Span<byte> initial = [];
        var writer = new BufferWriterSlim<byte>(initial);

        writer.Write(42);
        // Dispose should return the rented array to ArrayPool without exception
        writer.Dispose();
    }

    [Fact]
    public void DisposeWithNoHeapAllocationDoesNotThrow()
    {
        Span<byte> initial = stackalloc byte[8];
        var writer = new BufferWriterSlim<byte>(initial);
        writer.Write(1);
        writer.Dispose(); // buffer is on stack — nothing to return
    }

    //--------------------------------------------------------------------------------
    // WrittenSpanMutable
    //--------------------------------------------------------------------------------

    [Fact]
    public void WrittenSpanMutableAllowsEditing()
    {
        Span<byte> initial = stackalloc byte[8];
        var writer = new BufferWriterSlim<byte>(initial);

        writer.Write([1, 2, 3]);
        writer.WrittenSpanMutable[1] = 99;

        Assert.Equal(new byte[] { 1, 99, 3 }, writer.WrittenSpan.ToArray());

        writer.Dispose();
    }

    //--------------------------------------------------------------------------------
    // Non-byte generic (int)
    //--------------------------------------------------------------------------------

    [Fact]
    public void WorksWithIntType()
    {
        Span<int> initial = stackalloc int[4];
        var writer = new BufferWriterSlim<int>(initial);

        writer.Write(100);
        writer.Write(200);
        writer.Write(300);

        Assert.Equal(3, writer.WrittenCount);
        Assert.Equal(new[] { 100, 200, 300 }, writer.WrittenSpan.ToArray());

        writer.Dispose();
    }
}
