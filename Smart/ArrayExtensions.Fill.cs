namespace Smart
{
    using System;

    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // Fill
        //--------------------------------------------------------------------------------

        public static T[] Fill<T>(this T[] array, T value) => Fill(array, 0, array?.Length ?? 0, value);

        public static T[] Fill<T>(this T[] array, int offset, int length, T value)
        {
            if ((array.Length == 0) || (length <= 0))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length >> 1; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        public static byte[] Fill(this byte[] array, byte value) => Fill(array, 0, array?.Length ?? 0, value);

        public static byte[] Fill(this byte[] array, int offset, int length, byte value)
        {
            if ((array.Length == 0) || (length <= 0))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length >> 1; copy <<= 1)
            {
                Bytes.FastCopy(array, offset, array, offset + copy, copy);
            }

            Bytes.FastCopy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        public static short[] Fill(this short[] array, short value) => Fill(array, 0, array?.Length ?? 0, value);

        public static short[] Fill(this short[] array, int offset, int length, short value)
        {
            if ((array.Length == 0) || (length <= 0))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length >> 1; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        public static int[] Fill(this int[] array, int value) => Fill(array, 0, array?.Length ?? 0, value);

        public static int[] Fill(this int[] array, int offset, int length, int value)
        {
            if ((array.Length == 0) || (length <= 0))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length >> 1; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        public static long[] Fill(this long[] array, long value) => Fill(array, 0, array?.Length ?? 0, value);

        public static long[] Fill(this long[] array, int offset, int length, long value)
        {
            if ((array.Length == 0) || (length <= 0))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length >> 1; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        public static float[] Fill(this float[] array, float value) => Fill(array, 0, array?.Length ?? 0, value);

        public static float[] Fill(this float[] array, int offset, int length, float value)
        {
            if ((array.Length == 0) || (length <= 0))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length >> 1; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        public static double[] Fill(this double[] array, double value) => Fill(array, 0, array?.Length ?? 0, value);

        public static double[] Fill(this double[] array, int offset, int length, double value)
        {
            if ((array.Length == 0) || (length <= 0))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length >> 1; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        public static bool[] Fill(this bool[] array, bool value) => Fill(array, 0, array?.Length ?? 0, value);

        public static bool[] Fill(this bool[] array, int offset, int length, bool value)
        {
            if ((array.Length == 0) || (length <= 0))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length >> 1; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }

        public static char[] Fill(this char[] array, char value) => Fill(array, 0, array?.Length ?? 0, value);

        public static char[] Fill(this char[] array, int offset, int length, char value)
        {
            if ((array.Length == 0) || (length <= 0))
            {
                return array;
            }

            array[offset] = value;

            int copy;
            for (copy = 1; copy <= length >> 1; copy <<= 1)
            {
                Array.Copy(array, offset, array, offset + copy, copy);
            }

            Array.Copy(array, offset, array, offset + copy, length - copy);

            return array;
        }
    }
}
