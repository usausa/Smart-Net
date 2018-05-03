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
            get => position;
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
            get => limit;
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
        public static unsafe ByteBuffer CopyOf(byte[] array, int offset, int length)
        {
            var copy = new byte[length];

            fixed (byte* pSrc = &array[offset])
            fixed (byte* pDst = &copy[0])
            {
                Buffer.MemoryCopy(pSrc, pDst, length, length);
            }

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
    }
}
