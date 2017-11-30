namespace Smart.Reflection
{
    public static class TypeMetadataFactoryExtensions
    {
        public static void ConfigurePerformance(this TypeMetadataFactory factory)
        {
            factory.AccessorFactory = EmitTypeMetadataFactory.Default;
            factory.AccessorFactory = EmitTypeMetadataFactory.Default;
        }

        public static void ConfigureSafe(this TypeMetadataFactory factory)
        {
            factory.AccessorFactory = ReflectionTypeMetadataFactory.Default;
            factory.AccessorFactory = ReflectionTypeMetadataFactory.Default;
        }
    }
}
