namespace Smart.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class ReflectionTypeMetadataFactory : IActivatorFactory, IAccessorFactory, IArrayOperatorFactory
    {
        private class ActivatorInfo
        {
            public Type Type { get; }

            public Func<ConstructorInfo, object> Factory { get; }

            public ActivatorInfo(Type type, Func<ConstructorInfo, object> factory)
            {
                Type = type;
                Factory = factory;
            }
        }

        private static readonly Dictionary<int, ActivatorInfo> SupportedActiavators = new Dictionary<int, ActivatorInfo>
        {
            { 0, new ActivatorInfo(typeof(IActivator0), ci => new ReflectionConstructorActivator(ci)) },
            { 1, new ActivatorInfo(typeof(IActivator1), ci => new ReflectionActivatorActivator1(ci)) },
            { 2, new ActivatorInfo(typeof(IActivator2), ci => new ReflectionActivatorActivator2(ci)) },
            { 3, new ActivatorInfo(typeof(IActivator3), ci => new ReflectionActivatorActivator3(ci)) },
            { 4, new ActivatorInfo(typeof(IActivator4), ci => new ReflectionActivatorActivator4(ci)) },
            { 5, new ActivatorInfo(typeof(IActivator5), ci => new ReflectionActivatorActivator5(ci)) },
            { 6, new ActivatorInfo(typeof(IActivator6), ci => new ReflectionActivatorActivator6(ci)) },
            { 7, new ActivatorInfo(typeof(IActivator7), ci => new ReflectionActivatorActivator7(ci)) },
            { 8, new ActivatorInfo(typeof(IActivator8), ci => new ReflectionActivatorActivator8(ci)) },
        };

        /// <summary>
        ///
        /// </summary>
        public static ReflectionTypeMetadataFactory Default { get; } = new ReflectionTypeMetadataFactory();

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public IActivator CreateActivator(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return ci.GetParameters().Length == 0
                ? (IActivator)new ReflectionActivatorActivator(ci)
                : new ReflectionConstructorActivator(ci);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TActivator"></typeparam>
        /// <param name="ci"></param>
        /// <returns></returns>
        public TActivator CreateActivator<TActivator>(ConstructorInfo ci)
            where TActivator : IActivator
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (!SupportedActiavators.TryGetValue(ci.GetParameters().Length, out var activatorInfo) ||
                (activatorInfo.Type != typeof(TActivator)))
            {
                throw new ArgumentException(
                    $"Constructor is unmatched for activator. length = [{ci.GetParameters().Length}], type = {typeof(TActivator)}");
            }

            return (TActivator)activatorInfo.Factory(ci);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public IAccessor CreateAccessor(PropertyInfo pi)
        {
            return CreateAccessor(pi, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public IAccessor CreateAccessor(PropertyInfo pi, bool extension)
        {
            if (pi == null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderInterface = !extension ? null : AccessorHelper.FindValueHolderType(pi);
            if (holderInterface == null)
            {
                return new ReflectionAccessor(pi);
            }

            var vpi = AccessorHelper.GetValueTypeProperty(holderInterface);
            return new ReflectionValueHolderAccessor(pi, vpi);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IArrayOperator CreateArrayOperator(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return new ReflectionArrayOperator(type);
        }
    }
}
