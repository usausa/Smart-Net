namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class ComparerEnumerable
    {
        public static bool Contains<TSource, TCompareKey>(this IEnumerable<TSource> source, TSource value, Func<TSource, TCompareKey> compareKeySelector)
        {
            return source.Contains(value, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<TSource> Distinct<TSource, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TCompareKey> compareKeySelector)
        {
            return source.Distinct(Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<TSource> Except<TSource, TCompareKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TCompareKey> compareKeySelector)
        {
            return first.Except(second, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return source.GroupBy(keySelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return source.GroupBy(keySelector, resultSelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return source.GroupBy(keySelector, elementSelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return source.GroupBy(keySelector, elementSelector, resultSelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult, TCompareKey>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return outer.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<TSource> Intersect<TSource, TCompareKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TCompareKey> compareKeySelector)
        {
            return first.Intersect(second, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult, TCompareKey>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static bool SequenceEqual<TSource, TCompareKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TCompareKey> compareKeySelector)
        {
            return first.SequenceEqual(second, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return source.ToDictionary(keySelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return source.ToDictionary(keySelector, elementSelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static ILookup<TKey, TSource> ToLookup<TSource, TKey, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return source.ToLookup(keySelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement, TCompareKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TCompareKey> compareKeySelector)
        {
            return source.ToLookup(keySelector, elementSelector, Comparers.ProjectionEquality(compareKeySelector));
        }

        public static IEnumerable<TSource> Union<TSource, TCompareKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TCompareKey> compareKeySelector)
        {
            return first.Union(second, Comparers.ProjectionEquality(compareKeySelector));
        }
    }
}
