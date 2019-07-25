namespace Smart.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return (source is null) || (source.Count == 0);
        }

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

        public static void RemoveWhere<T>(this ICollection<T> source, Predicate<T> predicate)
        {
            var deleteItems = source.Where(x => predicate(x)).ToList();
            foreach (var item in deleteItems)
            {
                source.Remove(item);
            }
        }
    }
}
