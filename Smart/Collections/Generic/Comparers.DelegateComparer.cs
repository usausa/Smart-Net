namespace Smart.Collections.Generic;

using System;
using System.Collections.Generic;

public sealed class DelegateComparer<T> : IComparer<T>
{
    private readonly Func<T, T, int> comparer;

    public DelegateComparer(Func<T, T, int> comparer)
    {
        this.comparer = comparer;
    }

#if NETSTANDARD2_1
    public int Compare(T x, T y) => comparer(x, y);
#else
    public int Compare(T? x, T? y) => comparer(x!, y!);
#endif
}
