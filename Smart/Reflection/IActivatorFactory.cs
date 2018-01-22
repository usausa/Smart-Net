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
        IActivator CreateActivator(ConstructorInfo ci);

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TActivator"></typeparam>
        /// <param name="ci"></param>
        /// <returns></returns>
        TActivator CreateActivator<TActivator>(ConstructorInfo ci)
            where TActivator : IActivator;
    }
}
