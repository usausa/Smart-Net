namespace Smart
{
    using System;

    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // IndexOf
        //--------------------------------------------------------------------------------

        public static int IndexOf<T>(this T[] array, Func<T, bool> predicate)
        {
            if (array is null)
            {
                return -1;
            }

            for (var i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int IndexOf<T>(this T[] array, int start, Func<T, bool> predicate)
        {
            if (array is null)
            {
                return -1;
            }

            for (var i = start; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int IndexOf<T>(this T[] array, int start, int count, Func<T, bool> predicate)
        {
            if (array is null)
            {
                return -1;
            }

            var end = start + count;
            var limit = end > array.Length ? array.Length : end;
            for (var i = start; i < limit; i++)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        //--------------------------------------------------------------------------------
        // LastIndexOf
        //--------------------------------------------------------------------------------

        public static int LastIndexOf<T>(this T[] array, Func<T, bool> predicate)
        {
            if (array is null)
            {
                return -1;
            }

            for (var i = array.Length - 1; i >= 0; i--)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int LastIndexOf<T>(this T[] array, int start, Func<T, bool> predicate)
        {
            if (array is null)
            {
                return -1;
            }

            for (var i = start; i >= 0; i--)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int LastIndexOf<T>(this T[] array, int start, int count, Func<T, bool> predicate)
        {
            if (array is null)
            {
                return -1;
            }

            var end = start + 1 - count;
            var limit = end < 0 ? 0 : end;
            for (var i = start; i >= limit; i--)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
