namespace Smart.Linq
{
    using System.Collections.Generic;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static partial class EnumerableExtensions
    {
        //--------------------------------------------------------------------------------
        // OfType
        //--------------------------------------------------------------------------------

        public static IEnumerable<TResult> OfType<TSource, TResult>(this IEnumerable<TSource> source)
        {
            foreach (var value in source)
            {
                if (value is TResult result)
                {
                    yield return result;
                }
            }
        }
    }
}
