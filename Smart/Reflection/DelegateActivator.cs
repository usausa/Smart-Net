namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public class DelegateActivator : IActivator
    {
        private readonly Func<object[], object> activator;

        /// <summary>
        ///
        /// </summary>
        public ConstructorInfo Source { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="activator"></param>
        public DelegateActivator(ConstructorInfo source, Func<object[], object> activator)
        {
            Source = source;
            this.activator = activator;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public object Create(params object[] arguments)
        {
            return activator(arguments);
        }
    }
}
