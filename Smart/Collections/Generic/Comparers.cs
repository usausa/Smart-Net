namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public static class Comparers
    {
        public static ChainComparer<T> Chain<T>(params IComparer<T>[] comparers) => new(comparers);

        public static ComparisonComparer<T> Comparison<T>(Comparison<T> comparison) => new(comparison);

        public static DelegateComparer<T> Delegate<T>(Func<T, T, int> comparer) => new(comparer);

        public static DelegateEqualityComparer<T> DelegateEquality<T>(Func<T, T, bool> equals, Func<T, int> getHashCode) => new(equals, getHashCode);

        public static ProjectionComparer<TSource, TKey> Projection<TSource, TKey>(Func<TSource, TKey> keySelector) => new(keySelector);

        public static ProjectionEqualityComparer<TSource, TKey> ProjectionEquality<TSource, TKey>(Func<TSource, TKey> keySelector) => new(keySelector);

        public static IComparer<T> Reverse<T>(this IComparer<T> original) =>
            original is ReverseComparer<T> originalAsReverse ? originalAsReverse.OriginalComparer : new ReverseComparer<T>(original);
    }
}
