namespace Smart
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // Fill
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T[] Fill<T>(this T[] array, T value)
        {
            return Fill(array, 0, array?.Length ?? 0, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T[] Fill<T>(this T[] array, int offset, int length, T value)
        {
            if ((length <= 0) || (array == null))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Fill(this byte[] array, byte value)
        {
            return Fill(array, 0, array?.Length ?? 0, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Fill(this byte[] array, int offset, int length, byte value)
        {
            if ((length <= 0) || (array == null))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Buffer.BlockCopy(array, offset, array, offset + copy, copy);
            }

            Buffer.BlockCopy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short[] Fill(this short[] array, short value)
        {
            return Fill(array, 0, array?.Length ?? 0, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short[] Fill(this short[] array, int offset, int length, short value)
        {
            if ((length <= 0) || (array == null))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int[] Fill(this int[] array, int value)
        {
            return Fill(array, 0, array?.Length ?? 0, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int[] Fill(this int[] array, int offset, int length, int value)
        {
            if ((length <= 0) || (array == null))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long[] Fill(this long[] array, long value)
        {
            return Fill(array, 0, array?.Length ?? 0, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long[] Fill(this long[] array, int offset, int length, long value)
        {
            if ((length <= 0) || (array == null))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float[] Fill(this float[] array, float value)
        {
            return Fill(array, 0, array?.Length ?? 0, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float[] Fill(this float[] array, int offset, int length, float value)
        {
            if ((length <= 0) || (array == null))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double[] Fill(this double[] array, double value)
        {
            return Fill(array, 0, array?.Length ?? 0, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double[] Fill(this double[] array, int offset, int length, double value)
        {
            if ((length <= 0) || (array == null))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool[] Fill(this bool[] array, bool value)
        {
            return Fill(array, 0, array?.Length ?? 0, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool[] Fill(this bool[] array, int offset, int length, bool value)
        {
            if ((length <= 0) || (array == null))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char[] Fill(this char[] array, char value)
        {
            return Fill(array, 0, array?.Length ?? 0, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char[] Fill(this char[] array, int offset, int length, char value)
        {
            if ((length <= 0) || (array == null))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }
    }
}
