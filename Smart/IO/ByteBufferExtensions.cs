namespace Smart.IO
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public static class ByteBufferExtensions
    {
        //--------------------------------------------------------------------------------
        // Index
        //--------------------------------------------------------------------------------

        public static ByteBuffer PutByte(this ByteBuffer buffer, int index, byte value)
        {
            buffer.Array[index] = value;
            return buffer;
        }

        public static ByteBuffer PutBytes(this ByteBuffer buffer, int index, byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Buffer.BlockCopy(value, 0, buffer.Array, index, value.Length);
            return buffer;
        }

        public static ByteBuffer PutShort(this ByteBuffer buffer, int index, short value)
        {
            ByteOrder.Default.PutShort(buffer.Array, index, value);
            return buffer;
        }

        public static ByteBuffer PutShortLE(this ByteBuffer buffer, int index, short value)
        {
            ByteOrder.PutShortLE(buffer.Array, index, value);
            return buffer;
        }

        public static ByteBuffer PutShortBE(this ByteBuffer buffer, int index, short value)
        {
            ByteOrder.PutShortBE(buffer.Array, index, value);
            return buffer;
        }

        public static ByteBuffer PutInt(this ByteBuffer buffer, int index, int value)
        {
            ByteOrder.Default.PutInt(buffer.Array, index, value);
            return buffer;
        }

        public static ByteBuffer PutIntLE(this ByteBuffer buffer, int index, int value)
        {
            ByteOrder.PutIntLE(buffer.Array, index, value);
            return buffer;
        }

        public static ByteBuffer PutIntBE(this ByteBuffer buffer, int index, int value)
        {
            ByteOrder.PutIntBE(buffer.Array, index, value);
            return buffer;
        }

        public static ByteBuffer PutLong(this ByteBuffer buffer, int index, long value)
        {
            ByteOrder.Default.PutLong(buffer.Array, index, value);
            return buffer;
        }

        public static ByteBuffer PutLongLE(this ByteBuffer buffer, int index, long value)
        {
            ByteOrder.PutLongLE(buffer.Array, index, value);
            return buffer;
        }

        public static ByteBuffer PutLongBE(this ByteBuffer buffer, int index, long value)
        {
            ByteOrder.PutLongBE(buffer.Array, index, value);
            return buffer;
        }

        public static byte GetByte(this ByteBuffer buffer, int index)
        {
            return buffer.Array[index];
        }

        public static byte[] GetBytes(this ByteBuffer buffer, int index, int length)
        {
            var bytes = new byte[length];
            Buffer.BlockCopy(buffer.Array, index, bytes, 0, length);
            return bytes;
        }

        public static short GetShort(this ByteBuffer buffer, int index)
        {
            return ByteOrder.Default.GetShort(buffer.Array, index);
        }

        public static short GetShortLE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetShortLE(buffer.Array, index);
        }

        public static short GetShortBE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetShortBE(buffer.Array, index);
        }

        public static int GetInt(this ByteBuffer buffer, int index)
        {
            return ByteOrder.Default.GetInt(buffer.Array, index);
        }

        public static int GetIntLE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetIntLE(buffer.Array, index);
        }

        public static int GetIntBE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetIntBE(buffer.Array, index);
        }

        public static long GetLong(this ByteBuffer buffer, int index)
        {
            return ByteOrder.Default.GetLong(buffer.Array, index);
        }

        public static long GetLongLE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetLongLE(buffer.Array, index);
        }

        public static long GetLongBE(this ByteBuffer buffer, int index)
        {
            return ByteOrder.GetLongBE(buffer.Array, index);
        }

        //--------------------------------------------------------------------------------
        // Position
        //--------------------------------------------------------------------------------

        public static ByteBuffer PutByte(this ByteBuffer buffer, byte value)
        {
            buffer.Array[buffer.Position] = value;
            return buffer;
        }

        public static ByteBuffer PutBytes(this ByteBuffer buffer, byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Buffer.BlockCopy(value, 0, buffer.Array, buffer.Position, value.Length);
            return buffer;
        }

        public static ByteBuffer PutShort(this ByteBuffer buffer, short value)
        {
            ByteOrder.Default.PutShort(buffer.Array, buffer.Position, value);
            return buffer;
        }

        public static ByteBuffer PutShortLE(this ByteBuffer buffer, short value)
        {
            ByteOrder.PutShortLE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        public static ByteBuffer PutShortBE(this ByteBuffer buffer, short value)
        {
            ByteOrder.PutShortBE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        public static ByteBuffer PutInt(this ByteBuffer buffer, int value)
        {
            ByteOrder.Default.PutInt(buffer.Array, buffer.Position, value);
            return buffer;
        }

        public static ByteBuffer PutIntLE(this ByteBuffer buffer, int value)
        {
            ByteOrder.PutIntLE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        public static ByteBuffer PutIntBE(this ByteBuffer buffer, int value)
        {
            ByteOrder.PutIntBE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        public static ByteBuffer PutLong(this ByteBuffer buffer, long value)
        {
            ByteOrder.Default.PutLong(buffer.Array, buffer.Position, value);
            return buffer;
        }

        public static ByteBuffer PutLongLE(this ByteBuffer buffer, long value)
        {
            ByteOrder.PutLongLE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        public static ByteBuffer PutLongBE(this ByteBuffer buffer, long value)
        {
            ByteOrder.PutLongBE(buffer.Array, buffer.Position, value);
            return buffer;
        }

        public static byte GetByte(this ByteBuffer buffer)
        {
            return buffer.Array[buffer.Position];
        }

        public static byte[] GetBytes(this ByteBuffer buffer, int length)
        {
            var bytes = new byte[length];
            Buffer.BlockCopy(buffer.Array, buffer.Position, bytes, 0, length);
            return bytes;
        }

        public static short GetShort(this ByteBuffer buffer)
        {
            return ByteOrder.Default.GetShort(buffer.Array, buffer.Position);
        }

        public static short GetShortLE(this ByteBuffer buffer)
        {
            return ByteOrder.GetShortLE(buffer.Array, buffer.Position);
        }

        public static short GetShortBE(this ByteBuffer buffer)
        {
            return ByteOrder.GetShortBE(buffer.Array, buffer.Position);
        }

        public static int GetInt(this ByteBuffer buffer)
        {
            return ByteOrder.Default.GetInt(buffer.Array, buffer.Position);
        }

        public static int GetIntLE(this ByteBuffer buffer)
        {
            return ByteOrder.GetIntLE(buffer.Array, buffer.Position);
        }

        public static int GetIntBE(this ByteBuffer buffer)
        {
            return ByteOrder.GetIntBE(buffer.Array, buffer.Position);
        }

        public static long GetLong(this ByteBuffer buffer)
        {
            return ByteOrder.Default.GetLong(buffer.Array, buffer.Position);
        }

        public static long GetLongLE(this ByteBuffer buffer)
        {
            return ByteOrder.GetLongLE(buffer.Array, buffer.Position);
        }

        public static long GetLongBE(this ByteBuffer buffer)
        {
            return ByteOrder.GetLongBE(buffer.Array, buffer.Position);
        }

        //--------------------------------------------------------------------------------
        // Step
        //--------------------------------------------------------------------------------

        public static ByteBuffer PutByteStep(this ByteBuffer buffer, byte value)
        {
            buffer.Array[buffer.Position] = value;
            buffer.Position += 1;
            return buffer;
        }

        public static ByteBuffer PutBytesStep(this ByteBuffer buffer, byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Buffer.BlockCopy(value, 0, buffer.Array, buffer.Position, value.Length);
            buffer.Position += value.Length;
            return buffer;
        }

        public static ByteBuffer PutShortStep(this ByteBuffer buffer, short value)
        {
            ByteOrder.Default.PutShort(buffer.Array, buffer.Position, value);
            buffer.Position += 2;
            return buffer;
        }

        public static ByteBuffer PutShortLEStep(this ByteBuffer buffer, short value)
        {
            ByteOrder.PutShortLE(buffer.Array, buffer.Position, value);
            buffer.Position += 2;
            return buffer;
        }

        public static ByteBuffer PutShortBEStep(this ByteBuffer buffer, short value)
        {
            ByteOrder.PutShortBE(buffer.Array, buffer.Position, value);
            buffer.Position += 2;
            return buffer;
        }

        public static ByteBuffer PutIntStep(this ByteBuffer buffer, int value)
        {
            ByteOrder.Default.PutInt(buffer.Array, buffer.Position, value);
            buffer.Position += 4;
            return buffer;
        }

        public static ByteBuffer PutIntLEStep(this ByteBuffer buffer, int value)
        {
            ByteOrder.PutIntLE(buffer.Array, buffer.Position, value);
            buffer.Position += 4;
            return buffer;
        }

        public static ByteBuffer PutIntBEStep(this ByteBuffer buffer, int value)
        {
            ByteOrder.PutIntBE(buffer.Array, buffer.Position, value);
            buffer.Position += 4;
            return buffer;
        }

        public static ByteBuffer PutLongStep(this ByteBuffer buffer, long value)
        {
            ByteOrder.Default.PutLong(buffer.Array, buffer.Position, value);
            buffer.Position += 8;
            return buffer;
        }

        public static ByteBuffer PutLongLEStep(this ByteBuffer buffer, long value)
        {
            ByteOrder.PutLongLE(buffer.Array, buffer.Position, value);
            buffer.Position += 8;
            return buffer;
        }

        public static ByteBuffer PutLongBEStep(this ByteBuffer buffer, long value)
        {
            ByteOrder.PutLongBE(buffer.Array, buffer.Position, value);
            buffer.Position += 8;
            return buffer;
        }

        public static byte GetByteStep(this ByteBuffer buffer)
        {
            var value = buffer.Array[buffer.Position];
            buffer.Position += 1;
            return value;
        }

        public static byte[] GetBytesStep(this ByteBuffer buffer, int length)
        {
            var bytes = new byte[length];
            Buffer.BlockCopy(buffer.Array, buffer.Position, bytes, 0, length);
            buffer.Position += length;
            return bytes;
        }

        public static short GetShortStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.Default.GetShort(buffer.Array, buffer.Position);
            buffer.Position += 2;
            return value;
        }

        public static short GetShortLEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetShortLE(buffer.Array, buffer.Position);
            buffer.Position += 2;
            return value;
        }

        public static short GetShortBEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetShortBE(buffer.Array, buffer.Position);
            buffer.Position += 2;
            return value;
        }

        public static int GetIntStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.Default.GetInt(buffer.Array, buffer.Position);
            buffer.Position += 4;
            return value;
        }

        public static int GetIntLEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetIntLE(buffer.Array, buffer.Position);
            buffer.Position += 4;
            return value;
        }

        public static int GetIntBEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetIntBE(buffer.Array, buffer.Position);
            buffer.Position += 4;
            return value;
        }

        public static long GetLongStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.Default.GetLong(buffer.Array, buffer.Position);
            buffer.Position += 8;
            return value;
        }

        public static long GetLongLEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetLongLE(buffer.Array, buffer.Position);
            buffer.Position += 8;
            return value;
        }

        public static long GetLongBEStep(this ByteBuffer buffer)
        {
            var value = ByteOrder.GetLongBE(buffer.Array, buffer.Position);
            buffer.Position += 8;
            return value;
        }
    }
}
