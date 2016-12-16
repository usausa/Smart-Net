namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public class ComponentContainer : IComponentContainer
    {
        private static readonly Type EnumerableType = typeof(IEnumerable<>);

        private static readonly object[] EmptyResult = new object[0];

        private readonly IDictionary<Type, object[]> cache = new Dictionary<Type, object[]>();

        private readonly IDictionary<Type, ComponentEntry[]> mappings;

        /// <summary>
        ///
        /// </summary>
        /// <param name="config"></param>
        public ComponentContainer(IComponentConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            mappings = config.ToMappings();
        }

        /// <summary>
        ///
        /// </summary>
        ~ComponentContainer()
        {
            Dispose(false);
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (cache)
                {
                    foreach (var instance in cache.Values.SelectMany(x => x))
                    {
                        (instance as IDisposable)?.Dispose();
                    }

                    foreach (var entry in mappings.Values.SelectMany(x => x))
                    {
                        (entry.Constant as IDisposable)?.Dispose();
                    }

                    cache.Clear();
                    mappings.Clear();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T TryGet<T>()
        {
            return (T)TryGet(typeof(T));
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>()
        {
            return GetAll(typeof(T)).Cast<T>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns></returns>
        public object Get(Type componentType)
        {
            if (componentType == null)
            {
                throw new ArgumentNullException(nameof(componentType));
            }

            var objects = ResolveAll(componentType);
            if (objects.Length == 0)
            {
                throw new InvalidOperationException(
                    String.Format(CultureInfo.InvariantCulture, "No such component registerd. component type = {0}", componentType.Name));
            }

            return objects[objects.Length - 1];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns></returns>
        public object TryGet(Type componentType)
        {
            if (componentType == null)
            {
                throw new ArgumentNullException(nameof(componentType));
            }

            var objects = ResolveAll(componentType);
            return objects.Length > 0 ? objects[objects.Length - 1] : null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetAll(Type componentType)
        {
            return ResolveAll(componentType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (serviceType.GetTypeInfo().IsGenericType && serviceType.GetGenericTypeDefinition() == EnumerableType)
            {
                return ConvertArray(serviceType.GenericTypeArguments[0], GetAll(serviceType.GenericTypeArguments[0]));
            }

            return TryGet(serviceType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns></returns>
        private object[] ResolveAll(Type componentType)
        {
            lock (cache)
            {
                object[] objects;
                if (cache.TryGetValue(componentType, out objects))
                {
                    return objects;
                }

                ComponentEntry[] entries;
                if (!mappings.TryGetValue(componentType, out entries))
                {
                    return EmptyResult;
                }

                mappings.Remove(componentType);

                var list = new List<object>();
                foreach (var entry in entries)
                {
                    if (entry.Constant != null)
                    {
                        list.Add(entry.Constant);
                    }
                    else
                    {
                        var constructor = entry.ImplementType.GetConstructors().OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
                        if (constructor == null)
                        {
                            throw new InvalidOperationException(
                                String.Format(CultureInfo.InvariantCulture, "No constructor avaiable. implementation type = {0}", entry.ImplementType.Name));
                        }

                        var arguments = constructor.GetParameters().Select(p => Get(p.ParameterType)).ToArray();
                        var instance = constructor.Invoke(arguments);
                        list.Add(instance);
                    }
                }

                objects = list.ToArray();
                cache[componentType] = objects;

                return objects;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private static Array ConvertArray(Type elementType, IEnumerable<object> source)
        {
            var sourceArray = source.ToArray();
            var array = Array.CreateInstance(elementType, sourceArray.Length);
            Array.Copy(sourceArray, 0, array, 0, sourceArray.Length);
            return array;
        }
    }
}
