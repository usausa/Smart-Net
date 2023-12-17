namespace Benchmark.Collections.Concurrent;

using System.Collections.Concurrent;

using BenchmarkDotNet.Attributes;

using Smart.Collections.Concurrent;

[Config(typeof(BenchmarkConfig))]
public sealed class DictionaryBenchmark
{
    private readonly Dictionary<Type, object?> dictionary = [];

    private readonly ConcurrentDictionary<Type, object?> concurrentDictionary = new();

    private readonly ThreadsafeTypeHashArrayMap<object?> hashArrayMap = new();

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
    public object? Dictionary()
    {
        lock (dictionary)
        {
            return dictionary.GetValueOrDefault(key);
        }
    }

    [Benchmark]
    public object? ConcurrentDictionary()
    {
        return concurrentDictionary.GetValueOrDefault(key);
    }

    [Benchmark]
    public object? ThreadsafeTypeHashArrayMap()
    {
        return hashArrayMap.TryGetValue(key, out var obj) ? obj : null;
    }
}
