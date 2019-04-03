namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    using Smart.ComponentModel;

    public sealed partial class ReflectionDelegateFactory : IDelegateFactory
    {
        public static ReflectionDelegateFactory Default { get; } = new ReflectionDelegateFactory();

        // Constructor

        private ReflectionDelegateFactory()
        {
        }

        // Array

        public Func<int, Array> CreateArrayAllocator(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return length => Array.CreateInstance(type, length);
        }

        // Factory

        public Func<object[], object> CreateFactory(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return ci.GetParameters().Length == 0
                ? (Func<object[], object>)(parameters => Activator.CreateInstance(ci.DeclaringType))
                : ci.Invoke;
        }

        public Func<object> CreateFactory0(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            // specialized
            return () => Activator.CreateInstance(ci.DeclaringType);
        }

        public Func<T> CreateFactory<T>()
        {
            return Activator.CreateInstance<T>;
        }

        // Accessor

        public Func<object, object> CreateGetter(PropertyInfo pi)
        {
            return CreateGetter(pi, true);
        }

        public Func<object, object> CreateGetter(PropertyInfo pi, bool extension)
        {
            if (pi is null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            if (holderType is null)
            {
                if (!pi.CanRead)
                {
                    return null;
                }

                return pi.GetValue;
            }

            if (!pi.CanRead)
            {
                throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
            }

            var vpi = ValueHolderHelper.GetValueTypeProperty(holderType);
            return obj =>
            {
                var holder = pi.GetValue(obj, null);
                return vpi.GetValue(holder, null);
            };
        }

        public Action<object, object> CreateSetter(PropertyInfo pi)
        {
            return CreateSetter(pi, true);
        }

        public Action<object, object> CreateSetter(PropertyInfo pi, bool extension)
        {
            if (pi is null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            if (holderType is null)
            {
                if (!pi.CanWrite)
                {
                    return null;
                }

                return pi.SetValue;
            }

            if (!pi.CanRead)
            {
                throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
            }

            var vpi = ValueHolderHelper.GetValueTypeProperty(holderType);
            return (obj, value) =>
            {
                var holder = pi.GetValue(obj, null);
                vpi.SetValue(holder, value, null);
            };
        }

        // Accessor

        public Func<T, TMember> CreateGetter<T, TMember>(PropertyInfo pi)
        {
            return CreateGetter<T, TMember>(pi, true);
        }

        public Func<T, TMember> CreateGetter<T, TMember>(PropertyInfo pi, bool extension)
        {
            if (pi is null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            if (holderType is null)
            {
                if (!pi.CanRead)
                {
                    return null;
                }

                return obj => (TMember)pi.GetValue(obj, null);
            }

            if (!pi.CanRead)
            {
                throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
            }

            var vpi = ValueHolderHelper.GetValueTypeProperty(holderType);
            return obj =>
            {
                var holder = pi.GetValue(obj, null);
                return (TMember)vpi.GetValue(holder, null);
            };
        }

        public Action<T, TMember> CreateSetter<T, TMember>(PropertyInfo pi)
        {
            return CreateSetter<T, TMember>(pi, true);
        }

        public Action<T, TMember> CreateSetter<T, TMember>(PropertyInfo pi, bool extension)
        {
            if (pi is null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            if (holderType is null)
            {
                if (!pi.CanWrite)
                {
                    return null;
                }

                return (obj, value) => pi.SetValue(obj, value, null);
            }

            if (!pi.CanRead)
            {
                throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
            }

            var vpi = ValueHolderHelper.GetValueTypeProperty(holderType);
            return (obj, value) =>
            {
                var holder = pi.GetValue(obj, null);
                vpi.SetValue(holder, value, null);
            };
        }

        // Etc

        public Type GetExtendedPropertyType(PropertyInfo pi)
        {
            var holderType = ValueHolderHelper.FindValueHolderType(pi);
            var tpi = holderType is null ? pi : ValueHolderHelper.GetValueTypeProperty(holderType);
            return tpi.PropertyType;
        }
    }
}
