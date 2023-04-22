namespace Smart.Collections.Generic;

public sealed class ChainComparer<T> : IComparer<T>
{
    private readonly IComparer<T>[] comparers;

    public ChainComparer(params IComparer<T>[] comparers)
    {
        this.comparers = comparers;
    }

    public int Compare(T? x, T? y)
    {
        var local = comparers;
        for (var i = 0; i < local.Length; i++)
        {
            var ret = local[i].Compare(x, y);
            if (ret != 0)
            {
                return ret;
            }
        }

        return 0;
    }
}
