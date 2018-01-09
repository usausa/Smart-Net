namespace Smart.Reflection
{
    /// <summary>
    ///
    /// </summary>
    public static class TypeMetadataFactoryExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="factory"></param>
        public static void ConfigurePerformance(this TypeMetadataFactory factory)
        {
            factory.ActivatorFactory = EmitTypeMetadataFactory.Default;
            factory.AccessorFactory = EmitTypeMetadataFactory.Default;
            factory.ArrayOperatorFactory = EmitTypeMetadataFactory.Default;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="factory"></param>
        public static void ConfigureSafe(this TypeMetadataFactory factory)
        {
            factory.ActivatorFactory = ReflectionTypeMetadataFactory.Default;
            factory.AccessorFactory = ReflectionTypeMetadataFactory.Default;
            factory.ArrayOperatorFactory = ReflectionTypeMetadataFactory.Default;
        }
    }
}
