namespace Smart.Collections.Generic;

using System.Runtime.CompilerServices;

public static class DictionaryExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TValue? GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        where TKey : notnull
    {
        return dictionary.TryGetValue(key, out var value) ? value : default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TValue GetOr<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
    {
        return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TValue GetOr<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory)
    {
        return dictionary.TryGetValue(key, out var value) ? value : valueFactory();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary.TryGetValue(key, out var ret))
        {
            return ret;
        }

        ret = value;
        dictionary[key] = ret;

        return ret;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory)
    {
        if (dictionary.TryGetValue(key, out var ret))
        {
            return ret;
        }

        ret = valueFactory();
        dictionary[key] = ret;

        return ret;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CopyTo<TKey, TValue>(this IDictionary<TKey, TValue> src, IDictionary<TKey, TValue> dst)
    {
        CopyTo(src, dst, false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CopyTo<TKey, TValue>(this IDictionary<TKey, TValue> src, IDictionary<TKey, TValue> dst, bool replace)
    {
        foreach (var key in src.Keys)
        {
            if (replace || !dst.ContainsKey(key))
            {
                dst[key] = src[key];
            }
        }
    }
}
