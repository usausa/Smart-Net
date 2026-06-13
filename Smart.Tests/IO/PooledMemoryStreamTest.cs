namespace Smart.IO;

using System.Buffers;

public sealed class PooledMemoryStreamTest
{
    //--------------------------------------------------------------------------------
    // Write / Read
    //--------------------------------------------------------------------------------

    [Fact]
    public void WriteReadRoundTrip()
    {
        using var ms = new PooledMemoryStream();
        var data = new byte[] { 1, 2, 3, 4, 5 };

        ms.Write(data, 0, data.Length);
        Assert.Equal(5L, ms.Length);
        Assert.Equal(5L, ms.Position);

        ms.Position = 0;
        var buf = new byte[5];
        var read = ms.Read(buf, 0, buf.Length);
        Assert.Equal(5, read);
        Assert.Equal(data, buf);
    }

    [Fact]
    public void WriteReadSpanRoundTrip()
    {
        using var ms = new PooledMemoryStream();
        ReadOnlySpan<byte> data = [10, 20, 30];

        ms.Write(data);
        ms.Position = 0;

        var buf = new byte[3];
        var read = ms.Read(buf.AsSpan());
        Assert.Equal(3, read);
        Assert.Equal(new byte[] { 10, 20, 30 }, buf);
    }

