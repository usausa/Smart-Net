namespace Smart.Linq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    ///
    /// </summary>
    public static partial class EnumerableExtensions
    {
        //--------------------------------------------------------------------------------
        // Slice.Array
        //--------------------------------------------------------------------------------

        private struct SliceArrayEnumerator<T> : IEnumerator<T>
        {
            private readonly T[] array;

            private readonly int end;

            private int index;

            internal SliceArrayEnumerator(T[] array, int offset, int limit)
            {
                this.array = array;
                end = Math.Min(offset + limit, array.Length);
                index = Math.Max(offset, 0) - 1;
            }

            public void Dispose()
            {
            }

            public T Current => array[index];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                index++;
                return index < end;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        private struct SliceArrayEnumerable<T> : IEnumerable<T>
        {
            private readonly T[] array;

            private readonly int offset;

            private readonly int limit;

            public SliceArrayEnumerable(T[] array, int offset, int limit)
            {
                this.array = array;
                this.offset = offset;
                this.limit = limit;
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private SliceArrayEnumerator<T> GetEnumerator() => new SliceArrayEnumerator<T>(array, offset, limit);
        }

        public static IEnumerable<T> Slice<T>(this T[] source, int offset, int limit)
        {
            return new SliceArrayEnumerable<T>(source, offset, limit);
        }

        //--------------------------------------------------------------------------------
        // Slice.IList
        //--------------------------------------------------------------------------------

        private struct SliceListEnumerator<T> : IEnumerator<T>
        {
            private readonly IList<T> list;

            private readonly int end;

            private int index;

            internal SliceListEnumerator(IList<T> list, int offset, int limit)
            {
                this.list = list;
                end = Math.Min(offset + limit, list.Count);
                index = Math.Max(offset, 0) - 1;
            }

            public void Dispose()
            {
            }

            public T Current => list[index];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                index++;
                return index < end;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        private struct SliceListEnumerable<T> : IEnumerable<T>
        {
            private readonly IList<T> list;

            private readonly int offset;

            private readonly int limit;

            public SliceListEnumerable(IList<T> list, int offset, int limit)
            {
                this.list = list;
                this.offset = offset;
                this.limit = limit;
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private SliceListEnumerator<T> GetEnumerator() => new SliceListEnumerator<T>(list, offset, limit);
        }

        public static IEnumerable<T> Slice<T>(this IList<T> source, int offset, int limit)
        {
            return new SliceListEnumerable<T>(source, offset, limit);
        }

        //--------------------------------------------------------------------------------
        // Slice
        //--------------------------------------------------------------------------------

        private struct SliceEnumerator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> ie;

            private int count;

            internal SliceEnumerator(IEnumerator<T> ie, int offset, int limit)
            {
                while (offset > 0 && ie.MoveNext())
                {
                    offset--;
                }

                this.ie = ie;
                count = limit;
            }

            public void Dispose()
            {
            }

            public T Current => ie.Current;

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                count--;
                return count >= 0 && ie.MoveNext();
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        private struct SliceEnumerable<T> : IEnumerable<T>
        {
            private readonly IEnumerable<T> ie;

            private readonly int offset;

            private readonly int limit;

            public SliceEnumerable(IEnumerable<T> ie, int offset, int limit)
            {
                this.ie = ie;
                this.offset = offset;
                this.limit = limit;
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private SliceEnumerator<T> GetEnumerator() => new SliceEnumerator<T>(ie.GetEnumerator(), offset, limit);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int offset, int limit)
        {
            if (source is T[] array)
            {
                return new SliceArrayEnumerable<T>(array, offset, limit);
            }

            if (source is IList<T> list)
            {
                return new SliceListEnumerable<T>(list, offset, limit);
            }

            return new SliceEnumerable<T>(source, offset, limit);
        }
    }
}
