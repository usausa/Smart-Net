namespace Smart.Linq;

using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // Each
    //--------------------------------------------------------------------------------

    public static void Each<TSource>(this Span<TSource> source, Action<TSource> action)
    {
        for (var i = 0; i < source.Length; i++)
        {
            action(source[i]);
        }
    }

    public static void Each<TSource>(this ReadOnlySpan<TSource> source, Action<TSource> action)
    {
        for (var i = 0; i < source.Length; i++)
        {
            action(source[i]);
        }
    }

    public static void Each<TSource>(this TSource[] source, Action<TSource> action) =>
        source.AsSpan().Each(action);

    public static void Each<TSource>(this TSource[] source, int start, int length, Action<TSource> action) =>
        source.AsSpan(start, length).Each(action);

    public static void Each<TSource>(this List<TSource> source, Action<TSource> action) =>
        CollectionsMarshal.AsSpan(source).Each(action);

    public static void Each<TSource>(this List<TSource> source, int start, int length, Action<TSource> action) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Each(action);

    public static void Each<TSource>(this IList<TSource> source, Action<TSource> action)
    {
        for (var i = 0; i < source.Count; i++)
        {
            action(source[i]);
        }
    }

    public static void Each<TSource>(this IList<TSource> source, int start, int length, Action<TSource> action)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            action(source[i]);
        }
    }

    public static void Each<TSource>(this IReadOnlyList<TSource> source, Action<TSource> action)
    {
        for (var i = 0; i < source.Count; i++)
        {
            action(source[i]);
        }
    }

    public static void Each<TSource>(this IReadOnlyList<TSource> source, int start, int length, Action<TSource> action)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            action(source[i]);
        }
    }

    //--------------------------------------------------------------------------------
    // Each with state
    //--------------------------------------------------------------------------------

    public static void Each<TSource, TState>(this Span<TSource> source, TState state, Action<TSource, TState> action)
    {
        for (var i = 0; i < source.Length; i++)
        {
            action(source[i], state);
        }
    }

    public static void Each<TSource, TState>(this ReadOnlySpan<TSource> source, TState state, Action<TSource, TState> action)
    {
        for (var i = 0; i < source.Length; i++)
        {
            action(source[i], state);
        }
    }

    public static void Each<TSource, TState>(this TSource[] source, TState state, Action<TSource, TState> action) =>
        source.AsSpan().Each(state, action);

    public static void Each<TSource, TState>(this TSource[] source, int start, int length, TState state, Action<TSource, TState> action) =>
        source.AsSpan(start, length).Each(state, action);

    public static void Each<TSource, TState>(this List<TSource> source, TState state, Action<TSource, TState> action) =>
        CollectionsMarshal.AsSpan(source).Each(state, action);

    public static void Each<TSource, TState>(this List<TSource> source, int start, int length, TState state, Action<TSource, TState> action) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).Each(state, action);

    public static void Each<TSource, TState>(this IList<TSource> source, TState state, Action<TSource, TState> action)
    {
        for (var i = 0; i < source.Count; i++)
        {
            action(source[i], state);
        }
    }

    public static void Each<TSource, TState>(this IList<TSource> source, int start, int length, TState state, Action<TSource, TState> action)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            action(source[i], state);
        }
    }

    public static void Each<TSource, TState>(this IReadOnlyList<TSource> source, TState state, Action<TSource, TState> action)
    {
        for (var i = 0; i < source.Count; i++)
        {
            action(source[i], state);
        }
    }

    public static void Each<TSource, TState>(this IReadOnlyList<TSource> source, int start, int length, TState state, Action<TSource, TState> action)
    {
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            action(source[i], state);
        }
    }
}
