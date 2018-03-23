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
            { typeof(byte), (byte)0 },
            { typeof(sbyte), (sbyte)0 },
            { typeof(short), (short)0 },
            { typeof(ushort), (ushort)0 },
            { typeof(int), 0 },
            { typeof(uint), 0U },
            { typeof(long), 0L },
            { typeof(ulong), 0UL },
            { typeof(IntPtr), IntPtr.Zero },
            { typeof(UIntPtr), UIntPtr.Zero },
            { typeof(char), '\0' },
            { typeof(double), 0.0 },
            { typeof(float), 0.0f },
            { typeof(decimal), 0m }
        };

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static object GetDefaultValue(this Type type)
        {
            if (type.IsValueType && !type.IsNullableType())
            {
                if (DefaultValues.TryGetValue(type, out var value))
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
            return type.IsGenericType && (type.GetGenericTypeDefinition() == NullableType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool IsStruct(this Type type)
        {
            return type.IsValueType && !type.IsEnum && !type.IsPrimitive && !type.IsNullableType();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool IsAnonymous(this Type type)
        {
            return type.IsDefined(CompilerGeneratedAttributeType, false) &&
                type.IsGenericType &&
                type.Name.Contains("AnonymousType") &&
                (type.Name.StartsWith("<>", StringComparison.Ordinal) || type.Name.StartsWith("VB$", StringComparison.Ordinal)) &&
                ((type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic) &&
                ((type.Attributes & TypeAttributes.Sealed) == TypeAttributes.Sealed);
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static Type GetValueHolderType(this Type type)
        {
            return type.GetInterfaces().FirstOrDefault(it => it.IsGenericType && it.GetGenericTypeDefinition() == ValueHolderType);
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
