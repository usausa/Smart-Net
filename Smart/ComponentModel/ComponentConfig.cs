namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class ComponentConfig
    {
        private readonly Dictionary<Type, List<ComponentEntry>> mappings = new Dictionary<Type, List<ComponentEntry>>();

        private List<ComponentEntry> GetEntries(Type componentType)
        {
            if (mappings.TryGetValue(componentType, out var entries))
            {
                return entries;
            }

            entries = new List<ComponentEntry>();
            mappings[componentType] = entries;

            return entries;
        }

        public void Add<TComponent, TImplement>()
            where TImplement : TComponent
        {
            Add(typeof(TComponent), typeof(TImplement));
        }

        public void Add<TComponent>()
        {
            var type = typeof(TComponent);
            Add(type, type);
        }

        public void Add(Type componentType) => Add(componentType, componentType);

        public void Add(Type componentType, Type implementType)
        {
            var entries = GetEntries(componentType);
            entries.Add(new ComponentEntry(implementType));
        }

        public void Add<TComponent>(TComponent constant) => Add(typeof(TComponent), constant);

        public void Add(Type componentType, object constant)
        {
            var entries = GetEntries(componentType);
            entries.Add(new ComponentEntry(constant));
        }

        public void RemoveAll<TComponent>() => RemoveAll(typeof(TComponent));

        public void RemoveAll(Type componentType)
        {
            mappings.Remove(componentType);
        }

        public void Remove<TComponent, TImplement>() => Remove(typeof(TComponent), typeof(TImplement));

        public void Remove(Type componentType, Type implementType)
        {
            if (!mappings.TryGetValue(componentType, out var list))
            {
                return;
            }

            list.RemoveAll(x => x.ImplementType != null && x.ImplementType == implementType);
        }

        public void Remove<TComponent>(TComponent constant) => Remove(typeof(TComponent), constant);

        public void Remove(Type componentType, object constant)
        {
            if (!mappings.TryGetValue(componentType, out var list))
            {
                return;
            }

            list.RemoveAll(x => x.Constant != null && x.Constant == constant);
        }

        internal Dictionary<Type, ComponentEntry[]> ToMappings()
        {
            return mappings.ToDictionary(x => x.Key, x => x.Value.ToArray());
        }
    }
}
