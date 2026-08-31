namespace Smart.Collections.Generic;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#pragma warning disable CA1000
public sealed class ObjectEqualityComparer<T> : IEqualityComparer<T>
    where T : class
{
    public static ObjectEqualityComparer<T> Instance { get; } = new();

    private ObjectEqualityComparer()
    {
    }

    public bool Equals(T? x, T? y) => x == y;

    public int GetHashCode([DisallowNull] T obj) => RuntimeHelpers.GetHashCode(obj);
}
#pragma warning restore CA1000
