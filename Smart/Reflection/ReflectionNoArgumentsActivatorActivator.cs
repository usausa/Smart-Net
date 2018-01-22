namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    internal sealed class ReflectionActivatorActivator : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        public ConstructorInfo Source { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="constructor"></param>
        public ReflectionActivatorActivator(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }
    }

    internal sealed class ReflectionActivatorActivator0 : IActivator0
    {
        public ConstructorInfo Source { get; }

        public ReflectionActivatorActivator0(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }

        public object Create()
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }
    }

    internal sealed class ReflectionActivatorActivator1 : IActivator1
    {
        public ConstructorInfo Source { get; }

        public ReflectionActivatorActivator1(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }

        public object Create(object artument1)
        {
            return Activator.CreateInstance(
                Source.DeclaringType,
                artument1);
        }
    }

    internal sealed class ReflectionActivatorActivator2 : IActivator2
    {
        public ConstructorInfo Source { get; }

        public ReflectionActivatorActivator2(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }

        public object Create(
            object artument1,
            object artument2)
        {
            return Activator.CreateInstance(
                Source.DeclaringType,
                artument1,
                artument2);
        }
    }

    internal sealed class ReflectionActivatorActivator3 : IActivator3
    {
        public ConstructorInfo Source { get; }

        public ReflectionActivatorActivator3(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }

        public object Create(
            object artument1,
            object artument2,
            object artument3)
        {
            return Activator.CreateInstance(
                Source.DeclaringType,
                artument1,
                artument2,
                artument3);
        }
    }

    internal sealed class ReflectionActivatorActivator4 : IActivator4
    {
        public ConstructorInfo Source { get; }

        public ReflectionActivatorActivator4(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }

        public object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4)
        {
            return Activator.CreateInstance(
                Source.DeclaringType,
                artument1,
                artument2,
                artument3,
                artument4);
        }
    }

    internal sealed class ReflectionActivatorActivator5 : IActivator5
    {
        public ConstructorInfo Source { get; }

        public ReflectionActivatorActivator5(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }

        public object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4,
            object artument5)
        {
            return Activator.CreateInstance(
                Source.DeclaringType,
                artument1,
                artument2,
                artument3,
                artument4,
                artument5);
        }
    }

    internal sealed class ReflectionActivatorActivator6 : IActivator6
    {
        public ConstructorInfo Source { get; }

        public ReflectionActivatorActivator6(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }

        public object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4,
            object artument5,
            object artument6)
        {
            return Activator.CreateInstance(
                Source.DeclaringType,
                artument1,
                artument2,
                artument3,
                artument4,
                artument5,
                artument6);
        }
    }

    internal sealed class ReflectionActivatorActivator7 : IActivator7
    {
        public ConstructorInfo Source { get; }

        public ReflectionActivatorActivator7(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }

        public object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4,
            object artument5,
            object artument6,
            object artument7)
        {
            return Activator.CreateInstance(
                Source.DeclaringType,
                artument1,
                artument2,
                artument3,
                artument4,
                artument5,
                artument6,
                artument7);
        }
    }

    internal sealed class ReflectionActivatorActivator8 : IActivator8
    {
        public ConstructorInfo Source { get; }

        public ReflectionActivatorActivator8(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }

        public object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4,
            object artument5,
            object artument6,
            object artument7,
            object artument8)
        {
            return Activator.CreateInstance(
                Source.DeclaringType,
                artument1,
                artument2,
                artument3,
                artument4,
                artument5,
                artument6,
                artument7,
                artument8);
        }
    }
}
