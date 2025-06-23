namespace Smart.Linq;

using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

public static partial class EnumerableExtensions
{
    //--------------------------------------------------------------------------------
    // MapToArray
    //--------------------------------------------------------------------------------

    public static TResult[] MapToArray<TSource, TResult>(this Span<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TResult>(this TSource[] source, Func<TSource, TResult> selector) =>
        source.AsSpan().MapToArray(selector);

    public static TResult[] MapToArray<TSource, TResult>(this TSource[] source, int start, int length, Func<TSource, TResult> selector) =>
        source.AsSpan(start, length).MapToArray(selector);

    public static TResult[] MapToArray<TSource, TResult>(this List<TSource> source, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).MapToArray(selector);

    public static TResult[] MapToArray<TSource, TResult>(this List<TSource> source, int start, int length, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).MapToArray(selector);

    public static TResult[] MapToArray<TSource, TResult>(this ObservableCollection<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new TResult[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TResult>(this ObservableCollection<TSource> source, int start, int length, Func<TSource, TResult> selector)
    {
        var destination = new TResult[length];
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TResult>(this IList<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new TResult[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TResult>(this IList<TSource> source, int start, int length, Func<TSource, TResult> selector)
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
    // MapToArray with state
    //--------------------------------------------------------------------------------

    public static TResult[] MapToArray<TSource, TState, TResult>(this Span<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TState, TResult>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TState, TResult>(this TSource[] source, TState state, Func<TSource, TState, TResult> selector) =>
        source.AsSpan().MapToArray(state, selector);

    public static TResult[] MapToArray<TSource, TState, TResult>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, TResult> selector) =>
        source.AsSpan(start, length).MapToArray(state, selector);

    public static TResult[] MapToArray<TSource, TState, TResult>(this List<TSource> source, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).MapToArray(state, selector);

    public static TResult[] MapToArray<TSource, TState, TResult>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).MapToArray(state, selector);

    public static TResult[] MapToArray<TSource, TState, TResult>(this ObservableCollection<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TState, TResult>(this ObservableCollection<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[length];
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TState, TResult>(this IList<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

    public static TResult[] MapToArray<TSource, TState, TResult>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector)
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
    // MapToList
    //--------------------------------------------------------------------------------

#pragma warning disable CA1002
    public static List<TResult> MapToList<TSource, TResult>(this Span<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(source.Length);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Length; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(source.Length);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Length; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TResult>(this TSource[] source, Func<TSource, TResult> selector) =>
        source.AsSpan().MapToList(selector);

    public static List<TResult> MapToList<TSource, TResult>(this TSource[] source, int start, int length, Func<TSource, TResult> selector) =>
        source.AsSpan(start, length).MapToList(selector);

    public static List<TResult> MapToList<TSource, TResult>(this List<TSource> source, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).MapToList(selector);

    public static List<TResult> MapToList<TSource, TResult>(this List<TSource> source, int start, int length, Func<TSource, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).MapToList(selector);

    public static List<TResult> MapToList<TSource, TResult>(this ObservableCollection<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(source.Count);
        for (var i = 0; i < source.Count; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TResult>(this ObservableCollection<TSource> source, int start, int length, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(length);
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TResult>(this IList<TSource> source, Func<TSource, TResult> selector)
    {
        var destination = new List<TResult>(source.Count);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Count; i++)
        {
            destination.Add(selector(source[i]));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TResult>(this IList<TSource> source, int start, int length, Func<TSource, TResult> selector)
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
    // MapToList with state
    //--------------------------------------------------------------------------------

#pragma warning disable CA1002
    public static List<TResult> MapToList<TSource, TState, TResult>(this Span<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(source.Length);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Length; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TState, TResult>(this ReadOnlySpan<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(source.Length);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Length; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TState, TResult>(this TSource[] source, TState state, Func<TSource, TState, TResult> selector) =>
        source.AsSpan().MapToList(state, selector);

    public static List<TResult> MapToList<TSource, TState, TResult>(this TSource[] source, int start, int length, TState state, Func<TSource, TState, TResult> selector) =>
        source.AsSpan(start, length).MapToList(state, selector);

    public static List<TResult> MapToList<TSource, TState, TResult>(this List<TSource> source, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).MapToList(state, selector);

    public static List<TResult> MapToList<TSource, TState, TResult>(this List<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector) =>
        CollectionsMarshal.AsSpan(source).Slice(start, length).MapToList(state, selector);

    public static List<TResult> MapToList<TSource, TState, TResult>(this ObservableCollection<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(source.Count);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Count; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TState, TResult>(this ObservableCollection<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(length);
        var last = start + length;
        for (var i = start; i < last; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TState, TResult>(this IList<TSource> source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new List<TResult>(source.Count);
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < source.Count; i++)
        {
            destination.Add(selector(source[i], state));
        }
        return destination;
    }

    public static List<TResult> MapToList<TSource, TState, TResult>(this IList<TSource> source, int start, int length, TState state, Func<TSource, TState, TResult> selector)
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
