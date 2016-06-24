namespace Smart.Reflection
{
    using System;
    using System.Collections.Concurrent;
    using System.Globalization;
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

        private static readonly ConcurrentDictionary<Type, Tuple<PropertyInfo, Delegate, Delegate>> SharedValueProperties =
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
        /// <param name="fi"></param>
        /// <returns></returns>
        private static Type FindValueHolderType(FieldInfo fi)
        {
            return fi.FieldType.GetInterfaces()
                .FirstOrDefault(_ => _.IsGenericType && _.GetGenericTypeDefinition() == ValueHolderType);
        }

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
            if (!SharedValueProperties.TryGetValue(holderInterface, out tuple))
            {
                var vpi = holderInterface.GetProperty("Value");
                var getter = DelegateMethodGenerator.CreateTypedGetDelegate(vpi);
                var setter = DelegateMethodGenerator.CreateTypedSetDelegate(vpi);

                tuple = Tuple.Create(vpi, getter, setter);
                SharedValueProperties[holderInterface] = tuple;
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
        /// <param name="fi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static IAccessor ToReflectionAccessor(this FieldInfo fi, bool extension)
        {
            var holderInterface = !extension ? null : FindValueHolderType(fi);
            if (holderInterface != null)
            {
                var vpi = holderInterface.GetProperty("Value");
                return new ReflectionValueHolderFieldAccessor(fi, vpi);
            }

            return new ReflectionFieldAccessor(fi);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static IAccessor ToReflectionAccessor(this FieldInfo fi)
        {
            return new ReflectionFieldAccessor(fi);
        }

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
                var vpi = holderInterface.GetProperty("Value");
                return new ReflectionValueHolderPropertyAccessor(pi, vpi);
            }

            return new ReflectionPropertyAccessor(pi);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static IAccessor ToReflectionAccessor(this PropertyInfo pi)
        {
            return new ReflectionPropertyAccessor(pi);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static IAccessor ToAccessor(this MemberInfo mi, bool extension)
        {
            if (mi == null)
            {
                throw new ArgumentNullException(nameof(mi));
            }

            var fi = mi as FieldInfo;
            if (fi != null)
            {
                return ToAccessor(fi, extension);
            }

            var pi = mi as PropertyInfo;
            if (pi != null)
            {
                return ToAccessor(pi, extension);
            }

            throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, "Type {0} must be PropertyInfo or FieldInfo.", mi.GetType()));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public static IAccessor ToAccessor(this MemberInfo mi)
        {
            return ToAccessor(mi, false);
        }
    }
}
