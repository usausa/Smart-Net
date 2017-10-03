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
        // Indexed.Array
        //--------------------------------------------------------------------------------

        private struct IndexedArrayEnumerator<T> : IEnumerator<Indexed<T>>
        {
            private readonly T[] array;

            private int index;

            internal IndexedArrayEnumerator(T[] array)
            {
                this.array = array;
                index = -1;
            }

            public void Dispose()
            {
            }

            public Indexed<T> Current => new Indexed<T>(array[index], index);

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                index++;
                return index < array.Length;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        private struct IndexedArrayEnumerable<T> : IEnumerable<Indexed<T>>
        {
            private readonly T[] array;

            public IndexedArrayEnumerable(T[] array)
            {
                this.array = array;
            }

            IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private IndexedArrayEnumerator<T> GetEnumerator() => new IndexedArrayEnumerator<T>(array);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<Indexed<T>> Indexed<T>(this T[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return new IndexedArrayEnumerable<T>(source);
        }

        //--------------------------------------------------------------------------------
        // Indexed.IList
        //--------------------------------------------------------------------------------

        private struct IndexedListEnumerator<T> : IEnumerator<Indexed<T>>
        {
            private readonly IList<T> list;

            private int index;

            internal IndexedListEnumerator(IList<T> list)
            {
                this.list = list;
                index = -1;
            }

            public void Dispose()
            {
            }

            public Indexed<T> Current => new Indexed<T>(list[index], index);

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                index++;
                return index < list.Count;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        private struct IndexedListEnumerable<T> : IEnumerable<Indexed<T>>
        {
            private readonly IList<T> list;

            public IndexedListEnumerable(IList<T> list)
            {
                this.list = list;
            }

            IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private IndexedListEnumerator<T> GetEnumerator() => new IndexedListEnumerator<T>(list);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<Indexed<T>> Indexed<T>(this IList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return new IndexedListEnumerable<T>(source);
        }

        //--------------------------------------------------------------------------------
        // Indexed
        //--------------------------------------------------------------------------------

        private struct IndexedEnumerator<T> : IEnumerator<Indexed<T>>
        {
            private readonly IEnumerator<T> ie;

            private int index;

            internal IndexedEnumerator(IEnumerator<T> ie)
            {
                this.ie = ie;
                index = -1;
            }

            public void Dispose()
            {
            }

            public Indexed<T> Current => new Indexed<T>(ie.Current, index);

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                index++;
                return ie.MoveNext();
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        private struct IndexedEnumerable<T> : IEnumerable<Indexed<T>>
        {
            private readonly IEnumerable<T> ie;

            public IndexedEnumerable(IEnumerable<T> ie)
            {
                this.ie = ie;
            }

            IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private IndexedEnumerator<T> GetEnumerator() => new IndexedEnumerator<T>(ie.GetEnumerator());
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<Indexed<T>> Indexed<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source is T[] array)
            {
                return new IndexedArrayEnumerable<T>(array);
            }

            if (source is IList<T> list)
            {
                return new IndexedListEnumerable<T>(list);
            }

            return new IndexedEnumerable<T>(source);
        }
    }
}
