namespace Smart.IO;

public sealed class SpanReaderTest
{
    //--------------------------------------------------------------------------------
    // Properties
    //--------------------------------------------------------------------------------

    [Fact]
    public void InitialPropertiesAreCorrect()
    {
        ReadOnlySpan<byte> data = [1, 2, 3, 4, 5];
        var reader = new SpanReader<byte>(data);

        Assert.Equal(5, reader.Length);
        Assert.Equal(0, reader.Position);
        Assert.Equal(0, reader.Consumed);
        Assert.Equal(5, reader.Remaining);
    }

    [Fact]
    public void EmptySpanProperties()
    {
        var reader = new SpanReader<byte>([]);

        Assert.Equal(0, reader.Length);
        Assert.Equal(0, reader.Remaining);
        Assert.Equal(0, reader.Consumed);
    }

    //--------------------------------------------------------------------------------
    // Read() — single element
    //--------------------------------------------------------------------------------

    [Fact]
    public void ReadSingleElements()
    {
        ReadOnlySpan<byte> data = [10, 20, 30];
        var reader = new SpanReader<byte>(data);

        Assert.Equal(10, reader.Read());
        Assert.Equal(1, reader.Consumed);
        Assert.Equal(20, reader.Read());
        Assert.Equal(30, reader.Read());
        Assert.Equal(3, reader.Consumed);
        Assert.Equal(0, reader.Remaining);
    }

    [Fact]
    public void ReadAtEndThrows()
    {
        ReadOnlySpan<byte> data = [1];
        var reader = new SpanReader<byte>(data);
        _ = reader.Read(); // consume the only element

        try
        {
            _ = reader.Read();
            Assert.Fail("Expected InvalidOperationException");
        }
        catch (InvalidOperationException)
        {
            // expected
        }
    }

    [Fact]
    public void ReadOnEmptySpanThrows()
    {
        var reader = new SpanReader<byte>([]);

        try
        {
            _ = reader.Read();
            Assert.Fail("Expected InvalidOperationException");
        }
        catch (InvalidOperationException)
        {
            // expected
        }
    }

    //--------------------------------------------------------------------------------
    // Read(int count)
    //--------------------------------------------------------------------------------

    [Fact]
    public void ReadCountReturnsSlice()
    {
        ReadOnlySpan<byte> data = [1, 2, 3, 4, 5];
        var reader = new SpanReader<byte>(data);

        var slice = reader.Read(3);
        Assert.Equal(3, slice.Length);
        Assert.Equal(new byte[] { 1, 2, 3 }, slice.ToArray());
        Assert.Equal(2, reader.Remaining);
    }

    [Fact]
    public void ReadCountExactlyRemaining()
    {
        ReadOnlySpan<byte> data = [7, 8];
        var reader = new SpanReader<byte>(data);

        var slice = reader.Read(2);
        Assert.Equal(2, slice.Length);
        Assert.Equal(0, reader.Remaining);
    }

    [Fact]
    public void ReadCountBeyondRemainingThrows()
    {
        ReadOnlySpan<byte> data = [1, 2];
        var reader = new SpanReader<byte>(data);

        try
        {
            _ = reader.Read(3);
            Assert.Fail("Expected InvalidOperationException");
        }
        catch (InvalidOperationException)
        {
            // expected
        }
    }

    //--------------------------------------------------------------------------------
    // TryRead
    //--------------------------------------------------------------------------------

    [Fact]
    public void TryReadSingleSucceeds()
    {
        ReadOnlySpan<byte> data = [42];
        var reader = new SpanReader<byte>(data);

        var ok = reader.TryRead(out var value);
        Assert.True(ok);
        Assert.Equal(42, value);
    }

    [Fact]
    public void TryReadSingleAtEndFails()
    {
        var reader = new SpanReader<byte>([]);

        var ok = reader.TryRead(out var value);
        Assert.False(ok);
        Assert.Equal(default, value);
    }

    [Fact]
    public void TryReadCountSucceeds()
    {
        ReadOnlySpan<byte> data = [1, 2, 3, 4];
        var reader = new SpanReader<byte>(data);

        var ok = reader.TryRead(2, out var result);
        Assert.True(ok);
        Assert.Equal(2, result.Length);
        Assert.Equal(2, reader.Remaining);
    }

    [Fact]
    public void TryReadCountBeyondRemainingFails()
    {
        ReadOnlySpan<byte> data = [1, 2];
        var reader = new SpanReader<byte>(data);

        var ok = reader.TryRead(5, out var result);
        Assert.False(ok);
        Assert.Equal(0, result.Length);
        // Position must not advance on failure
        Assert.Equal(0, reader.Consumed);
    }

