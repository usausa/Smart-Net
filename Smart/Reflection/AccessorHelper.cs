namespace Smart.Reflection
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    public static class AccessorHelper
    {
        private static readonly Type ValueHolderType = typeof(IValueHolder<>);

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static Type FindValueHolderType(PropertyInfo pi)
        {
            if (pi.PropertyType.IsGenericType && (pi.PropertyType.GetGenericTypeDefinition() == ValueHolderType))
            {
                return pi.PropertyType;
            }

            return pi.PropertyType.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == ValueHolderType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo GetValueTypeProperty(Type type)
        {
            return type.GetRuntimeProperty("Value");
        }
    }
}
