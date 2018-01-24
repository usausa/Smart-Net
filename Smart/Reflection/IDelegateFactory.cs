namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public interface IDelegateFactory
    {
        // Array

        Func<int, Array> CreateArrayAllocator(Type type);

        // Factory

        Func<object[], object> CreateFactory(ConstructorInfo ci);

        Func<object> CreateFactory0(ConstructorInfo ci);

        Func<object, object> CreateFactory1(ConstructorInfo ci);

        Func<object, object, object> CreateFactory2(ConstructorInfo ci);

        Func<object, object, object, object> CreateFactory3(ConstructorInfo ci);

        Func<object, object, object, object, object> CreateFactory4(ConstructorInfo ci);

        Func<object, object, object, object, object, object> CreateFactory5(ConstructorInfo ci);

        Func<object, object, object, object, object, object, object> CreateFactory6(ConstructorInfo ci);

        Func<object, object, object, object, object, object, object, object> CreateFactory7(ConstructorInfo ci);

        Func<object, object, object, object, object, object, object, object, object> CreateFactory8(ConstructorInfo ci);

        // Accessor

        Func<object, object> CreateGetter(PropertyInfo pi);

        Func<object, object> CreateGetter(PropertyInfo pi, bool extension);

        Action<object, object> CreateSetter(PropertyInfo pi);

        Action<object, object> CreateSetter(PropertyInfo pi, bool extension);

        Type GetExtendedPropertyType(PropertyInfo pi);
    }
}
