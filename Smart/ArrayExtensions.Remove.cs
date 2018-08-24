namespace Smart
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // RemoveAt
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static T[] RemoveAt<T>(this T[] array, int offset)
        {
            return RemoveRange(array, offset, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] RemoveRange<T>(this T[] array, int start, int length)
        {
            if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new T[start + remainLength];

            if (start > 0)
            {
                Array.Copy(array, 0, result, 0, start);
            }

            if (remainLength > 0)
            {
                Array.Copy(array, remainStart, result, start, remainLength);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static byte[] RemoveAt(this byte[] array, int offset)
        {
            return RemoveRange(array, offset, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] RemoveRange(this byte[] array, int start, int length)
        {
            if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new byte[start + remainLength];

            if (start > 0)
            {
                Bytes.FastCopy(array, 0, result, 0, start);
            }

            if (remainLength > 0)
            {
                Bytes.FastCopy(array, remainStart, result, start, remainLength);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static short[] RemoveAt(this short[] array, int offset)
        {
            return RemoveRange(array, offset, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static short[] RemoveRange(this short[] array, int start, int length)
        {
            if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new short[start + remainLength];

            if (start > 0)
            {
                Array.Copy(array, 0, result, 0, start);
            }

            if (remainLength > 0)
            {
                Array.Copy(array, remainStart, result, start, remainLength);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int[] RemoveAt(this int[] array, int offset)
        {
            return RemoveRange(array, offset, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int[] RemoveRange(this int[] array, int start, int length)
        {
            if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new int[start + remainLength];

            if (start > 0)
            {
                Array.Copy(array, 0, result, 0, start);
            }

            if (remainLength > 0)
            {
                Array.Copy(array, remainStart, result, start, remainLength);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static long[] RemoveAt(this long[] array, int offset)
        {
            return RemoveRange(array, offset, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static long[] RemoveRange(this long[] array, int start, int length)
        {
            if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new long[start + remainLength];

            if (start > 0)
            {
                Array.Copy(array, 0, result, 0, start);
            }

            if (remainLength > 0)
            {
                Array.Copy(array, remainStart, result, start, remainLength);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float[] RemoveAt(this float[] array, int offset)
        {
            return RemoveRange(array, offset, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static float[] RemoveRange(this float[] array, int start, int length)
        {
            if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new float[start + remainLength];

            if (start > 0)
            {
                Array.Copy(array, 0, result, 0, start);
            }

            if (remainLength > 0)
            {
                Array.Copy(array, remainStart, result, start, remainLength);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static double[] RemoveAt(this double[] array, int offset)
        {
            return RemoveRange(array, offset, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static double[] RemoveRange(this double[] array, int start, int length)
        {
            if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new double[start + remainLength];

            if (start > 0)
            {
                Array.Copy(array, 0, result, 0, start);
            }

            if (remainLength > 0)
            {
                Array.Copy(array, remainStart, result, start, remainLength);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static bool[] RemoveAt(this bool[] array, int offset)
        {
            return RemoveRange(array, offset, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool[] RemoveRange(this bool[] array, int start, int length)
        {
            if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new bool[start + remainLength];

            if (start > 0)
            {
                Array.Copy(array, 0, result, 0, start);
            }

            if (remainLength > 0)
            {
                Array.Copy(array, remainStart, result, start, remainLength);
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static char[] RemoveAt(this char[] array, int offset)
        {
            return RemoveRange(array, offset, 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static char[] RemoveRange(this char[] array, int start, int length)
        {
            if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
            {
                return array;
            }

            var remainStart = start + length;
            var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
            var result = new char[start + remainLength];

            if (start > 0)
            {
                Array.Copy(array, 0, result, 0, start);
            }

            if (remainLength > 0)
            {
                Array.Copy(array, remainStart, result, start, remainLength);
            }

            return result;
        }
    }
}
