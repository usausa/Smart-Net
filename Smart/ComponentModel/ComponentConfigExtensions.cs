namespace Smart.ComponentModel
{
    public static class ComponentConfigExtensions
    {
        public static ComponentContainer ToContainer(this ComponentConfig config) => new(config);
    }
}