    //--------------------------------------------------------------------------------
    // Skip
    //--------------------------------------------------------------------------------

    [Fact]
    public void SkipAdvancesPosition()
    {
        ReadOnlySpan<byte> data = [1, 2, 3, 4, 5];
        var reader = new SpanReader<byte>(data);

        reader.Skip(3);
        Assert.Equal(3, reader.Consumed);
        Assert.Equal(2, reader.Remaining);
    }

    [Fact]
    public void SkipBeyondLengthThrows()
    {
        ReadOnlySpan<byte> data = [1, 2];
        var reader = new SpanReader<byte>(data);

        try
        {
            reader.Skip(3);
            Assert.Fail("Expected ArgumentOutOfRangeException");
        }
        catch (ArgumentOutOfRangeException)
        {
            // expected
        }
    }

    //--------------------------------------------------------------------------------
    // ReadToEnd
    //--------------------------------------------------------------------------------

    [Fact]
    public void ReadToEndConsumesAll()
    {
        ReadOnlySpan<byte> data = [5, 6, 7];
        var reader = new SpanReader<byte>(data);

        reader.Skip(1);
        var rest = reader.ReadToEnd();
        Assert.Equal(new byte[] { 6, 7 }, rest.ToArray());
        Assert.Equal(0, reader.Remaining);
    }

    //--------------------------------------------------------------------------------
    // ConsumedSpan / RemainingSpan
    //--------------------------------------------------------------------------------

    [Fact]
    public void ConsumedSpanMatchesConsumed()
    {
        ReadOnlySpan<byte> data = [1, 2, 3, 4];
        var reader = new SpanReader<byte>(data);

        reader.Skip(2);
        Assert.Equal(new byte[] { 1, 2 }, reader.ConsumedSpan.ToArray());
    }

    [Fact]
    public void RemainingSpanMatchesRemaining()
    {
        ReadOnlySpan<byte> data = [1, 2, 3, 4];
        var reader = new SpanReader<byte>(data);

        reader.Skip(2);
        Assert.Equal(new byte[] { 3, 4 }, reader.RemainingSpan.ToArray());
    }

    //--------------------------------------------------------------------------------
    // Position setter
    //--------------------------------------------------------------------------------

    [Fact]
    public void PositionSetterMovesCorrectly()
    {
        ReadOnlySpan<byte> data = [1, 2, 3, 4, 5];
        var reader = new SpanReader<byte>(data) { Position = 3 };

        Assert.Equal(3, reader.Consumed);
        Assert.Equal(2, reader.Remaining);
    }

    [Fact]
    public void PositionSetterToLengthIsAllowed()
    {
        ReadOnlySpan<byte> data = [1, 2, 3];
        var reader = new SpanReader<byte>(data) { Position = 3 };

        Assert.Equal(0, reader.Remaining);
    }

    [Fact]
    public void PositionSetterBeyondLengthThrows()
    {
        ReadOnlySpan<byte> data = [1, 2, 3];
        var reader = new SpanReader<byte>(data);

        try
        {
            reader.Position = 4;
            Assert.Fail("Expected ArgumentOutOfRangeException");
        }
        catch (ArgumentOutOfRangeException)
        {
            // expected
        }
    }

    //--------------------------------------------------------------------------------
    // ReadUnmanaged (little-endian byte representation)
    //--------------------------------------------------------------------------------

    [Fact]
    public void ReadUnmanagedInt32LittleEndian()
    {
        // 0x01020304 stored in little-endian: 04 03 02 01
        ReadOnlySpan<byte> data = [0x04, 0x03, 0x02, 0x01];
        var reader = new SpanReader<byte>(data);

        var value = reader.ReadUnmanaged<int>();
        Assert.Equal(0x01020304, value);
        Assert.Equal(0, reader.Remaining);
    }

    [Fact]
    public void ReadUnmanagedUInt16()
    {
        ReadOnlySpan<byte> data = [0xAB, 0xCD];
        var reader = new SpanReader<byte>(data);

        var value = reader.ReadUnmanaged<ushort>();
        Assert.Equal((ushort)0xCDAB, value);
        Assert.Equal(0, reader.Remaining);
    }

    [Fact]
    public void ReadUnmanagedAtEndThrows()
    {
        ReadOnlySpan<byte> data = [1, 2]; // only 2 bytes
        var reader = new SpanReader<byte>(data);

        try
        {
            _ = reader.ReadUnmanaged<int>(); // needs 4
            Assert.Fail("Expected InvalidOperationException");
        }
        catch (InvalidOperationException)
        {
            // expected
        }
    }
}
