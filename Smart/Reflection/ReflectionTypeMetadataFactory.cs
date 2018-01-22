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
        private static readonly Dictionary<int, Func<ConstructorInfo, object>> SupportedActiavators = new Dictionary<int, Func<ConstructorInfo, object>>
        {
            { 0, ci => new ReflectionConstructorActivator(ci) },
            { 1, ci => new ReflectionActivatorActivator1(ci) },
            { 2, ci => new ReflectionActivatorActivator2(ci) },
            { 3, ci => new ReflectionActivatorActivator3(ci) },
            { 4, ci => new ReflectionActivatorActivator4(ci) },
            { 5, ci => new ReflectionActivatorActivator5(ci) },
            { 6, ci => new ReflectionActivatorActivator6(ci) },
            { 7, ci => new ReflectionActivatorActivator7(ci) },
            { 8, ci => new ReflectionActivatorActivator8(ci) },
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

            if (!SupportedActiavators.TryGetValue(ci.GetParameters().Length, out var factory))
            {
                throw new ArgumentException(
                    $"Constructor is unmatched for activator. length = [{ci.GetParameters().Length}], type = {typeof(TActivator)}");
            }

            var activator = factory(ci);
            if (!activator.GetType().IsInstanceOfType(typeof(TActivator)))
            {
                throw new ArgumentException(
                    $"Constructor is unmatched for activator. length = [{ci.GetParameters().Length}], type = {typeof(TActivator)}");
            }

            return (TActivator)activator;
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
