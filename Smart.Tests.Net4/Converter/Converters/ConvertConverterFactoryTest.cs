namespace Smart.Converter.Converters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///
    /// </summary>
    [TestClass]
    public class ConvertConverterFactoryTest : AbstractMatchingTest
    {
        [TestMethod]
        [ExpectedException(typeof(ObjectConverterException))]
        public void TestStringToIntFailed()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(string.Empty), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectConverterException))]
        public void TestStringToIntNullableFailed()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int?>(string.Empty), 0);
        }

        [TestMethod]
        public void TestStringToBoolFalse()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<bool>("false"), false);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [TestMethod]
        public void TestStringToBoolTrue()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<bool>("true"), true);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [TestMethod]
        public void TestStringToByte()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<byte>("1"), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [TestMethod]
        public void TestStringToChar()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<char>("1"), '1');
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [TestMethod]
        public void TestStringToInt()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>("1"), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }
    }
}
