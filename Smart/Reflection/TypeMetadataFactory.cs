namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class TypeMetadataFactory : IActivatorFactory, IAccessorFactory, IArrayOperatorFactory
    {
        public static TypeMetadataFactory Default { get; } = new TypeMetadataFactory();

        public IActivatorFactory ActivatorFactory { get; set; }

        public IAccessorFactory AccessorFactory { get; set; }

        public IArrayOperatorFactory ArrayOperatorFactory { get; set; }

        /// <summary>
        ///
        /// </summary>
        private TypeMetadataFactory()
        {
            if (ReflectionHelper.IsCodegenAllowed)
            {
                ActivatorFactory = EmitTypeMetadataFactory.Default;
                AccessorFactory = EmitTypeMetadataFactory.Default;
                ArrayOperatorFactory = EmitTypeMetadataFactory.Default;
            }
            else
            {
                ActivatorFactory = ReflectionTypeMetadataFactory.Default;
                AccessorFactory = ReflectionTypeMetadataFactory.Default;
                ArrayOperatorFactory = ReflectionTypeMetadataFactory.Default;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public IActivator CreateActivator(ConstructorInfo ci)
        {
            return ActivatorFactory.CreateActivator(ci);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TActivator"></typeparam>
        /// <param name="ci"></param>
        /// <returns></returns>
        public TActivator CreateActivator<TActivator>(ConstructorInfo ci)
            where TActivator : IActivator
        {
            return ActivatorFactory.CreateActivator<TActivator>(ci);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public IAccessor CreateAccessor(PropertyInfo pi)
        {
            return AccessorFactory.CreateAccessor(pi);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public IAccessor CreateAccessor(PropertyInfo pi, bool extension)
        {
            return AccessorFactory.CreateAccessor(pi, extension);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IArrayOperator CreateArrayOperator(Type type)
        {
            return ArrayOperatorFactory.CreateArrayOperator(type);
        }
    }
}
