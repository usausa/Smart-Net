namespace Smart
{
    using System;

    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // SubArray
        //--------------------------------------------------------------------------------

        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Array.Empty<T>();
            }

            FixLength(ref length, array.Length - offset);
            var result = new T[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        public static byte[] SubArray(this byte[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Array.Empty<byte>();
            }

            FixLength(ref length, array.Length - offset);
            var result = new byte[length];

            Bytes.FastCopy(array, offset, result, 0, length);

            return result;
        }

        public static short[] SubArray(this short[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Array.Empty<short>();
            }

            FixLength(ref length, array.Length - offset);
            var result = new short[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        public static int[] SubArray(this int[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Array.Empty<int>();
            }

            FixLength(ref length, array.Length - offset);
            var result = new int[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        public static long[] SubArray(this long[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Array.Empty<long>();
            }

            FixLength(ref length, array.Length - offset);
            var result = new long[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        public static float[] SubArray(this float[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Array.Empty<float>();
            }

            FixLength(ref length, array.Length - offset);
            var result = new float[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        public static double[] SubArray(this double[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Array.Empty<double>();
            }

            FixLength(ref length, array.Length - offset);
            var result = new double[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        public static bool[] SubArray(this bool[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Array.Empty<bool>();
            }

            FixLength(ref length, array.Length - offset);
            var result = new bool[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }

        public static char[] SubArray(this char[] array, int offset, int length)
        {
            if (array is null)
            {
                return null;
            }

            if (offset >= array.Length)
            {
                return Array.Empty<char>();
            }

            FixLength(ref length, array.Length - offset);
            var result = new char[length];

            Array.Copy(array, offset, result, 0, length);

            return result;
        }
    }
}
