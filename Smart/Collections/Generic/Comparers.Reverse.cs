namespace Smart.Collections.Generic
{
    using System.Collections.Generic;

    public sealed class ReverseComparer<T> : IComparer<T>
    {
        public IComparer<T> OriginalComparer { get; }

        public ReverseComparer(IComparer<T> original)
        {
            OriginalComparer = original;
        }

        public int Compare(T x, T y) => OriginalComparer.Compare(y, x);
    }
}
