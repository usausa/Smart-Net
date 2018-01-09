namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class ActivatorMetadata
    {
        /// <summary>
        ///
        /// </summary>
        public ConstructorInfo Source { get; }

        /// <summary>
        ///
        /// </summary>
        public Func<object[], object> Create { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="create"></param>
        public ActivatorMetadata(
            ConstructorInfo source,
            Func<object[], object> create)
        {
            Source = source;
            Create = create;
        }
    }
}
