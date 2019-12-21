namespace Smart
{
    using System;

    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // Combine
        //--------------------------------------------------------------------------------

        public static T[] Combine<T>(this T[] array, params T[][] others)
        {
            if (others is null)
            {
                return array;
            }

            var length = array?.Length ?? 0;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length += other.Length;
                }
            }

            if (length == 0)
            {
                return array;
            }

            var result = new T[length];

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

        public static byte[] Combine(this byte[] array, params byte[][] others)
        {
            if (others is null)
            {
                return array;
            }

            var length = array?.Length ?? 0;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length += other.Length;
                }
            }

            if (length == 0)
            {
                return array;
            }

            var result = new byte[length];

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

        public static short[] Combine(this short[] array, params short[][] others)
        {
            if (others is null)
            {
                return array;
            }

            var length = array?.Length ?? 0;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length += other.Length;
                }
            }

            if (length == 0)
            {
                return array;
            }

            var result = new short[length];

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

        public static int[] Combine(this int[] array, params int[][] others)
        {
            if (others is null)
            {
                return array;
            }

            var length = array?.Length ?? 0;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length += other.Length;
                }
            }

            if (length == 0)
            {
                return array;
            }

            var result = new int[length];

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

        public static long[] Combine(this long[] array, params long[][] others)
        {
            if (others is null)
            {
                return array;
            }

            var length = array?.Length ?? 0;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length += other.Length;
                }
            }

            if (length == 0)
            {
                return array;
            }

            var result = new long[length];

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

        public static float[] Combine(this float[] array, params float[][] others)
        {
            if (others is null)
            {
                return array;
            }

            var length = array?.Length ?? 0;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length += other.Length;
                }
            }

            if (length == 0)
            {
                return array;
            }

            var result = new float[length];

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

        public static double[] Combine(this double[] array, params double[][] others)
        {
            if (others is null)
            {
                return array;
            }

            var length = array?.Length ?? 0;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length += other.Length;
                }
            }

            if (length == 0)
            {
                return array;
            }

            var result = new double[length];

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

        public static bool[] Combine(this bool[] array, params bool[][] others)
        {
            if (others is null)
            {
                return array;
            }

            var length = array?.Length ?? 0;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length += other.Length;
                }
            }

            if (length == 0)
            {
                return array;
            }

            var result = new bool[length];

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

        public static char[] Combine(this char[] array, params char[][] others)
        {
            if (others is null)
            {
                return array;
            }

            var length = array?.Length ?? 0;
            for (var i = 0; i < others.Length; i++)
            {
                var other = others[i];
                if (other != null)
                {
                    length += other.Length;
                }
            }

            if (length == 0)
            {
                return array;
            }

            var result = new char[length];

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
