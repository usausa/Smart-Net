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
        // Indexed.IList
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private struct IndexedListEnumerable<T> : IEnumerable<Indexed<T>>
        {
            private readonly IList<T> list;

            public IndexedListEnumerable(IList<T> list)
            {
                this.list = list;
            }

            private IndexedListEnumerator<T> GetEnumerator() => new IndexedListEnumerator<T>(list);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private struct IndexedListEnumerator<T> : IEnumerator<Indexed<T>>
        {
            public Indexed<T> Current => new Indexed<T>(list[index], index);

            private readonly IList<T> list;

            private int index;

            internal IndexedListEnumerator(IList<T> list)
            {
                this.list = list;
                index = -1;
            }

            public bool MoveNext()
            {
                index++;
                return index < list.Count;
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<Indexed<T>> Indexed<T>(this IList<T> source)
        {
            return new IndexedListEnumerable<T>(source);
        }

        //--------------------------------------------------------------------------------
        // Indexed.Array
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private struct IndexedArrayEnumerable<T> : IEnumerable<Indexed<T>>
        {
            private readonly T[] array;

            public IndexedArrayEnumerable(T[] array)
            {
                this.array = array;
            }

            private IndexedArrayEnumerator<T> GetEnumerator() => new IndexedArrayEnumerator<T>(array);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private struct IndexedArrayEnumerator<T> : IEnumerator<Indexed<T>>
        {
            public Indexed<T> Current => new Indexed<T>(array[index], index);

            private readonly T[] array;

            private int index;

            internal IndexedArrayEnumerator(T[] array)
            {
                this.array = array;
                index = -1;
            }

            public bool MoveNext()
            {
                index++;
                return index < array.Length;
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<Indexed<T>> Indexed<T>(this T[] source)
        {
            return new IndexedArrayEnumerable<T>(source);
        }

        //--------------------------------------------------------------------------------
        // Indexed
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private struct IndexedEnumerable<T> : IEnumerable<Indexed<T>>
        {
            private readonly IEnumerable<T> ie;

            public IndexedEnumerable(IEnumerable<T> ie) { this.ie = ie; }

            private IndexedEnumerator<T> GetEnumerator() => new IndexedEnumerator<T>(ie.GetEnumerator());

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private struct IndexedEnumerator<T> : IEnumerator<Indexed<T>>
        {
            public Indexed<T> Current => new Indexed<T>(ie.Current, index);

            private readonly IEnumerator<T> ie;

            private int index;

            internal IndexedEnumerator(IEnumerator<T> ie)
            {
                this.ie = ie;
                index = -1;
            }

            public bool MoveNext()
            {
                index++;
                return ie.MoveNext();
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<Indexed<T>> Indexed<T>(this IEnumerable<T> source)
        {
            return new IndexedEnumerable<T>(source);
        }
    }
}
