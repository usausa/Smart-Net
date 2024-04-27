namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // Any
    //--------------------------------------------------------------------------------

    // TODO state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this Span<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i]))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i]))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().Any(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).Any(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Any(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Any(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this IList<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
        {
            if (predicate(source[i]))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
        {
            if (predicate(source[i]))
            {
                return true;
            }
        }

        return false;
    }
}
