﻿namespace Smart.Converter.Converters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Smart.Converter.Types;

    /// <summary>
    ///
    /// </summary>
    [TestClass]
    public class AssignableConverterFactoryTest : AbstractMatchingTest
    {
        [TestMethod]
        public void TestAssignable()
        {
            var source = new DeliverdType();
            Assert.AreEqual(ObjectConverter.Default.Convert<BaseType>(source), source);
            Assert.AreEqual(FindMatchngFactory()?.GetType(), typeof(AssignableConverterFactory));
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectConverterException))]
        public void TestNotAssignable()
        {
            var source = new BaseType();
            Assert.AreEqual(ObjectConverter.Default.Convert<DeliverdType>(source), source);
        }
    }
}