namespace Smart.Collections.Generic
{
    using System;

    public struct ArrayBuffer<T>
    {
        private T[] buffer;

        private int size;

        public ArrayBuffer(int initialSize)
        {
            buffer = initialSize > 0 ? new T[initialSize] : Array.Empty<T>();
            size = 0;
        }

        public void Add(T value)
        {
            if (size >= buffer.Length)
            {
                Array.Resize(ref buffer, size == 0 ? 4 : size * 2);
            }

            buffer[size] = value;
            size++;
        }

        public T[] ToArray()
        {
            if (buffer.Length == size)
            {
                return buffer;
            }

            var array = new T[size];
            Array.Copy(buffer, array, size);
            return array;
        }
    }
}
