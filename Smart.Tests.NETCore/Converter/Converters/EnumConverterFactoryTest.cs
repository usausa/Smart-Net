namespace Smart.Converter.Converters
{
    using Smart.Converter.Types;

    using Xunit;

    /// <summary>
    ///
    /// </summary>
    public class EnumConverterFactoryTest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", Justification = "Ignore")]
        [Fact]
        public void ConvertFlagsToFlags()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<FlagsEnum2Type>(FlagsEnum1Type.Value1 | FlagsEnum1Type.Value2), FlagsEnum2Type.Value1 | FlagsEnum2Type.Value2);
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", Justification = "Ignore")]
        [Fact]
        public void ConvertFlagsToFlagsSourceUndefined()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<FlagsEnum2Type>(FlagsEnum1Type.Value1 | (FlagsEnum1Type)0x08), FlagsEnum2Type.Value1 | FlagsEnum2Type.Value8);
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", Justification = "Ignore")]
        [Fact]
        public void ConvertFlagsToFlagsTargetUndefined()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<FlagsEnum2Type>(FlagsEnum1Type.Value1 | FlagsEnum1Type.Value4), FlagsEnum2Type.Value1 | (FlagsEnum2Type)0x04);
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertEnumToEnum()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(Enum2Type.One, converter.Convert<Enum2Type>(Enum1Type.One));
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertEnumToEnumSourceUndefined()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(Enum2Type.Minus, converter.Convert<Enum2Type>((Enum1Type)(-1)));
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertEnumToEnumTargetUndefined()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<Enum2Type>(Enum1Type.Two), (Enum2Type)2);
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertStringToEnum()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(Enum1Type.One, converter.Convert<Enum1Type>("One"));
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertAssignableToEnum()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(Enum1Type.One, converter.Convert<Enum1Type>(1));
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertUnassignableToEnum()
        {
            var converter = new MatchingObjectConverter();
            Assert.Throws<ObjectConverterException>(
                () => converter.Convert<Enum1Type>(new StructType { Value1 = 1, Value2 = 2 }));
        }

        [Fact]
        public void ConvertEnumToAssignable()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<int>(Enum1Type.One));
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertEnumToAssignableNullable()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<int?>(Enum1Type.One));
            Assert.Equal(typeof(EnumConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertEnumToUnassignable()
        {
            var converter = new MatchingObjectConverter();
            Assert.Throws<ObjectConverterException>(
                () => converter.Convert<StructType>(Enum1Type.One));
        }
    }
}
