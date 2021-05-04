namespace Smart.Collections.Generic
{
    using System.Collections.Generic;

    public sealed class ChainComparer<T> : IComparer<T>
    {
        private readonly IComparer<T>[] comparers;

        public ChainComparer(params IComparer<T>[] comparers)
        {
            this.comparers = comparers;
        }

#if NETSTANDARD2_1
        public int Compare(T x, T y)
#else
        public int Compare(T? x, T? y)
#endif
        {
            for (var i = 0; i < comparers.Length; i++)
            {
                var ret = comparers[i].Compare(x, y);
                if (ret != 0)
                {
                    return ret;
                }
            }

            return 0;
        }
    }
}
