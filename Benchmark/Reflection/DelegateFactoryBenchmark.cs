namespace Benchmark.Reflection;

using System.Reflection;

using BenchmarkDotNet.Attributes;

using Smart.ComponentModel;
using Smart.Reflection;

[Config(typeof(BenchmarkConfig))]
public class DelegateFactoryBenchmark
{
    private static readonly ConstructorInfo Ci0 = typeof(Data0).GetConstructors()[0];
    private static readonly ConstructorInfo Ci1 = typeof(Data1).GetConstructors()[0];
    private static readonly ConstructorInfo Ci2 = typeof(Data2).GetConstructors()[0];

    private static readonly PropertyInfo Pii = typeof(MemberData).GetProperty(nameof(MemberData.IntValue))!;
    private static readonly PropertyInfo Pis = typeof(MemberData).GetProperty(nameof(MemberData.StringValue))!;
    private static readonly PropertyInfo PiHi = typeof(MemberData).GetProperty(nameof(MemberData.NotificationIntValue))!;
    private static readonly PropertyInfo PiHs = typeof(MemberData).GetProperty(nameof(MemberData.NotificationStringValue))!;

    // Dynamic
    private Func<object>? factory0Dynamic;
    private Func<object?, object>? factory1Dynamic;
    private Func<object?, object?, object>? factory2Dynamic;
    private Func<object?[]?, object>? factory2BDynamic;

    private Func<Data0>? typedFactory0Dynamic;
    private Func<string?, Data1>? typedFactory1Dynamic;
    private Func<string?, int, Data2>? typedFactory2Dynamic;

    private Func<object?, object?>? getterIntDynamic;
    private Func<object?, object?>? getterStringDynamic;
    private Func<object?, object?>? getterHolderIntDynamic;
    private Func<object?, object?>? getterHolderStringDynamic;

    private Func<MemberData?, int>? typedGetterIntDynamic;
    private Func<MemberData?, string?>? typedGetterStringDynamic;
    private Func<MemberData?, int>? typedGetterHolderIntDynamic;
    private Func<MemberData?, string?>? typedGetterHolderStringDynamic;

    private Action<object?, object?>? setterIntDynamic;
    private Action<object?, object?>? setterStringDynamic;
    private Action<object?, object?>? setterHolderIntDynamic;
    private Action<object?, object?>? setterHolderStringDynamic;

    private Action<MemberData?, int>? typedSetterIntDynamic;
    private Action<MemberData?, string?>? typedSetterStringDynamic;
    private Action<MemberData?, int>? typedSetterHolderIntDynamic;
    private Action<MemberData?, string?>? typedSetterHolderStringDynamic;

    // Reflection
    private Func<object>? factory0Reflection;
    private Func<object?, object>? factory1Reflection;
    private Func<object?, object?, object>? factory2Reflection;
    private Func<object?[]?, object>? factory2BReflection;

    private Func<Data0>? typedFactory0Reflection;
    private Func<string?, Data1>? typedFactory1Reflection;
    private Func<string?, int, Data2>? typedFactory2Reflection;

    private Func<object?, object?>? getterIntReflection;
    private Func<object?, object?>? getterStringReflection;
    private Func<object?, object?>? getterHolderIntReflection;
    private Func<object?, object?>? getterHolderStringReflection;

    private Func<MemberData?, int>? typedGetterIntReflection;
    private Func<MemberData?, string?>? typedGetterStringReflection;
    private Func<MemberData?, int>? typedGetterHolderIntReflection;
    private Func<MemberData?, string?>? typedGetterHolderStringReflection;

    private Action<object?, object?>? setterIntReflection;
    private Action<object?, object?>? setterStringReflection;
    private Action<object?, object?>? setterHolderIntReflection;
    private Action<object?, object?>? setterHolderStringReflection;

    private Action<MemberData?, int>? typedSetterIntReflection;
    private Action<MemberData?, string?>? typedSetterStringReflection;
    private Action<MemberData?, int>? typedSetterHolderIntReflection;
    private Action<MemberData?, string?>? typedSetterHolderStringReflection;

    private MemberData? data;

