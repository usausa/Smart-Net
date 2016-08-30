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
    internal static class TypeAbstraction
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
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
        public static bool GetIsDefined(this Type type, Type attributeType, bool inherit)
        {
#if PCL
            return type.GetTypeInfo().IsDefined(attributeType, inherit);
#else
            return type.IsDefined(attributeType, inherit);
#endif
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TypeAttributes GetTypeAttributes(this Type type)
        {
#if PCL
            return type.GetTypeInfo().Attributes;
#else
            return type.Attributes;
#endif
        }

#if PCL
    /// <summary>
    ///
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
        public static IEnumerable<Type> GetInterfaces(this Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<ConstructorInfo> GetConstructors(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyInfo GetProperty(this Type type, string name)
        {
            return type.GetRuntimeProperty(name);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsAssignableFrom(this Type type, Type c)
        {
            return type.GetTypeInfo().IsAssignableFrom(c.GetTypeInfo());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="nonPublic"></param>
        /// <returns></returns>
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
        public static MethodInfo GetSetMethod(this PropertyInfo pi, bool nonPublic)
        {
            var mi = pi.SetMethod;
            return (nonPublic || mi.IsPublic) ? mi : null;
        }
#endif
    }
}