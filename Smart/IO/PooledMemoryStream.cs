#if !NETSTANDARD2_0
namespace Smart.IO
{
    using System;
    using System.Buffers;
    using System.IO;
    using System.Runtime.CompilerServices;

#pragma warning disable IDE0032
    public sealed class PooledMemoryStream : Stream
    {
        private readonly ArrayPool<byte> pool;

        private byte[] rawBuffer;

        private bool disposed;

        private int position;

        private int length;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override bool CanSeek => true;

        public override long Length => length;

        public override long Position
        {
            get => position;
            set
            {
                if (value > rawBuffer.Length)
                {
                    throw new IndexOutOfRangeException();
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
            if (pool is null)
            {
                throw new ArgumentNullException(nameof(pool));
            }

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
            int newPosition;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newPosition = (int)offset;
                    break;
                case SeekOrigin.End:
                    newPosition = length - (int)offset;
                    break;
                case SeekOrigin.Current:
                    newPosition = position + (int)offset;
                    break;
                default:
                    throw new ArgumentException("Invalid seek origin.", nameof(origin));
            }

            if ((newPosition < 0) || (newPosition > rawBuffer.Length))
            {
                throw new IndexOutOfRangeException();
            }

            return position;
        }

        public override void SetLength(long value)
        {
            if ((value < 0) || (value > int.MaxValue))
            {
                throw new IndexOutOfRangeException();
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
            if (rawBuffer.Length < size)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
#pragma warning restore IDE0032
}
#endif
