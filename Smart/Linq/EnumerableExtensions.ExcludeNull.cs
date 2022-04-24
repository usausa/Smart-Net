namespace Smart.Linq;

using System.Runtime.CompilerServices;

public static partial class EnumerableExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> ExcludeNull<T>(this IEnumerable<T?> source) => source.Where(x => x is not null)!;
}
