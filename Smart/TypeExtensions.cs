namespace Smart
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using Smart.Collections.Concurrent;
    using Smart.ComponentModel;

    public static class TypeExtensions
    {
        private static readonly Type NullableType = typeof(Nullable<>);

        private static readonly Type CompilerGeneratedAttributeType = typeof(CompilerGeneratedAttribute);

        private static readonly Type GenericEnumerableType = typeof(IEnumerable<>);

        private static readonly Type EnumerableType = typeof(IEnumerable);

        private static readonly Type ObjectType = typeof(object);

        private static readonly Type ValueHolderType = typeof(IValueHolder<>);

        private static readonly ThreadsafeTypeHashArrayMap<object> DefaultValues = new ThreadsafeTypeHashArrayMap<object>();

        private static readonly Func<Type, object> NullFactory = t => null;

        private static readonly Func<Type, object> ValueFactory = Activator.CreateInstance;

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
        public static object GetDefaultValue(this Type type)
        {
            if (type.IsValueType)
            {
                if (DefaultValues.TryGetValue(type, out object value))
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
            return type.IsGenericType && (type.GetGenericTypeDefinition() == NullableType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsStruct(this Type type)
        {
            return type.IsValueType && !type.IsEnum && !type.IsPrimitive && !type.IsNullableType();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAnonymous(this Type type)
        {
            return type.IsDefined(CompilerGeneratedAttributeType, false) &&
                type.IsGenericType &&
                type.Name.Contains("AnonymousType") &&
                (type.Name.StartsWith("<>", StringComparison.Ordinal) || type.Name.StartsWith("VB$", StringComparison.Ordinal)) &&
                ((type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic) &&
                ((type.Attributes & TypeAttributes.Sealed) == TypeAttributes.Sealed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetCollectionElementType(this Type type)
        {
            if (type.HasElementType)
            {
                return type.GetElementType();
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == GenericEnumerableType)
            {
                return type.GenericTypeArguments[0];
            }

            var enumerableType = type.GetInterfaces().FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == GenericEnumerableType);
            if (enumerableType != null)
            {
                return enumerableType.GenericTypeArguments[0];
            }

            if (EnumerableType.IsAssignableFrom(type.GetTypeInfo()))
            {
                return ObjectType;
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetEnumType(this Type type)
        {
            if (type.IsEnum)
            {
                return type;
            }

            if (type.IsNullableType())
            {
                var genericType = Nullable.GetUnderlyingType(type);
                return genericType.IsEnum ? genericType : null;
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetValueHolderType(this Type type)
        {
            return type.GetInterfaces().FirstOrDefault(it => it.IsGenericType && it.GetGenericTypeDefinition() == ValueHolderType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PropertyInfo GetValueHolderProperty(this Type type)
        {
            return type.GetValueHolderType()?.GetRuntimeProperty("Value");
        }
    }
}
