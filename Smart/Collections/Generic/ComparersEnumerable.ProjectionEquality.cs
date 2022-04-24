namespace Smart.Collections.Generic;

using System.Runtime.CompilerServices;

public static partial class ComparerEnumerable
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains<TSource, TCompareKey>(this IEnumerable<TSource> source, TSource value, Func<TSource, TCompareKey> compareKeySelector) =>
        source.Contains(value, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TSource> Distinct<TSource, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TCompareKey> compareKeySelector) =>
        source.Distinct(Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TSource> Except<TSource, TCompareKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TCompareKey> compareKeySelector) =>
        first.Except(second, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, Func<TKey, TCompareKey> compareKeySelector) =>
        source.GroupBy(keySelector, resultSelector, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TCompareKey> compareKeySelector) =>
        source.GroupBy(keySelector, elementSelector, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, Func<TKey, TCompareKey> compareKeySelector) =>
        source.GroupBy(keySelector, elementSelector, resultSelector, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult, TCompareKey>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, Func<TKey, TCompareKey> compareKeySelector) =>
        outer.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TSource> Intersect<TSource, TCompareKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TCompareKey> compareKeySelector) =>
        first.Intersect(second, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult, TCompareKey>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, Func<TKey, TCompareKey> compareKeySelector) =>
        outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SequenceEqual<TSource, TCompareKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TCompareKey> compareKeySelector) =>
        first.SequenceEqual(second, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TCompareKey> compareKeySelector)
        where TKey : notnull =>
        source.ToDictionary(keySelector, elementSelector, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TCompareKey> compareKeySelector) =>
        source.ToLookup(keySelector, elementSelector, Comparers.ProjectionEquality(compareKeySelector));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TSource> Union<TSource, TCompareKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TCompareKey> compareKeySelector) =>
        first.Union(second, Comparers.ProjectionEquality(compareKeySelector));
}
