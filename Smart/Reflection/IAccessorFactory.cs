namespace Smart.Reflection
{
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public interface IAccessorFactory
    {
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
