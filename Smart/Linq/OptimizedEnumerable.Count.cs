namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // Count
    //--------------------------------------------------------------------------------

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
        for (var i = start; i < last; i++)
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
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i]))
            {
                count++;
            }
        }

        return count;
    }

    //--------------------------------------------------------------------------------
    // Count with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this Span<T> source, TState state, Func<T, TState, bool> predicate)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i], state))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this ReadOnlySpan<T> source, TState state, Func<T, TState, bool> predicate)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i], state))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this T[] source, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan().Count(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this T[] source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan(start, length).Count(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this List<T> source, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Count(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this List<T> source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Count(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this IList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        var count = 0;
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i], state))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this IList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var count = 0;
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i], state))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this IReadOnlyList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        var count = 0;
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i], state))
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<T, TState>(this IReadOnlyList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var count = 0;
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i], state))
            {
                count++;
            }
        }

        return count;
    }
}
