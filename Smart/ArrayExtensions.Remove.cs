namespace Smart
{
    using System;

    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // RemoveAt
        //--------------------------------------------------------------------------------

        public static T[] RemoveAt<T>(this T[] array, int offset) => RemoveRange(array, offset, 1);

        public static T[] RemoveRange<T>(this T[] array, int start, int length)
        {
            if ((array is null) || (array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new T[start + remainLength];

            if (start > 0)
            {
                array.AsSpan(0, start).CopyTo(result);
            }

            if (remainLength > 0)
            {
                array.AsSpan(remainStart).CopyTo(result.AsSpan(start));
            }

            return result;
        }
    }
}
