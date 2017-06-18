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
            return pi.PropertyType.GetTypeInfo().ImplementedInterfaces
                .FirstOrDefault(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == ValueHolderType);
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
