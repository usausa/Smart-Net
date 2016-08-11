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
        public void TestFlagsToFlags()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<FlagsEnum2Type>(FlagsEnum1Type.Value1 | FlagsEnum1Type.Value2), FlagsEnum2Type.Value1 | FlagsEnum2Type.Value2);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", Justification = "Ignore")]
        [TestMethod]
        public void TestFlagsToFlagsSourceUndefined()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<FlagsEnum2Type>(FlagsEnum1Type.Value1 | (FlagsEnum1Type)0x08), FlagsEnum2Type.Value1 | FlagsEnum2Type.Value8);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", Justification = "Ignore")]
        [TestMethod]
        public void TestFlagsToFlagsTargetUndefined()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<FlagsEnum2Type>(FlagsEnum1Type.Value1 | FlagsEnum1Type.Value4), FlagsEnum2Type.Value1 | (FlagsEnum2Type)0x04);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void TestEnumToEnum()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum2Type>(Enum1Type.One), Enum2Type.One);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void TestEnumToEnumSourceUndefined()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum2Type>((Enum1Type)(-1)), Enum2Type.Minus);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void TestEnumToEnumTargetUndefined()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum2Type>(Enum1Type.Two), (Enum2Type)2);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void TestStringToEnum()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum1Type>("One"), Enum1Type.One);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void TestAssignableToEnum()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<Enum1Type>(1), Enum1Type.One);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectConverterException))]
        public void TestUnassignableToEnum()
        {
            ObjectConverter.Default.Convert<Enum1Type>(new StructType { Value1 = 1, Value2 = 2 });
        }

        [TestMethod]
        public void TestEnumToAssignable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(Enum1Type.One), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        public void TestEnumToAssignableNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int?>(Enum1Type.One), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(EnumConverterFactory));
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectConverterException))]
        public void TestEnumToUnassignable()
        {
            ObjectConverter.Default.Convert<StructType>(Enum1Type.One);
        }
    }
}
