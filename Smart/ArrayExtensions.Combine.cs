namespace Smart
{
    using System;
    using System.Linq;

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
        /// <param name="others"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static T[] Combine<T>(this T[] array, params T[][] others)
        {
            var result = new T[array.Length + others.Sum(x => x.Length)];

            Buffer.BlockCopy(array, 0, result, 0, array.Length);

            var offset = array.Length;
            foreach (var other in others)
            {
                Buffer.BlockCopy(other, 0, result, offset, other.Length);
                offset += other.Length;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static byte[] Combine(this byte[] array, params byte[][] others)
        {
            var result = new byte[array.Length + others.Sum(x => x.Length)];

            Buffer.BlockCopy(array, 0, result, 0, array.Length);

            var offset = array.Length;
            foreach (var other in others)
            {
                Buffer.BlockCopy(other, 0, result, offset, other.Length);
                offset += other.Length;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static short[] Combine(this short[] array, params short[][] others)
        {
            var result = new short[array.Length + others.Sum(x => x.Length)];

            Buffer.BlockCopy(array, 0, result, 0, array.Length);

            var offset = array.Length;
            foreach (var other in others)
            {
                Buffer.BlockCopy(other, 0, result, offset, other.Length);
                offset += other.Length;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static int[] Combine(this int[] array, params int[][] others)
        {
            var result = new int[array.Length + others.Sum(x => x.Length)];

            Buffer.BlockCopy(array, 0, result, 0, array.Length);

            var offset = array.Length;
            foreach (var other in others)
            {
                Buffer.BlockCopy(other, 0, result, offset, other.Length);
                offset += other.Length;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static long[] Combine(this long[] array, params long[][] others)
        {
            var result = new long[array.Length + others.Sum(x => x.Length)];

            Buffer.BlockCopy(array, 0, result, 0, array.Length);

            var offset = array.Length;
            foreach (var other in others)
            {
                Buffer.BlockCopy(other, 0, result, offset, other.Length);
                offset += other.Length;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static float[] Combine(this float[] array, params float[][] others)
        {
            var result = new float[array.Length + others.Sum(x => x.Length)];

            Buffer.BlockCopy(array, 0, result, 0, array.Length);

            var offset = array.Length;
            foreach (var other in others)
            {
                Buffer.BlockCopy(other, 0, result, offset, other.Length);
                offset += other.Length;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static double[] Combine(this double[] array, params double[][] others)
        {
            var result = new double[array.Length + others.Sum(x => x.Length)];

            Buffer.BlockCopy(array, 0, result, 0, array.Length);

            var offset = array.Length;
            foreach (var other in others)
            {
                Buffer.BlockCopy(other, 0, result, offset, other.Length);
                offset += other.Length;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool[] Combine(this bool[] array, params bool[][] others)
        {
            var result = new bool[array.Length + others.Sum(x => x.Length)];

            Buffer.BlockCopy(array, 0, result, 0, array.Length);

            var offset = array.Length;
            foreach (var other in others)
            {
                Buffer.BlockCopy(other, 0, result, offset, other.Length);
                offset += other.Length;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static char[] Combine(this char[] array, params char[][] others)
        {
            var result = new char[array.Length + others.Sum(x => x.Length)];

            Buffer.BlockCopy(array, 0, result, 0, array.Length);

            var offset = array.Length;
            foreach (var other in others)
            {
                Buffer.BlockCopy(other, 0, result, offset, other.Length);
                offset += other.Length;
            }

            return result;
        }
    }
}
