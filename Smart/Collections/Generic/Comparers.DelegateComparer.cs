namespace Smart.Collections.Generic;

public sealed class DelegateComparer<T> : IComparer<T>
{
    private readonly Func<T, T, int> comparer;

    public DelegateComparer(Func<T, T, int> comparer)
    {
        this.comparer = comparer;
    }

    public int Compare(T? x, T? y) => comparer(x!, y!);
}
