namespace Smart.Linq;

using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // Any
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
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
    public static bool Any<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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
    public static bool Any<TSource>(this TSource[] source, Func<TSource, bool> predicate) =>
        source.AsSpan().Any(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource>(this TSource[] source, int start, int length, Func<TSource, bool> predicate) =>
        source.AsSpan(start, length).Any(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource>(this List<TSource> source, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Any(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource>(this List<TSource> source, int start, int length, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Any(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource>(this ObservableCollection<TSource> source, Func<TSource, bool> predicate)
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
    public static bool Any<TSource>(this ObservableCollection<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i]))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
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
    public static bool Any<TSource>(this IList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i]))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
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
    public static bool Any<TSource>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i]))
            {
                return true;
            }
        }

        return false;
    }

    //--------------------------------------------------------------------------------
    // Any with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this Span<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i], state))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (predicate(source[i], state))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this TSource[] source, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan().Any(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan(start, length).Any(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this List<TSource> source, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Any(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Any(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this ObservableCollection<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i], state))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this ObservableCollection<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i], state))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this IList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i], state))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i], state))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i], state))
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (predicate(source[i], state))
            {
                return true;
            }
        }

        return false;
    }
}
