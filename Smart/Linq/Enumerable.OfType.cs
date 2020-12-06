namespace Smart.Linq
{
    using System.Collections.Generic;

    public static partial class EnumerableExtensions
    {
        //--------------------------------------------------------------------------------
        // OfType
        //--------------------------------------------------------------------------------

        public static IEnumerable<TResult> OfType<TSource, TResult>(this IEnumerable<TSource> source)
            where TSource : class
            where TResult : TSource
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
