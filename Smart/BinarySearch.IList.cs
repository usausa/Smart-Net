namespace Smart
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static partial class BinarySearch
    {
        //--------------------------------------------------------------------------------
        // Func version
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T>(IList<T> list, Func<T, int> comparer) =>
            Find(list, 0, list.Count, comparer);

        public static int Find<T>(IList<T> list, int index, int length, Func<T, int> comparer)
        {
            var lo = index;
            var hi = index + length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer(list[mid]);

                if (c == 0)
                {
                    return mid;
                }

                if (c < 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return ~lo;
        }

        public static int FindFirst<T>(IList<T> list, Func<T, int> comparer) =>
            FindFirst(list, 0, list.Count, comparer);

        public static int FindFirst<T>(IList<T> list, int index, int length, Func<T, int> comparer)
        {
            var find = -1;
            var lo = index;
            var hi = index + length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer(list[mid]);

                if (c == 0)
                {
                    find = mid;
                    hi = mid - 1;
                }
                else if (c < 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return find >= 0 ? find : ~lo;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T>(IList<T> list, Func<T, int> comparer) =>
            FindLast(list, 0, list.Count, comparer);

        public static int FindLast<T>(IList<T> list, int index, int length, Func<T, int> comparer)
        {
            var find = -1;
            var lo = index;
            var hi = index + length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer(list[mid]);

                if (c == 0)
                {
                    find = mid;
                    lo = mid + 1;
                }
                else if (c < 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return find >= 0 ? find : ~lo;
        }

        //--------------------------------------------------------------------------------
        // IComparer version Find
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T>(IList<T> list, T key) =>
            Find(list, 0, list.Count, key, Functions<T>.Identify, Comparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T>(IList<T> list, T key, IComparer<T> comparer) =>
            Find(list, 0, list.Count, key, Functions<T>.Identify, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector) =>
            Find(list, 0, list.Count, key, selector, Comparer<TKey>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer) =>
            Find(list, 0, list.Count, key, selector, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T>(IList<T> list, int index, int length, T key) =>
            Find(list, index, length, key, Functions<T>.Identify, Comparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T>(IList<T> list, int index, int length, T key, IComparer<T> comparer) =>
            Find(list, index, length, key, Functions<T>.Identify, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T, TKey>(IList<T> list, int index, int length, TKey key, Func<T, TKey> selector) =>
            Find(list, index, length, key, selector, Comparer<TKey>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T, TKey>(IList<T> list, int index, int length, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            var lo = index;
            var hi = index + length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer.Compare(selector(list[mid]), key);

                if (c == 0)
                {
                    return mid;
                }

                if (c < 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return ~lo;
        }

        //--------------------------------------------------------------------------------
        // IComparer version FindFirst
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirst<T>(IList<T> list, T key) =>
            FindFirst(list, 0, list.Count, key, Functions<T>.Identify, Comparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirst<T>(IList<T> list, T key, IComparer<T> comparer) =>
            FindFirst(list, 0, list.Count, key, Functions<T>.Identify, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirst<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector) =>
            FindFirst(list, 0, list.Count, key, selector, Comparer<TKey>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirst<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer) =>
            FindFirst(list, 0, list.Count, key, selector, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirst<T>(IList<T> list, int index, int length, T key) =>
            FindFirst(list, index, length, key, Functions<T>.Identify, Comparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirst<T>(IList<T> list, int index, int length, T key, IComparer<T> comparer) =>
            FindFirst(list, index, length, key, Functions<T>.Identify, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirst<T, TKey>(IList<T> list, int index, int length, TKey key, Func<T, TKey> selector) =>
            FindFirst(list, index, length, key, selector, Comparer<TKey>.Default);

        public static int FindFirst<T, TKey>(IList<T> list, int index, int length, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            var find = -1;
            var lo = index;
            var hi = index + length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer.Compare(selector(list[mid]), key);

                if (c == 0)
                {
                    find = mid;
                    hi = mid - 1;
                }
                else if (c < 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return find >= 0 ? find : ~lo;
        }

        //--------------------------------------------------------------------------------
        // IComparer version FindLast
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T>(IList<T> list, T key) =>
            FindLast(list, 0, list.Count, key, Functions<T>.Identify, Comparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T>(IList<T> list, T key, IComparer<T> comparer) =>
            FindLast(list, 0, list.Count, key, Functions<T>.Identify, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector) =>
            FindLast(list, 0, list.Count, key, selector, Comparer<TKey>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer) =>
            FindLast(list, 0, list.Count, key, selector, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T>(IList<T> list, int index, int length, T key) =>
            FindLast(list, index, length, key, Functions<T>.Identify, Comparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T>(IList<T> list, int index, int length, T key, IComparer<T> comparer) =>
            FindLast(list, index, length, key, Functions<T>.Identify, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T, TKey>(IList<T> list, int index, int length, TKey key, Func<T, TKey> selector) =>
            FindLast(list, index, length, key, selector, Comparer<TKey>.Default);

        public static int FindLast<T, TKey>(IList<T> list, int index, int length, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            var find = -1;
            var lo = index;
            var hi = index + length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer.Compare(selector(list[mid]), key);

                if (c == 0)
                {
                    find = mid;
                    lo = mid + 1;
                }
                else if (c < 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return find >= 0 ? find : ~lo;
        }
    }
}
