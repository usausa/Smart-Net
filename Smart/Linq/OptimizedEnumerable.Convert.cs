namespace Smart.Linq;

using System.Runtime.InteropServices;

public static partial class OptimizedEnumerable
{
    //--------------------------------------------------------------------------------
    // ToArray
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

    public static TResult[] ToArray<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TResult>(this TSource[] source, Func<TSource, TResult> selector) =>
        source.AsSpan().ToArray(selector);

    public static TResult[] ToArray<TSource, TResult>(this TSource[] source, int start, int length, Func<TSource, TResult> selector) =>
        source.AsSpan(start, length).ToArray(selector);

    public static TResult[] ToArray<TSource, TResult>(this List<TSource> source, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).ToArray(selector);

    public static TResult[] ToArray<TSource, TResult>(this List<TSource> source, int start, int length, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).ToArray(selector);

    public static TResult[] ToArray<TSource, TResult>(this IList<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new TResult[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TResult>(this IList<TSource> source, int start, int length, Func<TSource, TResult> selector)
    {
        var destination = new TResult[length];
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TResult>(this IReadOnlyList<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new TResult[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TResult>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, TResult> selector)
    {
        var destination = new TResult[length];
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    //--------------------------------------------------------------------------------
    // ToArray with state
    //--------------------------------------------------------------------------------

    public static TResult[] ToArray<TSource, TState, TResult>(this Span<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TState, TResult>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TState, TResult>(this TSource[] source, TState state, Func<TSource, TState, TResult> selector) =>
        source.AsSpan().ToArray(state, selector);

    public static TResult[] ToArray<TSource, TState, TResult>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, TResult> selector) =>
        source.AsSpan(start, length).ToArray(state, selector);

    public static TResult[] ToArray<TSource, TState, TResult>(this List<TSource> source, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).ToArray(state, selector);

    public static TResult[] ToArray<TSource, TState, TResult>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).ToArray(state, selector);

    public static TResult[] ToArray<TSource, TState, TResult>(this IList<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TState, TResult>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[length];
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TState, TResult>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TState, TResult>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[length];
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    //--------------------------------------------------------------------------------
    // ToList
    //--------------------------------------------------------------------------------

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

    public static List<TResult> ToList<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(source.Length);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Length; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }

    public static List<TResult> ToList<TSource, TResult>(this TSource[] source, Func<TSource, TResult> selector) =>
        source.AsSpan().ToList(selector);

    public static List<TResult> ToList<TSource, TResult>(this TSource[] source, int start, int length, Func<TSource, TResult> selector) =>
        source.AsSpan(start, length).ToList(selector);

    public static List<TResult> ToList<TSource, TResult>(this List<TSource> source, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).ToList(selector);

    public static List<TResult> ToList<TSource, TResult>(this List<TSource> source, int start, int length, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).ToList(selector);

    public static List<TResult> ToList<TSource, TResult>(this IList<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(source.Count);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Count; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }

    public static List<TResult> ToList<TSource, TResult>(this IList<TSource> source, int start, int length, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(length);
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }

    public static List<TResult> ToList<TSource, TResult>(this IReadOnlyList<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(source.Count);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Count; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }

    public static List<TResult> ToList<TSource, TResult>(this IReadOnlyList<TSource> source, int start, int length, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(length);
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }
#pragma warning restore CA1002

    //--------------------------------------------------------------------------------
    // ToList with state
    //--------------------------------------------------------------------------------

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

    public static List<TResult> ToList<TSource, TState, TResult>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(source.Length);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Length; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }

    public static List<TResult> ToList<TSource, TState, TResult>(this TSource[] source, TState state, Func<TSource, TState, TResult> selector) =>
        source.AsSpan().ToList(state, selector);

    public static List<TResult> ToList<TSource, TState, TResult>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, TResult> selector) =>
        source.AsSpan(start, length).ToList(state, selector);

    public static List<TResult> ToList<TSource, TState, TResult>(this List<TSource> source, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).ToList(state, selector);

    public static List<TResult> ToList<TSource, TState, TResult>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).ToList(state, selector);

    public static List<TResult> ToList<TSource, TState, TResult>(this IList<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(source.Count);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Count; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }

    public static List<TResult> ToList<TSource, TState, TResult>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(length);
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }

    public static List<TResult> ToList<TSource, TState, TResult>(this IReadOnlyList<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(source.Count);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Count; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }

    public static List<TResult> ToList<TSource, TState, TResult>(this IReadOnlyList<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(length);
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }
#pragma warning restore CA1002
}
