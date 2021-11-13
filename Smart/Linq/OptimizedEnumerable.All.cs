namespace Smart.Linq;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
    public static bool All<T>(this T[] source, Func<T, bool> predicate)
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
    public static bool All<T>(this T[] source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Length ? source.Length : last;
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
    public static bool All<T>(this List<T> source, Func<T, bool> predicate)
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
    public static bool All<T>(this List<T> source, int start, int length, Func<T, bool> predicate)
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
}
