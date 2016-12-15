namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    ///
    /// </summary>
    public class ComponentContainer : IComponentContainer
    {
        private readonly IDictionary<Type, Type[]> mapping;

        private readonly IDictionary<Type, object> instances = new Dictionary<Type, object>();

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

            mapping = config.CreateMapping();
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
                lock (instances)
                {
                    foreach (var instance in instances.Values)
                    {
                        (instance as IDisposable)?.Dispose();
                    }

                    instances.Clear();
                }

                mapping.Clear();
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

            Type[] types;
            var implementationType = mapping.TryGetValue(componentType, out types) && types.Length > 0 ? types[types.Length - 1] : null;
            if (implementationType == null)
            {
                throw new InvalidOperationException(
                    String.Format(CultureInfo.InvariantCulture, "No such component registerd. component type = {0}", componentType.Name));
            }

            return ResolveInstance(implementationType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetAll(Type componentType)
        {
            Type[] types;
            if (!mapping.TryGetValue(componentType, out types))
            {
                yield break;
            }

            foreach (var implementationType in types)
            {
                yield return ResolveInstance(implementationType);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return Get(serviceType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        private object ResolveInstance(Type implementationType)
        {
            lock (instances)
            {
                object instance;
                if (instances.TryGetValue(implementationType, out instance))
                {
                    return instance;
                }

                var constructor = implementationType.GetConstructors().OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
                if (constructor == null)
                {
                    throw new InvalidOperationException(
                        String.Format(CultureInfo.InvariantCulture, "No constructor avaiable. implementation type = {0}", implementationType.Name));
                }

                var arguments = constructor.GetParameters().Select(p => Get(p.ParameterType)).ToArray();

                instance = constructor.Invoke(arguments);

                instances.Add(implementationType, instance);

                return instance;
            }
        }
    }
}
