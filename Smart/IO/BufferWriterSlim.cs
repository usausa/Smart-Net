namespace Smart.IO;

using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable IDE0032
[StructLayout(LayoutKind.Auto)]
public ref struct BufferWriterSlim<T>
{
    private readonly Span<T> initialBuffer;

    private T[]? buffer;

    private int position;

    private int capacity;

    public readonly int WrittenCount => position;

    public readonly int FreeCapacity => capacity - position;

    public readonly ReadOnlySpan<T> WrittenSpan =>
        buffer is null ? initialBuffer[..position] : buffer.AsSpan(0, position);

    public readonly Span<T> WrittenSpanMutable =>
        buffer is null ? initialBuffer[..position] : buffer.AsSpan(0, position);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BufferWriterSlim(Span<T> initialBuffer)
    {
        this.initialBuffer = initialBuffer;
        capacity = initialBuffer.Length;
    }

    public void Dispose()
    {
        var toReturn = buffer;
        buffer = null;
        if (toReturn is not null)
        {
            ArrayPool<T>.Shared.Return(toReturn, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
        }

        capacity = initialBuffer.Length;
        position = 0;
    }

    //--------------------------------------------------------------------------------
    // Write
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear() => position = 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(T value)
    {
        if (position >= capacity)
        {
            Grow(1);
        }

        GetCurrentBuffer()[position++] = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(ReadOnlySpan<T> source)
    {
        if (position + source.Length > capacity)
        {
            Grow(source.Length);
        }

        source.CopyTo(GetCurrentBuffer()[position..]);
        position += source.Length;
    }

    //--------------------------------------------------------------------------------
    // IBufferWriter like
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<T> GetSpan(int sizeHint = 0)
    {
        if (sizeHint < 1)
        {
            sizeHint = 1;
        }

        if (position + sizeHint > capacity)
        {
            Grow(sizeHint);
        }

        return GetCurrentBuffer()[position..];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Advance(int count) => position += count;

    //--------------------------------------------------------------------------------
    // Internal
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly Span<T> GetCurrentBuffer() =>
        buffer is null ? initialBuffer : buffer.AsSpan();

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void Grow(int additionalCapacity)
    {
        var needed = position + additionalCapacity;
        var newCapacity = Math.Max(needed, capacity == 0 ? 4 : capacity * 2);

        var newBuffer = ArrayPool<T>.Shared.Rent(newCapacity);
        WrittenSpanMutable.CopyTo(newBuffer);

        if (buffer is not null)
        {
            ArrayPool<T>.Shared.Return(buffer, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
        }

        buffer = newBuffer;
        capacity = newBuffer.Length;
    }
}
#pragma warning restore IDE0032
