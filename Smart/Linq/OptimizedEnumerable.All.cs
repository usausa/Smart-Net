namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // All
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (!predicate(source[i]))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (!predicate(source[i]))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this TSource[] source, Func<TSource, bool> predicate) =>
        source.AsSpan().All(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this TSource[] source, int start, int length, Func<TSource, bool> predicate) =>
        source.AsSpan(start, length).All(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this List<TSource> source, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).All(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this List<TSource> source, int start, int length, Func<TSource, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).All(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (!predicate(source[i]))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this IList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (!predicate(source[i]))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (!predicate(source[i]))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (!predicate(source[i]))
            {
                return false;
            }
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    // All with state
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this Span<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (!predicate(source[i], state))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Length; i++)
        {
            if (!predicate(source[i], state))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this TSource[] source, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan().All(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        source.AsSpan(start, length).All(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this List<TSource> source, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).All(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).All(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this IList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (!predicate(source[i], state))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (!predicate(source[i], state))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (!predicate(source[i], state))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, bool> predicate)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            if (!predicate(source[i], state))
            {
                return false;
            }
        }

        return true;
    }
}
