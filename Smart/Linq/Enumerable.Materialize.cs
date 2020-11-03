namespace Smart.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        //--------------------------------------------------------------------------------
        // Materialize
        //--------------------------------------------------------------------------------

        public static IEnumerable<T> Materialize<T>(this IEnumerable<T> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if ((source is ICollection<T>) || (source is IReadOnlyCollection<T>))
            {
                return source;
            }

            return source.ToArray();
        }
    }
}
