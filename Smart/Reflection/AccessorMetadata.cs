namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class AccessorMetadata
    {
        /// <summary>
        ///
        /// </summary>
        public PropertyInfo Source { get; }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///
        /// </summary>
        public Type Type { get; }

        /// <summary>
        ///
        /// </summary>
        public bool CanRead { get; }

        /// <summary>
        ///
        /// </summary>
        public bool CanWrite { get; }

        /// <summary>
        ///
        /// </summary>
        public Func<object, object> GetValue { get; }

        /// <summary>
        ///
        /// </summary>
        public Action<object, object> SetValue { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="canRead"></param>
        /// <param name="canWrite"></param>
        /// <param name="getValue"></param>
        /// <param name="setValue"></param>
        public AccessorMetadata(
            PropertyInfo source,
            string name,
            Type type,
            bool canRead,
            bool canWrite,
            Func<object, object> getValue,
            Action<object, object> setValue)
        {
            Source = source;
            Name = name;
            Type = type;
            CanRead = canRead;
            CanWrite = canWrite;
            GetValue = getValue;
            SetValue = setValue;
        }
    }
}
