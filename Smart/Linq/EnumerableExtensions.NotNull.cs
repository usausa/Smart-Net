namespace Smart.Linq;

using System.Linq;
using System.Runtime.CompilerServices;

public static partial class EnumerableExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> SelectNotNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult?> selector)
        where TResult : class =>
        (IEnumerable<TResult>)source.Select(selector).Where(static x => x is not null);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> SelectNotNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult?> selector)
        where TResult : struct =>
        (IEnumerable<TResult>)source.Select(selector).Where(static x => x.HasValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> WhereNotNull<TResult>(this IEnumerable<TResult?> source)
        where TResult : class =>
        (IEnumerable<TResult>)source.Where(static x => x is not null);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> WhereNotNull<TResult>(this IEnumerable<TResult?> source)
        where TResult : struct =>
        (IEnumerable<TResult>)source.Where(static x => x.HasValue);
}
