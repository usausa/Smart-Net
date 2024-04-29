namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // FindIndex
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
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
    public static int FindIndex<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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
    public static int FindIndex<TSource>(this TSource[] source, Func<TSource, bool> predicate) =>
        source.AsSpan().FindIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<TSource>(this TSource[] source, int start, int length, Func<TSource, bool> predicate) =>
        source.AsSpan(start, length).FindIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<TSource>(this List<TSource> source, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FindIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<TSource>(this List<TSource> source, int start, int length, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FindIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
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
    public static int FindIndex<TSource>(this IList<TSource> source, int start, int length, Func<TSource, bool> predicate)
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
    public static int FindIndex<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
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
    public static int FindIndex<TSource>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, bool> predicate)
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
    public static int FindIndex<TSource, TState>(this Span<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindIndex<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindIndex<TSource, TState>(this TSource[] source, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan().FindIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<TSource, TState>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan(start, length).FindIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<TSource, TState>(this List<TSource> source, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FindIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<TSource, TState>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FindIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindIndex<TSource, TState>(this IList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindIndex<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindIndex<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindIndex<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindLastIndex<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
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
    public static int FindLastIndex<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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
    public static int FindLastIndex<TSource>(this TSource[] source, Func<TSource, bool> predicate) =>
        source.AsSpan().FindLastIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<TSource>(this TSource[] source, int start, int length, Func<TSource, bool> predicate) =>
        source.AsSpan(start, length).FindLastIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<TSource>(this List<TSource> source, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FindLastIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<TSource>(this List<TSource> source, int start, int length, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FindLastIndex(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
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
    public static int FindLastIndex<TSource>(this IList<TSource> source, int start, int length, Func<TSource, bool> predicate)
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
    public static int FindLastIndex<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
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
    public static int FindLastIndex<TSource>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, bool> predicate)
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
    public static int FindLastIndex<TSource, TState>(this Span<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindLastIndex<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindLastIndex<TSource, TState>(this TSource[] source, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan().FindLastIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<TSource, TState>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan(start, length).FindLastIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<TSource, TState>(this List<TSource> source, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FindLastIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<TSource, TState>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FindLastIndex(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLastIndex<TSource, TState>(this IList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindLastIndex<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindLastIndex<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int FindLastIndex<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
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
