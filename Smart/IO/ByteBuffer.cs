namespace Smart.IO
{
    using System;

    public class ByteBuffer
    {
        // position <= limit <= array.Length

        private int position;

        private int limit;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Performance")]
        public byte[] Array { get; }

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

        public int Capacity { get; }

        public int Remaining => limit - position;

        public bool HasRemaining => position < limit;

        public ByteBuffer(int capacity)
        {
            Array = new byte[capacity];
            Capacity = capacity;
            limit = capacity;
        }

        public ByteBuffer(byte[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array = array;
            Capacity = array.Length;
            limit = Capacity;
        }

        public ByteBuffer(byte[] array, int offset, int length)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Array = array;
            position = offset;
            Capacity = length;
            limit = length;
        }

        public static ByteBuffer CopyOf(ByteBuffer array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            return CopyOf(array.Array, array.position, array.Remaining);
        }

        public static ByteBuffer CopyOf(byte[] array, int offset, int length)
        {
            var copy = new byte[length];
            Bytes.FastCopy(array, offset, copy, 0, length);
            return new ByteBuffer(copy, 0, length);
        }

        public ByteBuffer Clear()
        {
            position = 0;
            limit = Capacity;
            return this;
        }

        public ByteBuffer Flip()
        {
            limit = position;
            position = 0;
            return this;
        }
    }
}
