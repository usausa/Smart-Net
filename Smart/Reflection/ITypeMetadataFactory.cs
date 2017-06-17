namespace Smart.Reflection
{
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public interface ITypeMetadataFactory
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        IActivator CreateActivator(ConstructorInfo ci);

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        IAccessor CreateAccessor(PropertyInfo pi);

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        IAccessor CreateAccessor(PropertyInfo pi, bool extension);
    }
}
