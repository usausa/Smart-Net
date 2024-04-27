namespace Smart.Linq;

using System.Runtime.InteropServices;

public static partial class EnumerableExtensions
{
    //--------------------------------------------------------------------------------
    // Array/Span
    //--------------------------------------------------------------------------------

    public static TResult[] ToArray<TSource, TResult>(this Span<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TState, TResult>(this Span<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

#pragma warning disable CA1002
    public static List<TResult> ToList<TSource, TResult>(this List<TSource> source, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).ToList(selector);
#pragma warning restore CA1002

#pragma warning disable CA1002
    public static List<TResult> ToList<TSource, TState, TResult>(this List<TSource> source, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).ToList(state, selector);
#pragma warning restore CA1002

#pragma warning disable CA1002
    public static List<TResult> ToList<TSource, TResult>(this Span<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(source.Length);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Length; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }
#pragma warning restore CA1002

#pragma warning disable CA1002
    public static List<TResult> ToList<TSource, TState, TResult>(this Span<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(source.Length);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Length; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }
#pragma warning restore CA1002

    public static TResult[] ToArray<TSource, TResult>(this List<TSource> source, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).ToArray(selector);

    public static TResult[] ToArray<TSource, TState, TResult>(this List<TSource> source, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).ToArray(state, selector);
}
