namespace Smart.Reflection
{
    public static class TypeMetadataFactoryExtensions
    {
        public static void ConfigurePerformance(this TypeMetadataFactory factory)
        {
            factory.ActivatorFactory = EmitTypeMetadataFactory.Default;
            factory.AccessorFactory = EmitTypeMetadataFactory.Default;
        }

        public static void ConfigureSafe(this TypeMetadataFactory factory)
        {
            factory.ActivatorFactory = ReflectionTypeMetadataFactory.Default;
            factory.AccessorFactory = ReflectionTypeMetadataFactory.Default;
        }
    }
}
