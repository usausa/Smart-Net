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

        // TODO 2

        public static ByteBuffer PutInt(this ByteBuffer buffer, int index, int value)
        {
            ByteOrder.Default.PutInt(buffer.Array, index, value);
            return buffer;
        }

        // TODO 2

        public static ByteBuffer PutLong(this ByteBuffer buffer, int index, long value)
        {
            ByteOrder.Default.PutLong(buffer.Array, index, value);
            return buffer;
        }

        // TODO 2

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

        // TODO 2

        public static int GetInt(this ByteBuffer buffer, int index)
        {
            return ByteOrder.Default.GetInt(buffer.Array, index);
        }

        // TODO 2

        public static long GetLong(this ByteBuffer buffer, int index)
        {
            return ByteOrder.Default.GetLong(buffer.Array, index);
        }

        // TODO 2

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

        // TODO 3

        // TODO 3

        // TODO 3

        public static byte GetByte(this ByteBuffer buffer)
        {
            return buffer.Array[buffer.Position];
        }

        // TODO

        // TODO 3

        // TODO 3

        // TODO 3

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

        // TODO 3

        // TODO 3

        // TODO 3

        public static byte GetByteStep(this ByteBuffer buffer)
        {
            var value = buffer.Array[buffer.Position];
            buffer.Position += 1;
            return value;
        }

        // TODO

        // TODO 3

        // TODO 3

        // TODO 3
    }
}
