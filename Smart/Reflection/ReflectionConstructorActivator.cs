﻿namespace Smart.Reflection
{
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    internal sealed class ReflectionConstructorActivator : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        public ConstructorInfo Source { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="constructor"></param>
        public ReflectionConstructorActivator(ConstructorInfo constructor)
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
            return Source.Invoke(arguments);
        }
    }
}
