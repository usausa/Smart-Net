namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    using Smart.ComponentModel;

    public class ReflectionTypeMetadataFactory : IActivatorFactory, IAccessorFactory, IArrayFactory
    {
        public static ReflectionTypeMetadataFactory Default { get; } = new ReflectionTypeMetadataFactory();

        public ActivatorMetadata CreateActivator(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length == 0)
            {
                return new ActivatorMetadata(ci, args => Activator.CreateInstance(ci.DeclaringType));
            }

            return new ActivatorMetadata(ci, ci.Invoke);
        }

        public AccessorMetadata CreateAccessor(PropertyInfo pi)
        {
            return CreateAccessor(pi, true);
        }

        public AccessorMetadata CreateAccessor(PropertyInfo pi, bool extension)
        {
            if (pi == null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderInterface = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            if (holderInterface == null)
            {
                return new AccessorMetadata(
                    pi,
                    pi.Name,
                    pi.PropertyType,
                    pi.CanRead,
                    pi.CanWrite,
                    pi.GetValue,
                    pi.SetValue);
            }

            var vpi = ValueHolderHelper.GetValueTypeProperty(holderInterface);
            return new AccessorMetadata(
                pi,
                pi.Name,
                vpi.PropertyType,
                vpi.CanRead,
                vpi.CanWrite,
                obj =>
                {
                    var holder = vpi.GetValue(obj, null);
                    return pi.GetValue(holder, null);
                },
                (obj, value) =>
                {
                    var holder = vpi.GetValue(obj, null);
                    pi.SetValue(holder, value, null);
                });
        }

        public ArrayMetadata CreateArray(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return new ArrayMetadata(
                type,
                length => Array.CreateInstance(type, length));
        }
    }
}
