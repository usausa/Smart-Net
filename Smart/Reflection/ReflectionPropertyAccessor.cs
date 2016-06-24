namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    internal class ReflectionPropertyAccessor : IAccessor
    {
        private readonly PropertyInfo propertyInfo;

        /// <summary>
        ///
        /// </summary>
        public string Name => propertyInfo.Name;

        /// <summary>
        ///
        /// </summary>
        public Type Type => propertyInfo.PropertyType;

        /// <summary>
        ///
        /// </summary>
        public bool CanRead => propertyInfo.CanRead;

        /// <summary>
        ///
        /// </summary>
        public bool CanWrite => propertyInfo.CanWrite;

        /// <summary>
        ///
        /// </summary>
        /// <param name="propertyInfo"></param>
        public ReflectionPropertyAccessor(PropertyInfo propertyInfo)
        {
            this.propertyInfo = propertyInfo;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            return propertyInfo.GetValue(target, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            propertyInfo.SetValue(target, value, null);
        }
    }
}
