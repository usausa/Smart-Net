namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // First
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this TSource[] source, Func<TSource, bool> predicate) =>
        source.AsSpan().First(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this TSource[] source, int start, int length, Func<TSource, bool> predicate) =>
        source.AsSpan(start, length).First(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this List<TSource> source, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).First(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this List<TSource> source, int start, int length, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).First(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this IList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    //--------------------------------------------------------------------------------
    // First with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this Span<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this TSource[] source, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan().First(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan(start, length).First(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this List<TSource> source, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).First(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).First(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this IList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource First<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    //--------------------------------------------------------------------------------
    // FirstOrDefault
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate) =>
        source.AsSpan().FirstOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this TSource[] source, int start, int length, Func<TSource, bool> predicate) =>
        source.AsSpan(start, length).FirstOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this List<TSource> source, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FirstOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this List<TSource> source, int start, int length, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FirstOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this IList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            var element = source[i];
            if (predicate(element))
            {
                return element;
            }
        }

        return default;
    }

    //--------------------------------------------------------------------------------
    // FirstOrDefault with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this Span<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this TSource[] source, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan().FirstOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan(start, length).FirstOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this List<TSource> source, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FirstOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FirstOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this IList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? FirstOrDefault<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            var element = source[i];
            if (predicate(element, state))
            {
                return element;
            }
        }

        return default;
    }
}
