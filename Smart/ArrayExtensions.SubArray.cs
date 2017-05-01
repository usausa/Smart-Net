namespace Smart
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public static partial class ArrayExtensions
    {
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
            if (array == null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<T>.Array;
            }

            var fixedLength = array.Length - offset < length ? array.Length - offset : length;
            var result = new T[fixedLength];

            Array.Copy(array, offset, result, 0, fixedLength);

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
            if (array == null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<byte>.Array;
            }

            var fixedLength = array.Length - offset < length ? array.Length - offset : length;
            var result = new byte[fixedLength];

            Buffer.BlockCopy(array, offset, result, 0, fixedLength);

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
            if (array == null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<short>.Array;
            }

            var fixedLength = array.Length - offset < length ? array.Length - offset : length;
            var result = new short[fixedLength];

            Array.Copy(array, offset, result, 0, fixedLength);

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
            if (array == null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<int>.Array;
            }

            var fixedLength = array.Length - offset < length ? array.Length - offset : length;
            var result = new int[fixedLength];

            Array.Copy(array, offset, result, 0, fixedLength);

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
            if (array == null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<long>.Array;
            }

            var fixedLength = array.Length - offset < length ? array.Length - offset : length;
            var result = new long[fixedLength];

            Array.Copy(array, offset, result, 0, fixedLength);

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
            if (array == null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<float>.Array;
            }

            var fixedLength = array.Length - offset < length ? array.Length - offset : length;
            var result = new float[fixedLength];

            Array.Copy(array, offset, result, 0, fixedLength);

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
            if (array == null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<double>.Array;
            }

            var fixedLength = array.Length - offset < length ? array.Length - offset : length;
            var result = new double[fixedLength];

            Array.Copy(array, offset, result, 0, fixedLength);

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
            if (array == null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<bool>.Array;
            }

            var fixedLength = array.Length - offset < length ? array.Length - offset : length;
            var result = new bool[fixedLength];

            Array.Copy(array, offset, result, 0, fixedLength);

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
            if (array == null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Empty<char>.Array;
            }

            var fixedLength = array.Length - offset < length ? array.Length - offset : length;
            var result = new char[fixedLength];

            Array.Copy(array, offset, result, 0, fixedLength);

            return result;
        }
    }
}
