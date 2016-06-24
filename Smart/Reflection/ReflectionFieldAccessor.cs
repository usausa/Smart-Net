namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    internal class ReflectionFieldAccessor : IAccessor
    {
        private readonly FieldInfo fieldInfo;

        /// <summary>
        ///
        /// </summary>
        public string Name => fieldInfo.Name;

        /// <summary>
        ///
        /// </summary>
        public Type Type => fieldInfo.FieldType;

        /// <summary>
        ///
        /// </summary>
        public bool CanRead => true;

        /// <summary>
        ///
        /// </summary>
        public bool CanWrite => !fieldInfo.IsInitOnly;

        /// <summary>
        ///
        /// </summary>
        /// <param name="fieldInfo"></param>
        public ReflectionFieldAccessor(FieldInfo fieldInfo)
        {
            this.fieldInfo = fieldInfo;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            return fieldInfo.GetValue(target);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            fieldInfo.SetValue(target, value);
        }
    }
}
