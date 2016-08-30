﻿namespace Smart
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static T[] Fill<T>(this T[] array, T value)
        {
            return Fill(array, 0, array.Length, value);
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static T[] Fill<T>(this T[] array, int offset, int length, T value)
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static byte[] Fill(this byte[] array, byte value)
        {
            return Fill(array, 0, array.Length, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static byte[] Fill(this byte[] array, int offset, int length, byte value)
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static short[] Fill(this short[] array, short value)
        {
            return Fill(array, 0, array.Length, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static short[] Fill(this short[] array, int offset, int length, short value)
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static int[] Fill(this int[] array, int value)
        {
            return Fill(array, 0, array.Length, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static int[] Fill(this int[] array, int offset, int length, int value)
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static long[] Fill(this long[] array, long value)
        {
            return Fill(array, 0, array.Length, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static long[] Fill(this long[] array, int offset, int length, long value)
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static float[] Fill(this float[] array, float value)
        {
            return Fill(array, 0, array.Length, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static float[] Fill(this float[] array, int offset, int length, float value)
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static double[] Fill(this double[] array, double value)
        {
            return Fill(array, 0, array.Length, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static double[] Fill(this double[] array, int offset, int length, double value)
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool[] Fill(this bool[] array, bool value)
        {
            return Fill(array, 0, array.Length, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool[] Fill(this bool[] array, int offset, int length, bool value)
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static char[] Fill(this char[] array, char value)
        {
            return Fill(array, 0, array.Length, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static char[] Fill(this char[] array, int offset, int length, char value)
        {
            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length / 2; copy <<= 1)
            {
                Buffer.BlockCopy(array, offset, array, offset + copy, copy);
            }

            Buffer.BlockCopy(array, offset, array, offset + copy, length - copy);

            return array;
        }
    }
}