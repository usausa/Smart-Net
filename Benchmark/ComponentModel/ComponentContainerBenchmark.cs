namespace Benchmark.ComponentModel;

using BenchmarkDotNet.Attributes;

using Smart.ComponentModel;

[Config(typeof(BenchmarkConfig))]
public class ComponentContainerBenchmark
{
    private static readonly Type SingleType = typeof(SingleObject);

    private static readonly Type EnumerableServiceType = typeof(IEnumerable<IService>);

    private ComponentContainer container = default!;

    [GlobalSetup]
    public void Setup()
    {
        var config = new ComponentConfig();
        config.Add<SingleObject>();
        config.Add<IService, ServiceA>();
        config.Add<IService, ServiceB>();
        container = config.ToContainer();

        container.Get<SingleObject>();
        Consume(container.GetAll<IService>());
        container.GetService(EnumerableServiceType);
    }

    [GlobalCleanup]
    public void Cleanup() => container.Dispose();

    private static int Consume<T>(IEnumerable<T> source)
    {
        var count = 0;
        using var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            count++;
        }

        return count;
    }

    [Benchmark]
    public SingleObject Get() => container.Get<SingleObject>();

    [Benchmark]
    public bool TryGetMiss() => container.TryGet<UnregisteredObject>(out _);

    [Benchmark]
    public int GetAll() => Consume(container.GetAll<IService>());

    [Benchmark]
    public object? GetServiceSingle() => container.GetService(SingleType);

    [Benchmark]
    public object? GetServiceEnumerable() => container.GetService(EnumerableServiceType);

#pragma warning disable CA1040
    public interface IService
    {
    }
#pragma warning restore CA1040

    public sealed class ServiceA : IService
    {
    }

    public sealed class ServiceB : IService
    {
    }

    public sealed class SingleObject
    {
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class UnregisteredObject
    {
    }
}
