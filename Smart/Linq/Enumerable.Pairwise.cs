namespace Smart.Linq
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///
    /// </summary>
    public static partial class EnumerableExtensions
    {
        //--------------------------------------------------------------------------------
        // Pair
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Pairwise<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> resultSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (resultSelector == null)
            {
                throw new ArgumentNullException(nameof(resultSelector));
            }

            if (source is TSource[] array)
            {
                return Pairwise(array, resultSelector);
            }


            return PairwiseInternal(source, resultSelector);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        private static IEnumerable<TResult> PairwiseInternal<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TSource, TResult> resultSelector)
        {
            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext())
                {
                    yield break;
                }

                var previous = e.Current;
                while (e.MoveNext())
                {
                    yield return resultSelector(previous, e.Current);
                    previous = e.Current;
                }
            }
        }

        /// <summary>
        /// Optimized version for array.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Pairwise<TSource, TResult>(this TSource[] source, Func<TSource, TSource, TResult> resultSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (resultSelector == null)
            {
                throw new ArgumentNullException(nameof(resultSelector));
            }

            for (var index = 0; index < source.Length - 1; index++)
            {
                yield return resultSelector(source[index], source[index + 1]);
            }
        }

        /// <summary>
        /// Optimized version for IList.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Pairwise<TSource, TResult>(this IList<TSource> source, Func<TSource, TSource, TResult> resultSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (resultSelector == null)
            {
                throw new ArgumentNullException(nameof(resultSelector));
            }

            for (var index = 0; index < source.Count - 1; index++)
            {
                yield return resultSelector(source[index], source[index + 1]);
            }
        }
    }
}
