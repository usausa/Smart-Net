namespace Smart.Collections.Generic;

using System.Runtime.CompilerServices;

public static class CollectionExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty<T>(this ICollection<T>? source)
    {
        return (source is null) || (source.Count == 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddRange<T, TBase>(this ICollection<TBase> source, IEnumerable<T> collection)
        where T : TBase
    {
        foreach (var item in collection)
        {
            source.Add(item);
        }
    }

    public static void RemoveWhere<T>(this ICollection<T> source, Func<T, bool> predicate)
    {
        switch (source)
        {
            case List<T> list:
                list.RemoveAll(predicate.Invoke);
                break;
            case HashSet<T> set:
                set.RemoveWhere(predicate.Invoke);
                break;
            case IList<T> list:
                for (var i = list.Count - 1; i >= 0; i--)
                {
                    if (predicate(list[i]))
                    {
                        list.RemoveAt(i);
                    }
                }
                break;
            default:
                foreach (var item in source.Where(predicate).ToList())
                {
                    source.Remove(item);
                }
                break;
        }
    }
}
