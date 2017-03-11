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

        private static readonly Type DelegateNonNullableValueHolderAccessorType = typeof(DelegateNonNullableValueHolderAccessor<,>);

        private static readonly Type DelegateNullableValueHolderAccessorType = typeof(DelegateNullableValueHolderAccessor<,>);

        private static readonly Type DelegateNonNullableAccsessorType = typeof(DelegateNonNullableAccsessor<,>);

        private static readonly Type DelegateNullableAccsessorType = typeof(DelegateNullableAccsessor<,>);

        private static readonly ConcurrentDictionary<Type, Tuple<PropertyInfo, Delegate, Delegate>> SharedValueProperties =
            new ConcurrentDictionary<Type, Tuple<PropertyInfo, Delegate, Delegate>>();

        //--------------------------------------------------------------------------------
        // Helper
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        private static Type FindValueHolderType(PropertyInfo pi)
        {
            return pi.PropertyType.GetTypeInfo().ImplementedInterfaces
                .FirstOrDefault(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == ValueHolderType);
        }

        //--------------------------------------------------------------------------------
        // Generic
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static IAccessor ToAccessor(this PropertyInfo pi, bool extension)
        {
            return ToDelegateAccessor(pi, extension);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static IAccessor ToAccessor(this PropertyInfo pi)
        {
            return ToDelegateAccessor(pi, true);
        }

        //--------------------------------------------------------------------------------
        // Delegate
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static IAccessor ToDelegateAccessor(this PropertyInfo pi, bool extension)
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
        public static IAccessor ToDelegateAccessor(this PropertyInfo pi)
        {
            var getter = DelegateMethodGenerator.CreateGetter(pi);
            var setter = DelegateMethodGenerator.CreateSetter(pi);

            if (pi.PropertyType.GetTypeInfo().IsValueType)
            {
                var accessorType = DelegateNonNullableAccsessorType.MakeGenericType(pi.DeclaringType, pi.PropertyType);
                return (IAccessor)Activator.CreateInstance(accessorType, pi, getter, setter, pi.PropertyType.GetDefaultValue());
            }
            else
            {
                var accessorType = DelegateNullableAccsessorType.MakeGenericType(pi.DeclaringType, pi.PropertyType);
                return (IAccessor)Activator.CreateInstance(accessorType, pi, getter, setter);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="holderInterface"></param>
        /// <returns></returns>
        private static IAccessor ToValueHolderDelegateAccessorInternal(PropertyInfo pi, Type holderInterface)
        {
            var holderGetter = DelegateMethodGenerator.CreateGetter(pi);

            Tuple<PropertyInfo, Delegate, Delegate> tuple;
            if (!SharedValueProperties.TryGetValue(holderInterface, out tuple))
            {
                var vpi = holderInterface.GetRuntimeProperty("Value");
                var getter = DelegateMethodGenerator.CreateGetter(vpi);
                var setter = DelegateMethodGenerator.CreateSetter(vpi);

                tuple = Tuple.Create(vpi, getter, setter);
                SharedValueProperties[holderInterface] = tuple;
            }

            if (pi.PropertyType.GetTypeInfo().IsValueType)
            {
                var accessorType = DelegateNonNullableValueHolderAccessorType.MakeGenericType(pi.DeclaringType, tuple.Item1.PropertyType);
                return (IAccessor)Activator.CreateInstance(accessorType, pi, tuple.Item1.PropertyType, holderGetter, tuple.Item2, tuple.Item3, tuple.Item1.PropertyType.GetDefaultValue());
            }
            else
            {
                var accessorType = DelegateNullableValueHolderAccessorType.MakeGenericType(pi.DeclaringType, tuple.Item1.PropertyType);
                return (IAccessor)Activator.CreateInstance(accessorType, pi, tuple.Item1.PropertyType, holderGetter, tuple.Item2, tuple.Item3);
            }
        }

        //--------------------------------------------------------------------------------
        // Reflection
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static IAccessor ToReflectionAccessor(this PropertyInfo pi, bool extension)
        {
            var holderInterface = !extension ? null : FindValueHolderType(pi);
            if (holderInterface != null)
            {
                var vpi = holderInterface.GetRuntimeProperty("Value");
                return new ReflectionValueHolderAccessor(pi, vpi);
            }

            return new ReflectionAccessor(pi);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static IAccessor ToReflectionAccessor(this PropertyInfo pi)
        {
            return new ReflectionAccessor(pi);
        }
    }
}
