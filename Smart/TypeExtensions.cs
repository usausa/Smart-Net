namespace Smart
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///
    /// </summary>
    public static class TypeExtensions
    {
        private static readonly Type NullableType = typeof(Nullable<>);

        private static readonly Type CompilerGeneratedAttributeType = typeof(CompilerGeneratedAttribute);

        private static readonly Type GenericEnumerableType = typeof(IEnumerable<>);

#if PCL
        private static readonly TypeInfo EnumerableTypeInfo = typeof(IEnumerable).GetTypeInfo();
#else
        private static readonly Type EnumerableType = typeof(IEnumerable);
#endif

        private static readonly Type ObjectType = typeof(object);

        private static readonly Dictionary<Type, object> DefaultValues = new Dictionary<Type, object>
        {
            { typeof(bool), false },
            { typeof(byte), 0 },
            { typeof(sbyte), 0 },
            { typeof(short), 0 },
            { typeof(ushort), 0 },
            { typeof(int), 0 },
            { typeof(uint), 0U },
            { typeof(long), 0L },
            { typeof(ulong), 0UL },
            { typeof(IntPtr), IntPtr.Zero },
            { typeof(UIntPtr), UIntPtr.Zero },
            { typeof(char), '\0' },
            { typeof(double), 0.0 },
            { typeof(float), 0.0f }
        };

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static object GetDefaultValue(this Type type)
        {
#if PCL
            var typeInfo = type.GetTypeInfo();

            if (typeInfo.IsValueType && !(typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == NullableType))
#else
            if (type.IsValueType && !(type.IsGenericType && type.GetGenericTypeDefinition() == NullableType))
#endif
            {
                object value;
                if (DefaultValues.TryGetValue(type, out value))
                {
                    return value;
                }

                return Activator.CreateInstance(type);
            }

            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool IsNullableType(this Type type)
        {
#if PCL
            var typeInfo = type.GetTypeInfo();

            return typeInfo.IsGenericType && (typeInfo.GetGenericTypeDefinition() == NullableType);
#else
            return type.IsGenericType && (type.GetGenericTypeDefinition() == NullableType);
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool IsStruct(this Type type)
        {
#if PCL
            var typeInfo = type.GetTypeInfo();

            return typeInfo.IsValueType && !typeInfo.IsEnum && !typeInfo.IsPrimitive &&
                !(typeInfo.IsGenericType && (typeInfo.GetGenericTypeDefinition() == NullableType));
#else
            return type.IsValueType && !type.IsEnum && !type.IsPrimitive &&
                !(type.IsGenericType && (type.GetGenericTypeDefinition() == NullableType));
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool IsAnonymous(this Type type)
        {
#if PCL
            var typeInfo = type.GetTypeInfo();

            return (typeInfo.GetCustomAttribute(CompilerGeneratedAttributeType, false) != null) &&
                typeInfo.IsGenericType &&
                type.Name.Contains("AnonymousType") &&
                (type.Name.StartsWith("<>", StringComparison.Ordinal) || type.Name.StartsWith("VB$", StringComparison.Ordinal)) &&
                ((typeInfo.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic) &&
                ((typeInfo.Attributes & TypeAttributes.Sealed) == TypeAttributes.Sealed);
#else
            return Attribute.IsDefined(type, CompilerGeneratedAttributeType, false) &&
                type.IsGenericType &&
                type.Name.Contains("AnonymousType") &&
                (type.Name.StartsWith("<>", StringComparison.Ordinal) || type.Name.StartsWith("VB$", StringComparison.Ordinal)) &&
                ((type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic) &&
                ((type.Attributes & TypeAttributes.Sealed) == TypeAttributes.Sealed);
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static Type GetCollectionElementType(this Type type)
        {
            if (type.HasElementType)
            {
                return type.GetElementType();
            }

#if PCL
            var typeInfo = type.GetTypeInfo();

            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == GenericEnumerableType)
            {
                return typeInfo.GenericTypeArguments[0];
            }

            var enumerableType = typeInfo.ImplementedInterfaces
                .FirstOrDefault(t => t.GetTypeInfo().IsGenericType && t.GetTypeInfo().GetGenericTypeDefinition() == GenericEnumerableType);
            if (enumerableType != null)
            {
                return enumerableType.GetTypeInfo().GenericTypeArguments[0];
            }

            if (EnumerableTypeInfo.IsAssignableFrom(typeInfo))
            {
                return ObjectType;
            }
#else
            if (type.IsGenericType && type.GetGenericTypeDefinition() == GenericEnumerableType)
            {
                return type.GenericTypeArguments[0];
            }

            var enumerableType = type.GetInterfaces().FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == GenericEnumerableType);
            if (enumerableType != null)
            {
                return enumerableType.GenericTypeArguments[0];
            }

            if (EnumerableType.IsAssignableFrom(type))
            {
                return ObjectType;
            }
#endif

            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static Type GetNonNullableType(this Type type)
        {
#if PCL
            var typeInfo = type.GetTypeInfo();

            if (typeInfo.IsGenericType && (typeInfo.GetGenericTypeDefinition() == NullableType))
            {
                return typeInfo.GenericTypeArguments[0];
            }
#else
            if (type.IsGenericType && (type.GetGenericTypeDefinition() == NullableType))
            {
                return type.GenericTypeArguments[0];
            }
#endif

            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static Type GetEnumType(this Type type)
        {
#if PCL
            var typeInfo = type.GetTypeInfo();

            if (typeInfo.IsEnum)
            {
                return type;
            }

            if (typeInfo.IsGenericType && (type.GetGenericTypeDefinition() == NullableType))
            {
                var genericType = typeInfo.GenericTypeArguments[0];
                return genericType.GetTypeInfo().IsEnum ? genericType : null;
            }
#else
            if (type.IsEnum)
            {
                return type;
            }

            if (type.IsGenericType && (type.GetGenericTypeDefinition() == NullableType))
            {
                var genericType = type.GenericTypeArguments[0];
                return genericType.IsEnum ? genericType : null;
            }
#endif

            return null;
        }
    }
}
