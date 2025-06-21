namespace Smart.Linq;

using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // Count
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
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
    public static int Count<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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
    public static int Count<TSource>(this TSource[] source, Func<TSource, bool> predicate) =>
        source.AsSpan().Count(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TSource>(this TSource[] source, int start, int length, Func<TSource, bool> predicate) =>
        source.AsSpan(start, length).Count(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TSource>(this List<TSource> source, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Count(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TSource>(this List<TSource> source, int start, int length, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Count(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TSource>(this ObservableCollection<TSource> source, Func<TSource, bool> predicate)
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
    public static int Count<TSource>(this ObservableCollection<TSource> source, int start, int length, Func<TSource, bool> predicate)
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
    public static int Count<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
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
    public static int Count<TSource>(this IList<TSource> source, int start, int length, Func<TSource, bool> predicate)
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
    public static int Count<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
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
    public static int Count<TSource>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, bool> predicate)
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
    public static int Count<TSource, TState>(this Span<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int Count<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int Count<TSource, TState>(this TSource[] source, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan().Count(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TSource, TState>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan(start, length).Count(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TSource, TState>(this List<TSource> source, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Count(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TSource, TState>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Count(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TSource, TState>(this ObservableCollection<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int Count<TSource, TState>(this ObservableCollection<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
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
    public static int Count<TSource, TState>(this IList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int Count<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
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
    public static int Count<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
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
    public static int Count<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
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
