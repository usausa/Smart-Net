namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // All
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T>(this Span<T> source, Func<T, bool> predicate)
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
    public static bool All<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
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
    public static bool All<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().All(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).All(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).All(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).All(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T>(this IList<T> source, Func<T, bool> predicate)
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
    public static bool All<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
        {
            if (!predicate(source[i]))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
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
    public static bool All<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
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
    public static bool All<T, TState>(this Span<T> source, TState state, Func<T, TState, bool> predicate)
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
    public static bool All<T, TState>(this ReadOnlySpan<T> source, TState state, Func<T, TState, bool> predicate)
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
    public static bool All<T, TState>(this T[] source, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan().All(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T, TState>(this T[] source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        source.AsSpan(start, length).All(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T, TState>(this List<T> source, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).All(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T, TState>(this List<T> source, int start, int length, TState state, Func<T, TState, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).All(state, predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T, TState>(this IList<T> source, TState state, Func<T, TState, bool> predicate)
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
    public static bool All<T, TState>(this IList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
        {
            if (!predicate(source[i], state))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool All<T, TState>(this IReadOnlyList<T> source, TState state, Func<T, TState, bool> predicate)
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
    public static bool All<T, TState>(this IReadOnlyList<T> source, int start, int length, TState state, Func<T, TState, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
        {
            if (!predicate(source[i], state))
            {
                return false;
            }
        }

        return true;
    }
}
