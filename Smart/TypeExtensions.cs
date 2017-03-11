namespace Smart
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    public static class TypeExtensions
    {
        private static readonly Type NullableType = typeof(Nullable<>);

        private static readonly Type CompilerGeneratedAttributeType = typeof(CompilerGeneratedAttribute);

        private static readonly Type GenericEnumerableType = typeof(IEnumerable<>);

        private static readonly Type EnumerableType = typeof(IEnumerable);

        private static readonly Type ObjectType = typeof(object);

        private static readonly Type ValueHolderType = typeof(IValueHolder<>);

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
            if (type.GetTypeInfo().IsValueType && !type.IsNullableType())
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
            return type.GetTypeInfo().IsGenericType && (type.GetGenericTypeDefinition() == NullableType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool IsStruct(this Type type)
        {
            return type.GetTypeInfo().IsValueType && !type.GetTypeInfo().IsEnum && !type.GetTypeInfo().IsPrimitive && !type.IsNullableType();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool IsAnonymous(this Type type)
        {
            return type.GetTypeInfo().IsDefined(CompilerGeneratedAttributeType, false) &&
                type.GetTypeInfo().IsGenericType &&
                type.Name.Contains("AnonymousType") &&
                (type.Name.StartsWith("<>", StringComparison.Ordinal) || type.Name.StartsWith("VB$", StringComparison.Ordinal)) &&
                ((type.GetTypeInfo().Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic) &&
                ((type.GetTypeInfo().Attributes & TypeAttributes.Sealed) == TypeAttributes.Sealed);
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

            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == GenericEnumerableType)
            {
                return type.GenericTypeArguments[0];
            }

            var enumerableType = type.GetTypeInfo().ImplementedInterfaces.FirstOrDefault(t => t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == GenericEnumerableType);
            if (enumerableType != null)
            {
                return enumerableType.GenericTypeArguments[0];
            }

            if (EnumerableType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
            {
                return ObjectType;
            }

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
            if (type.GetTypeInfo().IsEnum)
            {
                return type;
            }

            if (type.IsNullableType())
            {
                var genericType = Nullable.GetUnderlyingType(type);
                return genericType.GetTypeInfo().IsEnum ? genericType : null;
            }

            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static Type GetValueHolderType(this Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces.FirstOrDefault(it => it.GetTypeInfo().IsGenericType && it.GetGenericTypeDefinition() == ValueHolderType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo GetValueHolderProperty(this Type type)
        {
            return type.GetValueHolderType()?.GetRuntimeProperty("Value");
        }
    }
}
