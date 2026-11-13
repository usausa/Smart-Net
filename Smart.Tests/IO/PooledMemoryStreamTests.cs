namespace Smart.IO;

using System.Buffers;
using System.Runtime.InteropServices;

public sealed class PooledMemoryStreamTests
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

    [Fact]
    public void ReadByteReturnsBytesThenMinusOne()
    {
        using var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3], 0, 3);
        ms.Position = 1;

        Assert.Equal(2, ms.ReadByte());
        Assert.Equal(3, ms.ReadByte());
        Assert.Equal(-1, ms.ReadByte());
        Assert.Equal(3L, ms.Position);

        ms.Position = 10;
        Assert.Equal(-1, ms.ReadByte());
        Assert.Equal(10L, ms.Position);
    }

    [Fact]
    public void WriteByteGrowsAndZeroFillsGap()
    {
        using var ms = new PooledMemoryStream(4);
        var expected = new byte[23];
        for (var i = 0; i < 20; i++)
        {
            ms.WriteByte((byte)(i + 1));
            expected[i] = (byte)(i + 1);
        }

        ms.Position = 22;
        ms.WriteByte(99);
        expected[22] = 99;

        Assert.Equal(23L, ms.Length);
        Assert.Equal(23L, ms.Position);
        Assert.Equal(expected, ms.GetRawBuffer().AsSpan(0, 23).ToArray());
    }

    [Fact]
    public void ReadByteWriteByteDoNotAllocate()
    {
        using var ms = new PooledMemoryStream();
        ms.SetLength(200);
        ReadAndWrite(ms);

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 100; i++)
        {
            ReadAndWrite(ms);
        }

        Assert.InRange(GC.GetAllocatedBytesForCurrentThread() - before, 0, 99);

        static void ReadAndWrite(PooledMemoryStream stream)
        {
            stream.Position = 0;
            _ = stream.ReadByte();
            stream.WriteByte(1);
        }
    }

    [Fact]
    public async Task WriteAsyncReadAsyncCompleteSynchronously()
    {
        var ms = new PooledMemoryStream(4);
        await using (ms.ConfigureAwait(true))
        {
            var data = new byte[] { 1, 2, 3, 4, 5 };
            var cancellationToken = TestContext.Current.CancellationToken;

            var write = ms.WriteAsync(data, 0, 3, cancellationToken);
            Assert.True(write.IsCompletedSuccessfully);
            await write.ConfigureAwait(true);
            var writeMemory = ms.WriteAsync(data.AsMemory(3, 2), cancellationToken).AsTask();
            Assert.True(writeMemory.IsCompletedSuccessfully);
            await writeMemory.ConfigureAwait(true);
            Assert.Equal(5L, ms.Length);

            ms.Position = 0;
            var buf = new byte[5];
            var read = ms.ReadAsync(buf, 0, 3, cancellationToken);
            Assert.True(read.IsCompletedSuccessfully);
            Assert.Equal(3, await read.ConfigureAwait(true));
            var readMemory = ms.ReadAsync(buf.AsMemory(3, 2), cancellationToken).AsTask();
            Assert.True(readMemory.IsCompletedSuccessfully);
            Assert.Equal(2, await readMemory.ConfigureAwait(true));
            Assert.Equal(data, buf);
        }
    }

    [Fact]
    public async Task ReadAsyncReusesTaskForSameCount()
    {
        var ms = new PooledMemoryStream();
        await using (ms.ConfigureAwait(true))
        {
            ms.SetLength(32);
            var cancellationToken = TestContext.Current.CancellationToken;

            var buf = new byte[16];
            var first = ms.ReadAsync(buf, 0, buf.Length, cancellationToken);
            var second = ms.ReadAsync(buf, 0, buf.Length, cancellationToken);
            Assert.Same(first, second);
            Assert.Equal(16, await second.ConfigureAwait(true));
            var third = ms.ReadAsync(buf, 0, buf.Length, cancellationToken);
            Assert.NotSame(second, third);
            Assert.Equal(0, await third.ConfigureAwait(true));
        }
    }

    [Fact]
    public void AsyncMembersReturnCanceledTaskWhenCanceled()
    {
        using var ms = new PooledMemoryStream();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var buffer = new byte[3];
        Assert.True(ms.WriteAsync(buffer, 0, buffer.Length, cts.Token).IsCanceled);
        Assert.True(ms.WriteAsync(buffer.AsMemory(), cts.Token).AsTask().IsCanceled);
        Assert.True(ms.ReadAsync(buffer, 0, buffer.Length, cts.Token).IsCanceled);
        Assert.True(ms.ReadAsync(buffer.AsMemory(), cts.Token).AsTask().IsCanceled);
        Assert.True(ms.FlushAsync(cts.Token).IsCanceled);
        Assert.Equal(0L, ms.Length);
    }

    //--------------------------------------------------------------------------------
    // CopyTo / CopyToAsync
    //--------------------------------------------------------------------------------

    [Fact]
    public void CopyToWritesFromRawBufferInOneCall()
    {
        using var ms = new PooledMemoryStream();
        ms.SetLength(200_000);
        ms.Position = 1_000;
        using var destination = new RecordingStream();

        ms.CopyTo(destination);

        var (buffer, offset, count) = Assert.Single(destination.Writes);
        Assert.Same(ms.GetRawBuffer(), buffer);
        Assert.Equal(1_000, offset);
        Assert.Equal(199_000, count);
        Assert.Equal(200_000L, ms.Position);
    }

    [Fact]
    public async Task CopyToAsyncCopiesRemainingToMemoryStreams()
    {
        var ms = new PooledMemoryStream(4);
        await using (ms.ConfigureAwait(true))
        {
            var cancellationToken = TestContext.Current.CancellationToken;
            await ms.WriteAsync(new byte[] { 1, 2, 3, 4, 5 }, cancellationToken).ConfigureAwait(true);

            var memory = new MemoryStream();
            await using (memory.ConfigureAwait(true))
            {
                ms.Position = 1;
                await ms.CopyToAsync(memory, cancellationToken).ConfigureAwait(true);
                Assert.Equal(new byte[] { 2, 3, 4, 5 }, memory.ToArray());
                Assert.Equal(5L, ms.Position);
            }

            var pooled = new PooledMemoryStream(4);
            await using (pooled.ConfigureAwait(true))
            {
                ms.Position = 2;
                await ms.CopyToAsync(pooled, cancellationToken).ConfigureAwait(true);
                Assert.Equal(new byte[] { 3, 4, 5 }, pooled.GetRawBuffer().AsSpan(0, (int)pooled.Length).ToArray());
                Assert.Equal(5L, ms.Position);
            }
        }
    }

    [Fact]
    public async Task CopyToAsyncToMemoryStreamWritesInOneCall()
    {
        var ms = new PooledMemoryStream();
        await using (ms.ConfigureAwait(true))
        {
            ms.SetLength(200_000);
            ms.Position = 0;
            var destination = new MemoryStream(new byte[150_000]);
            await using (destination.ConfigureAwait(true))
            {
                await Assert.ThrowsAsync<NotSupportedException>(() => ms.CopyToAsync(destination, TestContext.Current.CancellationToken)).ConfigureAwait(true);
                Assert.Equal(0L, destination.Position);
                Assert.Equal(200_000L, ms.Position);
            }
        }
    }

    [Fact]
    public async Task CopyToAsyncToOtherStreamDoesNotPassRawBuffer()
    {
        var ms = new PooledMemoryStream();
        await using (ms.ConfigureAwait(true))
        {
            ms.SetLength(100);
            ms.Position = 0;
            var destination = new RecordingStream();
            await using (destination.ConfigureAwait(true))
            {
                await ms.CopyToAsync(destination, TestContext.Current.CancellationToken).ConfigureAwait(true);

                var (buffer, _, count) = Assert.Single(destination.Writes);
                Assert.NotSame(ms.GetRawBuffer(), buffer);
                Assert.Equal(100, count);
                Assert.Equal(100L, ms.Position);
            }
        }
    }

    [Fact]
    public async Task CopyToAsyncReturnsCanceledTaskWhenCanceled()
    {
        var ms = new PooledMemoryStream();
        await using (ms.ConfigureAwait(true))
        {
            ms.SetLength(3);
            ms.Position = 0;
            var destination = new MemoryStream();
            await using (destination.ConfigureAwait(true))
            {
                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => ms.CopyToAsync(destination, new CancellationToken(true))).ConfigureAwait(true);
                Assert.Equal(0L, ms.Position);
                Assert.Equal(0L, destination.Length);
            }
        }
    }

    [Fact]
    public void CopyToSelfAppendsRemaining()
    {
        using var ms = new PooledMemoryStream(new PoisonPool(), 5);
        ms.Write([1, 2, 3, 4, 5], 0, 5);
        ms.Position = 2;

        ms.CopyTo(ms);

        Assert.Equal(8L, ms.Position);
        ms.Position = 0;
        var buf = new byte[8];
        ms.ReadExactly(buf, 0, buf.Length);
        Assert.Equal(new byte[] { 1, 2, 3, 4, 5, 3, 4, 5 }, buf);
    }

    [Fact]
    public async Task CopyToAsyncSelfAppendsRemaining()
    {
        var ms = new PooledMemoryStream(new PoisonPool(), 5);
        await using (ms.ConfigureAwait(true))
        {
            var cancellationToken = TestContext.Current.CancellationToken;
            await ms.WriteAsync(new byte[] { 1, 2, 3, 4, 5 }, cancellationToken).ConfigureAwait(true);
            ms.Position = 2;

            await ms.CopyToAsync(ms, cancellationToken).ConfigureAwait(true);

            Assert.Equal(8L, ms.Position);
            Assert.Equal(new byte[] { 1, 2, 3, 4, 5, 3, 4, 5 }, ms.GetRawBuffer().AsSpan(0, (int)ms.Length).ToArray());
        }
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

        Assert.Throws<ArgumentOutOfRangeException>(() => ms.Seek(-1, SeekOrigin.Begin));
    }

    [Fact]
    public void SeekPastLengthIsAllowed()
    {
        using var ms = new PooledMemoryStream(16);
        ms.Write([1, 2, 3], 0, 3);

        // MemoryStream contract: position may exceed length; read at that position returns 0
        var result = ms.Seek(100, SeekOrigin.Begin);
        Assert.Equal(100L, result);

        var buf = new byte[1];
        Assert.Equal(0, ms.Read(buf, 0, 1));
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

    [Fact]
    public void SetLengthExpansionZeroFillsGap()
    {
        using var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3, 4], 0, 4);

        // Shrink then grow again: the re-exposed region must not contain the old data
        ms.SetLength(0);
        ms.SetLength(4);

        ms.Position = 0;
        var buf = new byte[4];
        ms.ReadExactly(buf, 0, 4);
        Assert.Equal(new byte[4], buf);
    }

    [Fact]
    public void WritePastLengthZeroFillsGap()
    {
        using var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3, 4], 0, 4);
        ms.SetLength(2);

        ms.Position = 6;
        ms.Write([9], 0, 1);

        Assert.Equal(7L, ms.Length);
        ms.Position = 0;
        var buf = new byte[7];
        ms.ReadExactly(buf, 0, 7);
        Assert.Equal(new byte[] { 1, 2, 0, 0, 0, 0, 9 }, buf);
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
    public void WriteDoublesCapacityWhenPoolReturnsExactSize()
    {
        var pool = new ExactPool();
        using var ms = new PooledMemoryStream(pool, 1024);
        var chunk = new byte[1024];
        for (var i = 0; i < 64; i++)
        {
            chunk.AsSpan().Fill((byte)i);
            ms.Write(chunk, 0, chunk.Length);
        }

        int[] expected = [1024, 2048, 4096, 8192, 16384, 32768, 65536];
        Assert.Equal(expected, pool.Rented);
        Assert.Equal(65536L, ms.Length);
        for (var i = 0; i < 64; i++)
        {
            Assert.Equal(-1, ms.GetRawBuffer().AsSpan(i * 1024, 1024).IndexOfAnyExcept((byte)i));
        }
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

    [Fact]
    public void MembersThrowAfterDispose()
    {
        var ms = new PooledMemoryStream();
        ms.Write([1, 2, 3], 0, 3);
        ms.Dispose();

        var buffer = new byte[3];
        Assert.Throws<ObjectDisposedException>(() => ms.Write([4], 0, 1));
        Assert.Throws<ObjectDisposedException>(() => ms.Write(buffer.AsSpan()));
        Assert.Throws<ObjectDisposedException>(() => ms.Read(buffer, 0, buffer.Length));
        Assert.Throws<ObjectDisposedException>(() => ms.Read(buffer.AsSpan()));
        Assert.Throws<ObjectDisposedException>(() => ms.Seek(0, SeekOrigin.Begin));
        Assert.Throws<ObjectDisposedException>(() => ms.SetLength(0));
        Assert.Throws<ObjectDisposedException>(() => ms.Length);
        Assert.Throws<ObjectDisposedException>(() => ms.Position);
        Assert.Throws<ObjectDisposedException>(() => ms.Position = 0);
        Assert.Throws<ObjectDisposedException>(ms.GetRawBuffer);
        Assert.Throws<ObjectDisposedException>(() => ms.ReadByte());
        Assert.Throws<ObjectDisposedException>(() => ms.WriteByte(1));
        using var destination = new MemoryStream();
        Assert.Throws<ObjectDisposedException>(() => ms.CopyTo(destination));
    }

    [Fact]
    public async Task AsyncMembersFaultAfterDispose()
    {
        var ms = new PooledMemoryStream();
        await ms.DisposeAsync().ConfigureAwait(true);
        var cancellationToken = TestContext.Current.CancellationToken;

        var buffer = new byte[3];
        Task[] tasks =
        [
            ms.WriteAsync(buffer, 0, buffer.Length, cancellationToken),
            ms.WriteAsync(buffer.AsMemory(), cancellationToken).AsTask(),
            ms.ReadAsync(buffer, 0, buffer.Length, cancellationToken),
            ms.ReadAsync(buffer.AsMemory(), cancellationToken).AsTask()
        ];
        foreach (var task in tasks)
        {
            Assert.True(task.IsFaulted);
            await Assert.ThrowsAsync<ObjectDisposedException>(() => task).ConfigureAwait(true);
        }

        Assert.True(ms.FlushAsync(cancellationToken).IsCompletedSuccessfully);
        var destination = new MemoryStream();
        await using (destination.ConfigureAwait(true))
        {
            await Assert.ThrowsAsync<ObjectDisposedException>(() => ms.CopyToAsync(destination, cancellationToken)).ConfigureAwait(true);
        }
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

    [Fact]
    public void FlushAsyncCompletesSynchronously()
    {
        using var ms = new PooledMemoryStream();
        Assert.True(ms.FlushAsync(TestContext.Current.CancellationToken).IsCompletedSuccessfully);
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

    private sealed class PoisonPool : ArrayPool<byte>
    {
        public override byte[] Rent(int minimumLength) => new byte[minimumLength];

        public override void Return(byte[] array, bool clearArray = false) => array.AsSpan().Fill(0xFF);
    }

    private sealed class ExactPool : ArrayPool<byte>
    {
        public List<int> Rented { get; } = [];

        public override byte[] Rent(int minimumLength)
        {
            Rented.Add(minimumLength);
            return new byte[minimumLength];
        }

        public override void Return(byte[] array, bool clearArray = false)
        {
        }
    }

    private abstract class WriteOnlyStream : Stream
    {
        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();
    }

    private sealed class RecordingStream : WriteOnlyStream
    {
        public List<(byte[] Buffer, int Offset, int Count)> Writes { get; } = [];

        public override void Write(byte[] buffer, int offset, int count) => Writes.Add((buffer, offset, count));

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            Write(buffer, offset, count);
            return Task.CompletedTask;
        }

        public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
        {
            if (!MemoryMarshal.TryGetArray(buffer, out var segment))
            {
                throw new NotSupportedException();
            }

            Write(segment.Array!, segment.Offset, segment.Count);
            return ValueTask.CompletedTask;
        }
    }
}
