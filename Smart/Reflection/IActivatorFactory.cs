namespace Smart.Reflection
{
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public interface IActivatorFactory
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        ActivatorMetadata CreateActivator(ConstructorInfo ci);
    }
}
