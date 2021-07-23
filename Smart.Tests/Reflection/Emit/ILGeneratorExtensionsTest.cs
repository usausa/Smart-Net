namespace Smart.Reflection.Emit
{
    using System;
    using System.Reflection.Emit;

    using Xunit;

    public class ILGeneratorExtensionsTest
    {
        //--------------------------------------------------------------------------------
        // ByteTo
        //--------------------------------------------------------------------------------

        // Nop byte

        [Fact]
        public void ByteToSByte()
        {
            var converter = ConverterFactory.Create<byte, sbyte>();

            Assert.Equal(ManualConverter.ByteToSByte(0), converter(0));
            Assert.Equal(ManualConverter.ByteToSByte(1), converter(1));
            Assert.Equal(ManualConverter.ByteToSByte(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToSByte(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToChar()
        {
            var converter = ConverterFactory.Create<byte, char>();

            Assert.Equal(ManualConverter.ByteToChar(0), converter(0));
            Assert.Equal(ManualConverter.ByteToChar(1), converter(1));
            Assert.Equal(ManualConverter.ByteToChar(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToChar(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToInt16()
        {
            var converter = ConverterFactory.Create<byte, short>();

            Assert.Equal(ManualConverter.ByteToInt16(0), converter(0));
            Assert.Equal(ManualConverter.ByteToInt16(1), converter(1));
            Assert.Equal(ManualConverter.ByteToInt16(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToInt16(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToUInt16()
        {
            var converter = ConverterFactory.Create<byte, ushort>();

            Assert.Equal(ManualConverter.ByteToUInt16(0), converter(0));
            Assert.Equal(ManualConverter.ByteToUInt16(1), converter(1));
            Assert.Equal(ManualConverter.ByteToUInt16(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToUInt16(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToInt32()
        {
            var converter = ConverterFactory.Create<byte, int>();

            Assert.Equal(ManualConverter.ByteToInt32(0), converter(0));
            Assert.Equal(ManualConverter.ByteToInt32(1), converter(1));
            Assert.Equal(ManualConverter.ByteToInt32(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToInt32(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToUInt32()
        {
            var converter = ConverterFactory.Create<byte, uint>();

            Assert.Equal(ManualConverter.ByteToUInt32(0), converter(0));
            Assert.Equal(ManualConverter.ByteToUInt32(1), converter(1));
            Assert.Equal(ManualConverter.ByteToUInt32(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToUInt32(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToInt64()
        {
            var converter = ConverterFactory.Create<byte, long>();

            Assert.Equal(ManualConverter.ByteToInt64(0), converter(0));
            Assert.Equal(ManualConverter.ByteToInt64(1), converter(1));
            Assert.Equal(ManualConverter.ByteToInt64(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToInt64(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToUInt64()
        {
            var converter = ConverterFactory.Create<byte, ulong>();

            Assert.Equal(ManualConverter.ByteToUInt64(0), converter(0));
            Assert.Equal(ManualConverter.ByteToUInt64(1), converter(1));
            Assert.Equal(ManualConverter.ByteToUInt64(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToUInt64(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToSingle()
        {
            var converter = ConverterFactory.Create<byte, float>();

            Assert.Equal(ManualConverter.ByteToSingle(0), converter(0));
            Assert.Equal(ManualConverter.ByteToSingle(1), converter(1));
            Assert.Equal(ManualConverter.ByteToSingle(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToSingle(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToDouble()
        {
            var converter = ConverterFactory.Create<byte, double>();

            Assert.Equal(ManualConverter.ByteToDouble(0), converter(0));
            Assert.Equal(ManualConverter.ByteToDouble(1), converter(1));
            Assert.Equal(ManualConverter.ByteToDouble(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToDouble(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToDecimal()
        {
            var converter = ConverterFactory.Create<byte, decimal>();

            Assert.Equal(ManualConverter.ByteToDecimal(0), converter(0));
            Assert.Equal(ManualConverter.ByteToDecimal(1), converter(1));
            Assert.Equal(ManualConverter.ByteToDecimal(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToDecimal(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToIntPtr()
        {
            var converter = ConverterFactory.Create<byte, IntPtr>();

            Assert.Equal(ManualConverter.ByteToIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.ByteToIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.ByteToIntPtr(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToIntPtr(Byte.MaxValue), converter(Byte.MaxValue));
        }

        [Fact]
        public void ByteToUIntPtr()
        {
            var converter = ConverterFactory.Create<byte, UIntPtr>();

            Assert.Equal(ManualConverter.ByteToUIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.ByteToUIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.ByteToUIntPtr(Byte.MinValue), converter(Byte.MinValue));
            Assert.Equal(ManualConverter.ByteToUIntPtr(Byte.MaxValue), converter(Byte.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // SByteTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void SByteToByte()
        {
            var converter = ConverterFactory.Create<sbyte, byte>();

            Assert.Equal(ManualConverter.SByteToByte(0), converter(0));
            Assert.Equal(ManualConverter.SByteToByte(1), converter(1));
            Assert.Equal(ManualConverter.SByteToByte(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToByte(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToByte(SByte.MaxValue), converter(SByte.MaxValue));
        }

        // Nop sbyte

        [Fact]
        public void SByteToChar()
        {
            var converter = ConverterFactory.Create<sbyte, char>();

            Assert.Equal(ManualConverter.SByteToChar(0), converter(0));
            Assert.Equal(ManualConverter.SByteToChar(1), converter(1));
            Assert.Equal(ManualConverter.SByteToChar(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToChar(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToChar(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToInt16()
        {
            var converter = ConverterFactory.Create<sbyte, short>();

            Assert.Equal(ManualConverter.SByteToInt16(0), converter(0));
            Assert.Equal(ManualConverter.SByteToInt16(1), converter(1));
            Assert.Equal(ManualConverter.SByteToInt16(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToInt16(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToInt16(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToUInt16()
        {
            var converter = ConverterFactory.Create<sbyte, ushort>();

            Assert.Equal(ManualConverter.SByteToUInt16(0), converter(0));
            Assert.Equal(ManualConverter.SByteToUInt16(1), converter(1));
            Assert.Equal(ManualConverter.SByteToUInt16(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToUInt16(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToUInt16(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToInt32()
        {
            var converter = ConverterFactory.Create<sbyte, int>();

            Assert.Equal(ManualConverter.SByteToInt32(0), converter(0));
            Assert.Equal(ManualConverter.SByteToInt32(1), converter(1));
            Assert.Equal(ManualConverter.SByteToInt32(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToInt32(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToInt32(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToUInt32()
        {
            var converter = ConverterFactory.Create<sbyte, uint>();

            Assert.Equal(ManualConverter.SByteToUInt32(0), converter(0));
            Assert.Equal(ManualConverter.SByteToUInt32(1), converter(1));
            Assert.Equal(ManualConverter.SByteToUInt32(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToUInt32(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToUInt32(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToInt64()
        {
            var converter = ConverterFactory.Create<sbyte, long>();

            Assert.Equal(ManualConverter.SByteToInt64(0), converter(0));
            Assert.Equal(ManualConverter.SByteToInt64(1), converter(1));
            Assert.Equal(ManualConverter.SByteToInt64(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToInt64(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToInt64(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToUInt64()
        {
            var converter = ConverterFactory.Create<sbyte, ulong>();

            Assert.Equal(ManualConverter.SByteToUInt64(0), converter(0));
            Assert.Equal(ManualConverter.SByteToUInt64(1), converter(1));
            Assert.Equal(ManualConverter.SByteToUInt64(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToUInt64(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToUInt64(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToSingle()
        {
            var converter = ConverterFactory.Create<sbyte, float>();

            Assert.Equal(ManualConverter.SByteToSingle(0), converter(0));
            Assert.Equal(ManualConverter.SByteToSingle(1), converter(1));
            Assert.Equal(ManualConverter.SByteToSingle(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToSingle(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToSingle(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToDouble()
        {
            var converter = ConverterFactory.Create<sbyte, double>();

            Assert.Equal(ManualConverter.SByteToDouble(0), converter(0));
            Assert.Equal(ManualConverter.SByteToDouble(1), converter(1));
            Assert.Equal(ManualConverter.SByteToDouble(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToDouble(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToDouble(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToDecimal()
        {
            var converter = ConverterFactory.Create<sbyte, decimal>();

            Assert.Equal(ManualConverter.SByteToDecimal(0), converter(0));
            Assert.Equal(ManualConverter.SByteToDecimal(1), converter(1));
            Assert.Equal(ManualConverter.SByteToDecimal(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToDecimal(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToDecimal(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToIntPtr()
        {
            var converter = ConverterFactory.Create<sbyte, IntPtr>();

            Assert.Equal(ManualConverter.SByteToIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.SByteToIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.SByteToIntPtr(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToIntPtr(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToIntPtr(SByte.MaxValue), converter(SByte.MaxValue));
        }

        [Fact]
        public void SByteToUIntPtr()
        {
            var converter = ConverterFactory.Create<sbyte, UIntPtr>();

            Assert.Equal(ManualConverter.SByteToUIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.SByteToUIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.SByteToUIntPtr(-1), converter(-1));
            Assert.Equal(ManualConverter.SByteToUIntPtr(SByte.MinValue), converter(SByte.MinValue));
            Assert.Equal(ManualConverter.SByteToUIntPtr(SByte.MaxValue), converter(SByte.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // CharTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void CharToByte()
        {
            var converter = ConverterFactory.Create<char, byte>();

            Assert.Equal(ManualConverter.CharToByte((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToByte((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToByte(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToByte(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToSByte()
        {
            var converter = ConverterFactory.Create<char, sbyte>();

            Assert.Equal(ManualConverter.CharToSByte((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToSByte((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToSByte(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToSByte(Char.MaxValue), converter(Char.MaxValue));
        }

        // Nop char

        [Fact]
        public void CharToInt16()
        {
            var converter = ConverterFactory.Create<char, short>();

            Assert.Equal(ManualConverter.CharToInt16((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToInt16((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToInt16(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToInt16(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToUInt16()
        {
            var converter = ConverterFactory.Create<char, ushort>();

            Assert.Equal(ManualConverter.CharToUInt16((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToUInt16((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToUInt16(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToUInt16(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToInt32()
        {
            var converter = ConverterFactory.Create<char, int>();

            Assert.Equal(ManualConverter.CharToInt32((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToInt32((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToInt32(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToInt32(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToUInt32()
        {
            var converter = ConverterFactory.Create<char, uint>();

            Assert.Equal(ManualConverter.CharToUInt32((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToUInt32((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToUInt32(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToUInt32(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToInt64()
        {
            var converter = ConverterFactory.Create<char, long>();

            Assert.Equal(ManualConverter.CharToInt64((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToInt64((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToInt64(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToInt64(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToUInt64()
        {
            var converter = ConverterFactory.Create<char, ulong>();

            Assert.Equal(ManualConverter.CharToUInt64((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToUInt64((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToUInt64(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToUInt64(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToSingle()
        {
            var converter = ConverterFactory.Create<char, float>();

            Assert.Equal(ManualConverter.CharToSingle((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToSingle((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToSingle(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToSingle(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToDouble()
        {
            var converter = ConverterFactory.Create<char, double>();

            Assert.Equal(ManualConverter.CharToDouble((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToDouble((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToDouble(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToDouble(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToDecimal()
        {
            var converter = ConverterFactory.Create<char, decimal>();

            Assert.Equal(ManualConverter.CharToDecimal((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToDecimal((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToDecimal(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToDecimal(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToIntPtr()
        {
            var converter = ConverterFactory.Create<char, IntPtr>();

            Assert.Equal(ManualConverter.CharToIntPtr((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToIntPtr((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToIntPtr(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToIntPtr(Char.MaxValue), converter(Char.MaxValue));
        }

        [Fact]
        public void CharToUIntPtr()
        {
            var converter = ConverterFactory.Create<char, UIntPtr>();

            Assert.Equal(ManualConverter.CharToUIntPtr((char)0), converter((char)0));
            Assert.Equal(ManualConverter.CharToUIntPtr((char)1), converter((char)1));
            Assert.Equal(ManualConverter.CharToUIntPtr(Char.MinValue), converter(Char.MinValue));
            Assert.Equal(ManualConverter.CharToUIntPtr(Char.MaxValue), converter(Char.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // Int16To
        //--------------------------------------------------------------------------------

        [Fact]
        public void Int16ToByte()
        {
            var converter = ConverterFactory.Create<short, byte>();

            Assert.Equal(ManualConverter.Int16ToByte(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToByte(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToByte(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToByte(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToByte(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToSByte()
        {
            var converter = ConverterFactory.Create<short, sbyte>();

            Assert.Equal(ManualConverter.Int16ToSByte(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToSByte(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToSByte(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToSByte(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToSByte(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToChar()
        {
            var converter = ConverterFactory.Create<short, char>();

            Assert.Equal(ManualConverter.Int16ToChar(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToChar(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToChar(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToChar(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToChar(Int16.MaxValue), converter(Int16.MaxValue));
        }

        // Nop short

        [Fact]
        public void Int16ToUInt16()
        {
            var converter = ConverterFactory.Create<short, ushort>();

            Assert.Equal(ManualConverter.Int16ToUInt16(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToUInt16(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToUInt16(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToUInt16(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToUInt16(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToInt32()
        {
            var converter = ConverterFactory.Create<short, int>();

            Assert.Equal(ManualConverter.Int16ToInt32(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToInt32(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToInt32(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToInt32(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToInt32(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToUInt32()
        {
            var converter = ConverterFactory.Create<short, uint>();

            Assert.Equal(ManualConverter.Int16ToUInt32(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToUInt32(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToUInt32(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToUInt32(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToUInt32(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToInt64()
        {
            var converter = ConverterFactory.Create<short, long>();

            Assert.Equal(ManualConverter.Int16ToInt64(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToInt64(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToInt64(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToInt64(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToInt64(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToUInt64()
        {
            var converter = ConverterFactory.Create<short, ulong>();

            Assert.Equal(ManualConverter.Int16ToUInt64(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToUInt64(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToUInt64(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToUInt64(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToUInt64(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToSingle()
        {
            var converter = ConverterFactory.Create<short, float>();

            Assert.Equal(ManualConverter.Int16ToSingle(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToSingle(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToSingle(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToSingle(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToSingle(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToDouble()
        {
            var converter = ConverterFactory.Create<short, double>();

            Assert.Equal(ManualConverter.Int16ToDouble(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToDouble(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToDouble(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToDouble(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToDouble(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToDecimal()
        {
            var converter = ConverterFactory.Create<short, decimal>();

            Assert.Equal(ManualConverter.Int16ToDecimal(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToDecimal(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToDecimal(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToDecimal(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToDecimal(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToIntPtr()
        {
            var converter = ConverterFactory.Create<short, IntPtr>();

            Assert.Equal(ManualConverter.Int16ToIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToIntPtr(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToIntPtr(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToIntPtr(Int16.MaxValue), converter(Int16.MaxValue));
        }

        [Fact]
        public void Int16ToUIntPtr()
        {
            var converter = ConverterFactory.Create<short, UIntPtr>();

            Assert.Equal(ManualConverter.Int16ToUIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.Int16ToUIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.Int16ToUIntPtr(-1), converter(-1));
            Assert.Equal(ManualConverter.Int16ToUIntPtr(Int16.MinValue), converter(Int16.MinValue));
            Assert.Equal(ManualConverter.Int16ToUIntPtr(Int16.MaxValue), converter(Int16.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // UInt16To
        //--------------------------------------------------------------------------------

        [Fact]
        public void UInt16ToByte()
        {
            var converter = ConverterFactory.Create<ushort, byte>();

            Assert.Equal(ManualConverter.UInt16ToByte(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToByte(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToByte(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToByte(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToSByte()
        {
            var converter = ConverterFactory.Create<ushort, sbyte>();

            Assert.Equal(ManualConverter.UInt16ToSByte(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToSByte(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToSByte(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToSByte(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToChar()
        {
            var converter = ConverterFactory.Create<ushort, char>();

            Assert.Equal(ManualConverter.UInt16ToChar(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToChar(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToChar(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToChar(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToInt16()
        {
            var converter = ConverterFactory.Create<ushort, short>();

            Assert.Equal(ManualConverter.UInt16ToInt16(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToInt16(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToInt16(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToInt16(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        // Nop ushort

        [Fact]
        public void UInt16ToInt32()
        {
            var converter = ConverterFactory.Create<ushort, int>();

            Assert.Equal(ManualConverter.UInt16ToInt32(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToInt32(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToInt32(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToInt32(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToUInt32()
        {
            var converter = ConverterFactory.Create<ushort, uint>();

            Assert.Equal(ManualConverter.UInt16ToUInt32(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToUInt32(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToUInt32(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToUInt32(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToInt64()
        {
            var converter = ConverterFactory.Create<ushort, long>();

            Assert.Equal(ManualConverter.UInt16ToInt64(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToInt64(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToInt64(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToInt64(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToUInt64()
        {
            var converter = ConverterFactory.Create<ushort, ulong>();

            Assert.Equal(ManualConverter.UInt16ToUInt64(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToUInt64(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToUInt64(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToUInt64(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToSingle()
        {
            var converter = ConverterFactory.Create<ushort, float>();

            Assert.Equal(ManualConverter.UInt16ToSingle(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToSingle(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToSingle(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToSingle(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToDouble()
        {
            var converter = ConverterFactory.Create<ushort, double>();

            Assert.Equal(ManualConverter.UInt16ToDouble(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToDouble(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToDouble(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToDouble(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToDecimal()
        {
            var converter = ConverterFactory.Create<ushort, decimal>();

            Assert.Equal(ManualConverter.UInt16ToDecimal(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToDecimal(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToDecimal(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToDecimal(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToIntPtr()
        {
            var converter = ConverterFactory.Create<ushort, IntPtr>();

            Assert.Equal(ManualConverter.UInt16ToIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToIntPtr(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToIntPtr(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        [Fact]
        public void UInt16ToUIntPtr()
        {
            var converter = ConverterFactory.Create<ushort, UIntPtr>();

            Assert.Equal(ManualConverter.UInt16ToUIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.UInt16ToUIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.UInt16ToUIntPtr(UInt16.MinValue), converter(UInt16.MinValue));
            Assert.Equal(ManualConverter.UInt16ToUIntPtr(UInt16.MaxValue), converter(UInt16.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // Int32To
        //--------------------------------------------------------------------------------

        [Fact]
        public void Int32ToByte()
        {
            var converter = ConverterFactory.Create<int, byte>();

            Assert.Equal(ManualConverter.Int32ToByte(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToByte(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToByte(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToByte(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToByte(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToSByte()
        {
            var converter = ConverterFactory.Create<int, sbyte>();

            Assert.Equal(ManualConverter.Int32ToSByte(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToSByte(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToSByte(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToSByte(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToSByte(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToChar()
        {
            var converter = ConverterFactory.Create<int, char>();

            Assert.Equal(ManualConverter.Int32ToChar(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToChar(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToChar(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToChar(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToChar(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToInt16()
        {
            var converter = ConverterFactory.Create<int, short>();

            // Base
            Assert.Equal(0, converter(0));
            Assert.Equal(1, converter(1));
            Assert.Equal(-1, converter(-1));
            // Min/Max
            Assert.Equal(ManualConverter.Int32ToInt16(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToInt16(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToInt16(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToInt16(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToInt16(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToUInt16()
        {
            var converter = ConverterFactory.Create<int, ushort>();

            Assert.Equal(ManualConverter.Int32ToUInt16(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToUInt16(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToUInt16(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToUInt16(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToUInt16(Int32.MaxValue), converter(Int32.MaxValue));
        }

        // Nop int

        [Fact]
        public void Int32ToUInt32()
        {
            var converter = ConverterFactory.Create<int, uint>();

            Assert.Equal(ManualConverter.Int32ToUInt32(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToUInt32(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToUInt32(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToUInt32(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToUInt32(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToInt64()
        {
            var converter = ConverterFactory.Create<int, long>();

            Assert.Equal(ManualConverter.Int32ToInt64(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToInt64(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToInt64(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToInt64(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToInt64(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToUInt64()
        {
            var converter = ConverterFactory.Create<int, ulong>();

            Assert.Equal(ManualConverter.Int32ToUInt64(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToUInt64(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToUInt64(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToUInt64(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToUInt64(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToSingle()
        {
            var converter = ConverterFactory.Create<int, float>();

            Assert.Equal(ManualConverter.Int32ToSingle(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToSingle(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToSingle(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToSingle(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToSingle(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToDouble()
        {
            var converter = ConverterFactory.Create<int, double>();

            Assert.Equal(ManualConverter.Int32ToDouble(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToDouble(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToDouble(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToDouble(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToDouble(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToDecimal()
        {
            var converter = ConverterFactory.Create<int, decimal>();

            Assert.Equal(ManualConverter.Int32ToDecimal(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToDecimal(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToDecimal(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToDecimal(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToDecimal(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToIntPtr()
        {
            var converter = ConverterFactory.Create<int, IntPtr>();

            Assert.Equal(ManualConverter.Int32ToIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToIntPtr(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToIntPtr(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToIntPtr(Int32.MaxValue), converter(Int32.MaxValue));
        }

        [Fact]
        public void Int32ToUIntPtr()
        {
            var converter = ConverterFactory.Create<int, UIntPtr>();

            Assert.Equal(ManualConverter.Int32ToUIntPtr(0), converter(0));
            Assert.Equal(ManualConverter.Int32ToUIntPtr(1), converter(1));
            Assert.Equal(ManualConverter.Int32ToUIntPtr(-1), converter(-1));
            Assert.Equal(ManualConverter.Int32ToUIntPtr(Int32.MinValue), converter(Int32.MinValue));
            Assert.Equal(ManualConverter.Int32ToUIntPtr(Int32.MaxValue), converter(Int32.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // UInt32To
        //--------------------------------------------------------------------------------

        [Fact]
        public void UInt32ToByte()
        {
            var converter = ConverterFactory.Create<uint, byte>();

            Assert.Equal(ManualConverter.UInt32ToByte(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToByte(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToByte(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToByte(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToSByte()
        {
            var converter = ConverterFactory.Create<uint, sbyte>();

            Assert.Equal(ManualConverter.UInt32ToSByte(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToSByte(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToSByte(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToSByte(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToChar()
        {
            var converter = ConverterFactory.Create<uint, char>();

            Assert.Equal(ManualConverter.UInt32ToChar(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToChar(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToChar(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToChar(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToInt16()
        {
            var converter = ConverterFactory.Create<uint, short>();

            Assert.Equal(ManualConverter.UInt32ToInt16(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToInt16(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToInt16(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToInt16(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToUInt16()
        {
            var converter = ConverterFactory.Create<uint, ushort>();

            Assert.Equal(ManualConverter.UInt32ToUInt16(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToUInt16(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToUInt16(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToUInt16(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToInt32()
        {
            var converter = ConverterFactory.Create<uint, int>();

            Assert.Equal(ManualConverter.UInt32ToInt32(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToInt32(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToInt32(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToInt32(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        // Nop uint

        [Fact]
        public void UInt32ToInt64()
        {
            var converter = ConverterFactory.Create<uint, long>();

            Assert.Equal(ManualConverter.UInt32ToInt64(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToInt64(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToInt64(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToInt64(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToUInt64()
        {
            var converter = ConverterFactory.Create<uint, uint>();

            Assert.Equal(ManualConverter.UInt32ToUInt64(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToUInt64(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToUInt64(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToUInt64(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToSingle()
        {
            var converter = ConverterFactory.Create<uint, float>();

            Assert.Equal(ManualConverter.UInt32ToSingle(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToSingle(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToSingle(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToSingle(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToDouble()
        {
            var converter = ConverterFactory.Create<uint, double>();

            Assert.Equal(ManualConverter.UInt32ToDouble(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToDouble(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToDouble(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToDouble(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToDecimal()
        {
            var converter = ConverterFactory.Create<uint, decimal>();

            Assert.Equal(ManualConverter.UInt32ToDecimal(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToDecimal(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToDecimal(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToDecimal(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToIntPtr()
        {
            var converter = ConverterFactory.Create<uint, IntPtr>();

            Assert.Equal(ManualConverter.UInt32ToIntPtr(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToIntPtr(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToIntPtr(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToIntPtr(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        [Fact]
        public void UInt32ToUIntPtr()
        {
            var converter = ConverterFactory.Create<uint, UIntPtr>();

            Assert.Equal(ManualConverter.UInt32ToUIntPtr(0u), converter(0u));
            Assert.Equal(ManualConverter.UInt32ToUIntPtr(1u), converter(1u));
            Assert.Equal(ManualConverter.UInt32ToUIntPtr(UInt32.MinValue), converter(UInt32.MinValue));
            Assert.Equal(ManualConverter.UInt32ToUIntPtr(UInt32.MaxValue), converter(UInt32.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // Int64To
        //--------------------------------------------------------------------------------

        [Fact]
        public void Int64ToByte()
        {
            var converter = ConverterFactory.Create<long, byte>();

            Assert.Equal(ManualConverter.Int64ToByte(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToByte(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToByte(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToByte(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToByte(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToSByte()
        {
            var converter = ConverterFactory.Create<long, sbyte>();

            Assert.Equal(ManualConverter.Int64ToSByte(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToSByte(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToSByte(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToSByte(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToSByte(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToChar()
        {
            var converter = ConverterFactory.Create<long, char>();

            Assert.Equal(ManualConverter.Int64ToChar(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToChar(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToChar(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToChar(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToChar(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToInt16()
        {
            var converter = ConverterFactory.Create<long, short>();

            Assert.Equal(ManualConverter.Int64ToInt16(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToInt16(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToInt16(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToInt16(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToInt16(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToUInt16()
        {
            var converter = ConverterFactory.Create<long, ushort>();

            Assert.Equal(ManualConverter.Int64ToUInt16(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToUInt16(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToUInt16(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToUInt16(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToUInt16(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToInt32()
        {
            var converter = ConverterFactory.Create<long, int>();

            Assert.Equal(ManualConverter.Int64ToInt32(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToInt32(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToInt32(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToInt32(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToInt32(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToUInt32()
        {
            var converter = ConverterFactory.Create<long, uint>();

            Assert.Equal(ManualConverter.Int64ToUInt32(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToUInt32(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToUInt32(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToUInt32(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToUInt32(Int64.MaxValue), converter(Int64.MaxValue));
        }

        // Nop long

        [Fact]
        public void Int64ToUInt64()
        {
            var converter = ConverterFactory.Create<long, ulong>();

            Assert.Equal(ManualConverter.Int64ToUInt64(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToUInt64(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToUInt64(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToUInt64(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToUInt64(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToSingle()
        {
            var converter = ConverterFactory.Create<long, float>();

            Assert.Equal(ManualConverter.Int64ToSingle(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToSingle(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToSingle(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToSingle(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToSingle(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToDouble()
        {
            var converter = ConverterFactory.Create<long, double>();

            Assert.Equal(ManualConverter.Int64ToDouble(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToDouble(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToDouble(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToDouble(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToDouble(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToDecimal()
        {
            var converter = ConverterFactory.Create<long, decimal>();

            Assert.Equal(ManualConverter.Int64ToDecimal(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToDecimal(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToDecimal(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToDecimal(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToDecimal(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToIntPtr()
        {
            var converter = ConverterFactory.Create<long, IntPtr>();

            Assert.Equal(ManualConverter.Int64ToIntPtr(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToIntPtr(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToIntPtr(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToIntPtr(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToIntPtr(Int64.MaxValue), converter(Int64.MaxValue));
        }

        [Fact]
        public void Int64ToUIntPtr()
        {
            var converter = ConverterFactory.Create<long, UIntPtr>();

            Assert.Equal(ManualConverter.Int64ToUIntPtr(0L), converter(0L));
            Assert.Equal(ManualConverter.Int64ToUIntPtr(1L), converter(1L));
            Assert.Equal(ManualConverter.Int64ToUIntPtr(-1L), converter(-1L));
            Assert.Equal(ManualConverter.Int64ToUIntPtr(Int64.MinValue), converter(Int64.MinValue));
            Assert.Equal(ManualConverter.Int64ToUIntPtr(Int64.MaxValue), converter(Int64.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // UInt64To
        //--------------------------------------------------------------------------------

        [Fact]
        public void UInt64ToByte()
        {
            var converter = ConverterFactory.Create<ulong, byte>();

            Assert.Equal(ManualConverter.UInt64ToByte(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToByte(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToByte(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToByte(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToSByte()
        {
            var converter = ConverterFactory.Create<ulong, sbyte>();

            Assert.Equal(ManualConverter.UInt64ToSByte(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToSByte(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToSByte(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToSByte(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToChar()
        {
            var converter = ConverterFactory.Create<ulong, char>();

            Assert.Equal(ManualConverter.UInt64ToChar(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToChar(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToChar(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToChar(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToInt16()
        {
            var converter = ConverterFactory.Create<ulong, short>();

            Assert.Equal(ManualConverter.UInt64ToInt16(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToInt16(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToInt16(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToInt16(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToUInt16()
        {
            var converter = ConverterFactory.Create<ulong, ushort>();

            Assert.Equal(ManualConverter.UInt64ToUInt16(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToUInt16(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToUInt16(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToUInt16(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToInt32()
        {
            var converter = ConverterFactory.Create<ulong, int>();

            Assert.Equal(ManualConverter.UInt64ToInt32(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToInt32(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToInt32(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToInt32(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToUInt32()
        {
            var converter = ConverterFactory.Create<ulong, uint>();

            Assert.Equal(ManualConverter.UInt64ToUInt32(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToUInt32(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToUInt32(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToUInt32(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToInt64()
        {
            var converter = ConverterFactory.Create<ulong, long>();

            Assert.Equal(ManualConverter.UInt64ToInt64(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToInt64(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToInt64(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToInt64(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        // Nop ulong

        [Fact]
        public void UInt64ToSingle()
        {
            var converter = ConverterFactory.Create<ulong, float>();

            Assert.Equal(ManualConverter.UInt64ToSingle(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToSingle(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToSingle(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToSingle(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToDouble()
        {
            var converter = ConverterFactory.Create<ulong, double>();

            Assert.Equal(ManualConverter.UInt64ToDouble(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToDouble(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToDouble(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToDouble(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToDecimal()
        {
            var converter = ConverterFactory.Create<ulong, decimal>();

            Assert.Equal(ManualConverter.UInt64ToDecimal(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToDecimal(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToDecimal(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToDecimal(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToIntPtr()
        {
            var converter = ConverterFactory.Create<ulong, IntPtr>();

            Assert.Equal(ManualConverter.UInt64ToIntPtr(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToIntPtr(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToIntPtr(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToIntPtr(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        [Fact]
        public void UInt64ToUIntPtr()
        {
            var converter = ConverterFactory.Create<ulong, UIntPtr>();

            Assert.Equal(ManualConverter.UInt64ToUIntPtr(0ul), converter(0ul));
            Assert.Equal(ManualConverter.UInt64ToUIntPtr(1ul), converter(1ul));
            Assert.Equal(ManualConverter.UInt64ToUIntPtr(UInt64.MinValue), converter(UInt64.MinValue));
            Assert.Equal(ManualConverter.UInt64ToUIntPtr(UInt64.MaxValue), converter(UInt64.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // SingleTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void SingleToByte()
        {
            var converter = ConverterFactory.Create<float, byte>();

            Assert.Equal(ManualConverter.SingleToByte(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToByte(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToByte(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToByte(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToByte(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToSByte()
        {
            var converter = ConverterFactory.Create<float, sbyte>();

            Assert.Equal(ManualConverter.SingleToSByte(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToSByte(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToSByte(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToSByte(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToSByte(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToChar()
        {
            var converter = ConverterFactory.Create<float, char>();

            Assert.Equal(ManualConverter.SingleToChar(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToChar(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToChar(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToChar(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToChar(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToInt16()
        {
            var converter = ConverterFactory.Create<float, short>();

            Assert.Equal(ManualConverter.SingleToInt16(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToInt16(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToInt16(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToInt16(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToInt16(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToUInt16()
        {
            var converter = ConverterFactory.Create<float, ushort>();

            Assert.Equal(ManualConverter.SingleToUInt16(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToUInt16(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToUInt16(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToUInt16(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToUInt16(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToInt32()
        {
            var converter = ConverterFactory.Create<float, int>();

            Assert.Equal(ManualConverter.SingleToInt32(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToInt32(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToInt32(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToInt32(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToInt32(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToUInt32()
        {
            var converter = ConverterFactory.Create<float, uint>();

            Assert.Equal(ManualConverter.SingleToUInt32(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToUInt32(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToUInt32(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToUInt32(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToUInt32(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToInt64()
        {
            var converter = ConverterFactory.Create<float, long>();

            Assert.Equal(ManualConverter.SingleToInt64(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToInt64(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToInt64(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToInt64(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToInt64(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToUInt64()
        {
            var converter = ConverterFactory.Create<float, ulong>();

            Assert.Equal(ManualConverter.SingleToUInt64(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToUInt64(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToUInt64(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToUInt64(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToUInt64(Single.MaxValue), converter(Single.MaxValue));
        }

        // Nop float

        [Fact]
        public void SingleToDouble()
        {
            var converter = ConverterFactory.Create<float, double>();

            Assert.Equal(ManualConverter.SingleToDouble(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToDouble(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToDouble(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToDouble(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToDouble(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToDecimal()
        {
            var converter = ConverterFactory.Create<float, decimal>();

            Assert.Equal(ManualConverter.SingleToDecimal(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToDecimal(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToDecimal(-1f), converter(-1f));
            //Assert.Equal(ManualConverter.SingleToDecimal(Single.MinValue), converter(Single.MinValue));
            //Assert.Equal(ManualConverter.SingleToDecimal(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToIntPtr()
        {
            var converter = ConverterFactory.Create<float, IntPtr>();

            Assert.Equal(ManualConverter.SingleToIntPtr(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToIntPtr(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToIntPtr(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToIntPtr(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToIntPtr(Single.MaxValue), converter(Single.MaxValue));
        }

        [Fact]
        public void SingleToUIntPtr()
        {
            var converter = ConverterFactory.Create<float, UIntPtr>();

            Assert.Equal(ManualConverter.SingleToUIntPtr(0f), converter(0f));
            Assert.Equal(ManualConverter.SingleToUIntPtr(1f), converter(1f));
            Assert.Equal(ManualConverter.SingleToUIntPtr(-1f), converter(-1f));
            Assert.Equal(ManualConverter.SingleToUIntPtr(Single.MinValue), converter(Single.MinValue));
            Assert.Equal(ManualConverter.SingleToUIntPtr(Single.MaxValue), converter(Single.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // DoubleTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void DoubleToByte()
        {
            var converter = ConverterFactory.Create<double, byte>();

            Assert.Equal(ManualConverter.DoubleToByte(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToByte(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToByte(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToByte(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToByte(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToSByte()
        {
            var converter = ConverterFactory.Create<double, sbyte>();

            Assert.Equal(ManualConverter.DoubleToSByte(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToSByte(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToSByte(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToSByte(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToSByte(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToChar()
        {
            var converter = ConverterFactory.Create<double, char>();

            Assert.Equal(ManualConverter.DoubleToChar(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToChar(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToChar(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToChar(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToChar(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToInt16()
        {
            var converter = ConverterFactory.Create<double, short>();

            Assert.Equal(ManualConverter.DoubleToInt16(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToInt16(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToInt16(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToInt16(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToInt16(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToUInt16()
        {
            var converter = ConverterFactory.Create<double, ushort>();

            Assert.Equal(ManualConverter.DoubleToUInt16(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToUInt16(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToUInt16(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToUInt16(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToUInt16(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToInt32()
        {
            var converter = ConverterFactory.Create<double, int>();

            Assert.Equal(ManualConverter.DoubleToInt32(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToInt32(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToInt32(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToInt32(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToInt32(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToUInt32()
        {
            var converter = ConverterFactory.Create<double, uint>();

            Assert.Equal(ManualConverter.DoubleToUInt32(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToUInt32(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToUInt32(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToUInt32(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToUInt32(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToInt64()
        {
            var converter = ConverterFactory.Create<double, long>();

            Assert.Equal(ManualConverter.DoubleToInt64(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToInt64(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToInt64(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToInt64(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToInt64(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToUInt64()
        {
            var converter = ConverterFactory.Create<double, ulong>();

            Assert.Equal(ManualConverter.DoubleToUInt64(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToUInt64(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToUInt64(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToUInt64(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToUInt64(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToSingle()
        {
            var converter = ConverterFactory.Create<double, float>();

            Assert.Equal(ManualConverter.DoubleToSingle(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToSingle(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToSingle(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToSingle(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToSingle(Double.MinValue), converter(Double.MinValue));
        }

        // Nop double

        [Fact]
        public void DoubleToDecimal()
        {
            var converter = ConverterFactory.Create<double, decimal>();

            Assert.Equal(ManualConverter.DoubleToDecimal(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToDecimal(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToDecimal(-1d), converter(-1d));
            //Assert.Equal(ManualConverter.DoubleToDecimal(Double.MinValue), converter(Double.MinValue));
            //Assert.Equal(ManualConverter.DoubleToDecimal(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToIntPtr()
        {
            var converter = ConverterFactory.Create<double, IntPtr>();

            Assert.Equal(ManualConverter.DoubleToIntPtr(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToIntPtr(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToIntPtr(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToIntPtr(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToIntPtr(Double.MaxValue), converter(Double.MaxValue));
        }

        [Fact]
        public void DoubleToUIntPtr()
        {
            var converter = ConverterFactory.Create<double, UIntPtr>();

            Assert.Equal(ManualConverter.DoubleToUIntPtr(0d), converter(0d));
            Assert.Equal(ManualConverter.DoubleToUIntPtr(1d), converter(1d));
            Assert.Equal(ManualConverter.DoubleToUIntPtr(-1d), converter(-1d));
            Assert.Equal(ManualConverter.DoubleToUIntPtr(Double.MinValue), converter(Double.MinValue));
            Assert.Equal(ManualConverter.DoubleToUIntPtr(Double.MaxValue), converter(Double.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // DecimalTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void DecimalToByte()
        {
            var converter = ConverterFactory.Create<decimal, byte>();

            Assert.Equal(ManualConverter.DecimalToByte(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToByte(1m), converter(1m));
            //Assert.Equal(ManualConverter.DecimalToByte(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToByte(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToByte(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToSByte()
        {
            var converter = ConverterFactory.Create<decimal, sbyte>();

            Assert.Equal(ManualConverter.DecimalToSByte(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToSByte(1m), converter(1m));
            Assert.Equal(ManualConverter.DecimalToSByte(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToSByte(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToSByte(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToChar()
        {
            var converter = ConverterFactory.Create<decimal, char>();

            Assert.Equal(ManualConverter.DecimalToChar(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToChar(1m), converter(1m));
            //Assert.Equal(ManualConverter.DecimalToChar(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToChar(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToChar(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToInt16()
        {
            var converter = ConverterFactory.Create<decimal, short>();

            Assert.Equal(ManualConverter.DecimalToInt16(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToInt16(1m), converter(1m));
            Assert.Equal(ManualConverter.DecimalToInt16(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToInt16(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToInt16(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToUInt16()
        {
            var converter = ConverterFactory.Create<decimal, ushort>();

            Assert.Equal(ManualConverter.DecimalToUInt16(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToUInt16(1m), converter(1m));
            //Assert.Equal(ManualConverter.DecimalToUInt16(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToUInt16(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToUInt16(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToInt32()
        {
            var converter = ConverterFactory.Create<decimal, int>();

            Assert.Equal(ManualConverter.DecimalToInt32(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToInt32(1m), converter(1m));
            Assert.Equal(ManualConverter.DecimalToInt32(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToInt32(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToInt32(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToUInt32()
        {
            var converter = ConverterFactory.Create<decimal, uint>();

            Assert.Equal(ManualConverter.DecimalToUInt32(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToUInt32(1m), converter(1m));
            //Assert.Equal(ManualConverter.DecimalToUInt32(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToUInt32(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToUInt32(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToInt64()
        {
            var converter = ConverterFactory.Create<decimal, long>();

            Assert.Equal(ManualConverter.DecimalToInt64(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToInt64(1m), converter(1m));
            Assert.Equal(ManualConverter.DecimalToInt64(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToInt64(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToInt64(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToUInt64()
        {
            var converter = ConverterFactory.Create<decimal, ulong>();

            Assert.Equal(ManualConverter.DecimalToUInt64(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToUInt64(1m), converter(1m));
            //Assert.Equal(ManualConverter.DecimalToUInt64(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToUInt64(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToUInt64(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToSingle()
        {
            var converter = ConverterFactory.Create<decimal, float>();

            Assert.Equal(ManualConverter.DecimalToSingle(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToSingle(1m), converter(1m));
            Assert.Equal(ManualConverter.DecimalToSingle(-1m), converter(-1m));
            Assert.Equal(ManualConverter.DecimalToSingle(Decimal.MinValue), converter(Decimal.MinValue));
            Assert.Equal(ManualConverter.DecimalToSingle(Decimal.MinValue), converter(Decimal.MinValue));
        }

        [Fact]
        public void DecimalToDouble()
        {
            var converter = ConverterFactory.Create<decimal, double>();

            Assert.Equal(ManualConverter.DecimalToDouble(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToDouble(1m), converter(1m));
            Assert.Equal(ManualConverter.DecimalToDouble(-1m), converter(-1m));
            Assert.Equal(ManualConverter.DecimalToDouble(Decimal.MinValue), converter(Decimal.MinValue));
            Assert.Equal(ManualConverter.DecimalToDouble(Decimal.MinValue), converter(Decimal.MinValue));
        }

        // Nop decimal

        [Fact]
        public void DecimalToIntPtr()
        {
            var converter = ConverterFactory.Create<decimal, IntPtr>();

            Assert.Equal(ManualConverter.DecimalToIntPtr(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToIntPtr(1m), converter(1m));
            Assert.Equal(ManualConverter.DecimalToIntPtr(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToIntPtr(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToIntPtr(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        [Fact]
        public void DecimalToUIntPtr()
        {
            var converter = ConverterFactory.Create<decimal, UIntPtr>();

            Assert.Equal(ManualConverter.DecimalToUIntPtr(0m), converter(0m));
            Assert.Equal(ManualConverter.DecimalToUIntPtr(1m), converter(1m));
            //Assert.Equal(ManualConverter.DecimalToUIntPtr(-1m), converter(-1m));
            //Assert.Equal(ManualConverter.DecimalToUIntPtr(Decimal.MinValue), converter(Decimal.MinValue));
            //Assert.Equal(ManualConverter.DecimalToUIntPtr(Decimal.MaxValue), converter(Decimal.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // IntPtrTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void IntPtrToByte()
        {
            var converter = ConverterFactory.Create<IntPtr, byte>();

            Assert.Equal(ManualConverter.IntPtrToByte(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToByte((IntPtr)1), converter((IntPtr)1));
            //Assert.Equal(ManualConverter.IntPtrToByte(IntPtr.MinValue), converter(IntPtr.MinValue));
            //Assert.Equal(ManualConverter.IntPtrToByte(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        [Fact]
        public void IntPtrToSByte()
        {
            var converter = ConverterFactory.Create<IntPtr, sbyte>();

            Assert.Equal(ManualConverter.IntPtrToSByte(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToSByte((IntPtr)1), converter((IntPtr)1));
            //Assert.Equal(ManualConverter.IntPtrToSByte(IntPtr.MinValue), converter(IntPtr.MinValue));
            //Assert.Equal(ManualConverter.IntPtrToSByte(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        [Fact]
        public void IntPtrToChar()
        {
            var converter = ConverterFactory.Create<IntPtr, char>();

            Assert.Equal(ManualConverter.IntPtrToChar(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToChar((IntPtr)1), converter((IntPtr)1));
            //Assert.Equal(ManualConverter.IntPtrToChar(IntPtr.MinValue), converter(IntPtr.MinValue));
            //Assert.Equal(ManualConverter.IntPtrToChar(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        [Fact]
        public void IntPtrToInt16()
        {
            var converter = ConverterFactory.Create<IntPtr, short>();

            Assert.Equal(ManualConverter.IntPtrToInt16(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToInt16((IntPtr)1), converter((IntPtr)1));
            //Assert.Equal(ManualConverter.IntPtrToInt16(IntPtr.MinValue), converter(IntPtr.MinValue));
            //Assert.Equal(ManualConverter.IntPtrToInt16(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        [Fact]
        public void IntPtrToUInt16()
        {
            var converter = ConverterFactory.Create<IntPtr, ushort>();

            Assert.Equal(ManualConverter.IntPtrToUInt16(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToUInt16((IntPtr)1), converter((IntPtr)1));
            //Assert.Equal(ManualConverter.IntPtrToUInt16(IntPtr.MinValue), converter(IntPtr.MinValue));
            //Assert.Equal(ManualConverter.IntPtrToUInt16(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        [Fact]
        public void IntPtrToInt32()
        {
            var converter = ConverterFactory.Create<IntPtr, int>();

            Assert.Equal(ManualConverter.IntPtrToInt32(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToInt32((IntPtr)1), converter((IntPtr)1));
            //Assert.Equal(ManualConverter.IntPtrToInt32(IntPtr.MinValue), converter(IntPtr.MinValue));
            //Assert.Equal(ManualConverter.IntPtrToInt32(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        [Fact]
        public void IntPtrToUInt32()
        {
            var converter = ConverterFactory.Create<IntPtr, uint>();

            Assert.Equal(ManualConverter.IntPtrToUInt32(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToUInt32((IntPtr)1), converter((IntPtr)1));
            //Assert.Equal(ManualConverter.IntPtrToUInt32(IntPtr.MinValue), converter(IntPtr.MinValue));
            //Assert.Equal(ManualConverter.IntPtrToUInt32(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        [Fact]
        public void IntPtrToInt64()
        {
            var converter = ConverterFactory.Create<IntPtr, long>();

            Assert.Equal(ManualConverter.IntPtrToInt64(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToInt64((IntPtr)1), converter((IntPtr)1));
            Assert.Equal(ManualConverter.IntPtrToInt64(IntPtr.MinValue), converter(IntPtr.MinValue));
            Assert.Equal(ManualConverter.IntPtrToInt64(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        [Fact]
        public void IntPtrToUInt64()
        {
            var converter = ConverterFactory.Create<IntPtr, ulong>();

            Assert.Equal(ManualConverter.IntPtrToUInt64(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToUInt64((IntPtr)1), converter((IntPtr)1));
            Assert.Equal(ManualConverter.IntPtrToUInt64(IntPtr.MinValue), converter(IntPtr.MinValue));
            Assert.Equal(ManualConverter.IntPtrToUInt64(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        [Fact]
        public void IntPtrToSingle()
        {
            var converter = ConverterFactory.Create<IntPtr, float>();

            Assert.Equal(ManualConverter.IntPtrToSingle(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToSingle((IntPtr)1), converter((IntPtr)1));
            Assert.Equal(ManualConverter.IntPtrToSingle(IntPtr.MinValue), converter(IntPtr.MinValue));
            Assert.Equal(ManualConverter.IntPtrToSingle(IntPtr.MinValue), converter(IntPtr.MinValue));
        }

        [Fact]
        public void IntPtrToDouble()
        {
            var converter = ConverterFactory.Create<IntPtr, double>();

            Assert.Equal(ManualConverter.IntPtrToDouble(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToDouble((IntPtr)1), converter((IntPtr)1));
            Assert.Equal(ManualConverter.IntPtrToDouble(IntPtr.MinValue), converter(IntPtr.MinValue));
            Assert.Equal(ManualConverter.IntPtrToDouble(IntPtr.MinValue), converter(IntPtr.MinValue));
        }

        [Fact]
        public void IntPtrToDecimal()
        {
            var converter = ConverterFactory.Create<IntPtr, decimal>();

            Assert.Equal(ManualConverter.IntPtrToDecimal(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToDecimal((IntPtr)1), converter((IntPtr)1));
            Assert.Equal(ManualConverter.IntPtrToDecimal(IntPtr.MinValue), converter(IntPtr.MinValue));
            Assert.Equal(ManualConverter.IntPtrToDecimal(IntPtr.MinValue), converter(IntPtr.MinValue));
        }

        // Nop IntPtr

        [Fact]
        public void IntPtrToUIntPtr()
        {
            var converter = ConverterFactory.Create<IntPtr, UIntPtr>();

            Assert.Equal(ManualConverter.IntPtrToUIntPtr(IntPtr.Zero), converter(IntPtr.Zero));
            Assert.Equal(ManualConverter.IntPtrToUIntPtr((IntPtr)1), converter((IntPtr)1));
            Assert.Equal(ManualConverter.IntPtrToUIntPtr(IntPtr.MinValue), converter(IntPtr.MinValue));
            Assert.Equal(ManualConverter.IntPtrToUIntPtr(IntPtr.MaxValue), converter(IntPtr.MaxValue));
        }

        //--------------------------------------------------------------------------------
        // UIntPtrTo
        //--------------------------------------------------------------------------------

        [Fact]
        public void UIntPtrToByte()
        {
            var converter = ConverterFactory.Create<UIntPtr, byte>();

            Assert.Equal(ManualConverter.UIntPtrToByte(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToByte((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToByte(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            //Assert.Equal(ManualConverter.UIntPtrToByte(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        [Fact]
        public void UIntPtrToSByte()
        {
            var converter = ConverterFactory.Create<UIntPtr, sbyte>();

            Assert.Equal(ManualConverter.UIntPtrToSByte(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToSByte((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToSByte(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            //Assert.Equal(ManualConverter.UIntPtrToSByte(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        [Fact]
        public void UIntPtrToChar()
        {
            var converter = ConverterFactory.Create<UIntPtr, char>();

            Assert.Equal(ManualConverter.UIntPtrToChar(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToChar((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToChar(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            //Assert.Equal(ManualConverter.UIntPtrToChar(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        [Fact]
        public void UIntPtrToInt16()
        {
            var converter = ConverterFactory.Create<UIntPtr, short>();

            Assert.Equal(ManualConverter.UIntPtrToInt16(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToInt16((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToInt16(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            //Assert.Equal(ManualConverter.UIntPtrToInt16(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        [Fact]
        public void UIntPtrToUInt16()
        {
            var converter = ConverterFactory.Create<UIntPtr, ushort>();

            Assert.Equal(ManualConverter.UIntPtrToUInt16(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToUInt16((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToUInt16(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            //Assert.Equal(ManualConverter.UIntPtrToUInt16(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        [Fact]
        public void UIntPtrToInt32()
        {
            var converter = ConverterFactory.Create<UIntPtr, int>();

            Assert.Equal(ManualConverter.UIntPtrToInt32(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToInt32((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToInt32(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            //Assert.Equal(ManualConverter.UIntPtrToInt32(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        [Fact]
        public void UIntPtrToUInt32()
        {
            var converter = ConverterFactory.Create<UIntPtr, uint>();

            Assert.Equal(ManualConverter.UIntPtrToUInt32(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToUInt32((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToUInt32(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            //Assert.Equal(ManualConverter.UIntPtrToUInt32(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        [Fact]
        public void UIntPtrToInt64()
        {
            var converter = ConverterFactory.Create<UIntPtr, long>();

            Assert.Equal(ManualConverter.UIntPtrToInt64(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToInt64((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToInt64(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            Assert.Equal(ManualConverter.UIntPtrToInt64(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        [Fact]
        public void UIntPtrToUInt64()
        {
            var converter = ConverterFactory.Create<UIntPtr, ulong>();

            Assert.Equal(ManualConverter.UIntPtrToUInt64(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToUInt64((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToUInt64(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            Assert.Equal(ManualConverter.UIntPtrToUInt64(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        [Fact]
        public void UIntPtrToSingle()
        {
            var converter = ConverterFactory.Create<UIntPtr, float>();

            Assert.Equal(ManualConverter.UIntPtrToSingle(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToSingle((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToSingle(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            Assert.Equal(ManualConverter.UIntPtrToSingle(UIntPtr.MinValue), converter(UIntPtr.MinValue));
        }

        [Fact]
        public void UIntPtrToDouble()
        {
            var converter = ConverterFactory.Create<UIntPtr, double>();

            Assert.Equal(ManualConverter.UIntPtrToDouble(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToDouble((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToDouble(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            Assert.Equal(ManualConverter.UIntPtrToDouble(UIntPtr.MinValue), converter(UIntPtr.MinValue));
        }

        [Fact]
        public void UIntPtrToDecimal()
        {
            var converter = ConverterFactory.Create<UIntPtr, decimal>();

            Assert.Equal(ManualConverter.UIntPtrToDecimal(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToDecimal((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToDecimal(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            Assert.Equal(ManualConverter.UIntPtrToDecimal(UIntPtr.MinValue), converter(UIntPtr.MinValue));
        }

        [Fact]
        public void UIntPtrToIntPtr()
        {
            var converter = ConverterFactory.Create<UIntPtr, IntPtr>();

            Assert.Equal(ManualConverter.UIntPtrToIntPtr(UIntPtr.Zero), converter(UIntPtr.Zero));
            Assert.Equal(ManualConverter.UIntPtrToIntPtr((UIntPtr)1), converter((UIntPtr)1));
            Assert.Equal(ManualConverter.UIntPtrToIntPtr(UIntPtr.MinValue), converter(UIntPtr.MinValue));
            Assert.Equal(ManualConverter.UIntPtrToIntPtr(UIntPtr.MaxValue), converter(UIntPtr.MaxValue));
        }

        // Nop UIntPtr

        //--------------------------------------------------------------------------------
        // Helper
        //--------------------------------------------------------------------------------

        public static class ConverterFactory
        {
            public static Func<TSource, TDestination> Create<TSource, TDestination>()
            {
                var sourceType = typeof(TSource);
                var destinationType = typeof(TDestination);

                var dynamicMethod = new DynamicMethod(string.Empty, destinationType, new[] { sourceType }, true);
                var ilGenerator = dynamicMethod.GetILGenerator();

                // Argument
                ilGenerator.Emit(OpCodes.Ldarg_0);

                // Convert
                if (!ilGenerator.EmitPrimitiveConvert(sourceType, destinationType))
                {
                    throw new NotSupportedException();
                }

                // Return
                ilGenerator.Emit(OpCodes.Ret);

                return (Func<TSource, TDestination>)dynamicMethod.CreateDelegate(typeof(Func<TSource, TDestination>), null);
            }
        }

        public static class ManualConverter
        {
            public static sbyte ByteToSByte(byte x) => (sbyte)x;
            public static char ByteToChar(byte x) => (char)x;
            public static decimal ByteToDecimal(byte x) => x;
            public static double ByteToDouble(byte x) => x;
            public static float ByteToSingle(byte x) => x;
            public static int ByteToInt32(byte x) => x;
            public static uint ByteToUInt32(byte x) => x;
            public static IntPtr ByteToIntPtr(byte x) => (IntPtr)x;
            public static UIntPtr ByteToUIntPtr(byte x) => (UIntPtr)x;
            public static long ByteToInt64(byte x) => x;
            public static ulong ByteToUInt64(byte x) => x;
            public static short ByteToInt16(byte x) => x;
            public static ushort ByteToUInt16(byte x) => x;

            public static byte SByteToByte(sbyte x) => (byte)x;
            public static char SByteToChar(sbyte x) => (char)x;
            public static decimal SByteToDecimal(sbyte x) => x;
            public static double SByteToDouble(sbyte x) => x;
            public static float SByteToSingle(sbyte x) => x;
            public static int SByteToInt32(sbyte x) => x;
            public static uint SByteToUInt32(sbyte x) => (uint)x;
            public static IntPtr SByteToIntPtr(sbyte x) => (IntPtr)x;
            public static UIntPtr SByteToUIntPtr(sbyte x) => (UIntPtr)x;
            public static long SByteToInt64(sbyte x) => x;
            public static ulong SByteToUInt64(sbyte x) => (ulong)x;
            public static short SByteToInt16(sbyte x) => x;
            public static ushort SByteToUInt16(sbyte x) => (ushort)x;

            public static byte CharToByte(char x) => (byte)x;
            public static sbyte CharToSByte(char x) => (sbyte)x;
            public static decimal CharToDecimal(char x) => x;
            public static double CharToDouble(char x) => x;
            public static float CharToSingle(char x) => x;
            public static int CharToInt32(char x) => x;
            public static uint CharToUInt32(char x) => x;
            public static IntPtr CharToIntPtr(char x) => (IntPtr)x;
            public static UIntPtr CharToUIntPtr(char x) => (UIntPtr)x;
            public static long CharToInt64(char x) => x;
            public static ulong CharToUInt64(char x) => x;
            public static short CharToInt16(char x) => (short)x;
            public static ushort CharToUInt16(char x) => x;

            public static byte Int16ToByte(short x) => (byte)x;
            public static sbyte Int16ToSByte(short x) => (sbyte)x;
            public static char Int16ToChar(short x) => (char)x;
            public static decimal Int16ToDecimal(short x) => x;
            public static double Int16ToDouble(short x) => x;
            public static float Int16ToSingle(short x) => x;
            public static int Int16ToInt32(short x) => x;
            public static uint Int16ToUInt32(short x) => (uint)x;
            public static IntPtr Int16ToIntPtr(short x) => (IntPtr)x;
            public static UIntPtr Int16ToUIntPtr(short x) => (UIntPtr)x;
            public static long Int16ToInt64(short x) => x;
            public static ulong Int16ToUInt64(short x) => (ulong)x;
            public static ushort Int16ToUInt16(short x) => (ushort)x;

            public static byte UInt16ToByte(ushort x) => (byte)x;
            public static sbyte UInt16ToSByte(ushort x) => (sbyte)x;
            public static char UInt16ToChar(ushort x) => (char)x;
            public static decimal UInt16ToDecimal(ushort x) => x;
            public static double UInt16ToDouble(ushort x) => x;
            public static float UInt16ToSingle(ushort x) => x;
            public static int UInt16ToInt32(ushort x) => x;
            public static uint UInt16ToUInt32(ushort x) => x;
            public static IntPtr UInt16ToIntPtr(ushort x) => (IntPtr)x;
            public static UIntPtr UInt16ToUIntPtr(ushort x) => (UIntPtr)x;
            public static long UInt16ToInt64(ushort x) => x;
            public static ulong UInt16ToUInt64(ushort x) => x;
            public static short UInt16ToInt16(ushort x) => (short)x;

            public static byte Int32ToByte(int x) => (byte)x;
            public static sbyte Int32ToSByte(int x) => (sbyte)x;
            public static char Int32ToChar(int x) => (char)x;
            public static decimal Int32ToDecimal(int x) => x;
            public static double Int32ToDouble(int x) => x;
            public static float Int32ToSingle(int x) => x;
            public static uint Int32ToUInt32(int x) => (uint)x;
            public static IntPtr Int32ToIntPtr(int x) => (IntPtr)x;
            public static UIntPtr Int32ToUIntPtr(int x) => (UIntPtr)x;
            public static long Int32ToInt64(int x) => x;
            public static ulong Int32ToUInt64(int x) => (ulong)x;
            public static short Int32ToInt16(int x) => (short)x;
            public static ushort Int32ToUInt16(int x) => (ushort)x;

            public static byte UInt32ToByte(uint x) => (byte)x;
            public static sbyte UInt32ToSByte(uint x) => (sbyte)x;
            public static char UInt32ToChar(uint x) => (char)x;
            public static decimal UInt32ToDecimal(uint x) => x;
            public static double UInt32ToDouble(uint x) => x;
            public static float UInt32ToSingle(uint x) => x;
            public static int UInt32ToInt32(uint x) => (int)x;
            public static IntPtr UInt32ToIntPtr(uint x) => (IntPtr)x;
            public static UIntPtr UInt32ToUIntPtr(uint x) => (UIntPtr)x;
            public static long UInt32ToInt64(uint x) => x;
            public static ulong UInt32ToUInt64(uint x) => x;
            public static short UInt32ToInt16(uint x) => (short)x;
            public static ushort UInt32ToUInt16(uint x) => (ushort)x;

            public static byte Int64ToByte(long x) => (byte)x;
            public static sbyte Int64ToSByte(long x) => (sbyte)x;
            public static char Int64ToChar(long x) => (char)x;
            public static decimal Int64ToDecimal(long x) => x;
            public static double Int64ToDouble(long x) => x;
            public static float Int64ToSingle(long x) => x;
            public static int Int64ToInt32(long x) => (int)x;
            public static uint Int64ToUInt32(long x) => (uint)x;
            public static IntPtr Int64ToIntPtr(long x) => (IntPtr)x;
            public static UIntPtr Int64ToUIntPtr(long x) => (UIntPtr)x;
            public static ulong Int64ToUInt64(long x) => (ulong)x;
            public static short Int64ToInt16(long x) => (short)x;
            public static ushort Int64ToUInt16(long x) => (ushort)x;

            public static byte UInt64ToByte(ulong x) => (byte)x;
            public static sbyte UInt64ToSByte(ulong x) => (sbyte)x;
            public static char UInt64ToChar(ulong x) => (char)x;
            public static decimal UInt64ToDecimal(ulong x) => x;
            public static double UInt64ToDouble(ulong x) => x;
            public static float UInt64ToSingle(ulong x) => x;
            public static int UInt64ToInt32(ulong x) => (int)x;
            public static uint UInt64ToUInt32(ulong x) => (uint)x;
            public static IntPtr UInt64ToIntPtr(ulong x) => (IntPtr)x;
            public static UIntPtr UInt64ToUIntPtr(ulong x) => (UIntPtr)x;
            public static long UInt64ToInt64(ulong x) => (long)x;
            public static short UInt64ToInt16(ulong x) => (short)x;
            public static ushort UInt64ToUInt16(ulong x) => (ushort)x;

            public static byte SingleToByte(float x) => (byte)x;
            public static sbyte SingleToSByte(float x) => (sbyte)x;
            public static char SingleToChar(float x) => (char)x;
            public static decimal SingleToDecimal(float x) => (decimal)x;
            public static double SingleToDouble(float x) => x;
            public static int SingleToInt32(float x) => (int)x;
            public static uint SingleToUInt32(float x) => (uint)x;
            public static IntPtr SingleToIntPtr(float x) => (IntPtr)x;
            public static UIntPtr SingleToUIntPtr(float x) => (UIntPtr)x;
            public static long SingleToInt64(float x) => (long)x;
            public static ulong SingleToUInt64(float x) => (ulong)x;
            public static short SingleToInt16(float x) => (short)x;
            public static ushort SingleToUInt16(float x) => (ushort)x;

            public static byte DoubleToByte(double x) => (byte)x;
            public static sbyte DoubleToSByte(double x) => (sbyte)x;
            public static char DoubleToChar(double x) => (char)x;
            public static decimal DoubleToDecimal(double x) => (decimal)x;
            public static float DoubleToSingle(double x) => (float)x;
            public static int DoubleToInt32(double x) => (int)x;
            public static uint DoubleToUInt32(double x) => (uint)x;
            public static IntPtr DoubleToIntPtr(double x) => (IntPtr)x;
            public static UIntPtr DoubleToUIntPtr(double x) => (UIntPtr)x;
            public static long DoubleToInt64(double x) => (long)x;
            public static ulong DoubleToUInt64(double x) => (ulong)x;
            public static short DoubleToInt16(double x) => (short)x;
            public static ushort DoubleToUInt16(double x) => (ushort)x;

            public static byte DecimalToByte(decimal x) => (byte)x;
            public static sbyte DecimalToSByte(decimal x) => (sbyte)x;
            public static char DecimalToChar(decimal x) => (char)x;
            public static double DecimalToDouble(decimal x) => (double)x;
            public static float DecimalToSingle(decimal x) => (float)x;
            public static int DecimalToInt32(decimal x) => (int)x;
            public static uint DecimalToUInt32(decimal x) => (uint)x;
            public static IntPtr DecimalToIntPtr(decimal x) => (IntPtr)x;
            public static UIntPtr DecimalToUIntPtr(decimal x) => (UIntPtr)x;
            public static long DecimalToInt64(decimal x) => (long)x;
            public static ulong DecimalToUInt64(decimal x) => (ulong)x;
            public static short DecimalToInt16(decimal x) => (short)x;
            public static ushort DecimalToUInt16(decimal x) => (ushort)x;

            public static byte IntPtrToByte(IntPtr x) => (byte)x;
            public static sbyte IntPtrToSByte(IntPtr x) => (sbyte)x;
            public static char IntPtrToChar(IntPtr x) => (char)x;
            public static decimal IntPtrToDecimal(IntPtr x) => (decimal)x;
            public static double IntPtrToDouble(IntPtr x) => (double)x;
            public static float IntPtrToSingle(IntPtr x) => (float)x;
            public static int IntPtrToInt32(IntPtr x) => (int)x;
            public static uint IntPtrToUInt32(IntPtr x) => (uint)x;
            public static UIntPtr IntPtrToUIntPtr(IntPtr x) => (UIntPtr)(long)x;
            public static long IntPtrToInt64(IntPtr x) => (long)x;
            public static ulong IntPtrToUInt64(IntPtr x) => (ulong)x;
            public static short IntPtrToInt16(IntPtr x) => (short)x;
            public static ushort IntPtrToUInt16(IntPtr x) => (ushort)x;

            public static byte UIntPtrToByte(UIntPtr x) => (byte)x;
            public static sbyte UIntPtrToSByte(UIntPtr x) => (sbyte)x;
            public static char UIntPtrToChar(UIntPtr x) => (char)x;
            public static decimal UIntPtrToDecimal(UIntPtr x) => (decimal)x;
            public static double UIntPtrToDouble(UIntPtr x) => (double)x;
            public static float UIntPtrToSingle(UIntPtr x) => (float)x;
            public static int UIntPtrToInt32(UIntPtr x) => (int)x;
            public static uint UIntPtrToUInt32(UIntPtr x) => (uint)x;
            public static IntPtr UIntPtrToIntPtr(UIntPtr x) => (IntPtr)(ulong)x;
            public static long UIntPtrToInt64(UIntPtr x) => (long)x;
            public static ulong UIntPtrToUInt64(UIntPtr x) => (ulong)x;
            public static short UIntPtrToInt16(UIntPtr x) => (short)x;
            public static ushort UIntPtrToUInt16(UIntPtr x) => (ushort)x;
        }
    }
}
