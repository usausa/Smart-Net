namespace Smart.IO
{
    using System;
    using System.Buffers;
    using System.Runtime.CompilerServices;

    public sealed class ByteBuffer : IBufferWriter<byte>
    {
        // position <= limit <= capacity

        private readonly byte[] rawBuffer;

        private int position;

        private int limit;

        public int Position
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => position;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((uint)value > (uint)limit)
                {
                    throw new ArgumentException("Position is out of range.", nameof(value));
                }

                position = value;
            }
        }

        public int Limit
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => limit;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((uint)value > (uint)Capacity)
                {
                    throw new ArgumentException("Limit is out of range.", nameof(value));
                }

                limit = value;
                if (position > limit)
                {
                    position = limit;
                }
            }
        }

        public int Capacity { get; }

        public bool HasRemaining => position < limit;

        public int Remaining => limit - position;

        public ByteBuffer(int capacity)
        {
            rawBuffer = new byte[capacity];
            position = 0;
            limit = capacity;
            Capacity = capacity;
        }

        public ByteBuffer(byte[] bytes)
        {
            rawBuffer = bytes;
            position = 0;
            limit = bytes.Length;
            Capacity = limit;
        }

        public ByteBuffer(byte[] bytes, int start, int length)
        {
            rawBuffer = bytes;
            position = start;
            limit = length;
            Capacity = length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] GetRawBuffer() => rawBuffer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<byte> AsSpan() => new Span<byte>(rawBuffer, position, limit - position);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<byte> AsSpan(int start) => new Span<byte>(rawBuffer, position + start, limit - position - start);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<byte> AsSpan(int start, int length) => new Span<byte>(rawBuffer, position + start, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Memory<byte> AsMemory() => new Memory<byte>(rawBuffer, position, limit - position);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Memory<byte> AsMemory(int start) => new Memory<byte>(rawBuffer, position + start, limit - position - start);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Memory<byte> AsMemory(int start, int length) => new Memory<byte>(rawBuffer, position + start, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset()
        {
            position = 0;
            limit = Capacity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset(int size)
        {
            if ((uint)size > (uint)Capacity)
            {
                throw new ArgumentException("Limit is out of range.", nameof(size));
            }

            position = 0;
            limit = size;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Flip()
        {
            limit = position;
            position = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            Array.Clear(rawBuffer, 0, rawBuffer.Length);
        }

        public void Advance(int count) => position += count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Memory<byte> GetMemory(int sizeHint = 0) => new Memory<byte>(rawBuffer, position, limit - position);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<byte> GetSpan(int sizeHint = 0) => new Span<byte>(rawBuffer, position, limit - position);
    }
}
