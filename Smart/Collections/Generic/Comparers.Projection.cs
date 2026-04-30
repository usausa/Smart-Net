namespace Smart.Collections.Generic;

public sealed class ProjectionComparer<TSource, TKey> : IComparer<TSource>
{
    private static readonly EqualityComparer<TSource> EqualityComparer = EqualityComparer<TSource>.Default;

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
        if (EqualityComparer.Equals(x!, default!) && EqualityComparer.Equals(y!, default!))
        {
            return 0;
        }

        if (EqualityComparer.Equals(x!, default!))
        {
            return -1;
        }

        if (EqualityComparer.Equals(y!, default!))
        {
            return 1;
        }

        return comparer.Compare(keySelector(x!), keySelector(y!));
    }
}
