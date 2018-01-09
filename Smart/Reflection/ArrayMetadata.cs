namespace Smart.Reflection
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public sealed class ArrayMetadata
    {
        /// <summary>
        ///
        /// </summary>
        public Type Type { get; }

        /// <summary>
        ///
        /// </summary>
        public Func<int, Array> Create { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="create"></param>
        public ArrayMetadata(
            Type type,
            Func<int, Array> create)
        {
            Type = type;
            Create = create;
        }
    }
}
