namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class DictionaryExtensions
    {
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGetValue(key, out var value) ? value : default;
        }

        public static TValue GetOr<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }

        public static TValue GetOr<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory)
        {
            if (valueFactory is null)
            {
                throw new ArgumentNullException(nameof(valueFactory));
            }

            return dictionary.TryGetValue(key, out var value) ? value : valueFactory();
        }

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

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory)
        {
            if (valueFactory is null)
            {
                throw new ArgumentNullException(nameof(valueFactory));
            }

            if (dictionary.TryGetValue(key, out var ret))
            {
                return ret;
            }

            ret = valueFactory();
            dictionary[key] = ret;

            return ret;
        }

        public static void CopyTo<TKey, TValue>(this IDictionary<TKey, TValue> src, IDictionary<TKey, TValue> dst)
        {
            CopyTo(src, dst, false);
        }

        public static void CopyTo<TKey, TValue>(this IDictionary<TKey, TValue> src, IDictionary<TKey, TValue> dst, bool replace)
        {
            if (dst is null)
            {
                throw new ArgumentNullException(nameof(dst));
            }

            foreach (var key in src.Keys)
            {
                if (replace || !dst.ContainsKey(key))
                {
                    dst[key] = src[key];
                }
            }
        }
    }
}
