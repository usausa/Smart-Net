namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public sealed class AccessorInfo
    {
        public PropertyInfo Source { get; }

        public Type ValueType { get; }

        public Func<object, object> Getter { get; }

        public Action<object, object> Setter { get; }

        public AccessorInfo(PropertyInfo source, Type valueType, Func<object, object> getter, Action<object, object> setter)
        {
            Source = source;
            ValueType = valueType;
            Getter = getter;
            Setter = setter;
        }
    }
}
