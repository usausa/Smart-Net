namespace Smart.Reflection
{
    public static class DelegateFactoryExtensions
    {
        public static void ConfigurePerformance(this DelegateFactory factory)
        {
            factory.Factory = DynamicDelegateFactory.Default;
        }

        public static void ConfigureSafe(this DelegateFactory factory)
        {
            factory.Factory = ReflectionDelegateFactory.Default;
        }
    }
}
