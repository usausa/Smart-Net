namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ComparisonComparer<T> : IComparer<T>
    {
        private readonly Comparison<T> comparison;

        /// <summary>
        ///
        /// </summary>
        /// <param name="comparison"></param>
        public ComparisonComparer(Comparison<T> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            this.comparison = comparison;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            return comparison(x, y);
        }
    }
}
