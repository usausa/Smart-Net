namespace Smart.Converter.Converters
{
    using Smart.Converter.Types;

    using Xunit;

    public class EnumConverterFactoryTest
    {
        //--------------------------------------------------------------------------------
        // EnumToEnum
        //--------------------------------------------------------------------------------

        [Fact]
        public void EnumToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum2Type.Zero, converter.Convert(Enum1Type.Zero, typeof(Enum2Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void UndefinedEnumToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum2Type.Minus, converter.Convert((Enum1Type)(-1), typeof(Enum2Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToUndefinedEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((Enum2Type)2, converter.Convert(Enum1Type.Two, typeof(Enum2Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void FlagsEnumToFlagsEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(FlagsEnum2Type.Value1 | FlagsEnum2Type.Value2, converter.Convert(FlagsEnum1Type.Value1 | FlagsEnum1Type.Value2, typeof(FlagsEnum2Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void UndefinedFlagsEnumToFlagsEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(FlagsEnum2Type.Value1 | FlagsEnum2Type.Value8, converter.Convert(FlagsEnum1Type.Value1 | (FlagsEnum1Type)0x08, typeof(FlagsEnum2Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void FlagsEnumToUndefinedFlagsEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(FlagsEnum2Type.Value1 | (FlagsEnum2Type)0x04, converter.Convert(FlagsEnum1Type.Value1 | FlagsEnum1Type.Value4, typeof(FlagsEnum2Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        //--------------------------------------------------------------------------------
        // NotEnumToEnum
        //--------------------------------------------------------------------------------

        [Fact]
        public void ByteToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((byte)0, typeof(Enum1Type)));
            Assert.Equal(Enum1Type.One, converter.Convert((byte)1, typeof(Enum1Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void ByteToNullableEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((byte)0, typeof(Enum1Type?)));
            Assert.Equal(Enum1Type.One, converter.Convert((byte)1, typeof(Enum1Type?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void SByteToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((sbyte)0, typeof(Enum1Type)));
            Assert.Equal(Enum1Type.One, converter.Convert((sbyte)1, typeof(Enum1Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void SByteToNullableEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((sbyte)0, typeof(Enum1Type?)));
            Assert.Equal(Enum1Type.One, converter.Convert((sbyte)1, typeof(Enum1Type?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void ShortToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((short)0, typeof(Enum1Type)));
            Assert.Equal(Enum1Type.One, converter.Convert((short)1, typeof(Enum1Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void ShortToNullableEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((short)0, typeof(Enum1Type?)));
            Assert.Equal(Enum1Type.One, converter.Convert((short)1, typeof(Enum1Type?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void UShortToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((ushort)0, typeof(Enum1Type)));
            Assert.Equal(Enum1Type.One, converter.Convert((ushort)1, typeof(Enum1Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void UShortToNullableEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((ushort)0, typeof(Enum1Type?)));
            Assert.Equal(Enum1Type.One, converter.Convert((ushort)1, typeof(Enum1Type?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void IntToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert(0, typeof(Enum1Type)));
            Assert.Equal(Enum1Type.One, converter.Convert(1, typeof(Enum1Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void IntToNullableEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert(0, typeof(Enum1Type?)));
            Assert.Equal(Enum1Type.One, converter.Convert(1, typeof(Enum1Type?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void UIntToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert(0U, typeof(Enum1Type)));
            Assert.Equal(Enum1Type.One, converter.Convert(1U, typeof(Enum1Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void UIntToNullableEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert(0U, typeof(Enum1Type?)));
            Assert.Equal(Enum1Type.One, converter.Convert(1U, typeof(Enum1Type?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void CharToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((char)0, typeof(Enum1Type)));
            Assert.Equal(Enum1Type.One, converter.Convert((char)1, typeof(Enum1Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void CharToNullableEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert((char)0, typeof(Enum1Type?)));
            Assert.Equal(Enum1Type.One, converter.Convert((char)1, typeof(Enum1Type?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void StringToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Enum1Type.Zero, converter.Convert("Zero", typeof(Enum1Type)));
            Assert.Equal(Enum1Type.One, converter.Convert("One", typeof(Enum1Type)));
            Assert.Equal(Enum1Type.Zero, converter.Convert("0", typeof(Enum1Type)));
            Assert.Equal(Enum1Type.One, converter.Convert("1", typeof(Enum1Type)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void CanNotConvertToEnum()
        {
            var converter = new TestObjectConverter();
            Assert.False(converter.CanConvert(typeof(StructType), typeof(Enum1Type)));
        }

        //--------------------------------------------------------------------------------
        // EnumToNotEnum
        //--------------------------------------------------------------------------------

        [Fact]
        public void EnumToByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Enum1Type.Zero, typeof(byte)));
            Assert.Equal((byte)1, converter.Convert(Enum1Type.One, typeof(byte)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToNullableByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((byte)0, converter.Convert(Enum1Type.Zero, typeof(byte?)));
            Assert.Equal((byte)1, converter.Convert(Enum1Type.One, typeof(byte?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Enum1Type.Zero, typeof(sbyte)));
            Assert.Equal((sbyte)1, converter.Convert(Enum1Type.One, typeof(sbyte)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToNullableSByte()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((sbyte)0, converter.Convert(Enum1Type.Zero, typeof(sbyte?)));
            Assert.Equal((sbyte)1, converter.Convert(Enum1Type.One, typeof(sbyte?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Enum1Type.Zero, typeof(short)));
            Assert.Equal((short)1, converter.Convert(Enum1Type.One, typeof(short)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToNullableShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((short)0, converter.Convert(Enum1Type.Zero, typeof(short?)));
            Assert.Equal((short)1, converter.Convert(Enum1Type.One, typeof(short?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Enum1Type.Zero, typeof(ushort)));
            Assert.Equal((ushort)1, converter.Convert(Enum1Type.One, typeof(ushort)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToNullableUShort()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((ushort)0, converter.Convert(Enum1Type.Zero, typeof(ushort?)));
            Assert.Equal((ushort)1, converter.Convert(Enum1Type.One, typeof(ushort?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(Enum1Type.Zero, typeof(int)));
            Assert.Equal(1, converter.Convert(Enum1Type.One, typeof(int)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToNullableInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0, converter.Convert(Enum1Type.Zero, typeof(int?)));
            Assert.Equal(1, converter.Convert(Enum1Type.One, typeof(int?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(Enum1Type.Zero, typeof(long)));
            Assert.Equal(1L, converter.Convert(Enum1Type.One, typeof(long)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToNullableLong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0L, converter.Convert(Enum1Type.Zero, typeof(long?)));
            Assert.Equal(1L, converter.Convert(Enum1Type.One, typeof(long?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(Enum1Type.Zero, typeof(ulong)));
            Assert.Equal(1UL, converter.Convert(Enum1Type.One, typeof(ulong)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToNullableULong()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(0UL, converter.Convert(Enum1Type.Zero, typeof(ulong?)));
            Assert.Equal(1UL, converter.Convert(Enum1Type.One, typeof(ulong?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Enum1Type.Zero, typeof(char)));
            Assert.Equal((char)1, converter.Convert(Enum1Type.One, typeof(char)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToNullableChar()
        {
            var converter = new TestObjectConverter();
            Assert.Equal((char)0, converter.Convert(Enum1Type.Zero, typeof(char?)));
            Assert.Equal((char)1, converter.Convert(Enum1Type.One, typeof(char?)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void EnumToiString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("Zero", converter.Convert(Enum1Type.Zero, typeof(string)));
            Assert.Equal("One", converter.Convert(Enum1Type.One, typeof(string)));
            Assert.True(converter.UsedOnly<EnumConverterFactory>());
        }

        [Fact]
        public void CanNotConvertFromEnum()
        {
            var converter = new TestObjectConverter();
            Assert.False(converter.CanConvert(typeof(Enum1Type), typeof(StructType)));
        }
    }
}
