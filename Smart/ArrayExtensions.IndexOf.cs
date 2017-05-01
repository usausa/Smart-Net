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
            return IndexOf(array, 0, array?.Length ?? 0, predicate);
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

            var end = offset + length > array.Length ? array.Length : offset + length;
            for (var i = offset; i < end; i++)
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
