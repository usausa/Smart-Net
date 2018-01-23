namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public interface IAccessorFactory
    {
        Action<object, object> CreateGetter(PropertyInfo pi);

        Action<object, object> CreateGetter(PropertyInfo pi, bool extension);

        Action<object, object> CreateSetter(PropertyInfo pi);

        Action<object, object> CreateSetter(PropertyInfo pi, bool extension);
    }
}
