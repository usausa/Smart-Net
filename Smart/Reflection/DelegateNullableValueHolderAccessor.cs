namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TTarget"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    internal class DelegateNullableValueHolderAccessor<TTarget, TValue> : IAccessor
    {
        private readonly Func<TTarget, IValueHolder<TValue>> holderGetter;

        private readonly Func<IValueHolder<TValue>, TValue> getter;

        private readonly Action<IValueHolder<TValue>, TValue> setter;

        /// <summary>
        ///
        /// </summary>
        public PropertyInfo Source { get; }

        /// <summary>
        ///
        /// </summary>
        public string Name => Source.Name;

        /// <summary>
        ///
        /// </summary>
        public Type Type { get; }

        /// <summary>
        ///
        /// </summary>
        public bool CanRead => getter != null;

        /// <summary>
        ///
        /// </summary>
        public bool CanWrite => setter != null;

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="holderGetter"></param>
        /// <param name="getter"></param>
        /// <param name="setter"></param>
        public DelegateNullableValueHolderAccessor(PropertyInfo source, Type type, Func<TTarget, IValueHolder<TValue>> holderGetter, Func<IValueHolder<TValue>, TValue> getter, Action<IValueHolder<TValue>, TValue> setter)
        {
            Source = source;
            Type = type;
            this.holderGetter = holderGetter;
            this.getter = getter;
            this.setter = setter;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            var holder = holderGetter((TTarget)target);
            return getter(holder);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            var holder = holderGetter((TTarget)target);
            setter(holder, (TValue)value);
        }
    }
}
