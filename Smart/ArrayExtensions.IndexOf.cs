namespace Smart
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // IndexOf
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this T[] array, Func<T, bool> predicate)
        {
            if (array == null)
            {
                return -1;
            }

            for (var i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this T[] array, int offset, int length, Func<T, bool> predicate)
        {
            if (array == null)
            {
                return -1;
            }

            var end = offset + length;
            var limit = end > array.Length ? array.Length : end;
            for (var i = offset; i < limit; i++)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
