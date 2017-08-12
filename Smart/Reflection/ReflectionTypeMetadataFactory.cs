namespace Smart.Reflection
{
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class ReflectionTypeMetadataFactory : IActivatorFactory, IAccessorFactory
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
            return new ReflectionActivator(ci);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public IAccessor CreateAccessor(PropertyInfo pi)
        {
            return new ReflectionAccessor(pi);
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
    }
}
