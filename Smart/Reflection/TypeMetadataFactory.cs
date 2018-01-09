namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public class TypeMetadataFactory : IActivatorFactory, IAccessorFactory, IArrayFactory
    {
        public static TypeMetadataFactory Default { get; } = new TypeMetadataFactory();

        public IActivatorFactory ActivatorFactory { get; set; }

        public IAccessorFactory AccessorFactory { get; set; }

        public IArrayFactory ArrayOperatorFactory { get; set; }

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

        public ActivatorMetadata CreateActivator(ConstructorInfo ci)
        {
            return ActivatorFactory.CreateActivator(ci);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public AccessorMetadata CreateAccessor(PropertyInfo pi)
        {
            return AccessorFactory.CreateAccessor(pi);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public AccessorMetadata CreateAccessor(PropertyInfo pi, bool extension)
        {
            return AccessorFactory.CreateAccessor(pi, extension);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ArrayMetadata CreateArray(Type type)
        {
            return ArrayOperatorFactory.CreateArray(type);
        }
    }
}
