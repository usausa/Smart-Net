namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RemoveWhere<T>(this ICollection<T> source, Func<T, bool> predicate)
        {
            var deleteItems = source.Where(predicate).ToList();
            foreach (var item in deleteItems)
            {
                source.Remove(item);
            }
        }
    }
}
