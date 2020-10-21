namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public static class Comparers
    {
        public static ChainComparer<T> Chain<T>(params IComparer<T>[] comparers) =>
            new ChainComparer<T>(comparers);

        public static ComparisonComparer<T> Comparison<T>(Comparison<T> comparison) =>
            new ComparisonComparer<T>(comparison);

        public static DelegateComparer<T> Delegate<T>(Func<T, T, int> comparer) =>
            new DelegateComparer<T>(comparer);

        public static IEqualityComparer<T> DelegateEquality<T>(Func<T, T, bool> equals, Func<T, int> getHashCode) =>
            new DelegateEqualityComparer<T>(equals, getHashCode);

        public static ProjectionComparer<TSource, TKey> Projection<TSource, TKey>(Func<TSource, TKey> keySelector) =>
            new ProjectionComparer<TSource, TKey>(keySelector);

        public static ProjectionEqualityComparer<TSource, TKey> ProjectionEquality<TSource, TKey>(Func<TSource, TKey> keySelector) =>
            new ProjectionEqualityComparer<TSource, TKey>(keySelector);

        public static IComparer<T> Reverse<T>(this IComparer<T> original) =>
            original is ReverseComparer<T> originalAsReverse
                ? originalAsReverse.OriginalComparer
                : new ReverseComparer<T>(original);
    }
}
