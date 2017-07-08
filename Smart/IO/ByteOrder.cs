namespace Smart.IO
{
    using System.Runtime.CompilerServices;

    /// <summary>
    ///
    /// </summary>
    public interface IByteOrder
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        void PutShort(byte[] bytes, int index, short value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        void PutInt(byte[] bytes, int index, int value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        void PutLong(byte[] bytes, int index, long value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        short GetShort(byte[] bytes, int index);

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        int GetInt(byte[] bytes, int index);

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        long GetLong(byte[] bytes, int index);
    }

    /// <summary>
    ///
    /// </summary>
    internal sealed class LittleEndian : IByteOrder
    {
        public void PutShort(byte[] bytes, int index, short value)
        {
            bytes[index] = (byte)(value & 0xff);
            bytes[index + 1] = (byte)((value >> 8) & 0xff);
        }

        public void PutInt(byte[] bytes, int index, int value)
        {
            bytes[index] = (byte)(value & 0xff);
            bytes[index + 1] = (byte)((value >> 8) & 0xff);
            bytes[index + 2] = (byte)((value >> 16) & 0xff);
            bytes[index + 3] = (byte)((value >> 24) & 0xff);
        }

        public void PutLong(byte[] bytes, int index, long value)
        {
            bytes[index] = (byte)(value & 0xff);
            bytes[index + 1] = (byte)((value >> 8) & 0xff);
            bytes[index + 2] = (byte)((value >> 16) & 0xff);
            bytes[index + 3] = (byte)((value >> 24) & 0xff);
            bytes[index + 4] = (byte)((value >> 32) & 0xff);
            bytes[index + 5] = (byte)((value >> 40) & 0xff);
            bytes[index + 6] = (byte)((value >> 48) & 0xff);
            bytes[index + 7] = (byte)((value >> 56) & 0xff);
        }

        public short GetShort(byte[] bytes, int index)
        {
            return ByteOrders.GetShortLE(bytes, index);
        }

        public int GetInt(byte[] bytes, int index)
        {
            return ByteOrders.GetIntLE(bytes, index);
        }

        public long GetLong(byte[] bytes, int index)
        {
            return ByteOrders.GetLongLE(bytes, index);
        }
    }

    internal sealed class BigEndian : IByteOrder
    {
        public void PutShort(byte[] bytes, int index, short value)
        {
            bytes[index] = (byte)((value >> 8) & 0xff);
            bytes[index + 1] = (byte)(value & 0xff);
        }

        public void PutInt(byte[] bytes, int index, int value)
        {
            bytes[index] = (byte)((value >> 24) & 0xff);
            bytes[index + 1] = (byte)((value >> 16) & 0xff);
            bytes[index + 2] = (byte)((value >> 8) & 0xff);
            bytes[index + 3] = (byte)(value & 0xff);
        }

        public void PutLong(byte[] bytes, int index, long value)
        {
            bytes[index] = (byte)((value >> 56) & 0xff);
            bytes[index + 1] = (byte)((value >> 48) & 0xff);
            bytes[index + 2] = (byte)((value >> 40) & 0xff);
            bytes[index + 3] = (byte)((value >> 32) & 0xff);
            bytes[index + 4] = (byte)((value >> 24) & 0xff);
            bytes[index + 5] = (byte)((value >> 16) & 0xff);
            bytes[index + 6] = (byte)((value >> 8) & 0xff);
            bytes[index + 7] = (byte)(value & 0xff);
        }

        public short GetShort(byte[] bytes, int index)
        {
            return ByteOrders.GetShortBE(bytes, index);
        }

        public int GetInt(byte[] bytes, int index)
        {
            return ByteOrders.GetIntBE(bytes, index);
        }

        public long GetLong(byte[] bytes, int index)
        {
            return ByteOrders.GetLongBE(bytes, index);
        }
    }

    /// <summary>
    ///
    /// </summary>
    public static class ByteOrders
    {
        /// <summary>
        ///
        /// </summary>
        public static IByteOrder LittleEndian { get; } = new LittleEndian();

        /// <summary>
        ///
        /// </summary>
        public static IByteOrder BigEndian { get; } = new BigEndian();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe short GetShortLE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                return (short)((*pbyte) | (*(pbyte + 1) << 8));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int GetIntLE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                return (*pbyte) | (*(pbyte + 1) << 8) | (*(pbyte + 2) << 16) | (*(pbyte + 3) << 24);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe long GetLongLE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                var i1 = (*pbyte) | (*(pbyte + 1) << 8) | (*(pbyte + 2) << 16) | (*(pbyte + 3) << 24);
                var i2 = (*(pbyte + 4)) | (*(pbyte + 5) << 8) | (*(pbyte + 6) << 16) | (*(pbyte + 7) << 24);
                return (uint)i1 | ((long)i2 << 32);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe short GetShortBE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                return (short)((*pbyte << 8) | (*(pbyte + 1)));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int GetIntBE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                return (*pbyte << 24) | (*(pbyte + 1) << 16) | (*(pbyte + 2) << 8) | (*(pbyte + 3));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe long GetLongBE(byte[] value, int startIndex)
        {
            fixed (byte* pbyte = &value[startIndex])
            {
                var i1 = (*pbyte << 24) | (*(pbyte + 1) << 16) | (*(pbyte + 2) << 8) | (*(pbyte + 3));
                var i2 = (*(pbyte + 4) << 24) | (*(pbyte + 5) << 16) | (*(pbyte + 6) << 8) | (*(pbyte + 7));
                return (uint)i2 | ((long)i1 << 32);
            }
        }
    }
}
