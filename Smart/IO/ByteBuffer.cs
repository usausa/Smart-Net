namespace Smart.IO
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public class ByteBuffer
    {
        // position <= limit <= array.Length

        private int position;

        private int limit;

        private IByteOrder order = ByteOrders.Default;

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Performance")]
        public byte[] Array { get; }

        /// <summary>
        ///
        /// </summary>
        public int Position
        {
            get { return position; }
            set
            {
                if ((value > limit) || (value < 0))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                position = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int Limit
        {
            get { return limit; }
            set
            {
                if ((value > Capacity) || (value < 0))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                limit = value;
                if (position > limit)
                {
                    position = limit;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        ///
        /// </summary>
        public int Remaining => limit - position;

        /// <summary>
        ///
        /// </summary>
        public bool HasRemaining => position < limit;

        /// <summary>
        ///
        /// </summary>
        /// <param name="capacity"></param>
        public ByteBuffer(int capacity)
        {
            Array = new byte[capacity];
            Capacity = capacity;
            limit = capacity;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        public ByteBuffer(byte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array = array;
            Capacity = array.Length;
            limit = Capacity;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        public ByteBuffer(byte[] array, int offset, int length)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array = array;
            position = offset;
            Capacity = length;
            limit = length;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static ByteBuffer CopyOf(ByteBuffer array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            return CopyOf(array.Array, array.position, array.Remaining);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ByteBuffer CopyOf(byte[] array, int offset, int length)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var copy = new byte[length];
            Buffer.BlockCopy(array, offset, copy, 0, length);
            return new ByteBuffer(copy, 0, length);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ByteBuffer Clear()
        {
            position = 0;
            limit = Capacity;
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ByteBuffer Flip()
        {
            limit = position;
            position = 0;
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="byteOrder"></param>
        /// <returns></returns>
        public ByteBuffer Order(IByteOrder byteOrder)
        {
            if (byteOrder == null)
            {
                throw new ArgumentNullException(nameof(byteOrder));
            }

            order = byteOrder;
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ByteBuffer Put(int index, byte value)
        {
            Array[index] = value;
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ByteBuffer PutBytes(int index, byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Buffer.BlockCopy(value, 0, Array, index, value.Length);
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ByteBuffer PutShort(int index, short value)
        {
            order.PutShort(Array, index, value);
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ByteBuffer PutInt(int index, int value)
        {
            order.PutInt(Array, index, value);
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public byte Get(int index)
        {
            return Array[index];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public byte[] GetBytes(int index, int length)
        {
            var bytes = new byte[length];
            Buffer.BlockCopy(Array, index, bytes, 0, length);
            return bytes;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public short GetShort(int index)
        {
            return order.GetShort(Array, index);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetInt(int index)
        {
            return order.GetInt(Array, index);
        }
    }
}
