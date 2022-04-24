namespace Smart.Collections.Generic;

using System.Runtime.CompilerServices;

public static class Comparers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ChainComparer<T> Chain<T>(params IComparer<T>[] comparers) => new(comparers);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ComparisonComparer<T> Comparison<T>(Comparison<T> comparison) => new(comparison);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DelegateComparer<T> Delegate<T>(Func<T, T, int> comparer) => new(comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DelegateEqualityComparer<T> DelegateEquality<T>(Func<T, T, bool> equals, Func<T, int> getHashCode) => new(equals, getHashCode);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ProjectionComparer<TSource, TKey> Projection<TSource, TKey>(Func<TSource, TKey> keySelector) => new(keySelector);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ProjectionEqualityComparer<TSource, TKey> ProjectionEquality<TSource, TKey>(Func<TSource, TKey> keySelector) => new(keySelector);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IComparer<T> Reverse<T>(this IComparer<T> original) =>
        original is ReverseComparer<T> originalAsReverse ? originalAsReverse.OriginalComparer : new ReverseComparer<T>(original);
}
