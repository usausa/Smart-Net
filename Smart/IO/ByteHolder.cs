namespace Smart.IO;

using System;
using System.Runtime.CompilerServices;

public sealed class ByteHolder
{
    private readonly byte[] rawBuffer;

#pragma warning disable IDE0032
    private readonly int size;
#pragma warning restore IDE0032

    public int Length => size;

    public ByteHolder(byte[] array)
    {
        rawBuffer = array;
        size = array.Length;
    }

    public ByteHolder(byte[] array, int length)
    {
        rawBuffer = array;
        size = length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] GetRawBuffer() => rawBuffer;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan() => new(rawBuffer, 0, size);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan(int start) => new(rawBuffer, start, Length - start);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan(int start, int length) => new(rawBuffer, start, length);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Memory<byte> AsMemory() => new(rawBuffer, 0, Length);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Memory<byte> AsMemory(int start) => new(rawBuffer, start, Length - start);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Memory<byte> AsMemory(int start, int length) => new(rawBuffer, start, length);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear() => rawBuffer.AsSpan().Clear();
}
