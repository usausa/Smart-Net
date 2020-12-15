#nullable disable
namespace Smart.Collections.Generic
{
    using System.Collections.Generic;

    public sealed class ObjectEqualityComparer<T> : IEqualityComparer<T>
        where T : class
    {
        public static IEqualityComparer<T> Default { get; } = new ObjectEqualityComparer<T>();

        public bool Equals(T x, T y) => x == y;

        public int GetHashCode(T obj) => obj.GetHashCode();
    }
}