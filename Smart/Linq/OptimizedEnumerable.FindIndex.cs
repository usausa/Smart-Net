namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // FindIndex
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this Span<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().FindIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).FindIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FindIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FindIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this IList<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    //--------------------------------------------------------------------------------
    // FindIndex with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this Span<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this ReadOnlySpan<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this T[] source, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan().FindIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this T[] source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan(start, length).FindIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this List<T> source, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FindIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this List<T> source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FindIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this IList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this IList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this IReadOnlyList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<T, TState>(this IReadOnlyList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    //--------------------------------------------------------------------------------
    // FindLastIndex
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this Span<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().FindLastIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).FindLastIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FindLastIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FindLastIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this IList<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    //--------------------------------------------------------------------------------
    // FindLastIndex with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this Span<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this ReadOnlySpan<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this T[] source, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan().FindLastIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this T[] source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan(start, length).FindLastIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this List<T> source, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FindLastIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this List<T> source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FindLastIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this IList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this IList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this IReadOnlyList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<T, TState>(this IReadOnlyList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            if (predicate(source[i], state))
            {
                return i;
            }
        }

        return -1;
    }
}
