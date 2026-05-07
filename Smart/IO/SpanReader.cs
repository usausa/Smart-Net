namespace Smart.IO;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable IDE0032
[StructLayout(LayoutKind.Auto)]
public ref struct SpanReader<T>
{
    private readonly ref T reference;

    private readonly int length;

    private int position;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SpanReader(ReadOnlySpan<T> span)
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

    public readonly int Consumed => position;

    public readonly int Remaining => length - position;

    public readonly ReadOnlySpan<T> Span =>
        MemoryMarshal.CreateReadOnlySpan(ref reference, length);

    public readonly ReadOnlySpan<T> ConsumedSpan =>
        MemoryMarshal.CreateReadOnlySpan(ref reference, position);

    public readonly ReadOnlySpan<T> RemainingSpan =>
        MemoryMarshal.CreateReadOnlySpan(ref Unsafe.Add(ref reference, position), length - position);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref readonly T Read()
    {
        if ((uint)position >= (uint)length)
        {
            ThrowEndOfData();
        }

        return ref Unsafe.Add(ref reference, position++);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> Read(int count)
    {
        if (!TryRead(count, out var result))
        {
            ThrowEndOfData();
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TValue ReadUnmanaged<TValue>()
        where TValue : unmanaged
    {
        var size = Unsafe.SizeOf<TValue>();
        var span = Read(size);
        ref var byteRef = ref Unsafe.As<T, byte>(ref Unsafe.AsRef(in MemoryMarshal.GetReference(span)));
        return Unsafe.ReadUnaligned<TValue>(ref byteRef);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryRead(out T value)
    {
        if ((uint)position < (uint)length)
        {
            value = Unsafe.Add(ref reference, position++);
            return true;
        }

        value = default!;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryRead(int count, out ReadOnlySpan<T> result)
    {
        var newPos = position + count;
        if ((uint)newPos <= (uint)length)
        {
            result = MemoryMarshal.CreateReadOnlySpan(ref Unsafe.Add(ref reference, position), count);
            position = newPos;
            return true;
        }

        result = default;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Skip(int count)
    {
        var newPos = position + count;
        ArgumentOutOfRangeException.ThrowIfGreaterThan((uint)newPos, (uint)length, nameof(count));
        position = newPos;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> ReadToEnd()
    {
        var result = RemainingSpan;
        position = length;
        return result;
    }

    [System.Diagnostics.StackTraceHidden]
    private static void ThrowEndOfData() =>
        throw new InvalidOperationException("Not enough data remaining in the span.");
}
#pragma warning restore IDE0032
