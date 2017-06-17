namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    [Obsolete]
    public static class ActivatorExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static IActivator ToActivator(this ConstructorInfo ci, GeneratorMode mode)
        {
            if (!GeneratorConfig.SageMode && (mode == GeneratorMode.Throughput))
            {
                var activator = ExpressionMethodGenerator.CreateActivator(ci);
                return new DelegateActivator(ci, activator);
            }

            return new ReflectionActivator(ci);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public static IActivator ToActivator(this ConstructorInfo ci)
        {
            return ToActivator(ci, GeneratorConfig.GeneratorMode);
        }
    }
}
