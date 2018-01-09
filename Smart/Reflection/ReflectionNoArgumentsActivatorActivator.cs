namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    internal sealed class ReflectionActivatorActivator : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        public ConstructorInfo Source { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="constructor"></param>
        public ReflectionActivatorActivator(ConstructorInfo constructor)
        {
            Source = constructor;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(Source.DeclaringType);
        }
    }
}
