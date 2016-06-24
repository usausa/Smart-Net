namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    internal class ReflectionValueHolderPropertyAccessor : IAccessor
    {
        private readonly PropertyInfo propertyInfo;

        private readonly PropertyInfo valuePropertyInfo;

        /// <summary>
        ///
        /// </summary>
        public string Name => propertyInfo.Name;

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
        /// <param name="propertyInfo"></param>
        /// <param name="valuePropertyInfo"></param>
        public ReflectionValueHolderPropertyAccessor(PropertyInfo propertyInfo, PropertyInfo valuePropertyInfo)
        {
            this.propertyInfo = propertyInfo;
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
            return propertyInfo.GetValue(holder, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            var holder = valuePropertyInfo.GetValue(target, null);
            propertyInfo.SetValue(holder, value, null);
        }
    }
}
