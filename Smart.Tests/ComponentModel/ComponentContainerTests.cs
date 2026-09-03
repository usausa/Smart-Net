namespace Smart.ComponentModel;

public sealed class ComponentContainerTests
{
    [Fact]
    public void ComponentIsResolved()
    {
        var config = new ComponentConfig();
        config.Add<SimpleObject>();

        using var container = config.ToContainer();
        var obj = container.Get<SimpleObject>();

        Assert.NotNull(obj);
    }

    [Fact]
    public void ComponentIsMultipleResolved()
    {
        var config = new ComponentConfig();
        config.Add<ICalcService, AddCalcService>();
        config.Add<ICalcService, SubCalcService>();

        using var container = config.ToContainer();
        var services = container.GetAll<ICalcService>();

        Assert.Equal(2, services.Count());
    }

    [Fact]
    public void ComponentIsMultipleResolvedByGetService()
    {
        var config = new ComponentConfig();
        config.Add<ICalcService, AddCalcService>();
        config.Add<ICalcService, SubCalcService>();

        using var container = config.ToContainer();
        var services = (IEnumerable<ICalcService>?)container.GetService(typeof(IEnumerable<ICalcService>));

        Assert.Equal(2, services?.Count());
    }

    [Fact]
    public void ComponentIsNotResolved()
    {
        var config = new ComponentConfig();

        using var container = config.ToContainer();
        var ret = container.TryGet<SimpleObject>(out _);

        Assert.False(ret);
    }

    [Fact]
    public void ComponentIsNotResolvedByGetService()
    {
        var config = new ComponentConfig();

        using var container = config.ToContainer();
        var obj = container.GetService(typeof(SimpleObject));

        Assert.Null(obj);
    }

    [Fact]
    public void ComponentIsResolvedSameObject()
    {
        var config = new ComponentConfig();
        config.Add<SimpleObject>();

        using var container = config.ToContainer();
        var obj1 = container.Get<SimpleObject>();
        var obj2 = container.GetService(typeof(SimpleObject));

        Assert.Same(obj1, obj2);
    }

    [Fact]
    public void ComponentIsDisposed()
    {
        var config = new ComponentConfig();
        config.Add<DisposableObject>();

        DisposableObject obj;
        using (var container = config.ToContainer())
        {
            obj = container.Get<DisposableObject>();
        }

        Assert.Equal(1, obj.Disposed);
    }

    [Fact]
    public void ComponentAddedConstIsDisposed()
    {
        var config = new ComponentConfig();
#pragma warning disable CA2000
        config.Add(new DisposableObject());
#pragma warning restore CA2000

        DisposableObject obj;
        using (var container = config.ToContainer())
        {
            obj = container.Get<DisposableObject>();
        }

        Assert.Equal(1, obj.Disposed);
    }

    [Fact]
    public void ComponentIsResolvedWithMultipleArgument()
    {
        var config = new ComponentConfig();
        config.Add<ArrayParameterObject>();
        config.Add<ICalcService, AddCalcService>();
        config.Add<ICalcService, SubCalcService>();

        using var container = config.ToContainer();
        var obj = container.Get<ArrayParameterObject>();

        Assert.Equal(2, obj.CalcServices.Length);
    }

    [Fact]
    public void ComponentIsResolvedByDefaultConstructor()
    {
        var config = new ComponentConfig();
        config.Add<MultiConstructorObject>();

        using var container = config.ToContainer();
        var obj = container.Get<MultiConstructorObject>();

        Assert.Equal(0, obj.Arguments);
        Assert.Null(obj.CalcService);
    }

    [Fact]
    public void ComponentIsResolvedByConstructorWithArguments()
    {
        var config = new ComponentConfig();
        config.Add<MultiConstructorObject>();
        config.Add<ICalcService, AddCalcService>();

        using var container = config.ToContainer();
        var obj = container.Get<MultiConstructorObject>();

        Assert.Equal(1, obj.Arguments);
        Assert.NotNull(obj.CalcService);
    }

    [Fact]
    public void ComponentIsDisposedOnceWhenDisposedTwice()
    {
        var config = new ComponentConfig();
        config.Add<DisposableObject>();
#pragma warning disable CA2000
        var constant = new DisposableObject();
#pragma warning restore CA2000
        config.Add<IDisposable>(constant);

        var container = config.ToContainer();
        var resolved = container.Get<DisposableObject>();
        container.Dispose();
        container.Dispose();

        Assert.Equal(1, resolved.Disposed);
        Assert.Equal(1, constant.Disposed);
    }

    [Fact]
    public void ComponentIsNotResolvedAfterDispose()
    {
        var config = new ComponentConfig();
        config.Add<SimpleObject>();

        var container = config.ToContainer();
        container.Get<SimpleObject>();
        container.Dispose();

        Assert.False(container.TryGet<SimpleObject>(out _));
        Assert.Empty(container.GetAll<SimpleObject>());
        Assert.Null(container.GetService(typeof(SimpleObject)));
        Assert.Empty((IEnumerable<SimpleObject>)container.GetService(typeof(IEnumerable<SimpleObject>))!);
        Assert.Throws<InvalidOperationException>(container.Get<SimpleObject>);
    }

