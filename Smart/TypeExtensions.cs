namespace Smart;

using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

using Smart.Collections.Concurrent;
using Smart.ComponentModel;

public static class TypeExtensions
{
    private static readonly ThreadsafeTypeHashArrayMap<object?> DefaultValues = new();

    private static readonly Func<Type, object?> NullFactory = static _ => null;

    private static readonly Func<Type, object?> ValueFactory = Activator.CreateInstance;

    static TypeExtensions()
    {
        DefaultValues.AddIfNotExist(typeof(bool), default(bool));
        DefaultValues.AddIfNotExist(typeof(byte), default(byte));
        DefaultValues.AddIfNotExist(typeof(sbyte), default(sbyte));
        DefaultValues.AddIfNotExist(typeof(short), default(short));
        DefaultValues.AddIfNotExist(typeof(ushort), default(ushort));
        DefaultValues.AddIfNotExist(typeof(int), default(int));
        DefaultValues.AddIfNotExist(typeof(uint), default(uint));
        DefaultValues.AddIfNotExist(typeof(long), default(long));
        DefaultValues.AddIfNotExist(typeof(ulong), default(ulong));
        DefaultValues.AddIfNotExist(typeof(IntPtr), default(IntPtr));
        DefaultValues.AddIfNotExist(typeof(UIntPtr), default(UIntPtr));
        DefaultValues.AddIfNotExist(typeof(char), default(char));
        DefaultValues.AddIfNotExist(typeof(double), default(double));
        DefaultValues.AddIfNotExist(typeof(float), default(float));
        DefaultValues.AddIfNotExist(typeof(decimal), default(decimal));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object? GetDefaultValue(this Type type)
    {
        if (type.IsValueType)
        {
            if (DefaultValues.TryGetValue(type, out var value))
            {
                return value;
            }

            if (type.IsNullableType())
            {
                return DefaultValues.AddIfNotExist(type, NullFactory);
            }

            return DefaultValues.AddIfNotExist(type, ValueFactory);
        }

        return null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullableType(this Type type)
    {
        return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAnonymous(this Type type)
    {
        return type.IsDefined(typeof(CompilerGeneratedAttribute), false) &&
            type.IsGenericType &&
            type.Name.Contains("AnonymousType", StringComparison.Ordinal) &&
            (type.Name.StartsWith("<>", StringComparison.Ordinal) || type.Name.StartsWith("VB$", StringComparison.Ordinal)) &&
            ((type.Attributes & TypeAttributes.Sealed) == TypeAttributes.Sealed);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Type? GetCollectionElementType(this Type type)
    {
        if (type.HasElementType)
        {
            return type.GetElementType();
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            return type.GenericTypeArguments[0];
        }

        var enumerableType = type.GetInterfaces()
            .FirstOrDefault(static t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        if (enumerableType is not null)
        {
            return enumerableType.GenericTypeArguments[0];
        }

        if (typeof(IEnumerable).IsAssignableFrom(type.GetTypeInfo()))
        {
            return typeof(object);
        }

        return null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Type? GetEnumType(this Type type)
    {
        if (type.IsEnum)
        {
            return type;
        }

        var genericType = Nullable.GetUnderlyingType(type);
        return genericType is not null && genericType.IsEnum ? genericType : null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Type? GetValueHolderType(this Type type)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IValueHolder<>))
        {
            return type;
        }

        return type.GetInterfaces().FirstOrDefault(static it => it.IsGenericType && it.GetGenericTypeDefinition() == typeof(IValueHolder<>));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PropertyInfo? GetValueHolderProperty(this Type type)
    {
        return type.GetValueHolderType()?.GetRuntimeProperty("Value");
    }
}
