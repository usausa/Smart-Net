﻿namespace Smart.Reflection
{
    using System;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TTarget"></typeparam>
    /// <typeparam name="TMember"></typeparam>
    internal class NullableDelegateAccsessor<TTarget, TMember> : IAccessor
    {
        private readonly Func<TTarget, TMember> getter;

        private readonly Action<TTarget, TMember> setter;

        /// <summary>
        ///
        /// </summary>
        public string Name { get; }

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
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="getter"></param>
        /// <param name="setter"></param>
        public NullableDelegateAccsessor(string name, Type type, Func<TTarget, TMember> getter, Action<TTarget, TMember> setter)
        {
            Name = name;
            Type = type;
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
            return getter((TTarget)target);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            setter((TTarget)target, (TMember)value);
        }
    }
}