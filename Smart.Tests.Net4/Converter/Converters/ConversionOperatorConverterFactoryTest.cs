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
        public void ConvertImplicitToInt()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(new ImplicitType { Value = 1 }), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void ConvertImplicitToIntNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int?>(new ImplicitType { Value = 1 }), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void ConvertIntToImplicit()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<ImplicitType>(1).Value, 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void ConvertIntToImplicitNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<ImplicitType?>(1)?.Value, 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void ConvertExplicitToInt()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(new ExplicitType { Value = 1 }), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void ConvertExplicitToIntNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int?>(new ExplicitType { Value = 1 }), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void ConvertIntToExplicit()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<ExplicitType>(1).Value, 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }

        [TestMethod]
        public void ConvertIntToExplicitNullable()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<ExplicitType?>(1)?.Value, 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConversionOperatorConverterFactory));
        }
    }
}
