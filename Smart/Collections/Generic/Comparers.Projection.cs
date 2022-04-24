namespace Smart.Collections.Generic;

public sealed class ProjectionComparer<TSource, TKey> : IComparer<TSource>
{
    private readonly Func<TSource, TKey> keySelector;

    private readonly IComparer<TKey> comparer;

    public ProjectionComparer(Func<TSource, TKey> keySelector)
    {
        this.keySelector = keySelector;
        comparer = Comparer<TKey>.Default;
    }

    public ProjectionComparer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
    {
        this.keySelector = keySelector;
        this.comparer = comparer;
    }

    public int Compare(TSource? x, TSource? y)
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

        return comparer.Compare(keySelector(x!), keySelector(y!));
    }
}
