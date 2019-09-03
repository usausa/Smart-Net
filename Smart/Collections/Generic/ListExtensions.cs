namespace Smart.Collections.Generic
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class ListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T InsertAlso<T>(this IList<T> source, int index, T item)
        {
            source.Insert(index, item);
            return item;
        }
    }
}
