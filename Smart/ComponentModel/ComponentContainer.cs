namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public sealed class ComponentContainer : IComponentContainer
    {
        private static readonly Type EnumerableType = typeof(IEnumerable<>);

        private static readonly Type CollectionType = typeof(ICollection<>);

        private static readonly Type ListType = typeof(IList<>);

        private static readonly object[] EmptyResult = Array.Empty<object>();

        private readonly Dictionary<Type, object[]> cache = new Dictionary<Type, object[]>();

        private readonly Dictionary<Type, ComponentEntry[]> mappings;

        public ComponentContainer(IComponentConfig config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            mappings = config.ToMappings();
        }

        ~ComponentContainer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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

        public T Get<T>() => (T)Get(typeof(T));

        public T TryGet<T>() => (T)TryGet(typeof(T));

        public IEnumerable<T> GetAll<T>() => GetAll(typeof(T)).Cast<T>();

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

            // ReSharper disable once UseIndexFromEndExpression
            return objects[objects.Length - 1];
        }

        public object TryGet(Type componentType) => TryGet(componentType, out _);

        public object TryGet(Type componentType, out bool result)
        {
            if (componentType is null)
            {
                throw new ArgumentNullException(nameof(componentType));
            }

            var objects = ResolveAll(componentType);
            result = objects.Length > 0;
            // ReSharper disable once UseIndexFromEndExpression
            return result ? objects[objects.Length - 1] : null;
        }

        public IEnumerable<object> GetAll(Type componentType)
        {
            return ResolveAll(componentType);
        }

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

        private static Array ConvertArray(Type elementType, IEnumerable<object> source)
        {
            var sourceArray = source.ToArray();
            var array = Array.CreateInstance(elementType, sourceArray.Length);
            Array.Copy(sourceArray, 0, array, 0, sourceArray.Length);
            return array;
        }
    }
}
