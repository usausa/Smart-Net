namespace Smart.Collections.Generic
{
    using System.Runtime.CompilerServices;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class HashArrayMap<TKey, TValue>
    {
        private readonly KeyValue[][] tables;

        private readonly int hashMask;

        public HashArrayMap(int count)
        {
            var mask = 0;
            for (var i = 1L; i < count; i *= 2)
            {
                mask = (mask << 1) + 1;
            }

            hashMask = mask;
            tables = new KeyValue[mask + 1L][];
        }

        //public void Add(TKey key, TValue value)
        //{
        //    var index = key.GetHashCode() % hashCount;

        //    var currentSize = tables[index]?.Length ?? 0;
        //    var newArray = new KeyValue[currentSize + 1];
        //    if (tables[index] != null)
        //    {
        //        Array.Copy(tables[index], 0, newArray, 0, currentSize);
        //    }

        //    newArray[currentSize] = new KeyValue(key, value);
        //    tables[index] = newArray;
        //}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(TKey key, out TValue value)
        {
            var index = key.GetHashCode() & hashMask;

            var array = tables[index];
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i].Key.Equals(key))
                {
                    value = array[i].Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }

        // TODO GetOrAdd

        private class KeyValue
        {
            public TKey Key { get; }

            public TValue Value { get; }

            public KeyValue(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
