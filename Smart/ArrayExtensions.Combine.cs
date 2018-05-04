namespace Smart
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // Combine
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static T[] Combine<T>(this T[] array, params T[][] others)
        {
            var length = array?.Length;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length = (length ?? 0) + other.Length;
                }
            }

            if (!length.HasValue)
            {
                return null;
            }

            var result = new T[length.Value];

            int offset;
            if (array != null)
            {
                Array.Copy(array, 0, result, 0, array.Length);
                offset = array.Length;
            }
            else
            {
                offset = 0;
            }

            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    Array.Copy(other, 0, result, offset, other.Length);
                    offset += other.Length;
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static byte[] Combine(this byte[] array, params byte[][] others)
        {
            var length = array?.Length;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length = (length ?? 0) + other.Length;
                }
            }

            if (!length.HasValue)
            {
                return null;
            }

            if (length.Value == 0)
            {
                return Bytes.Empty;
            }

            var result = new byte[length.Value];

            int offset;
            if (array != null)
            {
                Bytes.FastCopy(array, 0, result, 0, array.Length);
                offset = array.Length;
            }
            else
            {
                offset = 0;
            }

            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    Bytes.FastCopy(other, 0, result, offset, other.Length);
                    offset += other.Length;
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static short[] Combine(this short[] array, params short[][] others)
        {
            var length = array?.Length;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length = (length ?? 0) + other.Length;
                }
            }

            if (!length.HasValue)
            {
                return null;
            }

            var result = new short[length.Value];

            int offset;
            if (array != null)
            {
                Array.Copy(array, 0, result, 0, array.Length);
                offset = array.Length;
            }
            else
            {
                offset = 0;
            }

            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    Array.Copy(other, 0, result, offset, other.Length);
                    offset += other.Length;
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static int[] Combine(this int[] array, params int[][] others)
        {
            var length = array?.Length;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length = (length ?? 0) + other.Length;
                }
            }

            if (!length.HasValue)
            {
                return null;
            }

            var result = new int[length.Value];

            int offset;
            if (array != null)
            {
                Array.Copy(array, 0, result, 0, array.Length);
                offset = array.Length;
            }
            else
            {
                offset = 0;
            }

            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    Array.Copy(other, 0, result, offset, other.Length);
                    offset += other.Length;
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static long[] Combine(this long[] array, params long[][] others)
        {
            var length = array?.Length;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length = (length ?? 0) + other.Length;
                }
            }

            if (!length.HasValue)
            {
                return null;
            }

            var result = new long[length.Value];

            int offset;
            if (array != null)
            {
                Array.Copy(array, 0, result, 0, array.Length);
                offset = array.Length;
            }
            else
            {
                offset = 0;
            }

            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    Array.Copy(other, 0, result, offset, other.Length);
                    offset += other.Length;
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static float[] Combine(this float[] array, params float[][] others)
        {
            var length = array?.Length;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length = (length ?? 0) + other.Length;
                }
            }

            if (!length.HasValue)
            {
                return null;
            }

            var result = new float[length.Value];

            int offset;
            if (array != null)
            {
                Array.Copy(array, 0, result, 0, array.Length);
                offset = array.Length;
            }
            else
            {
                offset = 0;
            }

            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    Array.Copy(other, 0, result, offset, other.Length);
                    offset += other.Length;
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static double[] Combine(this double[] array, params double[][] others)
        {
            var length = array?.Length;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length = (length ?? 0) + other.Length;
                }
            }

            if (!length.HasValue)
            {
                return null;
            }

            var result = new double[length.Value];

            int offset;
            if (array != null)
            {
                Array.Copy(array, 0, result, 0, array.Length);
                offset = array.Length;
            }
            else
            {
                offset = 0;
            }

            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    Array.Copy(other, 0, result, offset, other.Length);
                    offset += other.Length;
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static bool[] Combine(this bool[] array, params bool[][] others)
        {
            var length = array?.Length;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length = (length ?? 0) + other.Length;
                }
            }

            if (!length.HasValue)
            {
                return null;
            }

            var result = new bool[length.Value];

            int offset;
            if (array != null)
            {
                Array.Copy(array, 0, result, 0, array.Length);
                offset = array.Length;
            }
            else
            {
                offset = 0;
            }

            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    Array.Copy(other, 0, result, offset, other.Length);
                    offset += other.Length;
                }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static char[] Combine(this char[] array, params char[][] others)
        {
            var length = array?.Length;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length = (length ?? 0) + other.Length;
                }
            }

            if (!length.HasValue)
            {
                return null;
            }

            var result = new char[length.Value];

            int offset;
            if (array != null)
            {
                Array.Copy(array, 0, result, 0, array.Length);
                offset = array.Length;
            }
            else
            {
                offset = 0;
            }

            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    Array.Copy(other, 0, result, offset, other.Length);
                    offset += other.Length;
                }
            }

            return result;
        }
    }
}
