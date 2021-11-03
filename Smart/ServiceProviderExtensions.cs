namespace Smart
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ServiceProviderExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? GetService<T>(this IServiceProvider provider) => (T?)provider.GetService(typeof(T));
    }
}
