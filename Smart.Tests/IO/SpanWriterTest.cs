namespace Smart.IO;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public sealed class SpanWriterTest
{
    //--------------------------------------------------------------------------------
    // Properties
    //--------------------------------------------------------------------------------

    [Fact]
    public void InitialPropertiesAreCorrect()
    {
        Span<byte> buf = stackalloc byte[8];
        var writer = new SpanWriter<byte>(buf);

        Assert.Equal(8, writer.Length);
        Assert.Equal(0, writer.Position);
        Assert.Equal(0, writer.WrittenCount);
        Assert.Equal(8, writer.FreeCapacity);
    }

    [Fact]
    public void EmptySpanProperties()
    {
        var writer = new SpanWriter<byte>([]);

        Assert.Equal(0, writer.Length);
        Assert.Equal(0, writer.FreeCapacity);
    }

    //--------------------------------------------------------------------------------
    // Write(T value)
    //--------------------------------------------------------------------------------

    [Fact]
    public void WriteSingleValues()
    {
        Span<byte> buf = stackalloc byte[4];
        var writer = new SpanWriter<byte>(buf);

        writer.Write(1);
        writer.Write(2);
        writer.Write(3);

        Assert.Equal(3, writer.WrittenCount);
        Assert.Equal(new byte[] { 1, 2, 3 }, writer.WrittenSpan.ToArray());
    }

    [Fact]
    public void WriteAtCapacityThrows()
    {
        Span<byte> buf = stackalloc byte[2];
        var writer = new SpanWriter<byte>(buf);

        writer.Write(1);
        writer.Write(2);

        // No capacity remaining
        try
        {
            writer.Write(3);
            Assert.Fail("Expected InvalidOperationException");
        }
        catch (InvalidOperationException)
        {
            // expected
        }
    }

    [Fact]
    public void WriteOnEmptySpanThrows()
    {
        var writer = new SpanWriter<byte>([]);

        try
        {
            writer.Write(1);
            Assert.Fail("Expected InvalidOperationException");
        }
        catch (InvalidOperationException)
        {
            // expected
        }
    }

    //--------------------------------------------------------------------------------
    // Write(ReadOnlySpan<T>)
    //--------------------------------------------------------------------------------

    [Fact]
    public void WriteSpanSucceeds()
    {
        Span<byte> buf = stackalloc byte[8];
        var writer = new SpanWriter<byte>(buf);

        ReadOnlySpan<byte> src = [10, 20, 30];
        writer.Write(src);

        Assert.Equal(3, writer.WrittenCount);
        Assert.Equal(new byte[] { 10, 20, 30 }, writer.WrittenSpan.ToArray());
    }

    [Fact]
    public void WriteSpanExceedsCapacityThrows()
    {
        Span<byte> buf = stackalloc byte[2];
        var writer = new SpanWriter<byte>(buf);
        ReadOnlySpan<byte> src = [1, 2, 3];

        try
        {
            writer.Write(src);
            Assert.Fail("Expected InvalidOperationException");
        }
        catch (InvalidOperationException)
        {
            // expected
        }
    }

    //--------------------------------------------------------------------------------
    // TryWrite
    //--------------------------------------------------------------------------------

    [Fact]
    public void TryWriteSingleSucceeds()
    {
        Span<byte> buf = stackalloc byte[4];
        var writer = new SpanWriter<byte>(buf);

        var ok = writer.TryWrite(42);
        Assert.True(ok);
        Assert.Equal(1, writer.WrittenCount);
    }

    [Fact]
    public void TryWriteSingleAtEndFails()
    {
        Span<byte> buf = stackalloc byte[1];
        var writer = new SpanWriter<byte>(buf);
        writer.Write(1);

        var ok = writer.TryWrite(2);
        Assert.False(ok);
        Assert.Equal(1, writer.WrittenCount);
    }

    [Fact]
    public void TryWriteSpanSucceeds()
    {
        Span<byte> buf = stackalloc byte[8];
        var writer = new SpanWriter<byte>(buf);

        ReadOnlySpan<byte> src = [1, 2, 3];
        var ok = writer.TryWrite(src);
        Assert.True(ok);
        Assert.Equal(3, writer.WrittenCount);
    }

    [Fact]
    public void TryWriteSpanExceedsFails()
    {
        Span<byte> buf = stackalloc byte[2];
        var writer = new SpanWriter<byte>(buf);
        ReadOnlySpan<byte> src = [1, 2, 3];

        var ok = writer.TryWrite(src);
        Assert.False(ok);
        // Position must not advance on failure
        Assert.Equal(0, writer.WrittenCount);
    }

    //--------------------------------------------------------------------------------
    // Slide
    //--------------------------------------------------------------------------------

    [Fact]
    public void SlideReturnsCorrectSpan()
    {
        Span<byte> buf = stackalloc byte[8];
        var writer = new SpanWriter<byte>(buf);

        var slice = writer.Slide(3);
        slice[0] = 7;
        slice[1] = 8;
        slice[2] = 9;

        Assert.Equal(3, writer.WrittenCount);
        Assert.Equal(new byte[] { 7, 8, 9 }, writer.WrittenSpan.ToArray());
    }

    [Fact]
    public void SlideBeyondCapacityThrows()
    {
        Span<byte> buf = stackalloc byte[2];
        var writer = new SpanWriter<byte>(buf);

        try
        {
            _ = writer.Slide(3);
            Assert.Fail("Expected ArgumentOutOfRangeException");
        }
        catch (ArgumentOutOfRangeException)
        {
            // expected
        }
    }

    //--------------------------------------------------------------------------------
    // Fill
    //--------------------------------------------------------------------------------

    [Fact]
    public void FillFillsRemainingCapacity()
    {
        Span<byte> buf = stackalloc byte[5];
        var writer = new SpanWriter<byte>(buf);

        writer.Write(1);
        writer.Fill(0xFF);

        Assert.Equal(5, writer.WrittenCount);
        Assert.Equal(0, writer.FreeCapacity);

        var written = writer.WrittenSpan.ToArray();
        Assert.Equal(1, written[0]);
        Assert.Equal(0xFF, written[1]);
        Assert.Equal(0xFF, written[2]);
        Assert.Equal(0xFF, written[3]);
        Assert.Equal(0xFF, written[4]);
    }

    [Fact]
    public void FillOnFullBufferDoesNothing()
    {
        Span<byte> buf = stackalloc byte[2];
        var writer = new SpanWriter<byte>(buf);

        writer.Write(1);
        writer.Write(2);
        writer.Fill(0); // no remaining space — should be a no-op

        Assert.Equal(2, writer.WrittenCount);
    }

    //--------------------------------------------------------------------------------
    // Position setter
    //--------------------------------------------------------------------------------

    [Fact]
    public void PositionSetterMovesCorrectly()
    {
        Span<byte> buf = stackalloc byte[8];
        var writer = new SpanWriter<byte>(buf) { Position = 4 };

        Assert.Equal(4, writer.WrittenCount);
        Assert.Equal(4, writer.FreeCapacity);
    }

    [Fact]
    public void PositionSetterToLengthIsAllowed()
    {
        Span<byte> buf = stackalloc byte[4];
        var writer = new SpanWriter<byte>(buf) { Position = 4 };

        Assert.Equal(0, writer.FreeCapacity);
    }

    [Fact]
    public void PositionSetterBeyondLengthThrows()
    {
        Span<byte> buf = stackalloc byte[4];
        var writer = new SpanWriter<byte>(buf);

        try
        {
            writer.Position = 5;
            Assert.Fail("Expected ArgumentOutOfRangeException");
        }
        catch (ArgumentOutOfRangeException)
        {
            // expected
        }
    }

    //--------------------------------------------------------------------------------
    // WriteUnmanaged (little-endian byte representation)
    //--------------------------------------------------------------------------------

    [Fact]
    public void WriteUnmanagedInt32LittleEndian()
    {
        Span<byte> buf = stackalloc byte[4];
        var writer = new SpanWriter<byte>(buf);

        writer.WriteUnmanaged(0x01020304);

        // On a little-endian system: 04 03 02 01
        Assert.Equal(4, writer.WrittenCount);
        var written = writer.WrittenSpan;
        // Round-trip: read back as int must equal original
        var value = Unsafe.ReadUnaligned<int>(ref MemoryMarshal.GetReference(written));
        Assert.Equal(0x01020304, value);
    }

    [Fact]
    public void WriteUnmanagedUInt16()
    {
        Span<byte> buf = stackalloc byte[2];
        var writer = new SpanWriter<byte>(buf);

        writer.WriteUnmanaged((ushort)0xABCD);

        Assert.Equal(2, writer.WrittenCount);
        var written = writer.WrittenSpan;
        var value = Unsafe.ReadUnaligned<ushort>(ref MemoryMarshal.GetReference(written));
        Assert.Equal((ushort)0xABCD, value);
    }

    //--------------------------------------------------------------------------------
    // WrittenSpan content check
    //--------------------------------------------------------------------------------

    [Fact]
    public void WrittenSpanReflectsWrites()
    {
        Span<byte> buf = stackalloc byte[6];
        var writer = new SpanWriter<byte>(buf);

        writer.Write(1);
        writer.Write(2);
        writer.Write(3);

        var span = writer.WrittenSpan;
        Assert.Equal(3, span.Length);
        Assert.Equal(1, span[0]);
        Assert.Equal(2, span[1]);
        Assert.Equal(3, span[2]);
    }
}
