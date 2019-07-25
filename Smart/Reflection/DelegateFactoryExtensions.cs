namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
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

        public static Func<T, TMember> CreateGetter<T, TMember>(this IDelegateFactory factory, string name)
        {
            return factory.CreateGetter<T, TMember>(typeof(T).GetRuntimeProperty(name));
        }

        public static Func<T, TMember> CreateGetter<T, TMember>(this IDelegateFactory factory, string name, bool extension)
        {
            return factory.CreateGetter<T, TMember>(typeof(T).GetRuntimeProperty(name), extension);
        }

        public static Action<T, TMember> CreateSetter<T, TMember>(this IDelegateFactory factory, string name)
        {
            return factory.CreateSetter<T, TMember>(typeof(T).GetRuntimeProperty(name));
        }

        public static Action<T, TMember> CreateSetter<T, TMember>(this IDelegateFactory factory, string name, bool extension)
        {
            return factory.CreateSetter<T, TMember>(typeof(T).GetRuntimeProperty(name), extension);
        }
    }
}
