namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public sealed class ComparisonComparer<T> : IComparer<T>
    {
        private readonly Comparison<T> comparison;

        public ComparisonComparer(Comparison<T> comparison)
        {
            if (comparison is null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            this.comparison = comparison;
        }

        public int Compare(T x, T y) => comparison(x, y);
    }
}
