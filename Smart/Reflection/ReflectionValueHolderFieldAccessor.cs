namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    internal class ReflectionValueHolderFieldAccessor : IAccessor
    {
        private readonly FieldInfo fieldInfo;

        private readonly PropertyInfo valuePropertyInfo;

        /// <summary>
        ///
        /// </summary>
        public string Name => fieldInfo.Name;

        /// <summary>
        ///
        /// </summary>
        public Type Type => valuePropertyInfo.PropertyType;

        /// <summary>
        ///
        /// </summary>
        public bool CanRead => valuePropertyInfo.CanRead;

        /// <summary>
        ///
        /// </summary>
        public bool CanWrite => valuePropertyInfo.CanWrite;

        /// <summary>
        ///
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <param name="valuePropertyInfo"></param>
        public ReflectionValueHolderFieldAccessor(FieldInfo fieldInfo, PropertyInfo valuePropertyInfo)
        {
            this.fieldInfo = fieldInfo;
            this.valuePropertyInfo = valuePropertyInfo;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            var holder = valuePropertyInfo.GetValue(target, null);
            return fieldInfo.GetValue(holder);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            var holder = valuePropertyInfo.GetValue(target, null);
            fieldInfo.SetValue(holder, value);
        }
    }
}
