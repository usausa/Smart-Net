namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // First
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T>(this Span<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
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
    public static T First<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
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
    public static T First<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().First(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).First(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).First(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).First(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T>(this IList<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
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
    public static T First<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
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
    public static T First<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
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
    public static T First<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
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
    // First with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T, TState>(this Span<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
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
    public static T First<T, TState>(this ReadOnlySpan<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
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
    public static T First<T, TState>(this T[] source, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan().First(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T, TState>(this T[] source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan(start, length).First(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T, TState>(this List<T> source, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).First(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T, TState>(this List<T> source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).First(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T, TState>(this IList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
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
    public static T First<T, TState>(this IList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
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
    public static T First<T, TState>(this IReadOnlyList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
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
    public static T First<T, TState>(this IReadOnlyList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
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
    // FirstOrDefault
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T>(this Span<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
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
    public static T? FirstOrDefault<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
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
    public static T? FirstOrDefault<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().FirstOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).FirstOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FirstOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FirstOrDefault(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T>(this IList<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
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
    public static T? FirstOrDefault<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
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
    public static T? FirstOrDefault<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
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
    public static T? FirstOrDefault<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
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
    // FirstOrDefault with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T, TState>(this Span<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
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
    public static T? FirstOrDefault<T, TState>(this ReadOnlySpan<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
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
    public static T? FirstOrDefault<T, TState>(this T[] source, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan().FirstOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T, TState>(this T[] source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan(start, length).FirstOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T, TState>(this List<T> source, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).FirstOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T, TState>(this List<T> source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).FirstOrDefault(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T, TState>(this IList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
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
    public static T? FirstOrDefault<T, TState>(this IList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
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
    public static T? FirstOrDefault<T, TState>(this IReadOnlyList<T> source, TState state, Func<T, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
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
    public static T? FirstOrDefault<T, TState>(this IReadOnlyList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
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
