namespace Smart.IO
{
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
        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void PutShort(byte[] bytes, int index, short value)
        {
            bytes[index] = (byte)(value & 0xff);
            bytes[index + 1] = (byte)((value >> 8) & 0xff);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void PutInt(byte[] bytes, int index, int value)
        {
            bytes[index] = (byte)(value & 0xff);
            bytes[index + 1] = (byte)((value >> 8) & 0xff);
            bytes[index + 2] = (byte)((value >> 16) & 0xff);
            bytes[index + 3] = (byte)((value >> 24) & 0xff);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public short GetShort(byte[] bytes, int index)
        {
            return (short)(bytes[index] | (bytes[index + 1] << 8));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetInt(byte[] bytes, int index)
        {
            return bytes[index] | (bytes[index + 1] << 8) | (bytes[index + 2] << 16) | (bytes[index + 3] << 24);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public long GetLong(byte[] bytes, int index)
        {
            return bytes[index] | (bytes[index + 1] << 8) | (bytes[index + 2] << 16) | (bytes[index + 3] << 24) |
                   (bytes[index + 4] << 32) | (bytes[index + 5] << 40) | (bytes[index + 6] << 48) | (bytes[index + 7] << 56);
        }
    }

    /// <summary>
    ///
    /// </summary>
    internal sealed class BigEndian : IByteOrder
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void PutShort(byte[] bytes, int index, short value)
        {
            bytes[index] = (byte)((value >> 8) & 0xff);
            bytes[index + 1] = (byte)(value & 0xff);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void PutInt(byte[] bytes, int index, int value)
        {
            bytes[index] = (byte)((value >> 24) & 0xff);
            bytes[index + 1] = (byte)((value >> 16) & 0xff);
            bytes[index + 2] = (byte)((value >> 8) & 0xff);
            bytes[index + 3] = (byte)(value & 0xff);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public short GetShort(byte[] bytes, int index)
        {
            return (short)((bytes[index] << 8) | bytes[index + 1]);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetInt(byte[] bytes, int index)
        {
            return (bytes[index] << 24) | (bytes[index + 1] << 16) | (bytes[index + 2] << 8) | bytes[index + 3];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public long GetLong(byte[] bytes, int index)
        {
            return (bytes[index] << 56) | (bytes[index + 1] << 48) | (bytes[index + 2] << 40) | (bytes[index + 3] << 32) |
                   (bytes[index + 4] << 24) | (bytes[index + 5] << 16) | (bytes[index + 6] << 8) | bytes[index + 7];
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
    }
}
