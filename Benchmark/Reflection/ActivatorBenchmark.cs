namespace Benchmark.Reflection;

using BenchmarkDotNet.Attributes;

using Smart.Reflection;

[Config(typeof(BenchmarkConfig))]
public class ActivatorBenchmark
{
    private static readonly object[] Parameter1 = ["x"];

    private static readonly object[] Parameter8 = ["x", "x", "x", "x", "x", "x", "x", "x"];

    private Func<object?[]?, object>? newFactory0;
    private Func<object?[]?, object>? dynamicFactory0A;
    private Func<object?[]?, object>? reflectionFactory0A;
    private Func<object>? dynamicFactory0B;
    private Func<object>? reflectionFactory0B;

    private Func<object?[]?, object>? newFactory1;
    private Func<object?[]?, object>? dynamicFactory1A;
    private Func<object?[]?, object>? reflectionFactory1A;
    private Func<object?, object>? dynamicFactory1B;
    private Func<object?, object>? reflectionFactory1B;

    private Func<object?[]?, object>? newFactory8;
    private Func<object?[]?, object>? dynamicFactory8A;
    private Func<object?[]?, object>? reflectionFactory8A;
    private Func<object?, object?, object?, object?, object?, object?, object?, object?, object>? dynamicFactory8B;
    private Func<object?, object?, object?, object?, object?, object?, object?, object?, object>? reflectionFactory8B;

    [GlobalSetup]
    public void Setup()
    {
        var ctor0 = typeof(Data0).GetConstructors().First();
        var ctor1 = typeof(Data1).GetConstructors().First();
        var ctor8 = typeof(Data8).GetConstructors().First();

        newFactory0 = static _ => new Data0();
        dynamicFactory0A = DynamicDelegateFactory.Default.CreateFactory(ctor0);
        reflectionFactory0A = ReflectionDelegateFactory.Default.CreateFactory(ctor0);
        dynamicFactory0B = DynamicDelegateFactory.Default.CreateFactory0(ctor0);
        reflectionFactory0B = ReflectionDelegateFactory.Default.CreateFactory0(ctor0);

        newFactory1 = static args => new Data1((string?)args![0]);
        dynamicFactory1A = DynamicDelegateFactory.Default.CreateFactory(ctor1);
        reflectionFactory1A = ReflectionDelegateFactory.Default.CreateFactory(ctor1);
        dynamicFactory1B = DynamicDelegateFactory.Default.CreateFactory1(ctor1);
        reflectionFactory1B = ReflectionDelegateFactory.Default.CreateFactory1(ctor1);

        newFactory8 = static args => new Data8((string?)args![0], (string?)args[1], (string?)args[2], (string?)args[3], (string?)args[4], (string?)args[5], (string?)args[6], (string?)args[7]);
        dynamicFactory8A = DynamicDelegateFactory.Default.CreateFactory(ctor8);
        reflectionFactory8A = ReflectionDelegateFactory.Default.CreateFactory(ctor8);
        dynamicFactory8B = DynamicDelegateFactory.Default.CreateFactory8(ctor8);
        reflectionFactory8B = ReflectionDelegateFactory.Default.CreateFactory8(ctor8);
    }

    // 0

    [Benchmark]
    public object New() => newFactory0!(null);

    [Benchmark]
    public object Dynamic0A() => dynamicFactory0A!(null);

    [Benchmark]
    public object Dynamic0B() => dynamicFactory0B!();

    [Benchmark]
    public object Reflection0A() => reflectionFactory0A!(null);

    [Benchmark]
    public object Reflection0B() => reflectionFactory0B!();

    // 1

    [Benchmark]
    public object New1() => newFactory1!(Parameter1);

    [Benchmark]
    public object Dynamic1A() => dynamicFactory1A!(Parameter1);

    [Benchmark]
    public object Dynamic1B() => dynamicFactory1B!("x");

    [Benchmark]
    public object Reflection1A() => reflectionFactory1A!(Parameter1);

    [Benchmark]
    public object Reflection1B() => reflectionFactory1B!("x");

    // 8

    [Benchmark]
    public object New8() => newFactory8!(Parameter8);

    [Benchmark]
    public object Dynamic8A() => dynamicFactory8A!(Parameter8);

    [Benchmark]
    public object Dynamic8B() => dynamicFactory8B!("x", "x", "x", "x", "x", "x", "x", "x");

    [Benchmark]
    public object Reflection8A() => reflectionFactory8A!(Parameter8);

    [Benchmark]
    public object Reflection8B() => reflectionFactory8B!("x", "x", "x", "x", "x", "x", "x", "x");

    // Data

    public sealed class Data0
    {
    }

    public sealed class Data1
    {
        public string? P1 { get; }

        public Data1(string? p1)
        {
            P1 = p1;
        }
    }

    public sealed class Data8
    {
        public string? P1 { get; }
        public string? P2 { get; }
        public string? P3 { get; }
        public string? P4 { get; }
        public string? P5 { get; }
        public string? P6 { get; }
        public string? P7 { get; }
        public string? P8 { get; }

        public Data8(string? p1, string? p2, string? p3, string? p4, string? p5, string? p6, string? p7, string? p8)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
            P5 = p5;
            P6 = p6;
            P7 = p7;
            P8 = p8;
        }
    }
}
