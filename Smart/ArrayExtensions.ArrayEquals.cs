namespace Smart
{
    using System.Collections.Generic;

    /// <summary>
    ///
    /// </summary>
    public static partial class ArrayExtensions
    {
        //--------------------------------------------------------------------------------
        // ArrayEquals
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ArrayEquals<T>(this T[] array, int offset, T[] other, int otherOffset, int length)
        {
            return ArrayEquals(array, offset, other, otherOffset, length, EqualityComparer<T>.Default);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool ArrayEquals<T>(this T[] array, int offset, T[] other, int otherOffset, int length, IEqualityComparer<T> comparer)
        {
            if ((array == null) && (other == null))
            {
                return true;
            }

            if ((array == null) || (other == null))
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ArrayEquals(this byte[] array, int offset, byte[] other, int otherOffset, int length)
        {
            if ((array == null) && (other == null))
            {
                return true;
            }

            if ((array == null) || (other == null))
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ArrayEquals(this short[] array, int offset, short[] other, int otherOffset, int length)
        {
            if ((array == null) && (other == null))
            {
                return true;
            }

            if ((array == null) || (other == null))
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ArrayEquals(this int[] array, int offset, int[] other, int otherOffset, int length)
        {
            if ((array == null) && (other == null))
            {
                return true;
            }

            if ((array == null) || (other == null))
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ArrayEquals(this long[] array, int offset, long[] other, int otherOffset, int length)
        {
            if ((array == null) && (other == null))
            {
                return true;
            }

            if ((array == null) || (other == null))
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ArrayEquals(this float[] array, int offset, float[] other, int otherOffset, int length)
        {
            if ((array == null) && (other == null))
            {
                return true;
            }

            if ((array == null) || (other == null))
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ArrayEquals(this double[] array, int offset, double[] other, int otherOffset, int length)
        {
            if ((array == null) && (other == null))
            {
                return true;
            }

            if ((array == null) || (other == null))
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ArrayEquals(this bool[] array, int offset, bool[] other, int otherOffset, int length)
        {
            if ((array == null) && (other == null))
            {
                return true;
            }

            if ((array == null) || (other == null))
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ArrayEquals(this char[] array, int offset, char[] other, int otherOffset, int length)
        {
            if ((array == null) && (other == null))
            {
                return true;
            }

            if ((array == null) || (other == null))
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