    [GlobalSetup]
    public void Setup()
    {
        // Dynamic
        factory0Dynamic = DynamicDelegateFactory.Default.CreateFactory0(Ci0);
        factory1Dynamic = DynamicDelegateFactory.Default.CreateFactory1(Ci1);
        factory2Dynamic = DynamicDelegateFactory.Default.CreateFactory2(Ci2);
        factory2BDynamic = DynamicDelegateFactory.Default.CreateFactory(Ci2);

        typedFactory0Dynamic = DynamicDelegateFactory.Default.CreateFactory<Data0>();
        typedFactory1Dynamic = DynamicDelegateFactory.Default.CreateFactory<string, Data1>();
        typedFactory2Dynamic = DynamicDelegateFactory.Default.CreateFactory<string, int, Data2>();

        getterIntDynamic = DynamicDelegateFactory.Default.CreateGetter(Pii)!;
        getterStringDynamic = DynamicDelegateFactory.Default.CreateGetter(Pis)!;
        getterHolderIntDynamic = DynamicDelegateFactory.Default.CreateGetter(PiHi)!;
        getterHolderStringDynamic = DynamicDelegateFactory.Default.CreateGetter(PiHs)!;

        typedGetterIntDynamic = DynamicDelegateFactory.Default.CreateGetter<MemberData, int>(Pii);
        typedGetterStringDynamic = DynamicDelegateFactory.Default.CreateGetter<MemberData, string>(Pis);
        typedGetterHolderIntDynamic = DynamicDelegateFactory.Default.CreateGetter<MemberData, int>(PiHi);
        typedGetterHolderStringDynamic = DynamicDelegateFactory.Default.CreateGetter<MemberData, string>(PiHs);

        setterIntDynamic = DynamicDelegateFactory.Default.CreateSetter(Pii);
        setterStringDynamic = DynamicDelegateFactory.Default.CreateSetter(Pis);
        setterHolderIntDynamic = DynamicDelegateFactory.Default.CreateSetter(PiHi);
        setterHolderStringDynamic = DynamicDelegateFactory.Default.CreateSetter(PiHs);

        typedSetterIntDynamic = DynamicDelegateFactory.Default.CreateSetter<MemberData, int>(Pii);
        typedSetterStringDynamic = DynamicDelegateFactory.Default.CreateSetter<MemberData, string>(Pis);
        typedSetterHolderIntDynamic = DynamicDelegateFactory.Default.CreateSetter<MemberData, int>(PiHi);
        typedSetterHolderStringDynamic = DynamicDelegateFactory.Default.CreateSetter<MemberData, string>(PiHs);

        // Reflection
        factory0Reflection = ReflectionDelegateFactory.Default.CreateFactory0(Ci0);
        factory1Reflection = ReflectionDelegateFactory.Default.CreateFactory1(Ci1);
        factory2Reflection = ReflectionDelegateFactory.Default.CreateFactory2(Ci2);
        factory2BReflection = ReflectionDelegateFactory.Default.CreateFactory(Ci2);

        typedFactory0Reflection = ReflectionDelegateFactory.Default.CreateFactory<Data0>();
        typedFactory1Reflection = ReflectionDelegateFactory.Default.CreateFactory<string, Data1>();
        typedFactory2Reflection = ReflectionDelegateFactory.Default.CreateFactory<string, int, Data2>();

        getterIntReflection = ReflectionDelegateFactory.Default.CreateGetter(Pii);
        getterStringReflection = ReflectionDelegateFactory.Default.CreateGetter(Pis);
        getterHolderIntReflection = ReflectionDelegateFactory.Default.CreateGetter(PiHi);
        getterHolderStringReflection = ReflectionDelegateFactory.Default.CreateGetter(PiHs);

        typedGetterIntReflection = ReflectionDelegateFactory.Default.CreateGetter<MemberData, int>(Pii);
        typedGetterStringReflection = ReflectionDelegateFactory.Default.CreateGetter<MemberData, string>(Pis);
        typedGetterHolderIntReflection = ReflectionDelegateFactory.Default.CreateGetter<MemberData, int>(PiHi);
        typedGetterHolderStringReflection = ReflectionDelegateFactory.Default.CreateGetter<MemberData, string>(PiHs);

        setterIntReflection = ReflectionDelegateFactory.Default.CreateSetter(Pii);
        setterStringReflection = ReflectionDelegateFactory.Default.CreateSetter(Pis);
        setterHolderIntReflection = ReflectionDelegateFactory.Default.CreateSetter(PiHi);
        setterHolderStringReflection = ReflectionDelegateFactory.Default.CreateSetter(PiHs);

        typedSetterIntReflection = ReflectionDelegateFactory.Default.CreateSetter<MemberData, int>(Pii);
        typedSetterStringReflection = ReflectionDelegateFactory.Default.CreateSetter<MemberData, string>(Pis);
        typedSetterHolderIntReflection = ReflectionDelegateFactory.Default.CreateSetter<MemberData, int>(PiHi);
        typedSetterHolderStringReflection = ReflectionDelegateFactory.Default.CreateSetter<MemberData, string>(PiHs);
    }

    [IterationSetup]
    public void IterationSetup()
    {
        data = new MemberData();
    }

    // Factory

    [Benchmark]
    public object Factory0Dynamic() => factory0Dynamic!();
    [Benchmark]
    public object Factory1Dynamic() => factory1Dynamic!(string.Empty);
    [Benchmark]
    public object Factory2Dynamic() => factory2Dynamic!(string.Empty, 0);
    [Benchmark]
    public object Factory2BDynamic() => factory2BDynamic!(new object[] { string.Empty, 0 });

    // TypedFactory

    [Benchmark]
    public Data0 TypedFactory0Dynamic() => typedFactory0Dynamic!();
    [Benchmark]
    public Data1 TypedFactory1Dynamic() => typedFactory1Dynamic!(string.Empty);
    [Benchmark]
    public Data2 TypedFactory2Dynamic() => typedFactory2Dynamic!(string.Empty, 0);

    // Getter

