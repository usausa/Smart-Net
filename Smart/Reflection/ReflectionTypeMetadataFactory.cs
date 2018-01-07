namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class ReflectionTypeMetadataFactory : IActivatorFactory, IAccessorFactory, IArrayOperatorFactory
    {
        /// <summary>
        ///
        /// </summary>
        public static ReflectionTypeMetadataFactory Default { get; } = new ReflectionTypeMetadataFactory();

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public IActivator CreateActivator(ConstructorInfo ci)
        {
            return ci.GetParameters().Length == 0
                ? (IActivator)new ReflectionActivatorActivator(ci)
                : new ReflectionConstructorActivator(ci);
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
                return new ReflectionAccessor(pi);
            }

            var vpi = AccessorHelper.GetValueTypeProperty(holderInterface);
            return new ReflectionValueHolderAccessor(pi, vpi);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IArrayOperator CreateOperator(Type type)
        {
            return new ReflectionArrayOperator(type);
        }
    }
}
