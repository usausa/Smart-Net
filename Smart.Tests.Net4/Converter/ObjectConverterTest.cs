namespace Smart.Converter
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Smart.Converter.Converters;
    using Smart.Converter.Types;

    /// <summary>
    ///
    /// </summary>
    [TestClass]
    public class ObjectConverterTest : AbstractMatchingTest
    {
        [TestMethod]
        public void TestMatchNullToDefault()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(null), 0);
            Assert.AreEqual(FindMatchngFactory(), null);
        }

        [TestMethod]
        public void TestMatchSame()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<int>(0), 0);
            Assert.AreEqual(FindMatchngFactory(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectConverterException))]
        public void TestUnmatch()
        {
            ObjectConverter.Default.Convert<StructType>(string.Empty);
        }
    }
}
