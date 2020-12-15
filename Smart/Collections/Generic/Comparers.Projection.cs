#nullable disable
namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public sealed class ProjectionComparer<TSource, TKey> : IComparer<TSource>
    {
        private readonly Func<TSource, TKey> keySelector;

        private readonly IComparer<TKey> comparer;

        public ProjectionComparer(Func<TSource, TKey> keySelector)
            : this(keySelector, null)
        {
        }

        public ProjectionComparer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.comparer = comparer ?? Comparer<TKey>.Default;
            this.keySelector = keySelector;
        }

        public int Compare(TSource x, TSource y)
        {
            if (Equals(x, default(TSource)) && Equals(y, default(TSource)))
            {
                return 0;
            }

            if (Equals(x, default(TSource)))
            {
                return -1;
            }

            if (Equals(y, default(TSource)))
            {
                return 1;
            }

            return comparer.Compare(keySelector(x), keySelector(y));
        }
    }
}
