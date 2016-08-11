namespace Smart.Converter.Converters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Smart.Converter.Types;

    /// <summary>
    ///
    /// </summary>
    [TestClass]
    public class ConversionOperatorConverterFactoryTest : AbstractMatchingTest
    {
        [TestMethod]
        public void TestImplicitToInt()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(new ImplicitType { Value = 1 }), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void TestImplicitToIntNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int?>(new ImplicitType { Value = 1 }), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void TestIntToImplicit()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<ImplicitType>(1).Value, 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void TestIntToImplicitNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<ImplicitType?>(1)?.Value, 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void TestExplicitToInt()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(new ExplicitType { Value = 1 }), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void TestExplicitToIntNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int?>(new ExplicitType { Value = 1 }), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void TestIntToExplicit()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<ExplicitType>(1).Value, 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void TestIntToExplicitNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<ExplicitType?>(1)?.Value, 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }
    }
}
