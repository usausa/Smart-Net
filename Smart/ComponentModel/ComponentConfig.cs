namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///
    /// </summary>
    public class ComponentConfig : IComponentConfig
    {
        private readonly IDictionary<Type, ICollection<Type>> entries = new Dictionary<Type, ICollection<Type>>();

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        public void Add<TComponent, TImplement>()
            where TImplement : TComponent
        {
            Add(typeof(TComponent), typeof(TImplement));
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        public void Add<TComponent>()
        {
            var type = typeof(TComponent);
            Add(type, type);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        public void Add(Type componentType)
        {
            Add(componentType, componentType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        /// <param name="implementType"></param>
        public void Add(Type componentType, Type implementType)
        {
            if (componentType == null)
            {
                throw new ArgumentNullException(nameof(componentType));
            }

            if (implementType == null)
            {
                throw new ArgumentNullException(nameof(implementType));
            }

            if (!componentType.IsAssignableFrom(implementType))
            {
                throw new ArgumentException("Implement type is not component type.", nameof(implementType));
            }

            ICollection<Type> list;
            if (!entries.TryGetValue(componentType, out list))
            {
                list = new List<Type>();
                entries[componentType] = list;
            }

            list.Add(implementType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        public void RemoveAll<TComponent>()
        {
            RemoveAll(typeof(TComponent));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        public void RemoveAll(Type componentType)
        {
            entries.Remove(componentType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IDictionary<Type, Type[]> CreateMapping()
        {
            var mapping = new Dictionary<Type, Type[]>();
            foreach (var entry in entries)
            {
                mapping[entry.Key] = entry.Value.ToArray();
            }

            return mapping;
        }
    }
}
