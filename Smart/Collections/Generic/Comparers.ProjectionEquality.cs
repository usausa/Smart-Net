namespace Smart.Collections.Generic;

public sealed class ProjectionEqualityComparer<TSource, TKey> : IEqualityComparer<TSource>
{
    private readonly Func<TSource, TKey> keySelector;

    private readonly IEqualityComparer<TKey> comparer;

    public ProjectionEqualityComparer(Func<TSource, TKey> keySelector)
    {
        this.keySelector = keySelector;
        comparer = EqualityComparer<TKey>.Default;
    }

    public ProjectionEqualityComparer(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
        this.keySelector = keySelector;
        this.comparer = comparer;
    }

    public bool Equals(TSource? x, TSource? y)
    {
        if (x is null)
        {
            return y is null;
        }

        if (y is null)
        {
            return false;
        }

        return comparer.Equals(keySelector(x), keySelector(y));
    }

    public int GetHashCode(TSource obj) => comparer.GetHashCode(keySelector(obj)!);
}
