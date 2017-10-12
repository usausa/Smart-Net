namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class CodeGenerateTypeMetadataFactory : IActivatorFactory, IAccessorFactory
    {
        private static readonly Type DelegateNonNullableAccsessorType = typeof(DelegateNonNullableAccsessor<,>);

        private static readonly Type DelegateNullableAccsessorType = typeof(DelegateNullableAccsessor<,>);

        private static readonly Type DelegateNonNullableValueHolderAccessorType = typeof(DelegateNonNullableValueHolderAccessor<,>);

        private static readonly Type DelegateNullableValueHolderAccessorType = typeof(DelegateNullableValueHolderAccessor<,>);

        /// <summary>
        ///
        /// </summary>
        public static CodeGenerateTypeMetadataFactory Default { get; } = new CodeGenerateTypeMetadataFactory();

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public IActivator CreateActivator(ConstructorInfo ci)
        {
            var activator = ExpressionMethodGenerator.CreateActivator(ci);
            return new DelegateActivator(ci, activator);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public IAccessor CreateAccessor(PropertyInfo pi)
        {
            return CreateAccessor(pi, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public IAccessor CreateAccessor(PropertyInfo pi, bool extension)
        {
            var holderInterface = !extension ? null : AccessorHelper.FindValueHolderType(pi);
            if (holderInterface == null)
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
            else
            {
                var holderGetter = DelegateMethodGenerator.CreateGetter(pi);

                var vpi = AccessorHelper.GetValueTypeProperty(holderInterface);
                var getter = DelegateMethodGenerator.CreateGetter(vpi);
                var setter = DelegateMethodGenerator.CreateSetter(vpi);

                if (pi.PropertyType.GetTypeInfo().IsValueType)
                {
                    var accessorType = DelegateNonNullableValueHolderAccessorType.MakeGenericType(pi.DeclaringType, vpi.PropertyType);
                    return (IAccessor)Activator.CreateInstance(accessorType, pi, vpi.PropertyType, holderGetter, getter, setter, vpi.PropertyType.GetDefaultValue());
                }
                else
                {
                    var accessorType = DelegateNullableValueHolderAccessorType.MakeGenericType(pi.DeclaringType, vpi.PropertyType);
                    return (IAccessor)Activator.CreateInstance(accessorType, pi, vpi.PropertyType, holderGetter, getter, setter);
                }
            }
        }
    }
}