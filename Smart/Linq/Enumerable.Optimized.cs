namespace Smart.Linq
{
    using System;
    using System.Collections.Generic;

    public static partial class EnumerableExtensions
    {
        //--------------------------------------------------------------------------------
        // Count
        //--------------------------------------------------------------------------------

        // Optimized version for array.
        public static int Count<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            var count = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    count++;
                }
            }

            return count;
        }

        // Optimized version for List.
        public static int Count<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
        {
            var count = 0;
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    count++;
                }
            }

            return count;
        }

        //--------------------------------------------------------------------------------
        // Any
        //--------------------------------------------------------------------------------

        // Optimized version for array.
        public static bool Any<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    return true;
                }
            }

            return false;
        }

        // Optimized version for List.
        public static bool Any<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
        {
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    return true;
                }
            }

            return false;
        }

        //--------------------------------------------------------------------------------
        // All
        //--------------------------------------------------------------------------------

        // Optimized version for array.
        public static bool All<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            for (var i = 0; i < source.Length; i++)
            {
                if (!predicate(source[i]))
                {
                    return false;
                }
            }

            return true;
        }

        // Optimized version for IList.
        public static bool All<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
        {
            for (var i = 0; i < source.Count; i++)
            {
                if (!predicate(source[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
