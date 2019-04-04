﻿namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public sealed class ProjectionEqualityComparer<TSource, TKey> : IEqualityComparer<TSource>
    {
        private readonly Func<TSource, TKey> keySelector;

        private readonly IEqualityComparer<TKey> comparer;

        public ProjectionEqualityComparer(Func<TSource, TKey> keySelector)
            : this(keySelector, null)
        {
        }

        public ProjectionEqualityComparer(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (keySelector is null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            this.comparer = comparer ?? EqualityComparer<TKey>.Default;
            this.keySelector = keySelector;
        }

        public bool Equals(TSource x, TSource y)
        {
            if (Object.Equals(x, default(TSource)) && Object.Equals(y, default(TSource)))
            {
                return true;
            }

            if (Object.Equals(x, default(TSource)) || Object.Equals(y, default(TSource)))
            {
                return false;
            }

            return comparer.Equals(keySelector(x), keySelector(y));
        }

        public int GetHashCode(TSource obj)
        {
            if (Object.Equals(obj, default(TSource)))
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return comparer.GetHashCode(keySelector(obj));
        }
    }
}
