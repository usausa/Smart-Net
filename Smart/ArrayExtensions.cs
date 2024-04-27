namespace Smart;

using System.Runtime.CompilerServices;

public static class ArrayExtensions
{
    //--------------------------------------------------------------------------------
    // Combine
    //--------------------------------------------------------------------------------

    public static T[] Combine<T>(this T[] array, params T[]?[] others)
    {
        var length = array.Length;
        for (var i = 0; i < others.Length; i++)
        {
            var other = others[i];
            if (other is not null)
            {
                length += other.Length;
            }
        }

        if (length == 0)
        {
            return array;
        }

        var result = new T[length];

        array.AsSpan().CopyTo(result.AsSpan());
        var offset = array.Length;

        for (var i = 0; i < others.Length; i++)
        {
            var other = others[i];
            if (other is not null)
            {
                other.AsSpan().CopyTo(result.AsSpan(offset));
                offset += other.Length;
            }
        }

        return result;
    }

    //--------------------------------------------------------------------------------
    // RemoveAt
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] RemoveAt<T>(this T[] array, int offset) => RemoveRange(array, offset, 1);

    public static T[] RemoveRange<T>(this T[] array, int start, int length)
    {
        if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
        {
            return array;
        }

        var remainStart = start + length;
        var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
        var result = new T[start + remainLength];

        if (start > 0)
        {
            array.AsSpan(0, start).CopyTo(result);
        }

        if (remainLength > 0)
        {
            array.AsSpan(remainStart).CopyTo(result.AsSpan(start));
        }

        return result;
    }

    //--------------------------------------------------------------------------------
    // Convert
    //--------------------------------------------------------------------------------

    public static TResult[] ToArray<TSource, TResult>(this TSource[] source, Func<TSource, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i]);
        }
        return destination;
    }

    public static TResult[] ToArray<TSource, TState, TResult>(this TSource[] source, TState state, Func<TSource, TState, TResult> selector)
    {
        var destination = new TResult[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            destination[i] = selector(source[i], state);
        }
        return destination;
    }

#pragma warning disable CA1002
    public static List<TResult> ToList<TSource, TResult>(this TSource[] source, Func<TSource, TResult> selector)
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
    public static List<TResult> ToList<TSource, TState, TResult>(this TSource[] source, TState state, Func<TSource, TState, TResult> selector)
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
}
