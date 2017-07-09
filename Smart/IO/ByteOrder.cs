namespace Smart.IO
{
    using System;
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
            ByteOrder.PutShortLE(bytes, index, value);
        }

        public void PutInt(byte[] bytes, int index, int value)
        {
            ByteOrder.PutIntLE(bytes, index, value);
        }

        public void PutLong(byte[] bytes, int index, long value)
        {
            ByteOrder.PutLongLE(bytes, index, value);
        }

        public short GetShort(byte[] bytes, int index)
        {
            return ByteOrder.GetShortLE(bytes, index);
        }

        public int GetInt(byte[] bytes, int index)
        {
            return ByteOrder.GetIntLE(bytes, index);
        }

        public long GetLong(byte[] bytes, int index)
        {
            return ByteOrder.GetLongLE(bytes, index);
        }
    }

    internal sealed class BigEndian : IByteOrder
    {
        public void PutShort(byte[] bytes, int index, short value)
        {
            ByteOrder.PutShortBE(bytes, index, value);
        }

        public void PutInt(byte[] bytes, int index, int value)
        {
            ByteOrder.PutIntBE(bytes, index, value);
        }

        public void PutLong(byte[] bytes, int index, long value)
        {
            ByteOrder.PutLongBE(bytes, index, value);
        }

        public short GetShort(byte[] bytes, int index)
        {
            return ByteOrder.GetShortBE(bytes, index);
        }

        public int GetInt(byte[] bytes, int index)
        {
            return ByteOrder.GetIntBE(bytes, index);
        }

        public long GetLong(byte[] bytes, int index)
        {
            return ByteOrder.GetLongBE(bytes, index);
        }
    }

    /// <summary>
    ///
    /// </summary>
    public static class ByteOrder
    {
        private static readonly IByteOrder Little = new LittleEndian();

        private static readonly IByteOrder Big = new BigEndian();

        /// <summary>
        ///
        /// </summary>
        public static IByteOrder Default { get; } = BitConverter.IsLittleEndian ? Little : Big;

        /// <summary>
        ///
        /// </summary>
        public static IByteOrder LittleEndian { get; } = Little;

        /// <summary>
        ///
        /// </summary>
        public static IByteOrder BigEndian { get; } = Big;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void PutShortLE(byte[] bytes, int index, short value)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                *pbyte = (byte)(value & 0xff);
                *(pbyte + 1) = (byte)((value >> 8) & 0xff);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void PutIntLE(byte[] bytes, int index, int value)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                *pbyte = (byte)(value & 0xff);
                *(pbyte + 1) = (byte)((value >> 8) & 0xff);
                *(pbyte + 2) = (byte)((value >> 16) & 0xff);
                *(pbyte + 3) = (byte)((value >> 24) & 0xff);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void PutLongLE(byte[] bytes, int index, long value)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                *pbyte = (byte)(value & 0xff);
                *(pbyte + 1) = (byte)((value >> 8) & 0xff);
                *(pbyte + 2) = (byte)((value >> 16) & 0xff);
                *(pbyte + 3) = (byte)((value >> 24) & 0xff);
                *(pbyte + 4) = (byte)((value >> 32) & 0xff);
                *(pbyte + 5) = (byte)((value >> 40) & 0xff);
                *(pbyte + 6) = (byte)((value >> 48) & 0xff);
                *(pbyte + 7) = (byte)((value >> 56) & 0xff);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe short GetShortLE(byte[] bytes, int index)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                return (short)((*pbyte) | (*(pbyte + 1) << 8));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int GetIntLE(byte[] bytes, int index)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                return (*pbyte) | (*(pbyte + 1) << 8) | (*(pbyte + 2) << 16) | (*(pbyte + 3) << 24);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe long GetLongLE(byte[] bytes, int index)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                var i1 = (*pbyte) | (*(pbyte + 1) << 8) | (*(pbyte + 2) << 16) | (*(pbyte + 3) << 24);
                var i2 = (*(pbyte + 4)) | (*(pbyte + 5) << 8) | (*(pbyte + 6) << 16) | (*(pbyte + 7) << 24);
                return (uint)i1 | ((long)i2 << 32);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void PutShortBE(byte[] bytes, int index, short value)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                *pbyte = (byte)((value >> 8) & 0xff);
                *(pbyte + 1) = (byte)(value & 0xff);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void PutIntBE(byte[] bytes, int index, int value)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                *pbyte = (byte)((value >> 24) & 0xff);
                *(pbyte + 1) = (byte)((value >> 16) & 0xff);
                *(pbyte + 2) = (byte)((value >> 8) & 0xff);
                *(pbyte + 3) = (byte)(value & 0xff);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void PutLongBE(byte[] bytes, int index, long value)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                *pbyte = (byte)((value >> 56) & 0xff);
                *(pbyte + 1) = (byte)((value >> 48) & 0xff);
                *(pbyte + 2) = (byte)((value >> 40) & 0xff);
                *(pbyte + 3) = (byte)((value >> 32) & 0xff);
                *(pbyte + 4) = (byte)((value >> 24) & 0xff);
                *(pbyte + 5) = (byte)((value >> 16) & 0xff);
                *(pbyte + 6) = (byte)((value >> 8) & 0xff);
                *(pbyte + 7) = (byte)(value & 0xff);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe short GetShortBE(byte[] bytes, int index)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                return (short)((*pbyte << 8) | (*(pbyte + 1)));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int GetIntBE(byte[] bytes, int index)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                return (*pbyte << 24) | (*(pbyte + 1) << 16) | (*(pbyte + 2) << 8) | (*(pbyte + 3));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe long GetLongBE(byte[] bytes, int index)
        {
            fixed (byte* pbyte = &bytes[index])
            {
                var i1 = (*pbyte << 24) | (*(pbyte + 1) << 16) | (*(pbyte + 2) << 8) | (*(pbyte + 3));
                var i2 = (*(pbyte + 4) << 24) | (*(pbyte + 5) << 16) | (*(pbyte + 6) << 8) | (*(pbyte + 7));
                return (uint)i2 | ((long)i1 << 32);
            }
        }
    }
}
