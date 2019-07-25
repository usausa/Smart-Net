namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class BinarySearch
    {
        //--------------------------------------------------------------------------------
        // Func version
        //--------------------------------------------------------------------------------

        public static int Find<T>(IList<T> list, Func<T, int> comparer)
        {
            return Find(list, 0, list.Count, comparer);
        }

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

        public static int FindFirst<T>(IList<T> list, Func<T, int> comparer)
        {
            return FindFirst(list, 0, list.Count, comparer);
        }

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

        public static int FindLast<T>(IList<T> list, Func<T, int> comparer)
        {
            return FindLast(list, 0, list.Count, comparer);
        }

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

        public static int Find<T>(IList<T> list, T key)
        {
            return Find(list, 0, list.Count, key, Functions<T>.Identify, Comparer<T>.Default);
        }

        public static int Find<T>(IList<T> list, T key, IComparer<T> comparer)
        {
            return Find(list, 0, list.Count, key, Functions<T>.Identify, comparer);
        }

        public static int Find<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector)
        {
            return Find(list, 0, list.Count, key, selector, Comparer<TKey>.Default);
        }

        public static int Find<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            return Find(list, 0, list.Count, key, selector, comparer);
        }

        public static int Find<T>(IList<T> list, int index, int length, T key)
        {
            return Find(list, index, length, key, Functions<T>.Identify, Comparer<T>.Default);
        }

        public static int Find<T>(IList<T> list, int index, int length, T key, IComparer<T> comparer)
        {
            return Find(list, index, length, key, Functions<T>.Identify, comparer);
        }

        public static int Find<T, TKey>(IList<T> list, int index, int length, TKey key, Func<T, TKey> selector)
        {
            return Find(list, index, length, key, selector, Comparer<TKey>.Default);
        }

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

        public static int FindFirst<T>(IList<T> list, T key)
        {
            return FindFirst(list, 0, list.Count, key, Functions<T>.Identify, Comparer<T>.Default);
        }

        public static int FindFirst<T>(IList<T> list, T key, IComparer<T> comparer)
        {
            return FindFirst(list, 0, list.Count, key, Functions<T>.Identify, comparer);
        }

        public static int FindFirst<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector)
        {
            return FindFirst(list, 0, list.Count, key, selector, Comparer<TKey>.Default);
        }

        public static int FindFirst<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            return FindFirst(list, 0, list.Count, key, selector, comparer);
        }

        public static int FindFirst<T>(IList<T> list, int index, int length, T key)
        {
            return FindFirst(list, index, length, key, Functions<T>.Identify, Comparer<T>.Default);
        }

        public static int FindFirst<T>(IList<T> list, int index, int length, T key, IComparer<T> comparer)
        {
            return FindFirst(list, index, length, key, Functions<T>.Identify, comparer);
        }

        public static int FindFirst<T, TKey>(IList<T> list, int index, int length, TKey key, Func<T, TKey> selector)
        {
            return FindFirst(list, index, length, key, selector, Comparer<TKey>.Default);
        }

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

        public static int FindLast<T>(IList<T> list, T key)
        {
            return FindLast(list, 0, list.Count, key, Functions<T>.Identify, Comparer<T>.Default);
        }

        public static int FindLast<T>(IList<T> list, T key, IComparer<T> comparer)
        {
            return FindLast(list, 0, list.Count, key, Functions<T>.Identify, comparer);
        }

        public static int FindLast<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector)
        {
            return FindLast(list, 0, list.Count, key, selector, Comparer<TKey>.Default);
        }

        public static int FindLast<T, TKey>(IList<T> list, TKey key, Func<T, TKey> selector, IComparer<TKey> comparer)
        {
            return FindLast(list, 0, list.Count, key, selector, comparer);
        }

        public static int FindLast<T>(IList<T> list, int index, int length, T key)
        {
            return FindLast(list, index, length, key, Functions<T>.Identify, Comparer<T>.Default);
        }

        public static int FindLast<T>(IList<T> list, int index, int length, T key, IComparer<T> comparer)
        {
            return FindLast(list, index, length, key, Functions<T>.Identify, comparer);
        }

        public static int FindLast<T, TKey>(IList<T> list, int index, int length, TKey key, Func<T, TKey> selector)
        {
            return FindLast(list, index, length, key, selector, Comparer<TKey>.Default);
        }

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
