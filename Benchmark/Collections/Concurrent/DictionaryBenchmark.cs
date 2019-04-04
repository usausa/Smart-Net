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

        private readonly Dictionary<CompositeKey, object> compositeDictionary = new Dictionary<CompositeKey, object>();

        private readonly ConcurrentDictionary<CompositeKey, object> compositeConcurrentDictionary = new ConcurrentDictionary<CompositeKey, object>();

        private readonly ThreadsafeHashArrayMap<CompositeKey, object> compositeHashArrayMap = new ThreadsafeHashArrayMap<CompositeKey, object>();

        private readonly Type key = typeof(Class0);

        private readonly CompositeKey compositeKey = new CompositeKey(typeof(Class0), string.Empty);

        [GlobalSetup]
        public void Setup()
        {
            foreach (var type in Classes.Types)
            {
                dictionary[type] = type;
                concurrentDictionary[type] = type;
                hashArrayMap.AddIfNotExist(type, type);

                var ck = new CompositeKey(type, string.Empty);
                compositeDictionary[ck] = type;
                compositeConcurrentDictionary[ck] = type;
                compositeHashArrayMap.AddIfNotExist(ck, type);
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

        [Benchmark]
        public object CompositeDictionary()
        {
            lock (compositeDictionary)
            {
                return compositeDictionary.TryGetValue(compositeKey, out var obj) ? obj : null;
            }
        }

        [Benchmark]
        public object CompositeConcurrentDictionary()
        {
            return compositeConcurrentDictionary.TryGetValue(compositeKey, out var obj) ? obj : null;
        }

        [Benchmark]
        public object CompositeThreadsafeTypeHashArrayMap()
        {
            return compositeHashArrayMap.TryGetValue(compositeKey, out var obj) ? obj : null;
        }
    }
}
