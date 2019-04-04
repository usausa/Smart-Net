namespace Smart
{
    using System;

    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // IndexOf
        //--------------------------------------------------------------------------------

        public static int IndexOf<T>(this T[] array, Func<T, bool> predicate)
        {
            if (array is null)
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

        public static int IndexOf<T>(this T[] array, int offset, int length, Func<T, bool> predicate)
        {
            if (array is null)
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
