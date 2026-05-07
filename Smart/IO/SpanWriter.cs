namespace Smart.IO;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable IDE0032
[StructLayout(LayoutKind.Auto)]
public ref struct SpanWriter<T>
{
    private readonly ref T reference;

    private readonly int length;

    private int position;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SpanWriter(Span<T> span)
    {
        reference = ref MemoryMarshal.GetReference(span);
        length = span.Length;
    }

    public readonly int Length => length;

    public int Position
    {
        readonly get => position;
        set
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan((uint)value, (uint)length, nameof(value));
            position = value;
        }
    }

    public readonly int WrittenCount => position;

    public readonly int FreeCapacity => length - position;

    public readonly Span<T> Span => MemoryMarshal.CreateSpan(ref reference, length);

    public readonly Span<T> WrittenSpan => MemoryMarshal.CreateSpan(ref reference, position);

    public readonly Span<T> RemainingSpan => MemoryMarshal.CreateSpan(ref Unsafe.Add(ref reference, position), length - position);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(T value)
    {
        if ((uint)position >= (uint)length)
        {
            ThrowNoCapacity();
        }

        Unsafe.Add(ref reference, position++) = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(ReadOnlySpan<T> source)
    {
        if (!TryWrite(source))
        {
            ThrowNoCapacity();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUnmanaged<TValue>(TValue value)
        where TValue : unmanaged
    {
        var size = Unsafe.SizeOf<TValue>();
        var span = Slide(size);
        Unsafe.WriteUnaligned(ref Unsafe.As<T, byte>(ref MemoryMarshal.GetReference(span)), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryWrite(T value)
    {
        if ((uint)position < (uint)length)
        {
            Unsafe.Add(ref reference, position++) = value;
            return true;
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryWrite(ReadOnlySpan<T> source)
    {
        var newPos = position + source.Length;
        if ((uint)newPos <= (uint)length)
        {
            source.CopyTo(MemoryMarshal.CreateSpan(ref Unsafe.Add(ref reference, position), source.Length));
            position = newPos;
            return true;
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<T> Slide(int count)
    {
        var newPos = position + count;
        ArgumentOutOfRangeException.ThrowIfGreaterThan((uint)newPos, (uint)length, nameof(count));
        var result = MemoryMarshal.CreateSpan(ref Unsafe.Add(ref reference, position), count);
        position = newPos;
        return result;
    }

    /// <summary>Fills all remaining capacity with a single value.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Fill(T value)
    {
        RemainingSpan.Fill(value);
        position = length;
    }

    [System.Diagnostics.StackTraceHidden]
    private static void ThrowNoCapacity() =>
        throw new InvalidOperationException("No capacity remaining in the span.");
}
#pragma warning restore IDE0032
