namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class CollectionExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return (source is null) || (source.Count == 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> collection)
        {
            if (collection is null)
            {
                return;
            }

            foreach (var item in collection)
            {
                source.Add(item);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RemoveWhere<T>(this ICollection<T> source, Predicate<T> predicate)
        {
            var deleteItems = source.Where(x => predicate(x)).ToList();
            foreach (var item in deleteItems)
            {
                source.Remove(item);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AddAlso<T>(this ICollection<T> source, T item)
        {
            source.Add(item);
            return item;
        }
    }
}
