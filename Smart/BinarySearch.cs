namespace Smart
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class BinarySearch
    {
        // TODO List wrapper?

        //--------------------------------------------------------------------------------
        // Func version
        //--------------------------------------------------------------------------------

        public static int Find<T>(Span<T> span, Func<T, int> comparer)
        {
            var lo = 0;
            var hi = span.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer(span[mid]);

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

        public static int FindFirst<T>(Span<T> span, Func<T, int> comparer)
        {
            var find = -1;
            var lo = 0;
            var hi = span.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer(span[mid]);

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

        public static int FindLast<T>(Span<T> span, Func<T, int> comparer)
        {
            var find = -1;
            var lo = 0;
            var hi = span.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer(span[mid]);

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
        public static int Find<T>(Span<T> span, T key)
        {
            return Find(span, key, Functions<T>.Identify, Comparer<T>.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T>(Span<T> span, T key, IComparer<T> comparer)
        {
            return Find(span, key, Functions<T>.Identify, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Find<T, TKey>(Span<T> span, TKey key, Func<T, TKey> selector)
        {
            return Find(span, key, selector, Comparer<TKey>.Default);
        }

        public static int Find<T, TKey>(Span<T> span, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            var lo = 0;
            var hi = span.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer.Compare(selector(span[mid]), key);

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
        public static int FindFirst<T>(Span<T> span, T key)
        {
            return FindFirst(span, key, Functions<T>.Identify, Comparer<T>.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirst<T>(Span<T> span, T key, IComparer<T> comparer)
        {
            return FindFirst(span, key, Functions<T>.Identify, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindFirst<T, TKey>(Span<T> span, TKey key, Func<T, TKey> selector)
        {
            return FindFirst(span, key, selector, Comparer<TKey>.Default);
        }

        public static int FindFirst<T, TKey>(Span<T> span, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            var find = -1;
            var lo = 0;
            var hi = span.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer.Compare(selector(span[mid]), key);

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
        public static int FindLast<T>(Span<T> span, T key)
        {
            return FindLast(span, key, Functions<T>.Identify, Comparer<T>.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T>(Span<T> span, T key, IComparer<T> comparer)
        {
            return FindLast(span, key, Functions<T>.Identify, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindLast<T, TKey>(Span<T> span, TKey key, Func<T, TKey> selector)
        {
            return FindLast(span, key, selector, Comparer<TKey>.Default);
        }

        public static int FindLast<T, TKey>(Span<T> span, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            var find = -1;
            var lo = 0;
            var hi = span.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + ((hi - lo) >> 1);

                var c = comparer.Compare(selector(span[mid]), key);

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
