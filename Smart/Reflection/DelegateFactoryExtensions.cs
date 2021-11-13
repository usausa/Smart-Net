namespace Smart.Reflection;

using System;
using System.Reflection;

public static class DelegateFactoryExtensions
{
    public static void ConfigurePerformance(this DelegateFactory factory)
    {
        factory.Factory = DynamicDelegateFactory.Default;
    }

    public static void ConfigureSafe(this DelegateFactory factory)
    {
        factory.Factory = ReflectionDelegateFactory.Default;
    }

    public static Func<T?, TMember?>? CreateGetter<T, TMember>(this IDelegateFactory factory, string name)
    {
        var pi = typeof(T).GetRuntimeProperty(name);
        if (pi is null)
        {
            throw new ArgumentException("Invalid name.", nameof(name));
        }

        return factory.CreateGetter<T, TMember>(pi);
    }

    public static Func<T?, TMember?>? CreateGetter<T, TMember>(this IDelegateFactory factory, string name, bool extension)
    {
        var pi = typeof(T).GetRuntimeProperty(name);
        if (pi is null)
        {
            throw new ArgumentException("Invalid name.", nameof(name));
        }

        return factory.CreateGetter<T, TMember>(pi, extension);
    }

    public static Action<T?, TMember?>? CreateSetter<T, TMember>(this IDelegateFactory factory, string name)
    {
        var pi = typeof(T).GetRuntimeProperty(name);
        if (pi is null)
        {
            throw new ArgumentException("Invalid name.", nameof(name));
        }

        return factory.CreateSetter<T, TMember>(pi);
    }

    public static Action<T?, TMember?>? CreateSetter<T, TMember>(this IDelegateFactory factory, string name, bool extension)
    {
        var pi = typeof(T).GetRuntimeProperty(name);
        if (pi is null)
        {
            throw new ArgumentException("Invalid name.", nameof(name));
        }

        return factory.CreateSetter<T, TMember>(pi, extension);
    }
}
