namespace Smart.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    using Smart.ComponentModel;
    using Smart.Reflection.Emit;

    public sealed class DynamicDelegateFactory : IDelegateFactory
    {
        private static readonly Type VoidType = typeof(void);

        private static readonly Type ObjectType = typeof(object);

        private static readonly Type ObjectArrayType = typeof(object[]);

        private static readonly Type Int32Type = typeof(int);

        private static readonly Type ArrayType = typeof(Array);

        // ArrayAllocator

        private static readonly Type[] ArrayAllocatorParameterTypes = { ObjectType, Int32Type };

        private static readonly Type ArrayAllocatorType = typeof(Func<int, Array>);

        // Factory

        private static readonly Type[] FactoryParameterTypes = { ObjectType, ObjectArrayType };

        private static readonly Type[] Factory0ParameterTypes = { ObjectType };

        private static readonly Type[] Factory1ParameterTypes = { ObjectType, ObjectType };

        private static readonly Type[] Factory2ParameterTypes = { ObjectType, ObjectType, ObjectType };

        private static readonly Type[] Factory3ParameterTypes = { ObjectType, ObjectType, ObjectType, ObjectType };

        private static readonly Type[] Factory4ParameterTypes = { ObjectType, ObjectType, ObjectType, ObjectType, ObjectType };

        private static readonly Type[] Factory5ParameterTypes = { ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType };

        private static readonly Type[] Factory6ParameterTypes = { ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType };

        private static readonly Type[] Factory7ParameterTypes = { ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType };

        private static readonly Type[] Factory8ParameterTypes = { ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType, ObjectType };

        private static readonly Type FactoryType = typeof(Func<object[], object>);

        private static readonly Type Factory0Type = typeof(Func<object>);

        private static readonly Type Factory1Type = typeof(Func<object, object>);

        private static readonly Type Factory2Type = typeof(Func<object, object, object>);

        private static readonly Type Factory3Type = typeof(Func<object, object, object, object>);

        private static readonly Type Factory4Type = typeof(Func<object, object, object, object, object>);

        private static readonly Type Factory5Type = typeof(Func<object, object, object, object, object, object>);

        private static readonly Type Factory6Type = typeof(Func<object, object, object, object, object, object, object>);

        private static readonly Type Factory7Type = typeof(Func<object, object, object, object, object, object, object, object>);

        private static readonly Type Factory8Type = typeof(Func<object, object, object, object, object, object, object, object, object>);

        // Accessor

        private static readonly Type[] GetterParameterTypes = { ObjectType, ObjectType };

        private static readonly Type[] SetterParameterTypes = { ObjectType, ObjectType, ObjectType };

        private static readonly Type GetterType = typeof(Func<object, object>);

        private static readonly Type SetterType = typeof(Action<object, object>);

        // Property

        public static DynamicDelegateFactory Default { get; } = new DynamicDelegateFactory();

        // Array

        public Func<int, Array> CreateArrayAllocator(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var dynamic = new DynamicMethod(string.Empty, ArrayType, ArrayAllocatorParameterTypes, true);
            var il = dynamic.GetILGenerator();

            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Newarr, type);
            il.Emit(OpCodes.Ret);

            return (Func<int, Array>)dynamic.CreateDelegate(ArrayAllocatorType, null);
        }

        // Factory

        public Func<object[], object> CreateFactory(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            var dynamic = new DynamicMethod(string.Empty, ObjectType, FactoryParameterTypes, true);
            var il = dynamic.GetILGenerator();

            for (var i = 0; i < ci.GetParameters().Length; i++)
            {
                il.Emit(OpCodes.Ldarg_1);
                il.EmitLdcI4(i);
                il.Emit(OpCodes.Ldelem_Ref);
                var paramType = ci.GetParameters()[i].ParameterType;
                il.Emit(paramType.GetTypeInfo().IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, paramType);
            }

            il.Emit(OpCodes.Newobj, ci);
            il.Emit(OpCodes.Ret);

            return (Func<object[], object>)dynamic.CreateDelegate(FactoryType, null);
        }

        private static Delegate CreateFactoryInternal(ConstructorInfo ci, Type[] parameterTypes, Type delegateType)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            if (ci.GetParameters().Length != parameterTypes.Length - 1)
            {
                throw new ArgumentException($"Constructor parameter length is invalid. length={ci.GetParameters().Length}", nameof(ci));
            }

            var dynamic = new DynamicMethod(string.Empty, ObjectType, parameterTypes, true);
            var il = dynamic.GetILGenerator();

            for (var i = 0; i < ci.GetParameters().Length; i++)
            {
                il.EmitLdarg(i + 1);
                il.EmitTypeConversion(ci.GetParameters()[i].ParameterType);
            }

            il.Emit(OpCodes.Newobj, ci);
            il.Emit(OpCodes.Ret);

            return dynamic.CreateDelegate(delegateType, null);
        }

        public Func<object> CreateFactory0(ConstructorInfo ci)
        {
            return (Func<object>)CreateFactoryInternal(ci, Factory0ParameterTypes, Factory0Type);
        }

        public Func<object, object> CreateFactory1(ConstructorInfo ci)
        {
            return (Func<object, object>)CreateFactoryInternal(ci, Factory1ParameterTypes, Factory1Type);
        }

        public Func<object, object, object> CreateFactory2(ConstructorInfo ci)
        {
            return (Func<object, object, object>)CreateFactoryInternal(ci, Factory2ParameterTypes, Factory2Type);
        }

        public Func<object, object, object, object> CreateFactory3(ConstructorInfo ci)
        {
            return (Func<object, object, object, object>)CreateFactoryInternal(ci, Factory3ParameterTypes, Factory3Type);
        }

        public Func<object, object, object, object, object> CreateFactory4(ConstructorInfo ci)
        {
            return (Func<object, object, object, object, object>)CreateFactoryInternal(ci, Factory4ParameterTypes, Factory4Type);
        }

        public Func<object, object, object, object, object, object> CreateFactory5(ConstructorInfo ci)
        {
            return (Func<object, object, object, object, object, object>)CreateFactoryInternal(ci, Factory5ParameterTypes, Factory5Type);
        }

        public Func<object, object, object, object, object, object, object> CreateFactory6(ConstructorInfo ci)
        {
            return (Func<object, object, object, object, object, object, object>)CreateFactoryInternal(ci, Factory6ParameterTypes, Factory6Type);
        }

        public Func<object, object, object, object, object, object, object, object> CreateFactory7(ConstructorInfo ci)
        {
            return (Func<object, object, object, object, object, object, object, object>)CreateFactoryInternal(ci, Factory7ParameterTypes, Factory7Type);
        }

        public Func<object, object, object, object, object, object, object, object, object> CreateFactory8(ConstructorInfo ci)
        {
            return (Func<object, object, object, object, object, object, object, object, object>)CreateFactoryInternal(ci, Factory8ParameterTypes, Factory8Type);
        }

        // Accessor

        public Func<object, object> CreateGetter(PropertyInfo pi)
        {
            return CreateGetter(pi, true);
        }

        public Func<object, object> CreateGetter(PropertyInfo pi, bool extension)
        {
            if (pi == null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            var isValueProperty = holderType != null;
            var vpi = isValueProperty ? ValueHolderHelper.GetValueTypeProperty(holderType) : pi;

            if (isValueProperty && !pi.CanRead)
            {
                throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
            }

            if (!vpi.CanRead)
            {
                return null;
            }

            var dynamic = new DynamicMethod(string.Empty, ObjectType, GetterParameterTypes, true);
            var il = dynamic.GetILGenerator();

            if (!pi.GetGetMethod().IsStatic)
            {
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Castclass, pi.DeclaringType);
            }

            il.Emit(pi.GetGetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, pi.GetGetMethod());

            if (isValueProperty)
            {
                il.Emit(OpCodes.Callvirt, vpi.GetGetMethod());
            }
            if (vpi.PropertyType.IsValueType)
            {
                il.Emit(OpCodes.Box, vpi.PropertyType);
            }

            il.Emit(OpCodes.Ret);

            return (Func<object, object>)dynamic.CreateDelegate(GetterType, null);
        }

        public Action<object, object> CreateSetter(PropertyInfo pi)
        {
            return CreateSetter(pi, true);
        }

        public Action<object, object> CreateSetter(PropertyInfo pi, bool extension)
        {
            if (pi == null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            var isValueProperty = holderType != null;
            var vpi = isValueProperty ? ValueHolderHelper.GetValueTypeProperty(holderType) : pi;

            if (isValueProperty && !pi.CanRead)
            {
                throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
            }

            if (!vpi.CanWrite)
            {
                return null;
            }

            var isStatic = isValueProperty ? pi.GetGetMethod().IsStatic : pi.GetSetMethod().IsStatic;

            var dynamic = new DynamicMethod(string.Empty, VoidType, SetterParameterTypes, true);
            var il = dynamic.GetILGenerator();

            if (vpi.PropertyType.IsValueType)
            {
                var hasValue = il.DefineLabel();

                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Brtrue_S, hasValue);

                // null
                if (!isStatic)
                {
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Castclass, pi.DeclaringType);
                }

                if (isValueProperty)
                {
                    il.Emit(pi.GetGetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, pi.GetGetMethod());
                }

                var type = vpi.PropertyType.IsEnum ? vpi.PropertyType.GetEnumUnderlyingType() : vpi.PropertyType;
                if (LdcDictionary.TryGetValue(type, out var action))
                {
                    action(il);
                }
                else
                {
                    var local = il.DeclareLocal(vpi.PropertyType);
                    il.Emit(OpCodes.Ldloca_S, local);
                    il.Emit(OpCodes.Initobj, vpi.PropertyType);
                    il.Emit(OpCodes.Ldloc_0);
                }

                il.Emit(vpi.GetSetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, vpi.GetSetMethod());

                il.Emit(OpCodes.Ret);

                // not null
                il.MarkLabel(hasValue);

                if (!isStatic)
                {
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Castclass, pi.DeclaringType);
                }

                if (isValueProperty)
                {
                    il.Emit(pi.GetGetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, pi.GetGetMethod());
                }

                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Unbox_Any, vpi.PropertyType);

                il.Emit(vpi.GetSetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, vpi.GetSetMethod());

                il.Emit(OpCodes.Ret);
            }
            else
            {
                if (!isStatic)
                {
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Castclass, pi.DeclaringType);
                }

                if (isValueProperty)
                {
                    il.Emit(pi.GetGetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, pi.GetGetMethod());
                }

                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Castclass, vpi.PropertyType);

                il.Emit(vpi.GetSetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, vpi.GetSetMethod());

                il.Emit(OpCodes.Ret);
            }

            return (Action<object, object>)dynamic.CreateDelegate(SetterType, null);
        }

        private static readonly Dictionary<Type, Action<ILGenerator>> LdcDictionary = new Dictionary<Type, Action<ILGenerator>>
        {
            { typeof(bool), il => il.Emit(OpCodes.Ldc_I4_0) },
            { typeof(byte), il => il.Emit(OpCodes.Ldc_I4_0) },
            { typeof(char), il => il.Emit(OpCodes.Ldc_I4_0) },
            { typeof(short), il => il.Emit(OpCodes.Ldc_I4_0) },
            { typeof(int), il => il.Emit(OpCodes.Ldc_I4_0) },
            { typeof(sbyte), il => il.Emit(OpCodes.Ldc_I4_0) },
            { typeof(ushort), il => il.Emit(OpCodes.Ldc_I4_0) },
            { typeof(uint), il => il.Emit(OpCodes.Ldc_I4_0) },      // Simplicity
            { typeof(long), il => il.Emit(OpCodes.Ldc_I8, 0L) },
            { typeof(ulong), il => il.Emit(OpCodes.Ldc_I8, 0L) },   // Simplicity
            { typeof(float), il => il.Emit(OpCodes.Ldc_R4, 0f) },
            { typeof(double), il => il.Emit(OpCodes.Ldc_R8, 0d) },
            { typeof(IntPtr), il => il.Emit(OpCodes.Ldc_I4_0) },    // Simplicity
            { typeof(UIntPtr), il => il.Emit(OpCodes.Ldc_I4_0) },   // Simplicity
        };
    }
}
