namespace Smart.IO
{
    using System;
    using System.Runtime.CompilerServices;

#pragma warning disable IDE0032
    public sealed class ByteHolder
    {
        private readonly byte[] rawBuffer;

        private readonly int size;

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
        public void Clear()
        {
            Array.Clear(rawBuffer, 0, rawBuffer.Length);
        }
    }
#pragma warning restore IDE0032
}
