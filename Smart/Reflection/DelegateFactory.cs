namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public class DelegateFactory : IDelegateFactory
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

        public Func<object> CreateFactory0(ConstructorInfo ci)
        {
            return Factory.CreateFactory0(ci);
        }

        public Func<object, object> CreateFactory1(ConstructorInfo ci)
        {
            return Factory.CreateFactory1(ci);
        }

        public Func<object, object, object> CreateFactory2(ConstructorInfo ci)
        {
            return Factory.CreateFactory2(ci);
        }

        public Func<object, object, object, object> CreateFactory3(ConstructorInfo ci)
        {
            return Factory.CreateFactory3(ci);
        }

        public Func<object, object, object, object, object> CreateFactory4(ConstructorInfo ci)
        {
            return Factory.CreateFactory4(ci);
        }

        public Func<object, object, object, object, object, object> CreateFactory5(ConstructorInfo ci)
        {
            return Factory.CreateFactory5(ci);
        }

        public Func<object, object, object, object, object, object, object> CreateFactory6(ConstructorInfo ci)
        {
            return Factory.CreateFactory6(ci);
        }

        public Func<object, object, object, object, object, object, object, object> CreateFactory7(ConstructorInfo ci)
        {
            return Factory.CreateFactory7(ci);
        }

        public Func<object, object, object, object, object, object, object, object, object> CreateFactory8(ConstructorInfo ci)
        {
            return Factory.CreateFactory8(ci);
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

        public Type GetExtendedPropertyType(PropertyInfo pi)
        {
            return Factory.GetExtendedPropertyType(pi);
        }
    }
}
