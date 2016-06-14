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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            var result = new T[Math.Min(length, array.Length - offset)];

            Buffer.BlockCopy(array, offset, result, 0, result.Length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static byte[] SubArray(this byte[] array, int offset, int length)
        {
            var result = new byte[Math.Min(length, array.Length - offset)];

            Buffer.BlockCopy(array, offset, result, 0, result.Length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static short[] SubArray(this short[] array, int offset, int length)
        {
            var result = new short[Math.Min(length, array.Length - offset)];

            Buffer.BlockCopy(array, offset, result, 0, result.Length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static int[] SubArray(this int[] array, int offset, int length)
        {
            var result = new int[Math.Min(length, array.Length - offset)];

            Buffer.BlockCopy(array, offset, result, 0, result.Length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static long[] SubArray(this long[] array, int offset, int length)
        {
            var result = new long[Math.Min(length, array.Length - offset)];

            Buffer.BlockCopy(array, offset, result, 0, result.Length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static float[] SubArray(this float[] array, int offset, int length)
        {
            var result = new float[Math.Min(length, array.Length - offset)];

            Buffer.BlockCopy(array, offset, result, 0, result.Length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static double[] SubArray(this double[] array, int offset, int length)
        {
            var result = new double[Math.Min(length, array.Length - offset)];

            Buffer.BlockCopy(array, offset, result, 0, result.Length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool[] SubArray(this bool[] array, int offset, int length)
        {
            var result = new bool[Math.Min(length, array.Length - offset)];

            Buffer.BlockCopy(array, offset, result, 0, result.Length);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static char[] SubArray(this char[] array, int offset, int length)
        {
            var result = new char[Math.Min(length, array.Length - offset)];

            Buffer.BlockCopy(array, offset, result, 0, result.Length);

            return result;
        }
    }
}
