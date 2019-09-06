namespace Benchmark.Collections.Concurrent
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using BenchmarkDotNet.Attributes;

    using Smart.Collections.Concurrent;

    [Config(typeof(BenchmarkConfig))]
    public class DictionaryBenchmark
    {
        private readonly Dictionary<Type, object> dictionary = new Dictionary<Type, object>();

        private readonly ConcurrentDictionary<Type, object> concurrentDictionary = new ConcurrentDictionary<Type, object>();

        private readonly ThreadsafeTypeHashArrayMap<object> hashArrayMap = new ThreadsafeTypeHashArrayMap<object>();

        private readonly Type key = typeof(Class0);

        [GlobalSetup]
        public void Setup()
        {
            foreach (var type in Classes.Types)
            {
                dictionary[type] = type;
                concurrentDictionary[type] = type;
                hashArrayMap.AddIfNotExist(type, type);
            }
        }

        [Benchmark]
        public object Dictionary()
        {
            lock (dictionary)
            {
                return dictionary.TryGetValue(key, out var obj) ? obj : null;
            }
        }

        [Benchmark]
        public object ConcurrentDictionary()
        {
            return concurrentDictionary.TryGetValue(key, out var obj) ? obj : null;
        }

        [Benchmark]
        public object ThreadsafeTypeHashArrayMap()
        {
            return hashArrayMap.TryGetValue(key, out var obj) ? obj : null;
        }
    }
}
