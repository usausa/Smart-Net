namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // Last
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
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
    public static TSource Last<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
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
    public static TSource Last<TSource>(this TSource[] source, Func<TSource, bool> predicate) =>
        source.AsSpan().Last(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource>(this TSource[] source, int start, int length, Func<TSource, bool> predicate) =>
        source.AsSpan(start, length).Last(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource>(this List<TSource> source, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Last(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource>(this List<TSource> source, int start, int length, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Last(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
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
    public static TSource Last<TSource>(this IList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
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
    public static TSource Last<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
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
    public static TSource Last<TSource>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
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
    // Last with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource, TState>(this Span<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
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
    public static TSource Last<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
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
    public static TSource Last<TSource, TState>(this TSource[] source, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan().Last(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource, TState>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan(start, length).Last(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource, TState>(this List<TSource> source, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Last(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource, TState>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Last(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource Last<TSource, TState>(this IList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
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
    public static TSource Last<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
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
    public static TSource Last<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
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
    public static TSource Last<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
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
    // LastOrDefault
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
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
    public static TSource? LastOrDefault<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
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
    public static TSource? LastOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate) =>
        source.AsSpan().LastOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource>(this TSource[] source, int start, int length, Func<TSource, bool> predicate) =>
        source.AsSpan(start, length).LastOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource>(this List<TSource> source, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).LastOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource>(this List<TSource> source, int start, int length, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).LastOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
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
    public static TSource? LastOrDefault<TSource>(this IList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
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
    public static TSource? LastOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
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
    public static TSource? LastOrDefault<TSource>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
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
    // LastOrDefault with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource, TState>(this Span<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
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
    public static TSource? LastOrDefault<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
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
    public static TSource? LastOrDefault<TSource, TState>(this TSource[] source, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan().LastOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource, TState>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan(start, length).LastOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource, TState>(this List<TSource> source, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).LastOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource, TState>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).LastOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource? LastOrDefault<TSource, TState>(this IList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
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
    public static TSource? LastOrDefault<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
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
    public static TSource? LastOrDefault<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
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
    public static TSource? LastOrDefault<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
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
