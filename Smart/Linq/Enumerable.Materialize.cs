namespace Smart.Linq
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

            if ((source is ICollection<T>) || (source is IReadOnlyCollection<T>))
            {
                return source;
            }

            return source.ToArray();
        }
    }
}
