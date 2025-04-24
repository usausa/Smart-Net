namespace Smart.ComponentModel;

using System.Reflection;

public static class ValueHolderHelper
{
    public static bool IsValueHolderType(Type type)
    {
        if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(IValueHolder<>)))
        {
            return true;
        }

        return type.GetInterfaces()
            .Any(static i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValueHolder<>));
    }

    public static Type? FindValueHolderType(PropertyInfo pi)
    {
        if (pi.PropertyType.IsGenericType && (pi.PropertyType.GetGenericTypeDefinition() == typeof(IValueHolder<>)))
        {
            return pi.PropertyType;
        }

        return pi.PropertyType.GetInterfaces()
            .FirstOrDefault(static i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValueHolder<>));
    }

    public static PropertyInfo? GetValueTypeProperty(Type type)
    {
        return type.GetRuntimeProperty(nameof(IValueHolder<>.Value));
    }
}
