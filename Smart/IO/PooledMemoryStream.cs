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

    public override bool CanRead => !disposed;

    public override bool CanWrite => !disposed;

    public override bool CanSeek => !disposed;

    public override long Length => length;

    public override long Position
    {
        get => position;
        set
        {
            if ((ulong)value > (uint)rawBuffer.Length)
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

    public override long Seek(long offset, SeekOrigin origin)
    {
        var newPosition = origin switch
        {
            SeekOrigin.Begin => (int)offset,
            SeekOrigin.End => length + (int)offset,
            SeekOrigin.Current => position + (int)offset,
            _ => throw new ArgumentException("Invalid seek origin.", nameof(origin))
        };

        if ((uint)newPosition > (uint)rawBuffer.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(offset));
        }

        position = newPosition;
        return position;
    }

    public override void SetLength(long value)
    {
        if ((uint)value > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        length = (int)value;
        EnsureCapacity(length);

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
            var tmp = pool.Rent(size);
            rawBuffer.AsSpan().CopyTo(tmp);
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

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public int ReadInternal(Span<byte> buffer)
    {
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

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void WriteInternal(ReadOnlySpan<byte> buffer)
    {
        var newPosition = position + buffer.Length;
        EnsureCapacity(newPosition);

        buffer.CopyTo(rawBuffer.AsSpan(position));

        position = newPosition;
        if (position > length)
        {
            length = position;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] GetRawBuffer() => rawBuffer;
}
