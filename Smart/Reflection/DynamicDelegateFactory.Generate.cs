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
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory0ParameterTypes, Factory0Type));
        }

        public Func<object, object> CreateFactory1(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory1ParameterTypes, Factory1Type));
        }

        public Func<object, object, object> CreateFactory2(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory2ParameterTypes, Factory2Type));
        }

        public Func<object, object, object, object> CreateFactory3(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory3ParameterTypes, Factory3Type));
        }

        public Func<object, object, object, object, object> CreateFactory4(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory4ParameterTypes, Factory4Type));
        }

        public Func<object, object, object, object, object, object> CreateFactory5(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory5ParameterTypes, Factory5Type));
        }

        public Func<object, object, object, object, object, object, object> CreateFactory6(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory6ParameterTypes, Factory6Type));
        }

        public Func<object, object, object, object, object, object, object, object> CreateFactory7(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory7ParameterTypes, Factory7Type));
        }

        public Func<object, object, object, object, object, object, object, object, object> CreateFactory8(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory8ParameterTypes, Factory8Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object> CreateFactory9(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory9ParameterTypes, Factory9Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object> CreateFactory10(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory10ParameterTypes, Factory10Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory11(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory11ParameterTypes, Factory11Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory12(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory12ParameterTypes, Factory12Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory13(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory13ParameterTypes, Factory13Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory14(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory14ParameterTypes, Factory14Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory15(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory15ParameterTypes, Factory15Type));
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory16(ConstructorInfo ci)
        {
            if (ci is null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            return (Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(x, Factory16ParameterTypes, Factory16Type));
        }

        public Func<T> CreateFactory<T>()
        {
            var ci = typeof(T).GetConstructor(Type.EmptyTypes);
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T) },
                    typeof(Func<T>)));
        }

        public Func<TP1, T> CreateFactory<TP1, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1) },
                    typeof(Func<TP1, T>)));
        }

        public Func<TP1, TP2, T> CreateFactory<TP1, TP2, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2) },
                    typeof(Func<TP1, TP2, T>)));
        }

        public Func<TP1, TP2, TP3, T> CreateFactory<TP1, TP2, TP3, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3) },
                    typeof(Func<TP1, TP2, TP3, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, T> CreateFactory<TP1, TP2, TP3, TP4, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4) },
                    typeof(Func<TP1, TP2, TP3, TP4, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12), typeof(TP13) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12), typeof(TP13) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12), typeof(TP13), typeof(TP14) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12), typeof(TP13), typeof(TP14) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12), typeof(TP13), typeof(TP14), typeof(TP15) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12), typeof(TP13), typeof(TP14), typeof(TP15) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, T>)));
        }

        public Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, T>()
        {
            var ci = typeof(T).GetConstructor(new[] { typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12), typeof(TP13), typeof(TP14), typeof(TP15), typeof(TP16) });
            if (ci is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, T>)typedFactoryCache
                .GetOrAdd(ci, x=> CreateFactoryInternal(
                    ci,
                    typeof(T),
                    new[] { typeof(T), typeof(TP1), typeof(TP2), typeof(TP3), typeof(TP4), typeof(TP5), typeof(TP6), typeof(TP7), typeof(TP8), typeof(TP9), typeof(TP10), typeof(TP11), typeof(TP12), typeof(TP13), typeof(TP14), typeof(TP15), typeof(TP16) },
                    typeof(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, T>)));
        }

    }
}