    [Benchmark]
    public object? GetterIntDynamic() => getterIntDynamic!(data!);
    [Benchmark]
    public object? GetterStringDynamic() => getterStringDynamic!(data!);
    [Benchmark]
    public object? GetterHolderIntDynamic() => getterHolderIntDynamic!(data!);
    [Benchmark]
    public object? GetterHolderStringDynamic() => getterHolderStringDynamic!(data!);

    // TypedGetter

    [Benchmark]
    public int TypedGetterIntDynamic() => typedGetterIntDynamic!(data!);
    [Benchmark]
    public string? TypedGetterStringDynamic() => typedGetterStringDynamic!(data!);
    [Benchmark]
    public int TypedGetterHolderIntDynamic() => typedGetterHolderIntDynamic!(data!);
    [Benchmark]
    public string? TypedGetterHolderStringDynamic() => typedGetterHolderStringDynamic!(data!);

    // Setter

    [Benchmark]
    public void SetterIntDynamic() => setterIntDynamic!(data!, 0);
    [Benchmark]
    public void SetterStringDynamic() => setterStringDynamic!(data!, string.Empty);
    [Benchmark]
    public void SetterHolderIntDynamic() => setterHolderIntDynamic!(data!, 0);
    [Benchmark]
    public void SetterHolderStringDynamic() => setterHolderStringDynamic!(data!, string.Empty);

    // TypedSetter

    [Benchmark]
    public void TypedSetterIntDynamic() => typedSetterIntDynamic!(data!, 0);
    [Benchmark]
    public void TypedSetterStringDynamic() => typedSetterStringDynamic!(data!, string.Empty);
    [Benchmark]
    public void TypedSetterHolderIntDynamic() => typedSetterHolderIntDynamic!(data!, 0);
    [Benchmark]
    public void TypedSetterHolderStringDynamic() => typedSetterHolderStringDynamic!(data!, string.Empty);

    // Factory

    [Benchmark]
    public object Factory0Reflection() => factory0Reflection!();
    [Benchmark]
    public object Factory1Reflection() => factory1Reflection!(string.Empty);
    [Benchmark]
    public object Factory2Reflection() => factory2Reflection!(string.Empty, 0);
    [Benchmark]
    public object Factory2BReflection() => factory2BReflection!(new object[] { string.Empty, 0 });

    // TypedFactory

    [Benchmark]
    public Data0 TypedFactory0Reflection() => typedFactory0Reflection!();
    [Benchmark]
    public Data1 TypedFactory1Reflection() => typedFactory1Reflection!(string.Empty);
    [Benchmark]
    public Data2 TypedFactory2Reflection() => typedFactory2Reflection!(string.Empty, 0);

    // Getter

    [Benchmark]
    public object? GetterIntReflection() => getterIntReflection!(data!);
    [Benchmark]
    public object? GetterStringReflection() => getterStringReflection!(data!);
    [Benchmark]
    public object? GetterHolderIntReflection() => getterHolderIntReflection!(data!);
    [Benchmark]
    public object? GetterHolderStringReflection() => getterHolderStringReflection!(data!);

    // TypedGetter

    [Benchmark]
    public int TypedGetterIntReflection() => typedGetterIntReflection!(data!);
    [Benchmark]
    public string? TypedGetterStringReflection() => typedGetterStringReflection!(data!);
    [Benchmark]
    public int TypedGetterHolderIntReflection() => typedGetterHolderIntReflection!(data!);
    [Benchmark]
    public string? TypedGetterHolderStringReflection() => typedGetterHolderStringReflection!(data!);

    // Setter

    [Benchmark]
    public void SetterIntReflection() => setterIntReflection!(data!, 0);
    [Benchmark]
    public void SetterStringReflection() => setterStringReflection!(data!, string.Empty);
    [Benchmark]
    public void SetterHolderIntReflection() => setterHolderIntReflection!(data!, 0);
    [Benchmark]
    public void SetterHolderStringReflection() => setterHolderStringReflection!(data!, string.Empty);

    // TypedSetter

    [Benchmark]
    public void TypedSetterIntReflection() => typedSetterIntReflection!(data!, 0);
    [Benchmark]
    public void TypedSetterStringReflection() => typedSetterStringReflection!(data!, string.Empty);
    [Benchmark]
    public void TypedSetterHolderIntReflection() => typedSetterHolderIntReflection!(data!, 0);
    [Benchmark]
    public void TypedSetterHolderStringReflection() => typedSetterHolderStringReflection!(data!, string.Empty);

    // Data

    public class MemberData
    {
        public int IntValue { get; set; }

        public string? StringValue { get; set; }

        public IValueHolder<string?> NotificationStringValue { get; } = new NotificationValue<string?>();

        public IValueHolder<int> NotificationIntValue { get; } = new NotificationValue<int>();
    }

    public class Data0
    {
    }

    public class Data1
    {
        public string? P1 { get; }

        public Data1(string? p1)
        {
            P1 = p1;
        }
    }

    public class Data2
    {
        public string? P1 { get; }

        public int P2 { get; }

        public Data2(string? p1, int p2)
        {
            P1 = p1;
            P2 = p2;
        }
    }
}
