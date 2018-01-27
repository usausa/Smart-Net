﻿// <auto-generated />
namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public sealed partial class DynamicDelegateFactory
    {
        private static readonly Type[] Factory0ParameterTypes = { typeof(object) };

        private static readonly Type[] Factory1ParameterTypes = { typeof(object), typeof(object) };

        private static readonly Type[] Factory2ParameterTypes = { typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory3ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory4ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory5ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory6ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory7ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory8ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory9ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory10ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory11ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory12ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory13ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory14ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory15ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type[] Factory16ParameterTypes = { typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object) };

        private static readonly Type Factory0Type = typeof(Func<object>);

        private static readonly Type Factory1Type = typeof(Func<object, object>);

        private static readonly Type Factory2Type = typeof(Func<object, object, object>);

        private static readonly Type Factory3Type = typeof(Func<object, object, object, object>);

        private static readonly Type Factory4Type = typeof(Func<object, object, object, object, object>);

        private static readonly Type Factory5Type = typeof(Func<object, object, object, object, object, object>);

        private static readonly Type Factory6Type = typeof(Func<object, object, object, object, object, object, object>);

        private static readonly Type Factory7Type = typeof(Func<object, object, object, object, object, object, object, object>);

        private static readonly Type Factory8Type = typeof(Func<object, object, object, object, object, object, object, object, object>);

        private static readonly Type Factory9Type = typeof(Func<object, object, object, object, object, object, object, object, object, object>);

        private static readonly Type Factory10Type = typeof(Func<object, object, object, object, object, object, object, object, object, object, object>);

        private static readonly Type Factory11Type = typeof(Func<object, object, object, object, object, object, object, object, object, object, object, object>);

        private static readonly Type Factory12Type = typeof(Func<object, object, object, object, object, object, object, object, object, object, object, object, object>);

        private static readonly Type Factory13Type = typeof(Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object>);

        private static readonly Type Factory14Type = typeof(Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>);

        private static readonly Type Factory15Type = typeof(Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>);

        private static readonly Type Factory16Type = typeof(Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>);

        public Func<object> CreateFactory0(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory0ParameterTypes, Factory0Type));
        }

        public Func<object, object> CreateFactory1(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory1ParameterTypes, Factory1Type));
        }

        public Func<object, object, object> CreateFactory2(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory2ParameterTypes, Factory2Type));
        }

        public Func<object, object, object, object> CreateFactory3(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory3ParameterTypes, Factory3Type));
        }

        public Func<object, object, object, object, object> CreateFactory4(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory4ParameterTypes, Factory4Type));
        }

        public Func<object, object, object, object, object, object> CreateFactory5(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory5ParameterTypes, Factory5Type));
        }

        public Func<object, object, object, object, object, object, object> CreateFactory6(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory6ParameterTypes, Factory6Type));
        }

        public Func<object, object, object, object, object, object, object, object> CreateFactory7(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory7ParameterTypes, Factory7Type));
        }

        public Func<object, object, object, object, object, object, object, object, object> CreateFactory8(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory8ParameterTypes, Factory8Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object> CreateFactory9(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory9ParameterTypes, Factory9Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object> CreateFactory10(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory10ParameterTypes, Factory10Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory11(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory11ParameterTypes, Factory11Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory12(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory12ParameterTypes, Factory12Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory13(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory13ParameterTypes, Factory13Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory14(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory14ParameterTypes, Factory14Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory15(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory15ParameterTypes, Factory15Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory16(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory16ParameterTypes, Factory16Type));
        }

    }
}