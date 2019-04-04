namespace Smart.Collections.Concurrent
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Xunit;

    /// <summary>
    ///
    /// </summary>
    public class ThreadsafeHashArrayMapTest
    {
        private static string Factory(int value)
        {
            return value.ToString();
        }

        [Fact]
        public void TestBasic()
        {
            var map = new ThreadsafeHashArrayMap<int, string>();

            // Initial
            Assert.Equal(0, map.Count);
            Assert.False(map.TryGetValue(1, out string _));
            Assert.False(map.ContainsKey(1));
            Assert.Null(map.GetValueOrDefault(1));

            // Add
            Assert.Equal("1", map.AddIfNotExist(1, "1"));

            Assert.Equal(1, map.Count);
            Assert.True(map.TryGetValue(1, out string _));
            Assert.True(map.ContainsKey(1));
            Assert.Equal("1", map.GetValueOrDefault(1));

            // Add failed
            Assert.Equal("1", map.AddIfNotExist(1, "1b"));

            Assert.Equal(1, map.Count);

            // Clear
            map.Clear();

            Assert.Equal(0, map.Count);
            Assert.False(map.TryGetValue(1, out string _));
        }

        [Fact]
        public void TestGrowth()
        {
            var map = new ThreadsafeHashArrayMap<int, string>(1);
            for (var i = 0; i < 20; i++)
            {
                map.AddIfNotExist(i, Factory);

                Assert.Equal(i + 1, map.Count);
                Assert.Equal(1, map.Depth);
            }
        }

        [Fact]
        public void TestRange()
        {
            var map = new ThreadsafeHashArrayMap<int, string>(1);

            // AddRange1
            map.AddRangeIfNotExist(Enumerable.Range(1, 10), Factory);

            Assert.Equal(10, map.Count);

            // AddRange2
            map.AddRangeIfNotExist(Enumerable.Range(6, 10).Select(x => new KeyValuePair<int, string>(x, x.ToString())));

            Assert.Equal(15, map.Count);

            // IEnumerable
            var dic = map.ToDictionary(x => x.Key, x => x.Value);
            foreach (var i in Enumerable.Range(1, 15))
            {
                Assert.True(dic.ContainsKey(i));
            }
        }

        [Fact]
        public void TestThread()
        {
            var map = new ThreadsafeHashArrayMap<int, string>(1);

            using (var evThreadStarted = new CountdownEvent(2))
            using (var evThread1Completed = new CountdownEvent(1))
            {
                // ReSharper disable AccessToDisposedClosure
                var t1 = new Thread(() =>
                {
                    Assert.False(map.ContainsKey(1));

                    evThreadStarted.Signal();

                    var ret = map.AddIfNotExist(1, key => "t1");

                    evThread1Completed.Signal();

                    Assert.Equal("t1", ret);
                }) { IsBackground = true };

                var t2 = new Thread(() =>
                {
                    evThreadStarted.Signal();
                    evThread1Completed.Wait();

                    Assert.True(map.ContainsKey(1));

                    var ret = map.AddIfNotExist(1, key => "t2");

                    Assert.Equal("t1", ret);
                })
                { IsBackground = true };

                t1.Start();
                t2.Start();

                evThreadStarted.Wait();

                t1.Join();
                t2.Join();
                // ReSharper restore AccessToDisposedClosure
            }
        }
    }
}
