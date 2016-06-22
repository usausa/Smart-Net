﻿namespace Smart.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///
    /// </summary>
    public static partial class EnumerableExtensions
    {
        //--------------------------------------------------------------------------------
        // Append
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
        {
            foreach (var i in source)
            {
                yield return i;
            }

            yield return item;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
        {
            yield return item;

            foreach (var i in source)
            {
                yield return i;
            }
        }

        //--------------------------------------------------------------------------------
        // Materialize
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Materialize<T>(this IEnumerable<T> source)
        {
            return source.Materialize(true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="nullToEmpty"></param>
        /// <returns></returns>
        public static IEnumerable<T> Materialize<T>(this IEnumerable<T> source, bool nullToEmpty)
        {
            if (nullToEmpty && source == null)
            {
                return Enumerable.Empty<T>();
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source is ICollection<T>)
            {
                return source;
            }

            return source.ToArray();
        }

        //--------------------------------------------------------------------------------
        // Index
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

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

        //--------------------------------------------------------------------------------
        // Indexed
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<Indexed<T>> Indexed<T>(this IEnumerable<T> source)
        {
            return source.Select((x, i) => new Indexed<T>(x, i));
        }
    }
}
