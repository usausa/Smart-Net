namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    using Smart.ComponentModel;

    public sealed class ReflectionDelegateFactory : IDelegateFactory
    {
        public static ReflectionDelegateFactory Default { get; } = new ReflectionDelegateFactory();

        // Array

        public Func<int, Array> CreateArrayAllocator(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return length => Array.CreateInstance(type, length);
        }

        // Factory

        public Func<object[], object> CreateFactory(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return ci.GetParameters().Length == 0
                ? (Func<object[], object>)(parameters => Activator.CreateInstance(ci.DeclaringType))
                : ci.Invoke;
        }

        public Func<object> CreateFactory0(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            // specialized
            return () => Activator.CreateInstance(ci.DeclaringType);
        }

        public Func<object, object> CreateFactory1(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 1)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return p1 => ci.Invoke(new[] { p1 });
        }

        public Func<object, object, object> CreateFactory2(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 2)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2) => ci.Invoke(new[] { p1, p2 });
        }

        public Func<object, object, object, object> CreateFactory3(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 3)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3) => ci.Invoke(new[] { p1, p2, p3 });
        }

        public Func<object, object, object, object, object> CreateFactory4(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 4)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4) => ci.Invoke(new[] { p1, p2, p3, p4 });
        }

        public Func<object, object, object, object, object, object> CreateFactory5(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 5)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5) => ci.Invoke(new[] { p1, p2, p3, p4, p5 });
        }

        public Func<object, object, object, object, object, object, object> CreateFactory6(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 6)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6 });
        }

        public Func<object, object, object, object, object, object, object, object> CreateFactory7(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 7)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7 });
        }

        public Func<object, object, object, object, object, object, object, object, object> CreateFactory8(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 8)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8 });
        }

        // Accessor

        public Func<object, object> CreateGetter(PropertyInfo pi)
        {
            return CreateGetter(pi, true);
        }

        public Func<object, object> CreateGetter(PropertyInfo pi, bool extension)
        {
            if (pi == null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            if (holderType == null)
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
            if (pi == null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            if (holderType == null)
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

        public Type GetExtendedPropertyType(PropertyInfo pi)
        {
            var holderType = ValueHolderHelper.FindValueHolderType(pi);
            var tpi = holderType != null ? ValueHolderHelper.GetValueTypeProperty(holderType) : pi;
            return tpi.PropertyType;
        }
    }
}
