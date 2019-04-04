namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;

    public interface IComponentConfig
    {
        Dictionary<Type, ComponentEntry[]> ToMappings();
    }
}
