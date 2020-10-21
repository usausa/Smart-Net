namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class ComparerEnumerable
    {
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, int> compare) =>
            source.OrderBy(keySelector, Comparers.Delegate(compare));

        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, int> compare) =>
            source.OrderByDescending(keySelector, Comparers.Delegate(compare));

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, int> compare) =>
            source.ThenBy(keySelector, Comparers.Delegate(compare));

        public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, int> compare) =>
            source.ThenByDescending(keySelector, Comparers.Delegate(compare));
    }
}
