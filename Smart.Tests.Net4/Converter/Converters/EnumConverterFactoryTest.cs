namespace Smart.Converter.Converters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Smart.Converter.Types;

    /// <summary>
    ///
    /// </summary>
    [TestClass]
    public class EnumConverterFactoryTest : AbstractMatchingTest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", Justification = "Ignore")]
        [TestMethod]
        public void ConvertFlagsToFlags()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<FlagsEnum2Type>(FlagsEnum1Type.Value1 | FlagsEnum1Type.Value2), FlagsEnum2Type.Value1 | FlagsEnum2Type.Value2);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", Justification = "Ignore")]
        [TestMethod]
        public void ConvertFlagsToFlagsSourceUndefined()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<FlagsEnum2Type>(FlagsEnum1Type.Value1 | (FlagsEnum1Type)0x08), FlagsEnum2Type.Value1 | FlagsEnum2Type.Value8);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", Justification = "Ignore")]
        [TestMethod]
        public void ConvertFlagsToFlagsTargetUndefined()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<FlagsEnum2Type>(FlagsEnum1Type.Value1 | FlagsEnum1Type.Value4), FlagsEnum2Type.Value1 | (FlagsEnum2Type)0x04);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void ConvertEnumToEnum()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum2Type>(Enum1Type.One), Enum2Type.One);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void ConvertEnumToEnumSourceUndefined()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum2Type>((Enum1Type)(-1)), Enum2Type.Minus);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void ConvertEnumToEnumTargetUndefined()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum2Type>(Enum1Type.Two), (Enum2Type)2);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void ConvertStringToEnum()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum1Type>("One"), Enum1Type.One);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void ConvertAssignableToEnum()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum1Type>(1), Enum1Type.One);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectConverterException))]
        public void ConvertUnassignableToEnum()
        {
            ObjectConverter.Default.Convert<Enum1Type>(new StructType { Value1 = 1, Value2 = 2 });
        }

        [TestMethod]
        public void ConvertEnumToAssignable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(Enum1Type.One), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void ConvertEnumToAssignableNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int?>(Enum1Type.One), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectConverterException))]
        public void ConvertEnumToUnassignable()
        {
            ObjectConverter.Default.Convert<StructType>(Enum1Type.One);
        }
    }
}
