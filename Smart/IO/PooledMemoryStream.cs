namespace Smart.IO;

using System.Buffers;
using System.Runtime.CompilerServices;

public sealed class PooledMemoryStream : Stream
{
    private readonly ArrayPool<byte> pool;

    private byte[] rawBuffer;

    private bool disposed;

    private int position;

    private int length;

    private Task<int>? lastReadTask;

    private int lastReadCount;

    public override bool CanRead => !disposed;

    public override bool CanWrite => !disposed;

    public override bool CanSeek => !disposed;

    public override long Length
    {
        get
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            return length;
        }
    }

    public override long Position
    {
        get
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            return position;
        }
        set
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            if ((ulong)value > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            position = (int)value;
        }
    }

    public PooledMemoryStream()
        : this(ArrayPool<byte>.Shared)
    {
    }

    public PooledMemoryStream(int capacity)
        : this(ArrayPool<byte>.Shared, capacity)
    {
    }

    public PooledMemoryStream(ArrayPool<byte> pool, int capacity = 4096)
    {
        this.pool = pool;
        rawBuffer = pool.Rent(capacity);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (!disposed)
        {
            pool.Return(rawBuffer);
            disposed = true;
        }
    }

    public override void Flush()
    {
    }

    public override Task FlushAsync(CancellationToken cancellationToken)
    {
        return cancellationToken.IsCancellationRequested ? Task.FromCanceled(cancellationToken) : Task.CompletedTask;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        var newPosition = origin switch
        {
            SeekOrigin.Begin => offset,
            SeekOrigin.End => length + offset,
            SeekOrigin.Current => position + offset,
            _ => throw new ArgumentException("Invalid seek origin.", nameof(origin))
        };

        if ((ulong)newPosition > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(offset));
        }

        position = (int)newPosition;
        return position;
    }

    public override void SetLength(long value)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        if ((ulong)value > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        var newLength = (int)value;
        EnsureCapacity(newLength);

        if (newLength > length)
        {
            rawBuffer.AsSpan(length, newLength - length).Clear();
        }

        length = newLength;
        if (position > length)
        {
            position = length;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void EnsureCapacity(int size)
    {
        if ((uint)rawBuffer.Length < (uint)size)
        {
            var newSize = size < 0 ? size : Math.Max(size, (int)Math.Min(2L * rawBuffer.Length, Array.MaxLength));
            var tmp = pool.Rent(newSize);
            rawBuffer.AsSpan(0, length).CopyTo(tmp);
            pool.Return(rawBuffer);
            rawBuffer = tmp;
        }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        return ReadInternal(buffer.AsSpan(offset, count));
    }

    public override int Read(Span<byte> buffer)
    {
        return ReadInternal(buffer);
    }

    public override int ReadByte()
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        return position < length ? rawBuffer[position++] : -1;
    }

    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        ValidateBufferArguments(buffer, offset, count);
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<int>(cancellationToken);
        }

        try
        {
            var read = ReadInternal(buffer.AsSpan(offset, count));
            if ((lastReadTask is null) || (lastReadCount != read))
            {
                lastReadTask = Task.FromResult(read);
                lastReadCount = read;
            }

            return lastReadTask;
        }
        catch (ObjectDisposedException ex)
        {
            return Task.FromException<int>(ex);
        }
    }

    public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return ValueTask.FromCanceled<int>(cancellationToken);
        }

        try
        {
            return new ValueTask<int>(ReadInternal(buffer.Span));
        }
        catch (ObjectDisposedException ex)
        {
            return ValueTask.FromException<int>(ex);
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int ReadInternal(Span<byte> buffer)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        var remain = length - position;
        var read = buffer.Length > remain ? remain : buffer.Length;
        if (read <= 0)
        {
            return 0;
        }

        rawBuffer.AsSpan(position, read).CopyTo(buffer);

        position += read;
        return read;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        WriteInternal(buffer.AsSpan(offset, count));
    }

    public override void Write(ReadOnlySpan<byte> buffer)
    {
        WriteInternal(buffer);
    }

    public override void WriteByte(byte value)
    {
        WriteInternal(new ReadOnlySpan<byte>(in value));
    }

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        ValidateBufferArguments(buffer, offset, count);
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled(cancellationToken);
        }

        try
        {
            WriteInternal(buffer.AsSpan(offset, count));
            return Task.CompletedTask;
        }
        catch (ObjectDisposedException ex)
        {
            return Task.FromException(ex);
        }
    }

    public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return ValueTask.FromCanceled(cancellationToken);
        }

        try
        {
            WriteInternal(buffer.Span);
            return ValueTask.CompletedTask;
        }
        catch (ObjectDisposedException ex)
        {
            return ValueTask.FromException(ex);
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void WriteInternal(ReadOnlySpan<byte> buffer)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        var newPosition = position + buffer.Length;
        EnsureCapacity(newPosition);

        if (position > length)
        {
            rawBuffer.AsSpan(length, position - length).Clear();
        }

        buffer.CopyTo(rawBuffer.AsSpan(position));

        position = newPosition;
        if (position > length)
        {
            length = position;
        }
    }

    public override void CopyTo(Stream destination, int bufferSize)
    {
        if (destination == this)
        {
            base.CopyTo(destination, bufferSize);
            return;
        }

        ValidateCopyToArguments(destination, bufferSize);
        ObjectDisposedException.ThrowIf(disposed, this);
        var offset = position;
        var count = length - offset;
        if (count > 0)
        {
            position = length;
            destination.Write(rawBuffer, offset, count);
        }
    }

    public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
    {
        var direct = destination switch
        {
            PooledMemoryStream other => other != this,
            MemoryStream => destination.GetType() == typeof(MemoryStream),
            _ => false
        };
        if (!direct)
        {
            return base.CopyToAsync(destination, bufferSize, cancellationToken);
        }

        ValidateCopyToArguments(destination, bufferSize);
        ObjectDisposedException.ThrowIf(disposed, this);
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled(cancellationToken);
        }

        var offset = position;
        var count = length - offset;
        if (count <= 0)
        {
            return Task.CompletedTask;
        }

        position = length;
        return destination.WriteAsync(rawBuffer, offset, count, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] GetRawBuffer()
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        return rawBuffer;
    }
}
