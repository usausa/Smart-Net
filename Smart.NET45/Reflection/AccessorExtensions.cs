namespace Smart.Reflection
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;

    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    public static class AccessorExtension
    {
        private static readonly Type ValueHolderType = typeof(IValueHolder<>);

        private static readonly Type NonNullableValueHolderDelegateAccessorType = typeof(NonNullableValueHolderDelegateAccessor<,>);

        private static readonly Type NullableValueHolderDelegateAccessorType = typeof(NullableValueHolderDelegateAccessor<,>);

        private static readonly Type NonNullableDelegateAccsessorType = typeof(NonNullableDelegateAccsessor<,>);

        private static readonly Type NullableDelegateAccsessorType = typeof(NullableDelegateAccsessor<,>);

        private static readonly ConcurrentDictionary<Type, Tuple<PropertyInfo, Delegate, Delegate>> ValuePropertyCaches =
            new ConcurrentDictionary<Type, Tuple<PropertyInfo, Delegate, Delegate>>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        private static Type FindValueHolderType(PropertyInfo pi)
        {
            return pi.PropertyType.GetInterfaces()
                .FirstOrDefault(_ => _.IsGenericType && _.GetGenericTypeDefinition() == ValueHolderType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static IAccessor ToAccessor(this PropertyInfo pi)
        {
            return ToAccessor(pi, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static IAccessor ToAccessor(this PropertyInfo pi, bool extension)
        {
            var holderInterface = !extension ? null : FindValueHolderType(pi);
            if (holderInterface != null)
            {
                return ToValueHolderDelegateAccessorInternal(pi, holderInterface);
            }

            return ToDelegateAccessor(pi);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static IAccessor ToValueHolderDelegateAccessor(this PropertyInfo pi)
        {
            var holderInterface = FindValueHolderType(pi);
            if (holderInterface == null)
            {
                throw new ArgumentException("PropertyType is not IValueHolder.", nameof(pi));
            }

            return ToValueHolderDelegateAccessorInternal(pi, holderInterface);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="holderInterface"></param>
        /// <returns></returns>
        private static IAccessor ToValueHolderDelegateAccessorInternal(PropertyInfo pi, Type holderInterface)
        {
            var holderGetter = DelegateMethodGenerator.CreateTypedGetDelegate(pi);

            Tuple<PropertyInfo, Delegate, Delegate> tuple;
            if (!ValuePropertyCaches.TryGetValue(holderInterface, out tuple))
            {
                var vpi = holderInterface.GetProperty("Value");
                var getter = DelegateMethodGenerator.CreateTypedGetDelegate(vpi);
                var setter = DelegateMethodGenerator.CreateTypedSetDelegate(vpi);

                tuple = Tuple.Create(vpi, getter, setter);
                ValuePropertyCaches[holderInterface] = tuple;
            }

            if (tuple.Item1.PropertyType.IsValueType)
            {
                var accessorType = NonNullableValueHolderDelegateAccessorType.MakeGenericType(pi.DeclaringType, tuple.Item1.PropertyType);
                return (IAccessor)Activator.CreateInstance(accessorType, pi.Name, tuple.Item1.PropertyType, holderGetter, tuple.Item2, tuple.Item3, tuple.Item1.PropertyType.GetDefaultValue());
            }
            else
            {
                var accessorType = NullableValueHolderDelegateAccessorType.MakeGenericType(pi.DeclaringType, tuple.Item1.PropertyType);
                return (IAccessor)Activator.CreateInstance(accessorType, pi.Name, tuple.Item1.PropertyType, holderGetter, tuple.Item2, tuple.Item3);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static IAccessor ToDelegateAccessor(this PropertyInfo pi)
        {
            var getter = DelegateMethodGenerator.CreateTypedGetDelegate(pi);
            var setter = DelegateMethodGenerator.CreateTypedSetDelegate(pi);

            if (pi.PropertyType.IsValueType)
            {
                var accessorType = NonNullableDelegateAccsessorType.MakeGenericType(pi.DeclaringType, pi.PropertyType);
                return (IAccessor)Activator.CreateInstance(accessorType, pi.Name, pi.PropertyType, getter, setter, pi.PropertyType.GetDefaultValue());
            }
            else
            {
                var accessorType = NullableDelegateAccsessorType.MakeGenericType(pi.DeclaringType, pi.PropertyType);
                return (IAccessor)Activator.CreateInstance(accessorType, pi.Name, pi.PropertyType, getter, setter);
            }
        }
    }
}
