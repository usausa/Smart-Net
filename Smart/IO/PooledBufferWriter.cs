namespace Smart.IO;

using System.Buffers;
using System.Runtime.CompilerServices;

#pragma warning disable IDE0032
public sealed class PooledBufferWriter<T> : IBufferWriter<T>, IDisposable
{
    private T[] buffer;

    private int index;

    public ReadOnlyMemory<T> WrittenMemory => buffer.AsMemory(0, index);

    public ReadOnlySpan<T> WrittenSpan => buffer.AsSpan(0, index);

    public int WrittenCount => index;

    public int Capacity => buffer.Length;

    public int FreeCapacity => buffer.Length - index;

    public PooledBufferWriter(int initialCapacity)
    {
        buffer = ArrayPool<T>.Shared.Rent(initialCapacity);
        buffer.AsSpan().Clear();
    }

    public void Dispose()
    {
        if (buffer.Length > 0)
        {
            ArrayPool<T>.Shared.Return(buffer);
            buffer = [];
        }
    }

    public void Clear()
    {
        index = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Advance(int count)
    {
        index += count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Memory<T> GetMemory(int sizeHint = 0)
    {
        GrowIfRequired(sizeHint);
        return buffer.AsMemory(index);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<T> GetSpan(int sizeHint = 0)
    {
        GrowIfRequired(sizeHint);
        return buffer.AsSpan(index);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void GrowIfRequired(int sizeHint)
    {
        if (sizeHint == 0)
        {
            sizeHint = 1;
        }

        var newSize = index + sizeHint;
        if ((uint)newSize > (uint)buffer.Length)
        {
            var newBuffer = ArrayPool<T>.Shared.Rent(newSize);
            buffer[..index].CopyTo(newBuffer.AsSpan());
            ArrayPool<T>.Shared.Return(buffer);
            buffer = newBuffer;
        }
    }
}
#pragma warning restore IDE0032
