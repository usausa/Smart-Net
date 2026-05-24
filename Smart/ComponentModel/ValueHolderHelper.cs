namespace Smart.ComponentModel;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

public static class ValueHolderHelper
{
    public static bool IsValueHolderType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)] Type type)
    {
        if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(IValueHolder<>)))
        {
            return true;
        }

        return type.GetInterfaces()
            .Any(static i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValueHolder<>));
    }

    [UnconditionalSuppressMessage("Trimming", "IL2075", Justification = "PropertyInfo.PropertyType cannot be annotated; IValueHolder<> is a known framework type and its interfaces are preserved.")]
    [UnconditionalSuppressMessage("Trimming", "IL2073", Justification = "PropertyInfo.PropertyType and FirstOrDefault cannot propagate DynamicallyAccessedMembers; IValueHolder<> is a known type whose properties are preserved.")]
    [return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)]
    public static Type? FindValueHolderType(PropertyInfo pi)
    {
        if (pi.PropertyType.IsGenericType && (pi.PropertyType.GetGenericTypeDefinition() == typeof(IValueHolder<>)))
        {
            return pi.PropertyType;
        }

        return pi.PropertyType.GetInterfaces()
            .FirstOrDefault(static i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValueHolder<>));
    }

    public static PropertyInfo? GetValueTypeProperty([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] Type type)
    {
        return type.GetRuntimeProperty(nameof(IValueHolder<>.Value));
    }
}
