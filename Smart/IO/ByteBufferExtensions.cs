namespace Smart.IO
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///
    /// </summary>
    public static class ByteBufferExtensions
    {
        //--------------------------------------------------------------------------------
        // Index
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutByte(this ByteBuffer buffer, int index, byte value)
        {
            buffer.Array[index] = value;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ByteBuffer PutBytes(this ByteBuffer buffer, int index, byte[] value)
        {
            var length = value.Length;

            fixed (byte* pSrc = &value[0])
            fixed (byte* pDst = &buffer.Array[index])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ByteBuffer PutBytes(this ByteBuffer buffer, int index, byte[] value, int offset, int length)
        {
            fixed (byte* pSrc = &value[offset])
            fixed (byte* pDst = &buffer.Array[index])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ByteBuffer PutBytes(this ByteBuffer buffer, int index, ByteBuffer value)
        {
            var length = value.Remaining;

            fixed (byte* pSrc = &value.Array[value.Position])
            fixed (byte* pDst = &buffer.Array[index])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutShort(this ByteBuffer buffer, int index, short value)
        {
            ByteOrder.Default.PutShort(buffer.Array, index, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutShortLE(this ByteBuffer buffer, int index, short value)
        {
            ByteOrder.PutShortLE(buffer.Array, index, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutShortBE(this ByteBuffer buffer, int index, short value)
        {
            ByteOrder.PutShortBE(buffer.Array, index, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutInt(this ByteBuffer buffer, int index, int value)
        {
            ByteOrder.Default.PutInt(buffer.Array, index, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutIntLE(this ByteBuffer buffer, int index, int value)
        {
            ByteOrder.PutIntLE(buffer.Array, index, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutIntBE(this ByteBuffer buffer, int index, int value)
        {
            ByteOrder.PutIntBE(buffer.Array, index, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutLong(this ByteBuffer buffer, int index, long value)
        {
            ByteOrder.Default.PutLong(buffer.Array, index, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutLongLE(this ByteBuffer buffer, int index, long value)
        {
            ByteOrder.PutLongLE(buffer.Array, index, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutLongBE(this ByteBuffer buffer, int index, long value)
        {
            ByteOrder.PutLongBE(buffer.Array, index, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GetByte(this ByteBuffer buffer, int index)
        {
            return buffer.Array[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte[] GetBytes(this ByteBuffer buffer, int index, int length)
        {
            var bytes = new byte[length];

            fixed (byte* pSrc = &buffer.Array[index])
            fixed (byte* pDst = &bytes[0])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            return bytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void GetBytes(this ByteBuffer buffer, int index, byte[] destination, int offset, int length)
        {
            fixed (byte* pSrc = &buffer.Array[index])
            fixed (byte* pDst = &destination[offset])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShort(this ByteBuffer buffer, int index)
        {
            return ByteOrder.Default.GetShort(buffer.Array, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShortLE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetShortLE(buffer.Array, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShortBE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetShortBE(buffer.Array, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetInt(this ByteBuffer buffer, int index)
        {
            return ByteOrder.Default.GetInt(buffer.Array, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIntLE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetIntLE(buffer.Array, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIntBE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetIntBE(buffer.Array, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLong(this ByteBuffer buffer, int index)
        {
            return ByteOrder.Default.GetLong(buffer.Array, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLongLE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetLongLE(buffer.Array, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLongBE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetLongBE(buffer.Array, index);
        }

        //--------------------------------------------------------------------------------
        // Position
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutByte(this ByteBuffer buffer, byte value)
        {
            buffer.Array[buffer.Position] = value;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ByteBuffer PutBytes(this ByteBuffer buffer, byte[] value)
        {
            var length = value.Length;

            fixed (byte* pSrc = &value[0])
            fixed (byte* pDst = &buffer.Array[buffer.Position])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ByteBuffer PutBytes(this ByteBuffer buffer, byte[] value, int offset, int length)
        {
            fixed (byte* pSrc = &value[offset])
            fixed (byte* pDst = &buffer.Array[buffer.Position])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ByteBuffer PutBytes(this ByteBuffer buffer, ByteBuffer value)
        {
            var length = value.Remaining;

            fixed (byte* pSrc = &value.Array[value.Position])
            fixed (byte* pDst = &buffer.Array[buffer.Position])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutShort(this ByteBuffer buffer, short value)
        {
            ByteOrder.Default.PutShort(buffer.Array, buffer.Position, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutShortLE(this ByteBuffer buffer, short value)
        {
            ByteOrder.PutShortLE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutShortBE(this ByteBuffer buffer, short value)
        {
            ByteOrder.PutShortBE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutInt(this ByteBuffer buffer, int value)
        {
            ByteOrder.Default.PutInt(buffer.Array, buffer.Position, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutIntLE(this ByteBuffer buffer, int value)
        {
            ByteOrder.PutIntLE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutIntBE(this ByteBuffer buffer, int value)
        {
            ByteOrder.PutIntBE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutLong(this ByteBuffer buffer, long value)
        {
            ByteOrder.Default.PutLong(buffer.Array, buffer.Position, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutLongLE(this ByteBuffer buffer, long value)
        {
            ByteOrder.PutLongLE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutLongBE(this ByteBuffer buffer, long value)
        {
            ByteOrder.PutLongBE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GetByte(this ByteBuffer buffer)
        {
            return buffer.Array[buffer.Position];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte[] GetBytes(this ByteBuffer buffer, int length)
        {
            var bytes = new byte[length];

            fixed (byte* pSrc = &buffer.Array[buffer.Position])
            fixed (byte* pDst = &bytes[0])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            return bytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void GetBytes(this ByteBuffer buffer, byte[] destination, int offset, int length)
        {
            fixed (byte* pSrc = &buffer.Array[buffer.Position])
            fixed (byte* pDst = &destination[offset])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShort(this ByteBuffer buffer)
        {
            return ByteOrder.Default.GetShort(buffer.Array, buffer.Position);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShortLE(this ByteBuffer buffer)
        {
            return ByteOrder.GetShortLE(buffer.Array, buffer.Position);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShortBE(this ByteBuffer buffer)
        {
            return ByteOrder.GetShortBE(buffer.Array, buffer.Position);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetInt(this ByteBuffer buffer)
        {
            return ByteOrder.Default.GetInt(buffer.Array, buffer.Position);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIntLE(this ByteBuffer buffer)
        {
            return ByteOrder.GetIntLE(buffer.Array, buffer.Position);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIntBE(this ByteBuffer buffer)
        {
            return ByteOrder.GetIntBE(buffer.Array, buffer.Position);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLong(this ByteBuffer buffer)
        {
            return ByteOrder.Default.GetLong(buffer.Array, buffer.Position);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLongLE(this ByteBuffer buffer)
        {
            return ByteOrder.GetLongLE(buffer.Array, buffer.Position);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLongBE(this ByteBuffer buffer)
        {
            return ByteOrder.GetLongBE(buffer.Array, buffer.Position);
        }

        //--------------------------------------------------------------------------------
        // Step
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutByteStep(this ByteBuffer buffer, byte value)
        {
            buffer.Array[buffer.Position] = value;
            buffer.Position += 1;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ByteBuffer PutBytesStep(this ByteBuffer buffer, byte[] value)
        {
            var length = value.Length;

            fixed (byte* pSrc = &value[0])
            fixed (byte* pDst = &buffer.Array[buffer.Position])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            buffer.Position += length;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ByteBuffer PutBytesStep(this ByteBuffer buffer, byte[] value, int offset, int length)
        {
            fixed (byte* pSrc = &value[offset])
            fixed (byte* pDst = &buffer.Array[buffer.Position])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            buffer.Position += length;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ByteBuffer PutBytesStep(this ByteBuffer buffer, ByteBuffer value)
        {
            var length = value.Remaining;

            fixed (byte* pSrc = &value.Array[value.Position])
            fixed (byte* pDst = &buffer.Array[buffer.Position])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            buffer.Position += length;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutShortStep(this ByteBuffer buffer, short value)
        {
            ByteOrder.Default.PutShort(buffer.Array, buffer.Position, value);
            buffer.Position += 2;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutShortLEStep(this ByteBuffer buffer, short value)
        {
            ByteOrder.PutShortLE(buffer.Array, buffer.Position, value);
            buffer.Position += 2;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutShortBEStep(this ByteBuffer buffer, short value)
        {
            ByteOrder.PutShortBE(buffer.Array, buffer.Position, value);
            buffer.Position += 2;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutIntStep(this ByteBuffer buffer, int value)
        {
            ByteOrder.Default.PutInt(buffer.Array, buffer.Position, value);
            buffer.Position += 4;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutIntLEStep(this ByteBuffer buffer, int value)
        {
            ByteOrder.PutIntLE(buffer.Array, buffer.Position, value);
            buffer.Position += 4;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutIntBEStep(this ByteBuffer buffer, int value)
        {
            ByteOrder.PutIntBE(buffer.Array, buffer.Position, value);
            buffer.Position += 4;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutLongStep(this ByteBuffer buffer, long value)
        {
            ByteOrder.Default.PutLong(buffer.Array, buffer.Position, value);
            buffer.Position += 8;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutLongLEStep(this ByteBuffer buffer, long value)
        {
            ByteOrder.PutLongLE(buffer.Array, buffer.Position, value);
            buffer.Position += 8;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteBuffer PutLongBEStep(this ByteBuffer buffer, long value)
        {
            ByteOrder.PutLongBE(buffer.Array, buffer.Position, value);
            buffer.Position += 8;
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GetByteStep(this ByteBuffer buffer)
        {
            var value = buffer.Array[buffer.Position];
            buffer.Position += 1;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte[] GetBytesStep(this ByteBuffer buffer, int length)
        {
            var bytes = new byte[length];

            fixed (byte* pSrc = &buffer.Array[buffer.Position])
            fixed (byte* pDst = &bytes[0])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            buffer.Position += length;
            return bytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void GetBytesStep(this ByteBuffer buffer, byte[] destination, int offset, int length)
        {
            fixed (byte* pSrc = &buffer.Array[buffer.Position])
            fixed (byte* pDst = &destination[offset])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

            buffer.Position += length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShortStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.Default.GetShort(buffer.Array, buffer.Position);
            buffer.Position += 2;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShortLEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetShortLE(buffer.Array, buffer.Position);
            buffer.Position += 2;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GetShortBEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetShortBE(buffer.Array, buffer.Position);
            buffer.Position += 2;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIntStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.Default.GetInt(buffer.Array, buffer.Position);
            buffer.Position += 4;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIntLEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetIntLE(buffer.Array, buffer.Position);
            buffer.Position += 4;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIntBEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetIntBE(buffer.Array, buffer.Position);
            buffer.Position += 4;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLongStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.Default.GetLong(buffer.Array, buffer.Position);
            buffer.Position += 8;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLongLEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetLongLE(buffer.Array, buffer.Position);
            buffer.Position += 8;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetLongBEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetLongBE(buffer.Array, buffer.Position);
            buffer.Position += 8;
            return value;
        }
    }
}
