namespace Smart
{
    using System;
#if PCL
    using System.Collections.Generic;
#endif
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public static class TypeAbstraction
    {
        //--------------------------------------------------------------------------------
        // Attributes
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static TypeAttributes GetTypeAttributes(this Type type)
        {
#if PCL
            return type.GetTypeInfo().Attributes;
#else
            return type.Attributes;
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool GetIsAbstract(this Type type)
        {
#if PCL
            return type.GetTypeInfo().IsAbstract;
#else
            return type.IsAbstract;
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool GetIsValueType(this Type type)
        {
#if PCL
            return type.GetTypeInfo().IsValueType;
#else
            return type.IsValueType;
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool GetIsEnum(this Type type)
        {
#if PCL
            return type.GetTypeInfo().IsEnum;
#else
            return type.IsEnum;
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool GetIsGenericType(this Type type)
        {
#if PCL
            return type.GetTypeInfo().IsGenericType;
#else
            return type.IsGenericType;
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool GetContainsGenericParameters(this Type type)
        {
#if PCL
            return type.GetTypeInfo().ContainsGenericParameters;
#else
            return type.ContainsGenericParameters;
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool GetIsInterface(this Type type)
        {
#if PCL
            return type.GetTypeInfo().IsInterface;
#else
            return type.IsInterface;
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool GetIsPrimitive(this Type type)
        {
#if PCL
            return type.GetTypeInfo().IsPrimitive;
#else
            return type.IsPrimitive;
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Ignore")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool GetIsDefined(this Type type, Type attributeType, bool inherit)
        {
#if PCL
            return type.GetTypeInfo().IsDefined(attributeType, inherit);
#else
            return type.IsDefined(attributeType, inherit);
#endif
        }

#if PCL
        //--------------------------------------------------------------------------------
        // PCL
        //--------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static IEnumerable<ConstructorInfo> GetConstructors(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors;
        }

        //--------------------------------------------------------------------------------
        // Method
        //--------------------------------------------------------------------------------

            /// <summary>
            ///
            /// </summary>
            /// <param name="source"></param>
            /// <param name="name"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
        public static MethodInfo GetMethod(this Type source, string name, Type[] parameters)
        {
            return source.GetRuntimeMethod(name, parameters);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetMethods(this Type source)
        {
            return source.GetRuntimeMethods();
        }

        //--------------------------------------------------------------------------------
        // Property
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static PropertyInfo GetProperty(this Type type, string name)
        {
            return type.GetRuntimeProperty(name);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static IEnumerable<PropertyInfo> GetProperties(this Type type)
        {
            return type.GetRuntimeProperties();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="nonPublic"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static MethodInfo GetGetMethod(this PropertyInfo pi, bool nonPublic)
        {
            var mi = pi.GetMethod;
            return (nonPublic || mi.IsPublic) ? mi : null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="nonPublic"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static MethodInfo GetSetMethod(this PropertyInfo pi, bool nonPublic)
        {
            var mi = pi.SetMethod;
            return (nonPublic || mi.IsPublic) ? mi : null;
        }

        //--------------------------------------------------------------------------------
        // Field
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static FieldInfo GetField(this Type source, string name)
        {
            return source.GetRuntimeField(name);
        }

        //--------------------------------------------------------------------------------
        // Interface
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static IEnumerable<Type> GetInterfaces(this Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces;
        }

        //--------------------------------------------------------------------------------
        // Attributes
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Ignore")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static bool IsAssignableFrom(this Type type, Type c)
        {
            return type.GetTypeInfo().IsAssignableFrom(c.GetTypeInfo());
        }
#endif
    }
}