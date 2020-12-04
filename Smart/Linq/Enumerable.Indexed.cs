namespace Smart.Linq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static partial class EnumerableExtensions
    {
        private sealed class IndexedEnumerator<T> : IEnumerator<Indexed<T>>
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
                ie.Dispose();
            }

            public Indexed<T> Current => new Indexed<T>(ie.Current, index);

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                index++;
                return ie.MoveNext();
            }

            public void Reset() => throw new NotSupportedException();
        }

        private readonly struct IndexedEnumerable<T> : IEnumerable<Indexed<T>>
        {
            private readonly IEnumerable<T> ie;

            public IndexedEnumerable(IEnumerable<T> ie)
            {
                this.ie = ie;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => new IndexedEnumerator<T>(ie.GetEnumerator());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            IEnumerator IEnumerable.GetEnumerator() => new IndexedEnumerator<T>(ie.GetEnumerator());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<Indexed<T>> Indexed<T>(this IEnumerable<T> source)
        {
            return new IndexedEnumerable<T>(source);
        }
    }
}