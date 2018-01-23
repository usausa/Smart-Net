namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public interface IActivatorFactory
    {
        Func<object[], object> CreateActivator(ConstructorInfo ci);

        Func<object> CreateActivator0(ConstructorInfo ci);

        Func<object, object> CreateActivator1(ConstructorInfo ci);

        Func<object, object, object> CreateActivator2(ConstructorInfo ci);

        Func<object, object, object, object> CreateActivator3(ConstructorInfo ci);

        Func<object, object, object, object, object> CreateActivator4(ConstructorInfo ci);

        Func<object, object, object, object, object, object> CreateActivator5(ConstructorInfo ci);

        Func<object, object, object, object, object, object, object> CreateActivator6(ConstructorInfo ci);

        Func<object, object, object, object, object, object, object, object> CreateActivator7(ConstructorInfo ci);

        Func<object, object, object, object, object, object, object, object, object> CreateActivator8(ConstructorInfo ci);
    }
}
