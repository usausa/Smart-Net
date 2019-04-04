namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    ///
    /// </summary>
    public sealed class ComponentContainer : IComponentContainer
    {
        private static readonly Type EnumerableType = typeof(IEnumerable<>);

        private static readonly Type CollectionType = typeof(ICollection<>);

        private static readonly Type ListType = typeof(IList<>);

        private static readonly object[] EmptyResult = Array.Empty<object>();

        private readonly Dictionary<Type, object[]> cache = new Dictionary<Type, object[]>();

        private readonly Dictionary<Type, ComponentEntry[]> mappings;

        /// <summary>
        ///
        /// </summary>
        /// <param name="config"></param>
        public ComponentContainer(IComponentConfig config)
        {
            if (config is null)
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
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (cache)
                {
                    var disposed = new HashSet<object>();
                    foreach (var instance in cache.Values.SelectMany(x => x))
                    {
                        if (instance is IDisposable disposable)
                        {
                            disposable.Dispose();
                            disposed.Add(instance);
                        }
                    }

                    foreach (var entry in mappings.Values.SelectMany(x => x))
                    {
                        if ((entry.Constant is IDisposable disposable) && !disposed.Contains(disposable))
                        {
                            disposable.Dispose();
                        }
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
            if (componentType is null)
            {
                throw new ArgumentNullException(nameof(componentType));
            }

            var objects = ResolveAll(componentType);
            if (objects.Length == 0)
            {
                throw new InvalidOperationException(
                    String.Format(CultureInfo.InvariantCulture, "No such component registered. component type = {0}", componentType.Name));
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
            return TryGet(componentType, out _);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public object TryGet(Type componentType, out bool result)
        {
            if (componentType is null)
            {
                throw new ArgumentNullException(nameof(componentType));
            }

            var objects = ResolveAll(componentType);
            result = objects.Length > 0;
            return result ? objects[objects.Length - 1] : null;
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
            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (serviceType.IsGenericType && serviceType.GetGenericTypeDefinition() == EnumerableType)
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
                if (cache.TryGetValue(componentType, out var objects))
                {
                    return objects;
                }

                if (!mappings.TryGetValue(componentType, out var entries))
                {
                    return EmptyResult;
                }

                objects = entries
                    .Select(entry => entry.Constant ?? CreateInstance(entry.ImplementType))
                    .ToArray();
                cache[componentType] = objects;

                return objects;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private object CreateInstance(Type type)
        {
            foreach (var ci in type.GetConstructors().OrderByDescending(c => c.GetParameters().Length))
            {
                if (ci.GetParameters().Length == 0)
                {
                    return ci.Invoke(null);
                }

                var match = true;
                var arguments = new object[ci.GetParameters().Length];
                for (var i = 0; i < arguments.Length; i++)
                {
                    var pi = ci.GetParameters()[i];
                    var elementType = GetElementType(pi.ParameterType);
                    if (elementType is null)
                    {
                        arguments[i] = TryGet(pi.ParameterType, out match);
                    }
                    else
                    {
                        arguments[i] = ConvertArray(elementType, GetAll(elementType));
                    }

                    if (!match)
                    {
                        break;
                    }
                }

                if (!match)
                {
                    continue;
                }

                return ci.Invoke(arguments);
            }

            throw new InvalidOperationException(
                String.Format(CultureInfo.InvariantCulture, "Constructor parameter unresolved. implementation type = {0}", type.Name));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Type GetElementType(Type type)
        {
            if (type.IsArray)
            {
                return type.GetElementType();
            }

            if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();
                if ((genericType == EnumerableType) || (genericType == CollectionType) || (genericType == ListType))
                {
                    return type.GenericTypeArguments[0];
                }
            }

            return null;
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
