namespace Smart.Reflection
{
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public static class ActivatorExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <param name="safeMode"></param>
        /// <returns></returns>
        public static IActivator ToActivator(this ConstructorInfo ci, bool safeMode)
        {
            if (safeMode)
            {
                return new ReflectionActivator(ci);
            }

            var activator = ExpressionMethodGenerator.CreateActivator(ci);
            return new DelegateActivator(ci, activator);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public static IActivator ToActivator(this ConstructorInfo ci)
        {
            return ToActivator(ci, GeneratorConfig.SafeMode);
        }
    }
}
