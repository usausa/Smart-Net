namespace Smart.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;

public static partial class ComparerEnumerable
{
    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison) =>
        source.OrderBy(keySelector, Comparers.Comparison(comparison));

    public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison) =>
        source.OrderByDescending(keySelector, Comparers.Comparison(comparison));

    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison) =>
        source.ThenBy(keySelector, Comparers.Comparison(comparison));

    public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, Comparison<TKey> comparison) =>
        source.ThenByDescending(keySelector, Comparers.Comparison(comparison));
}
