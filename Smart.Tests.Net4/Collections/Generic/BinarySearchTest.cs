namespace Smart.Collections.Generic
{
    using System.Collections.Generic;

    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// BinarySearchTest の概要の説明
    /// </summary>
    [TestClass]
    public class BinarySearchTest
    {
        private static void AssertIndex(List<int> expects, List<int> actuals)
        {
            for (var i = 0; i < expects.Count; i++)
            {
                if (expects[i] >= 0)
                {
                    Assert.AreEqual(expects[i], actuals[i]);
                }
                else
                {
                    Assert.IsTrue(actuals[i] < 0);
                }
            }
        }

        [TestMethod]
        public void TestFindFirst()
        {
            var array = new[] { 1, 1, 3, 3, 3, 5, 5, 5, 5 };    // 9個
            var list = array.ToList();
            var keys = Enumerable.Range(0, 7);                  // 0-6

            var expects = new List<int>();
            var actuals = new List<int>();

            foreach (var i in keys)
            {
                var key = i;
                expects.Add(list.IndexOf(key));
                actuals.Add(BinarySearch.FindFirst(array, x => x - key));
            }

            AssertIndex(expects, actuals);
        }

        [TestMethod]
        public void TestFindLast()
        {
            var array = new[] { 1, 1, 3, 3, 3, 5, 5, 5, 5 };    // 9個
            var list = array.ToList();
            var keys = Enumerable.Range(0, 7);                  // 0-6

            var expects = new List<int>();
            var actuals = new List<int>();

            foreach (var i in keys)
            {
                var key = i;
                expects.Add(list.LastIndexOf(key));
                actuals.Add(BinarySearch.FindLast(array, x => x - key));
            }

            AssertIndex(expects, actuals);
        }

        [TestMethod]
        public void TestFindInsertIndex()
        {
            var array = new[] { 1, 1, 3, 3, 3, 5, 5, 5, 5 };    // 9個

            Assert.AreEqual(-1, BinarySearch.Find(array, x => x - 0));
            Assert.AreEqual(-3, BinarySearch.Find(array, x => x - 2));
            Assert.AreEqual(-6, BinarySearch.Find(array, x => x - 4));
            Assert.AreEqual(-10, BinarySearch.Find(array, x => x - 6));
        }
    }
}
