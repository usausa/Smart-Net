namespace Smart.Converter.Converters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Smart.Converter.Types;

    /// <summary>
    ///
    /// </summary>
    [TestClass]
    public class ToStringConverterFactoryTest : AbstractMatchingTest
    {
        [TestMethod]
        public void TestToString()
        {
            Assert.AreEqual(ObjectConverter.Default.Convert<string>(new StructType { Value1 = 1, Value2 = 2 }), "(1, 2)");
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(ToStringConverterFactory));
        }
    }
}
