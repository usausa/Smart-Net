namespace Smart
{
    using System.Collections.Generic;

    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // ArrayEquals
        //--------------------------------------------------------------------------------

        public static bool ArrayEquals<T>(this T[] array, int offset, T[] other, int otherOffset, int length)
        {
            return ArrayEquals(array, offset, other, otherOffset, length, EqualityComparer<T>.Default);
        }

        public static bool ArrayEquals<T>(this T[] array, int offset, T[] other, int otherOffset, int length, IEqualityComparer<T> comparer)
        {
            if ((array is null) && (other is null))
            {
                return true;
            }

            if ((array is null) || (other is null))
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (!comparer.Equals(array[offset + i], other[otherOffset + i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArrayEquals(this byte[] array, int offset, byte[] other, int otherOffset, int length)
        {
            if ((array is null) && (other is null))
            {
                return true;
            }

            if ((array is null) || (other is null))
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (array[offset + i] != other[otherOffset + i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArrayEquals(this short[] array, int offset, short[] other, int otherOffset, int length)
        {
            if ((array is null) && (other is null))
            {
                return true;
            }

            if ((array is null) || (other is null))
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (array[offset + i] != other[otherOffset + i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArrayEquals(this int[] array, int offset, int[] other, int otherOffset, int length)
        {
            if ((array is null) && (other is null))
            {
                return true;
            }

            if ((array is null) || (other is null))
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (array[offset + i] != other[otherOffset + i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArrayEquals(this long[] array, int offset, long[] other, int otherOffset, int length)
        {
            if ((array is null) && (other is null))
            {
                return true;
            }

            if ((array is null) || (other is null))
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (array[offset + i] != other[otherOffset + i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArrayEquals(this float[] array, int offset, float[] other, int otherOffset, int length)
        {
            if ((array is null) && (other is null))
            {
                return true;
            }

            if ((array is null) || (other is null))
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (array[offset + i].CompareTo(other[otherOffset + i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArrayEquals(this double[] array, int offset, double[] other, int otherOffset, int length)
        {
            if ((array is null) && (other is null))
            {
                return true;
            }

            if ((array is null) || (other is null))
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (array[offset + i].CompareTo(other[otherOffset + i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArrayEquals(this bool[] array, int offset, bool[] other, int otherOffset, int length)
        {
            if ((array is null) && (other is null))
            {
                return true;
            }

            if ((array is null) || (other is null))
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (array[offset + i] != other[otherOffset + i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArrayEquals(this char[] array, int offset, char[] other, int otherOffset, int length)
        {
            if ((array is null) && (other is null))
            {
                return true;
            }

            if ((array is null) || (other is null))
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (array[offset + i] != other[otherOffset + i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
