namespace Smart.ComponentModel
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class ValueHolderHelper
    {
        private static readonly Type ValueHolderType = typeof(IValueHolder<>);

        public static bool IsValueHolderType(Type type)
        {
            if (type.IsGenericType && (type.GetGenericTypeDefinition() == ValueHolderType))
            {
                return true;
            }

            return type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == ValueHolderType);
        }

        public static Type? FindValueHolderType(PropertyInfo pi)
        {
            if (pi.PropertyType.IsGenericType && (pi.PropertyType.GetGenericTypeDefinition() == ValueHolderType))
            {
                return pi.PropertyType;
            }

            return pi.PropertyType.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == ValueHolderType);
        }

        public static PropertyInfo? GetValueTypeProperty(Type type)
        {
            return type.GetRuntimeProperty("Value");
        }
    }
}
