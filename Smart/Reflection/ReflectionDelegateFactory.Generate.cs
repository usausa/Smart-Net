﻿// <auto-generated />
namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public sealed partial class ReflectionDelegateFactory
    {
        public Func<object, object> CreateFactory1(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 1)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1) => ci.Invoke(new[] { p1 });
        }

        public Func<object, object, object> CreateFactory2(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 2)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2) => ci.Invoke(new[] { p1, p2 });
        }

        public Func<object, object, object, object> CreateFactory3(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 3)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3) => ci.Invoke(new[] { p1, p2, p3 });
        }

        public Func<object, object, object, object, object> CreateFactory4(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 4)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4) => ci.Invoke(new[] { p1, p2, p3, p4 });
        }

        public Func<object, object, object, object, object, object> CreateFactory5(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 5)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5) => ci.Invoke(new[] { p1, p2, p3, p4, p5 });
        }

        public Func<object, object, object, object, object, object, object> CreateFactory6(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 6)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6 });
        }

        public Func<object, object, object, object, object, object, object, object> CreateFactory7(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 7)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7 });
        }

        public Func<object, object, object, object, object, object, object, object, object> CreateFactory8(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 8)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8 });
        }

        public Func<object, object, object, object, object, object, object, object, object, object> CreateFactory9(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 9)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8, p9) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9 });
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object> CreateFactory10(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 10)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 });
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory11(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 11)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 });
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory12(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 12)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 });
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory13(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 13)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 });
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory14(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 14)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14 });
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory15(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 15)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15 });
        }

        public Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateFactory16(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != 16)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            return (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) => ci.Invoke(new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16 });
        }

    }
}