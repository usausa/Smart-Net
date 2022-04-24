namespace Smart.Collections.Generic;

public sealed class ComparisonComparer<T> : IComparer<T>
{
    private readonly Comparison<T> comparison;

    public ComparisonComparer(Comparison<T> comparison)
    {
        this.comparison = comparison;
    }

    public int Compare(T? x, T? y) => comparison(x!, y!);
}
