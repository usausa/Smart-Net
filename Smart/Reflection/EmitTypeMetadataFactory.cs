namespace Smart.Reflection
{
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class EmitTypeMetadataFactory : IActivatorFactory, IAccessorFactory
    {
        /// <summary>
        ///
        /// </summary>
        public static EmitTypeMetadataFactory Default { get; } = new EmitTypeMetadataFactory();

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public IActivator CreateActivator(ConstructorInfo ci)
        {
            return EmitMethodGenerator.CreateActivator(ci);
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
            return EmitMethodGenerator.CreateAccessor(pi, extension);
        }
    }
}