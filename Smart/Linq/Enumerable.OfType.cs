namespace Smart.Linq
{
    using System.Collections.Generic;

    public static partial class EnumerableExtensions
    {
        //--------------------------------------------------------------------------------
        // Materialize
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
