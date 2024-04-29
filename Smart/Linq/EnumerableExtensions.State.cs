namespace Smart.Linq;

using System;

public static partial class EnumerableExtensions
{
    //--------------------------------------------------------------------------------
    // Any
    //--------------------------------------------------------------------------------

    public static bool Any<TSource, TState>(this IEnumerable<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        foreach (var element in source)
        {
            if (predicate(element, state))
            {
                return true;
            }
        }

        return false;
    }

    //--------------------------------------------------------------------------------
    // All
    //--------------------------------------------------------------------------------

    public static bool All<TSource, TState>(this IEnumerable<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        foreach (var element in source)
        {
            if (!predicate(element, state))
            {
                return false;
            }
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    // Count
    //--------------------------------------------------------------------------------

    public static int Count<TSource, TState>(this IEnumerable<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        var count = 0;
        foreach (var element in source)
        {
            checked
            {
                if (predicate(element, state))
                {
                    count++;
                }
            }
        }

        return count;
    }

    //--------------------------------------------------------------------------------
    // First
    //--------------------------------------------------------------------------------

    public static TSource First<TSource, TState>(this IEnumerable<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        foreach (var element in source)
        {
            if (predicate(element, state))
            {
                return element;
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    public static TSource? FirstOrDefault<TSource, TState>(this IEnumerable<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        foreach (var element in source)
        {
            if (predicate(element, state))
            {
                return element;
            }
        }

        return default;
    }

    //--------------------------------------------------------------------------------
    // Last
    //--------------------------------------------------------------------------------

    public static TSource Last<TSource, TState>(this IEnumerable<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        if (source is IList<TSource> list)
        {
            for (var i = list.Count - 1; i >= 0; --i)
            {
                var result = list[i];
                if (predicate(result, state))
                {
                    return result;
                }
            }
        }
        else
        {
            using var e = source.GetEnumerator();
            while (e.MoveNext())
            {
                var result = e.Current;
                if (predicate(result, state))
                {
                    while (e.MoveNext())
                    {
                        var element = e.Current;
                        if (predicate(element, state))
                        {
                            result = element;
                        }
                    }

                    return result;
                }
            }
        }

        throw new InvalidOperationException("Sequence contains no matching element");
    }

    public static TSource? LastOrDefault<TSource, TState>(this IEnumerable<TSource> source, TState state, Func<TSource, TState, bool> predicate)
    {
        if (source is IList<TSource> list)
        {
            for (var i = list.Count - 1; i >= 0; --i)
            {
                var result = list[i];
                if (predicate(result, state))
                {
                    return result;
                }
            }
        }
        else
        {
            using var e = source.GetEnumerator();
            while (e.MoveNext())
            {
                var result = e.Current;
                if (predicate(result, state))
                {
                    while (e.MoveNext())
                    {
                        var element = e.Current;
                        if (predicate(element, state))
                        {
                            result = element;
                        }
                    }

                    return result;
                }
            }
        }

        return default;
    }
}
