namespace Smart.Reflection
{
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class TypeMetadataFactory : IActivatorFactory
    {
        public static TypeMetadataFactory Default { get; } = new TypeMetadataFactory();

        public IActivatorFactory ActivatorFactory { get; set; }

        public IAccessorFactory AccessorFactory { get; set; }

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
    }
}
