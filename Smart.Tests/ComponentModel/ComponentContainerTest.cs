namespace Smart.ComponentModel;

using Xunit;

public sealed class ComponentContainerTest
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

    public sealed class SimpleObject
    {
    }

#pragma warning disable CA1040
    public interface ICalcService
    {
    }
#pragma warning restore CA1040

    public sealed class AddCalcService : ICalcService
    {
    }

    public sealed class SubCalcService : ICalcService
    {
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
