namespace Smart.Linq;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class EnumerableExtensions
{
    //--------------------------------------------------------------------------------
    // IndexOf
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf<T>(this Span<T> source, Func<T, bool> predicate)
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
    public static int IndexOf<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
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
    public static int IndexOf<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().IndexOf(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).IndexOf(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).IndexOf(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).IndexOf(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf<T>(this IList<T> source, Func<T, bool> predicate)
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
    public static int IndexOf<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
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
    public static int IndexOf<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        for (var i = start; i < max; i++)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    //--------------------------------------------------------------------------------
    // LastIndexOf
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf<T>(this Span<T> source, Func<T, bool> predicate)
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
    public static int LastIndexOf<T>(this ReadOnlySpan<T> source, Func<T, bool> predicate)
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
    public static int LastIndexOf<T>(this T[] source, Func<T, bool> predicate) =>
        source.AsSpan().LastIndexOf(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf<T>(this T[] source, int start, int length, Func<T, bool> predicate) =>
        source.AsSpan(start, length).LastIndexOf(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf<T>(this List<T> source, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).LastIndexOf(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf<T>(this List<T> source, int start, int length, Func<T, bool> predicate) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).LastIndexOf(predicate);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf<T>(this IList<T> source, Func<T, bool> predicate)
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
    public static int LastIndexOf<T>(this IList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        if (start < 0)
        {
            start = 0;
        }

        for (var i = max - 1; i >= start; i--)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf<T>(this IReadOnlyList<T> source, Func<T, bool> predicate)
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
    public static int LastIndexOf<T>(this IReadOnlyList<T> source, int start, int length, Func<T, bool> predicate)
    {
        var last = start + length;
        var max = last > source.Count ? source.Count : last;
        if (start < 0)
        {
            start = 0;
        }

        for (var i = max - 1; i >= start; i--)
        {
            if (predicate(source[i]))
            {
                return i;
            }
        }

        return -1;
    }
}
