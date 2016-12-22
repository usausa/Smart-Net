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
        public void ConvertStringToIntFailed()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(string.Empty), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectConverterException))]
        public void ConvertStringToIntNullableFailed()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int?>(string.Empty), 0);
        }

        [TestMethod]
        public void ConvertStringToBoolFalse()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<bool>("false"), false);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [TestMethod]
        public void ConvertStringToBoolTrue()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<bool>("true"), true);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [TestMethod]
        public void ConvertStringToByte()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<byte>("1"), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [TestMethod]
        public void ConvertStringToChar()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<char>("1"), '1');
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [TestMethod]
        public void ConvertStringToInt()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>("1"), 1);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }
    }
}
