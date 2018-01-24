namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public sealed class DynamicDelegateFactory : IDelegateFactory
    {
        public static DynamicDelegateFactory Default { get; } = new DynamicDelegateFactory();

        public Func<int, Array> CreateArrayAllocator(Type type)
        {
            throw new NotImplementedException();
        }

        public Func<object[], object> CreateFactory(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object> CreateFactory0(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object, object> CreateFactory1(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object, object, object> CreateFactory2(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object, object, object, object> CreateFactory3(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object, object, object, object, object> CreateFactory4(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object, object, object, object, object, object> CreateFactory5(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object, object, object, object, object, object, object> CreateFactory6(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object, object, object, object, object, object, object, object> CreateFactory7(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object, object, object, object, object, object, object, object, object> CreateFactory8(ConstructorInfo ci)
        {
            throw new NotImplementedException();
        }

        public Func<object, object> CreateGetter(PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        public Func<object, object> CreateGetter(PropertyInfo pi, bool extension)
        {
            throw new NotImplementedException();
        }

        public Action<object, object> CreateSetter(PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        public Action<object, object> CreateSetter(PropertyInfo pi, bool extension)
        {
            throw new NotImplementedException();
        }
    }
}