    [Fact]
    public void PartialReadReturnsAvailableBytes()
    {
        using var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3], 0, 3);
        ms.Position = 1;

        var buf = new byte[10];
        var read = ms.Read(buf, 0, buf.Length);
        Assert.Equal(2, read);
        Assert.Equal(2, buf[0]);
        Assert.Equal(3, buf[1]);
    }

    [Fact]
    public void ReadAtEndReturnsZero()
    {
        using var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3], 0, 3);

        var buf = new byte[5];
        var read = ms.Read(buf, 0, buf.Length);
        Assert.Equal(0, read);
    }

    //--------------------------------------------------------------------------------
    // Position / Seek / SetLength
    //--------------------------------------------------------------------------------

    [Fact]
    public void SeekFromBegin()
    {
        using var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3, 4, 5], 0, 5);

        var result = ms.Seek(2, SeekOrigin.Begin);
        Assert.Equal(2L, result);
        Assert.Equal(2L, ms.Position);
    }

    [Fact]
    public void SeekFromCurrent()
    {
        using var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3, 4, 5], 0, 5);
        ms.Position = 2;

        var result = ms.Seek(1, SeekOrigin.Current);
        Assert.Equal(3L, result);
    }

    [Fact]
    public void SeekFromEnd()
    {
        using var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3, 4, 5], 0, 5);

        // Stream contract: offset is relative to the end, so negative values move backwards
        var result = ms.Seek(-2, SeekOrigin.End);
        Assert.Equal(3L, result);

        var end = ms.Seek(0, SeekOrigin.End);
        Assert.Equal(5L, end);
    }

    [Fact]
    public void SeekOutOfRangeThrows()
    {
        using var ms = new PooledMemoryStream(16);

        // Seeking beyond capacity should throw
        Assert.Throws<ArgumentOutOfRangeException>(() => ms.Seek(int.MaxValue, SeekOrigin.Begin));
    }

    [Fact]
    public void SetLengthExpandsStream()
    {
        using var ms = new PooledMemoryStream();
        ms.SetLength(100);

        Assert.Equal(100L, ms.Length);
    }

    [Fact]
    public void SetLengthClampsPosition()
    {
        using var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3, 4, 5], 0, 5);
        // Position is now 5

        ms.SetLength(3);
        Assert.Equal(3L, ms.Length);
        // Position must be clamped to Length
        Assert.Equal(3L, ms.Position);
    }

    [Fact]
    public void SetLengthThenWriteFromCurrent()
    {
        using var ms = new PooledMemoryStream();
        ms.SetLength(10);
        ms.Position = 0;
        ms.Write([9, 8, 7], 0, 3);

        Assert.Equal(10L, ms.Length);
        ms.Position = 0;
        var buf = new byte[3];
        ms.ReadExactly(buf, 0, 3);
        Assert.Equal(new byte[] { 9, 8, 7 }, buf);
    }

    [Fact]
    public void SetLengthNegativeThrows()
    {
        using var ms = new PooledMemoryStream();
        Assert.Throws<ArgumentOutOfRangeException>(() => ms.SetLength(-1L));
    }

    //--------------------------------------------------------------------------------
    // Capacity expansion boundary
    //--------------------------------------------------------------------------------

    [Fact]
    public void WriteExactInitialCapacity()
    {
        using var ms = new PooledMemoryStream(8);
        // ArrayPool may return a larger buffer, but we test with exactly 8 bytes written
        var data = new byte[8];
        for (var i = 0; i < data.Length; i++)
        {
            data[i] = (byte)i;
        }

        ms.Write(data, 0, data.Length);
        Assert.Equal(8L, ms.Length);

        ms.Position = 0;
        var buf = new byte[8];
        ms.ReadExactly(buf, 0, buf.Length);
        Assert.Equal(data, buf);
    }

    [Fact]
    public void WriteOneByteOverInitialCapacity()
    {
        // Use a capacity that ArrayPool will satisfy exactly (power-of-two)
        using var ms = new PooledMemoryStream(16);
        var data = new byte[17];
        for (var i = 0; i < data.Length; i++)
        {
            data[i] = (byte)(i + 1);
        }

        ms.Write(data, 0, data.Length);
        Assert.Equal(17L, ms.Length);

        ms.Position = 0;
        var buf = new byte[17];
        ms.ReadExactly(buf, 0, buf.Length);
        Assert.Equal(data, buf);
    }

    [Fact]
    public void WriteLargeData()
    {
        using var ms = new PooledMemoryStream(16);
        var data = new byte[10_000];
        for (var i = 0; i < data.Length; i++)
        {
            data[i] = (byte)(i & 0xFF);
        }

        ms.Write(data, 0, data.Length);
        Assert.Equal(10_000L, ms.Length);

        ms.Position = 0;
        var buf = new byte[10_000];
        var read = ms.Read(buf, 0, buf.Length);
        Assert.Equal(10_000, read);
        Assert.Equal(data, buf);
    }

    [Fact]
    public void MultipleWritesAccumulate()
    {
        using var ms = new PooledMemoryStream(4);
        ms.Write([1, 2], 0, 2);
        ms.Write([3, 4], 0, 2);
        ms.Write([5], 0, 1);

        Assert.Equal(5L, ms.Length);

        ms.Position = 0;
        var buf = new byte[5];
        ms.ReadExactly(buf, 0, buf.Length);
        Assert.Equal(new byte[] { 1, 2, 3, 4, 5 }, buf);
    }

    //--------------------------------------------------------------------------------
    // Dispose behaviour
    //--------------------------------------------------------------------------------

    [Fact]
    public void DoubleDisposeDoesNotThrow()
    {
        var ms = new PooledMemoryStream();
        ms.Dispose();
        ms.Dispose(); // must not throw
    }

    [Fact]
    public void StreamPropertiesAfterDispose()
    {
        var ms = new PooledMemoryStream();
        ms.Dispose();

        // Stream contract: a closed stream reports false for CanRead/CanWrite/CanSeek
        Assert.False(ms.CanRead);
        Assert.False(ms.CanWrite);
        Assert.False(ms.CanSeek);
    }

    //--------------------------------------------------------------------------------
    // GetRawBuffer
    //--------------------------------------------------------------------------------

    [Fact]
    public void GetRawBufferReturnsNonNull()
    {
        using var ms = new PooledMemoryStream();
        var buf = ms.GetRawBuffer();
        Assert.NotNull(buf);
        Assert.True(buf.Length > 0);
    }

    //--------------------------------------------------------------------------------
    // CanXxx / Flush
    //--------------------------------------------------------------------------------

    [Fact]
    public void CanReadWriteSeekAreTrue()
    {
        using var ms = new PooledMemoryStream();
        Assert.True(ms.CanRead);
        Assert.True(ms.CanWrite);
        Assert.True(ms.CanSeek);
    }

    [Fact]
    public void FlushDoesNotThrow()
    {
        using var ms = new PooledMemoryStream();
        ms.Flush(); // no-op; should not throw
    }

    //--------------------------------------------------------------------------------
    // Custom ArrayPool constructor
    //--------------------------------------------------------------------------------

    [Fact]
    public void CustomPoolConstructorIsUsed()
    {
        // Verify that the two-argument constructor accepting a pool doesn't throw
        using var ms = new PooledMemoryStream(ArrayPool<byte>.Shared, 64);
        ms.Write([42], 0, 1);
        ms.Position = 0;
        var buf = new byte[1];
        ms.ReadExactly(buf, 0, 1);
        Assert.Equal(42, buf[0]);
    }
}
