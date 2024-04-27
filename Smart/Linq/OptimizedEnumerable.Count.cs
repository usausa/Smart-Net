namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // Count
    //--------------------------------------------------------------------------------

    // TODO List

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this Span<T> source, Func<T, bool> predicate)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i]))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i]))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().Count(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).Count(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Count(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Count(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this IList<T> source, Func<T, bool> predicate)
    {
        var count = 0;
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var count = 0;
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
        {
            if (predicate(source[i]))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
    {
        var count = 0;
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var count = 0;
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
        {
            if (predicate(source[i]))
            {
                count++;
            }
        }

        return count;
    }
}
