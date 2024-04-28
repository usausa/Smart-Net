namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // Last
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this Span<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().Last(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).Last(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Last(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Last(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this IList<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    //--------------------------------------------------------------------------------
    // Last with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this Span<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this ReadOnlySpan<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this T[] source, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan().Last(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this T[] source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan(start, length).Last(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this List<T> source, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Last(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this List<T> source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Last(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this IList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this IList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this IReadOnlyList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T, TState>(this IReadOnlyList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    //--------------------------------------------------------------------------------
    // LastOrDefault
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this Span<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().LastOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).LastOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).LastOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).LastOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this IList<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            var result = source[i];
            if (predicate(result))
            {
                return result;
            }
        }

        return default;
    }

    //--------------------------------------------------------------------------------
    // LastOrDefault with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this Span<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this ReadOnlySpan<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Length - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this T[] source, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan().LastOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this T[] source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan(start, length).LastOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this List<T> source, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).LastOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this List<T> source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).LastOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this IList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this IList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this IReadOnlyList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = source.Count - 1; i >= 0; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T, TState>(this IReadOnlyList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = start + length - 1; i >= start; i--)
        {
            var result = source[i];
            if (predicate(result, state))
            {
                return result;
            }
        }

        return default;
    }
}
