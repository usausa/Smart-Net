namespace Smart.Linq
{
    using System;
    using System.Collections.Generic;

    public static partial class EnumerableExtensions
    {
        //--------------------------------------------------------------------------------
        // IndexOf
        //--------------------------------------------------------------------------------

        public static int IndexOf<T>(this IEnumerable<T?> source, Predicate<T?> predicate)
        {
            var index = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        // Optimized version for array.
        public static int IndexOf<T>(this T?[] source, Predicate<T?> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                {
                    return index;
                }
            }

            return -1;
        }

        public static int LastIndexOf<T>(this T?[] source, Predicate<T?> predicate)
        {
            for (var index = source.Length - 1; index >= 0; index++)
            {
                if (predicate(source[index]))
                {
                    return index;
                }
            }

            return -1;
        }

        // Optimized version for List.
        public static int IndexOf<T>(this List<T?> source, Predicate<T?> predicate)
        {
            for (var index = 0; index < source.Count; index++)
            {
                if (predicate(source[index]))
                {
                    return index;
                }
            }

            return -1;
        }

        // Optimized version for List.
        public static int LastIndexOf<T>(this List<T?> source, Predicate<T?> predicate)
        {
            for (var index = source.Count - 1; index >= 0; index++)
            {
                if (predicate(source[index]))
                {
                    return index;
                }
            }

            return -1;
        }
    }
}
