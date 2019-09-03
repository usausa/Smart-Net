namespace Smart.Collections.Generic
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class ListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T InsertAlso<T, TBase>(this IList<TBase> source, int index, T item)
            where T : TBase
        {
            source.Insert(index, item);
            return item;
        }
    }
}
