namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class CodeGenerateTypeMetadataFactory : IActivatorFactory, IAccessorFactory
    {
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