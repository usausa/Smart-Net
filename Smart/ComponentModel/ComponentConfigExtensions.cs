namespace Smart.ComponentModel
{
    public static class ComponentConfigExtensions
    {
        public static ComponentContainer ToContainer(this IComponentConfig config)
        {
            return new ComponentContainer(config);
        }
    }
}
