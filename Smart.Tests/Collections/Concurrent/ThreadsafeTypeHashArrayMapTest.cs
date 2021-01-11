namespace Smart.Collections.Concurrent
{
    using System;
    using System.Threading;

    using Xunit;

    public class ThreadsafeTypeHashArrayMapTest
    {
        private static string Factory(Type type)
        {
            return type.Name;
        }

        [Fact]
        public void TestBasic()
        {
            var map = new ThreadsafeTypeHashArrayMap<string>();

            // Initial
            Assert.Equal(0, map.Diagnostics.Count);
            Assert.False(map.TryGetValue(Class01.Type, out var _));
            Assert.False(map.ContainsKey(Class01.Type));
            Assert.Null(map.GetValueOrDefault(Class01.Type));

            // Add
            Assert.Equal("1", map.AddIfNotExist(Class01.Type, "1"));

            Assert.Equal(1, map.Diagnostics.Count);
            Assert.True(map.TryGetValue(Class01.Type, out var _));
            Assert.True(map.ContainsKey(Class01.Type));
            Assert.Equal("1", map.GetValueOrDefault(Class01.Type));

            // Add failed
            Assert.Equal("1", map.AddIfNotExist(Class01.Type, "1b"));

            Assert.Equal(1, map.Diagnostics.Count);

            // Clear
            map.Clear();

            Assert.Equal(0, map.Diagnostics.Count);
            Assert.False(map.TryGetValue(Class01.Type, out var _));
        }

        [Fact]
        public void TestGrowth()
        {
            var map = new ThreadsafeTypeHashArrayMap<string>(1);

            map.AddIfNotExist(Class01.Type, Factory);
            Assert.Equal(1, map.Diagnostics.Count);
            map.AddIfNotExist(Class02.Type, Factory);
            Assert.Equal(2, map.Diagnostics.Count);
            map.AddIfNotExist(Class03.Type, Factory);
            Assert.Equal(3, map.Diagnostics.Count);
            map.AddIfNotExist(Class04.Type, Factory);
            Assert.Equal(4, map.Diagnostics.Count);
            map.AddIfNotExist(Class05.Type, Factory);
            Assert.Equal(5, map.Diagnostics.Count);
            map.AddIfNotExist(Class06.Type, Factory);
            Assert.Equal(6, map.Diagnostics.Count);
            map.AddIfNotExist(Class07.Type, Factory);
            Assert.Equal(7, map.Diagnostics.Count);
            map.AddIfNotExist(Class08.Type, Factory);
            Assert.Equal(8, map.Diagnostics.Count);
            map.AddIfNotExist(Class09.Type, Factory);
            Assert.Equal(9, map.Diagnostics.Count);
            map.AddIfNotExist(Class10.Type, Factory);
            Assert.Equal(10, map.Diagnostics.Count);
        }

        [Fact]
        public void TestThread()
        {
            var map = new ThreadsafeTypeHashArrayMap<string>(1);

            using var evThreadStarted = new CountdownEvent(2);
            using var evThread1Completed = new CountdownEvent(1);

            // ReSharper disable AccessToDisposedClosure
            var t1 = new Thread(() =>
            {
                Assert.False(map.ContainsKey(Class01.Type));

                evThreadStarted.Signal();

                var ret = map.AddIfNotExist(Class01.Type, _ => "t1");

                evThread1Completed.Signal();

                Assert.Equal("t1", ret);
            })
            {
                IsBackground = true
            };

            var t2 = new Thread(() =>
            {
                evThreadStarted.Signal();
                evThread1Completed.Wait();

                Assert.True(map.ContainsKey(Class01.Type));

                var ret = map.AddIfNotExist(Class01.Type, _ => "t2");

                Assert.Equal("t1", ret);
            })
            {
                IsBackground = true
            };

            t1.Start();
            t2.Start();

            evThreadStarted.Wait();

            t1.Join();
            t2.Join();
            // ReSharper restore AccessToDisposedClosure
        }
    }
}
