namespace Smart.Reflection
{
    public static class TypeMetadataFactoryExtensions
    {
        public static void ConfigurePerformance(this TypeMetadataFactory factory)
        {
            factory.AccessorFactory = CodeGenerateTypeMetadataFactory.Default;
            factory.AccessorFactory = CodeGenerateTypeMetadataFactory.Default;
        }

        public static void ConfigureSafe(this TypeMetadataFactory factory)
        {
            factory.AccessorFactory = ReflectionTypeMetadataFactory.Default;
            factory.AccessorFactory = ReflectionTypeMetadataFactory.Default;
        }
    }
}