    [Fact]
    public void ComponentIsNotResolvedWhenAllRegistrationsRemoved()
    {
        var config = new ComponentConfig();
        config.Add<ICalcService, AddCalcService>();
        config.Remove<ICalcService, AddCalcService>();

        using var container = config.ToContainer();

        Assert.False(container.TryGet<ICalcService>(out _));
        Assert.Empty(container.GetAll<ICalcService>());
        Assert.Null(container.GetService(typeof(ICalcService)));
        Assert.Throws<InvalidOperationException>(container.Get<ICalcService>);
    }

    [Fact]
    public void ComponentIsResolvedAsEmptyEnumerableWhenNotRegistered()
    {
        var config = new ComponentConfig();

        using var container = config.ToContainer();
        var services = (IEnumerable<ICalcService>?)container.GetService(typeof(IEnumerable<ICalcService>));

        Assert.NotNull(services);
        Assert.Empty(services);
    }

    [Fact]
    public void GenericComponentIsResolvedByGetService()
    {
        var config = new ComponentConfig();
        config.Add<IComparer<int>, IntComparer>();

        using var container = config.ToContainer();
        var comparer = container.GetService(typeof(IComparer<int>));

        Assert.IsType<IntComparer>(comparer);
    }

    [Fact]
    public void ComponentIsResolvedSameInstanceByAllAccessors()
    {
        var config = new ComponentConfig();
        config.Add<ICalcService, AddCalcService>();
        config.Add<ICalcService, SubCalcService>();

        using var container = config.ToContainer();
        var single = container.Get<ICalcService>();
        var all = container.GetAll<ICalcService>().ToArray();
        var byService = ((IEnumerable<ICalcService>)container.GetService(typeof(IEnumerable<ICalcService>))!).ToArray();

        Assert.Same(all[^1], single);
        Assert.Same(all[0], byService[0]);
        Assert.Same(all[1], byService[1]);
    }

    [Fact]
    public void ComponentIsResolvedRepeatedlyWithSameContent()
    {
        var config = new ComponentConfig();
        config.Add<ICalcService, AddCalcService>();
        config.Add<ICalcService, SubCalcService>();

        using var container = config.ToContainer();
        var first = container.GetAll<ICalcService>().ToArray();
        var second = container.GetAll<ICalcService>().ToArray();

        Assert.Equal(first, second);
    }

    [Fact]
    public void ComponentInjectedArrayIsNotSharedWithResolvedResult()
    {
        var config = new ComponentConfig();
        config.Add<ArrayParameterObject>();
        config.Add<ICalcService, AddCalcService>();
        config.Add<ICalcService, SubCalcService>();

        using var container = config.ToContainer();
        var obj = container.Get<ArrayParameterObject>();
        obj.CalcServices[0] = null!;

        Assert.All(container.GetAll<ICalcService>(), Assert.NotNull);
    }

    [Fact]
    public void ComponentAddedConstToMultipleTypesIsDisposedOnce()
    {
        var config = new ComponentConfig();
#pragma warning disable CA2000
        var obj = new DisposableObject();
#pragma warning restore CA2000
        config.Add<IDisposable>(obj);
        config.Add(obj);

        using (config.ToContainer())
        {
            Assert.Equal(0, obj.Disposed);
        }

        Assert.Equal(1, obj.Disposed);
    }

    [Fact]
    public void ComponentAddedConstToMultipleTypesIsDisposedOnceWhenResolved()
    {
        var config = new ComponentConfig();
#pragma warning disable CA2000
        var obj = new DisposableObject();
#pragma warning restore CA2000
        config.Add<IDisposable>(obj);
        config.Add(obj);

        using (var container = config.ToContainer())
        {
            Assert.Same(obj, container.Get<DisposableObject>());
            Assert.Same(obj, container.Get<IDisposable>());
        }

        Assert.Equal(1, obj.Disposed);
    }

    [Fact]
    public void ComponentIsResolvedOnceUnderConcurrency()
    {
        var config = new ComponentConfig();
        config.Add<SimpleObject>();

        using var container = config.ToContainer();
        var results = new SimpleObject[32];
        // ReSharper disable once AccessToDisposedClosure
        Parallel.For(0, results.Length, i => results[i] = container.Get<SimpleObject>());

        Assert.All(results, x => Assert.Same(results[0], x));
    }

    public sealed class SimpleObject;

#pragma warning disable CA1040
    public interface ICalcService;
#pragma warning restore CA1040

    public sealed class AddCalcService : ICalcService;

    public sealed class SubCalcService : ICalcService;

    public sealed class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y) => x.CompareTo(y);
    }

    public sealed class DisposableObject : IDisposable
    {
        public int Disposed { get; set; }

        public void Dispose()
        {
            Disposed++;
        }
    }

#pragma warning disable CA1819
    public sealed class ArrayParameterObject
    {
        public ICalcService[] CalcServices { get; set; }

        public ArrayParameterObject(ICalcService[] calcServices)
        {
            CalcServices = calcServices;
        }
    }
#pragma warning restore CA1819

    public sealed class MultiConstructorObject
    {
        public int Arguments { get; set; }

        public ICalcService? CalcService { get; set; }

        public MultiConstructorObject()
        {
            Arguments = 0;
        }

        public MultiConstructorObject(ICalcService calcService)
        {
            Arguments = 1;
            CalcService = calcService;
        }
    }
}
