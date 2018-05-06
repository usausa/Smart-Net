namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public sealed partial class DelegateFactory : IDelegateFactory
    {
        public static DelegateFactory Default { get; } = new DelegateFactory();

        public IDelegateFactory Factory { get; set; }

        public DelegateFactory()
        {
            if (ReflectionHelper.IsCodegenAllowed)
            {
                Factory = DynamicDelegateFactory.Default;
            }
            else
            {
                Factory = ReflectionDelegateFactory.Default;
            }
        }

        // Array

        public Func<int, Array> CreateArrayAllocator(Type type)
        {
            return Factory.CreateArrayAllocator(type);
        }

        // Factory

        public Func<object[], object> CreateFactory(ConstructorInfo ci)
        {
            return Factory.CreateFactory(ci);
        }

        // Accessor

        public Func<object, object> CreateGetter(PropertyInfo pi)
        {
            return Factory.CreateGetter(pi);
        }

        public Func<object, object> CreateGetter(PropertyInfo pi, bool extension)
        {
            return Factory.CreateGetter(pi, extension);
        }

        public Action<object, object> CreateSetter(PropertyInfo pi)
        {
            return Factory.CreateSetter(pi);
        }

        public Action<object, object> CreateSetter(PropertyInfo pi, bool extension)
        {
            return Factory.CreateSetter(pi, extension);
        }

        // Accessor

        public Func<T, TMember> CreateGetter<T, TMember>(PropertyInfo pi)
        {
            return Factory.CreateGetter<T, TMember>(pi);
        }

        public Func<T, TMember> CreateGetter<T, TMember>(PropertyInfo pi, bool extension)
        {
            return Factory.CreateGetter<T, TMember>(pi, extension);
        }

        public Action<T, TMember> CreateSetter<T, TMember>(PropertyInfo pi)
        {
            return Factory.CreateSetter<T, TMember>(pi);
        }

        public Action<T, TMember> CreateSetter<T, TMember>(PropertyInfo pi, bool extension)
        {
            return Factory.CreateSetter<T, TMember>(pi, extension);
        }

        // Etc

        public Type GetExtendedPropertyType(PropertyInfo pi)
        {
            return Factory.GetExtendedPropertyType(pi);
        }
    }
}
