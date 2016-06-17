namespace Smart
{
    using System;
    using System.Collections.Concurrent;
#if PCL
    using System.Reflection;
#endif

    /// <summary>
    ///
    /// </summary>
    public static class DefaultValue
    {
        private static readonly ConcurrentDictionary<Type, object> Cache = new ConcurrentDictionary<Type, object>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Of(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

#if PCL
            if (type.GetTypeInfo().IsValueType && (Nullable.GetUnderlyingType(type) == null))
#else
            if (type.IsValueType && (Nullable.GetUnderlyingType(type) == null))
#endif
            {
                object value;
                if (!Cache.TryGetValue(type, out value))
                {
                    value = Activator.CreateInstance(type);
                    Cache[type] = value;
                }

                return value;
            }

            return null;
        }
    }
}
