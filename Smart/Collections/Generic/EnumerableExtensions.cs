namespace Smart.Collections.Generic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public static class EnumerableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return (source is null) || !source.Any();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}
