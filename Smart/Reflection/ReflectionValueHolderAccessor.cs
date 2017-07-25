namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    internal sealed class ReflectionValueHolderAccessor : IAccessor
    {
        private readonly PropertyInfo valueProperty;

        /// <summary>
        ///
        /// </summary>
        public PropertyInfo Source { get; }

        /// <summary>
        ///
        /// </summary>
        public string Name => Source.Name;

        /// <summary>
        ///
        /// </summary>
        public Type Type => valueProperty.PropertyType;

        /// <summary>
        ///
        /// </summary>
        public bool CanRead => valueProperty.CanRead;

        /// <summary>
        ///
        /// </summary>
        public bool CanWrite => valueProperty.CanWrite;

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="valueProperty"></param>
        public ReflectionValueHolderAccessor(PropertyInfo source, PropertyInfo valueProperty)
        {
            Source = source;
            this.valueProperty = valueProperty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            var holder = valueProperty.GetValue(target, null);
            return Source.GetValue(holder, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            var holder = valueProperty.GetValue(target, null);
            Source.SetValue(holder, value, null);
        }
    }
}
