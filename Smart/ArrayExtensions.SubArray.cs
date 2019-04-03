namespace Smart
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // SubArray
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<T>.Array;
            }

            FixLength(ref length, array.Length - offset);
            var result = new T[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] SubArray(this byte[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<byte>.Array;
            }

            FixLength(ref length, array.Length - offset);
            var result = new byte[length];

            Bytes.FastCopy(array, offset, result, 0, length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static short[] SubArray(this short[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<short>.Array;
            }

            FixLength(ref length, array.Length - offset);
            var result = new short[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int[] SubArray(this int[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<int>.Array;
            }

            FixLength(ref length, array.Length - offset);
            var result = new int[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static long[] SubArray(this long[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<long>.Array;
            }

            FixLength(ref length, array.Length - offset);
            var result = new long[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static float[] SubArray(this float[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<float>.Array;
            }

            FixLength(ref length, array.Length - offset);
            var result = new float[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static double[] SubArray(this double[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<double>.Array;
            }

            FixLength(ref length, array.Length - offset);
            var result = new double[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool[] SubArray(this bool[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<bool>.Array;
            }

            FixLength(ref length, array.Length - offset);
            var result = new bool[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static char[] SubArray(this char[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<char>.Array;
            }

            FixLength(ref length, array.Length - offset);
            var result = new char[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }
    }
}
