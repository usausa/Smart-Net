namespace Smart.Reflection
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    using Smart.ComponentModel;
    using Smart.Reflection.Emit;

    public sealed partial class DynamicDelegateFactory : IDelegateFactory
    {
        // Array cache

        private readonly ConcurrentDictionary<Type, Func<int, Array>> arrayAllocatorCache = new();

        // Factory cache

        private readonly ConcurrentDictionary<ConstructorInfo, Func<object?[]?, object>> factoryCache = new();

        private readonly ConcurrentDictionary<ConstructorInfo, Delegate> factoryDelegateCache = new();

        // Typed factory cache

        private readonly ConcurrentDictionary<ConstructorInfo, Delegate> typedFactoryCache = new();

        // Default structure cache

        private readonly ConcurrentDictionary<Type, Func<object?[]?, object>> defaultStructFactoryCache = new();

        private readonly ConcurrentDictionary<Type, Delegate> defaultStructDelegateCache = new();

        private readonly ConcurrentDictionary<Type, Delegate> typedDefaultStructDelegateCache = new();

        // Property cache

        private readonly ConcurrentDictionary<PropertyInfo, Func<object, object?>?> getterCache = new();

        private readonly ConcurrentDictionary<PropertyInfo, Func<object, object?>?> extensionGetterCache = new();

        private readonly ConcurrentDictionary<PropertyInfo, Action<object, object?>?> setterCache = new();

        private readonly ConcurrentDictionary<PropertyInfo, Action<object, object?>?> extensionSetterCache = new();

        // Typed Property cache

        private readonly ConcurrentDictionary<PropertyInfo, Delegate?> typedGetterCache = new();

        private readonly ConcurrentDictionary<PropertyInfo, Delegate?> typedExtensionGetterCache = new();

        private readonly ConcurrentDictionary<PropertyInfo, Delegate?> typedSetterCache = new();

        private readonly ConcurrentDictionary<PropertyInfo, Delegate?> typedExtensionSetterCache = new();

        // Property

        public static DynamicDelegateFactory Default { get; } = new();

        public bool IsCodegenRequired => true;

        // Constructor

        private DynamicDelegateFactory()
        {
        }

        //--------------------------------------------------------------------------------
        // Array
        //--------------------------------------------------------------------------------

        public Func<int, Array> CreateArrayAllocator(Type type)
        {
            return arrayAllocatorCache.GetOrAdd(type, CreateArrayAllocatorInternal);
        }

        private static Func<int, Array> CreateArrayAllocatorInternal(Type type)
        {
            var dynamicMethod = new DynamicMethod(string.Empty, typeof(Array), new[] { typeof(object), typeof(int) }, true);
            var il = dynamicMethod.GetILGenerator();

            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Newarr, type);
            il.Emit(OpCodes.Ret);

            return (Func<int, Array>)dynamicMethod.CreateDelegate(typeof(Func<int, Array>), null);
        }

        //--------------------------------------------------------------------------------
        // Factory
        //--------------------------------------------------------------------------------

        public Func<object> CreateFactory(Type type)
        {
            if (type.IsValueType)
            {
                return (Func<object>)defaultStructDelegateCache
                    .GetOrAdd(type, x => CreateDefaultStructFactoryInternal(false, x, Type.EmptyTypes));
            }

            var ci = type.GetConstructor(Type.EmptyTypes);
            if (ci is null)
            {
                throw new ArgumentException("Constructor not found.");
            }

            return (Func<object>)factoryDelegateCache
                .GetOrAdd(ci, x => CreateFactoryInternal(
                    x,
                    typeof(object),
                    Type.EmptyTypes));
        }

        public Func<object?[]?, object> CreateFactory(Type type, Type[] argumentTypes)
        {
            if (type.IsValueType && (argumentTypes.Length == 0))
            {
                return defaultStructFactoryCache
                    .GetOrAdd(type, x => (Func<object?[]?, object>)CreateDefaultStructFactoryInternal(false, x, new[] { typeof(object?[]) }));
            }

            var ci = type.GetConstructor(argumentTypes);
            if (ci?.DeclaringType is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return CreateFactory(ci);
        }

        public Func<object?[]?, object> CreateFactory(ConstructorInfo ci)
        {
            return factoryCache.GetOrAdd(ci, CreateFactoryInternal);
        }

        public Func<T> CreateFactory<T>()
        {
            var type = typeof(T);
            if (type.IsValueType)
            {
                return (Func<T>)typedDefaultStructDelegateCache
                    .GetOrAdd(type, x => CreateDefaultStructFactoryInternal(true, x, Type.EmptyTypes));
            }

            var ci = type.GetConstructor(Type.EmptyTypes);
            if (ci?.DeclaringType is null)
            {
                throw new ArgumentException("Constructor type parameter is invalid.");
            }

            return (Func<T>)typedFactoryCache.GetOrAdd(ci, x => CreateFactoryInternal(x, x.DeclaringType!, Type.EmptyTypes));
        }

        // Factory Helper

        private static Delegate CreateDefaultStructFactoryInternal(bool typed, Type type, Type[] argumentTypes)
        {
            var delegateOpenType = FactoryDelegateTypes[argumentTypes.Length];
            var returnType = typed ? type : typeof(object);

            var parameterTypes = new Type[argumentTypes.Length + 1];
            parameterTypes[0] = typeof(object);
            Array.Copy(argumentTypes, 0, parameterTypes, 1, argumentTypes.Length);

            var typeArguments = new Type[argumentTypes.Length + 1];
            Array.Copy(argumentTypes, 0, typeArguments, 0, argumentTypes.Length);
            typeArguments[^1] = returnType;

            var delegateType = delegateOpenType.MakeGenericType(typeArguments);

            var dynamicMethod = new DynamicMethod(string.Empty, returnType, parameterTypes, true);
            var il = dynamicMethod.GetILGenerator();

            var local = il.DeclareLocal(type);
            il.Emit(OpCodes.Ldloca_S, local);
            il.Emit(OpCodes.Initobj, type);
            il.Emit(OpCodes.Ldloc_0);

            if (!typed)
            {
                il.Emit(OpCodes.Box, type);
            }

            il.Emit(OpCodes.Ret);

            return dynamicMethod.CreateDelegate(delegateType, null);
        }

        private static Func<object?[]?, object> CreateFactoryInternal(ConstructorInfo ci)
        {
            var returnType = ci.DeclaringType!.IsValueType ? typeof(object) : ci.DeclaringType;

            var dynamicMethod = new DynamicMethod(string.Empty, returnType, new[] { typeof(object), typeof(object?[]) }, true);
            var il = dynamicMethod.GetILGenerator();

            for (var i = 0; i < ci.GetParameters().Length; i++)
            {
                il.Emit(OpCodes.Ldarg_1);
                il.EmitLdcI4(i);
                il.Emit(OpCodes.Ldelem_Ref);
                il.EmitTypeConversion(ci.GetParameters()[i].ParameterType);
            }

            il.Emit(OpCodes.Newobj, ci);
            if (ci.DeclaringType.IsValueType)
            {
                il.Emit(OpCodes.Box, ci.DeclaringType);
            }
            il.Emit(OpCodes.Ret);

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(object?[]), returnType);
            return (Func<object?[]?, object>)dynamicMethod.CreateDelegate(delegateType, null);
        }

        private static readonly Dictionary<int, Type> FactoryDelegateTypes = new()
        {
            { 0, typeof(Func<>) },
            { 1, typeof(Func<,>) },
            { 2, typeof(Func<,,>) },
            { 3, typeof(Func<,,,>) },
            { 4, typeof(Func<,,,,>) },
            { 5, typeof(Func<,,,,,>) },
            { 6, typeof(Func<,,,,,,>) },
            { 7, typeof(Func<,,,,,,,>) },
            { 8, typeof(Func<,,,,,,,,>) },
            { 9, typeof(Func<,,,,,,,,,>) },
            { 10, typeof(Func<,,,,,,,,,,>) },
            { 11, typeof(Func<,,,,,,,,,,,>) },
            { 12, typeof(Func<,,,,,,,,,,,,>) },
            { 13, typeof(Func<,,,,,,,,,,,,,>) },
            { 14, typeof(Func<,,,,,,,,,,,,,,>) },
            { 15, typeof(Func<,,,,,,,,,,,,,,,>) },
            { 16, typeof(Func<,,,,,,,,,,,,,,,,>) }
        };

        private static Delegate CreateFactoryInternal(ConstructorInfo ci, Type returnType, Type[] argumentTypes)
        {
            var delegateOpenType = FactoryDelegateTypes[argumentTypes.Length];

            var parameterTypes = new Type[argumentTypes.Length + 1];
            parameterTypes[0] = typeof(object);
            Array.Copy(argumentTypes, 0, parameterTypes, 1, argumentTypes.Length);

            var typeArguments = new Type[argumentTypes.Length + 1];
            Array.Copy(argumentTypes, 0, typeArguments, 0, argumentTypes.Length);
            typeArguments[^1] = returnType;

            var delegateType = delegateOpenType.MakeGenericType(typeArguments);

            var dynamicMethod = new DynamicMethod(string.Empty, returnType, parameterTypes, true);
            var il = dynamicMethod.GetILGenerator();

            for (var i = 0; i < ci.GetParameters().Length; i++)
            {
                il.EmitLdarg(i + 1);
                if (argumentTypes[i] == typeof(object))
                {
                    il.EmitTypeConversion(ci.GetParameters()[i].ParameterType);
                }
                else if (ci.GetParameters()[i].ParameterType.IsNullableType() && !argumentTypes[i].IsNullableType())
                {
                    var underlyingType = Nullable.GetUnderlyingType(ci.GetParameters()[i].ParameterType);
                    var nullableCtor = ci.GetParameters()[i].ParameterType.GetConstructor(new[] { underlyingType! })!;
                    il.Emit(OpCodes.Newobj, nullableCtor);
                }
            }

            il.Emit(OpCodes.Newobj, ci);
            if ((returnType == typeof(object)) && (ci.DeclaringType!.IsValueType))
            {
                il.Emit(OpCodes.Box, ci.DeclaringType);
            }
            il.Emit(OpCodes.Ret);

            return dynamicMethod.CreateDelegate(delegateType, null);
        }

        //--------------------------------------------------------------------------------
        // Accessor
        //--------------------------------------------------------------------------------

        public Func<object, object?>? CreateGetter(PropertyInfo pi)
        {
            return CreateGetter(pi, true);
        }

        public Func<object, object?>? CreateGetter(PropertyInfo pi, bool extension)
        {
            if ((pi.DeclaringType is null) || pi.DeclaringType.IsValueType)
            {
                throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            var isValueHolder = holderType is not null;
            var tpi = isValueHolder ? ValueHolderHelper.GetValueTypeProperty(holderType!)! : pi;
            var memberType = tpi.PropertyType.IsValueType ? typeof(object) : tpi.PropertyType;

            return extension
                ? extensionGetterCache.GetOrAdd(pi, x => (Func<object, object>?)CreateGetterInternal(x, tpi, isValueHolder, typeof(object), memberType))
                : getterCache.GetOrAdd(pi, x => (Func<object, object>?)CreateGetterInternal(x, tpi, false, typeof(object), memberType));
        }

        public Action<object, object?>? CreateSetter(PropertyInfo pi)
        {
            return CreateSetter(pi, true);
        }

        public Action<object, object?>? CreateSetter(PropertyInfo pi, bool extension)
        {
            if ((pi.DeclaringType is null) || pi.DeclaringType.IsValueType)
            {
                throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            var isValueHolder = holderType is not null;
            var tpi = isValueHolder ? ValueHolderHelper.GetValueTypeProperty(holderType!)! : pi;

            return extension
                ? extensionSetterCache.GetOrAdd(pi, x => (Action<object, object?>?)CreateSetterInternal(x, tpi, isValueHolder, typeof(object), typeof(object)))
                : setterCache.GetOrAdd(pi, x => (Action<object, object?>?)CreateSetterInternal(x, tpi, false, typeof(object), typeof(object)));
        }

        // Accessor

        public Func<T, TMember?>? CreateGetter<T, TMember>(PropertyInfo pi)
        {
            return CreateGetter<T, TMember>(pi, true);
        }

        public Func<T, TMember?>? CreateGetter<T, TMember>(PropertyInfo pi, bool extension)
        {
            if ((pi.DeclaringType is null) || pi.DeclaringType.IsValueType)
            {
                throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            var isValueHolder = holderType is not null;
            var tpi = isValueHolder ? ValueHolderHelper.GetValueTypeProperty(holderType!)! : pi;

            if (tpi.PropertyType != typeof(TMember))
            {
                throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
            }

            return (Func<T, TMember?>?)(extension
                ? typedExtensionGetterCache.GetOrAdd(pi, x => CreateGetterInternal(x, tpi, isValueHolder, typeof(T), typeof(TMember)))
                : typedGetterCache.GetOrAdd(pi, x => CreateGetterInternal(x, tpi, false, typeof(T), typeof(TMember))));
        }

        public Action<T, TMember?>? CreateSetter<T, TMember>(PropertyInfo pi)
        {
            return CreateSetter<T, TMember>(pi, true);
        }

        public Action<T, TMember?>? CreateSetter<T, TMember>(PropertyInfo pi, bool extension)
        {
            if ((pi.DeclaringType is null) || pi.DeclaringType.IsValueType)
            {
                throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
            }

            var holderType = !extension ? null : ValueHolderHelper.FindValueHolderType(pi);
            var isValueHolder = holderType is not null;
            var tpi = isValueHolder ? ValueHolderHelper.GetValueTypeProperty(holderType!)! : pi;

            if (tpi.PropertyType != typeof(TMember))
            {
                throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
            }

            return (Action<T, TMember?>?)(extension
                ? typedExtensionSetterCache.GetOrAdd(pi, x => CreateSetterInternal(x, tpi, isValueHolder, typeof(T), typeof(TMember)))
                : typedSetterCache.GetOrAdd(pi, x => CreateSetterInternal(x, tpi, false, typeof(T), typeof(TMember))));
        }

        // Accessor helper

        private static Delegate? CreateGetterInternal(PropertyInfo pi, PropertyInfo tpi, bool isValueHolder, Type targetType, Type memberType)
        {
            if (isValueHolder && !pi.CanRead)
            {
                throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
            }

            if (!tpi.CanRead)
            {
                return null;
            }

            var dynamicMethod = new DynamicMethod(string.Empty, memberType, new[] { typeof(object), targetType }, true);
            var il = dynamicMethod.GetILGenerator();

            if (!pi.GetGetMethod()!.IsStatic)
            {
                il.Emit(OpCodes.Ldarg_1);
                if (targetType == typeof(object))
                {
                    il.Emit(OpCodes.Castclass, pi.DeclaringType!);
                }
            }

            il.EmitCallMethod(pi.GetGetMethod()!);

            if (isValueHolder)
            {
                il.Emit(OpCodes.Callvirt, tpi.GetGetMethod()!);
            }

            if ((memberType == typeof(object)) && (tpi.PropertyType.IsValueType))
            {
                il.Emit(OpCodes.Box, tpi.PropertyType);
            }

            il.Emit(OpCodes.Ret);

            var delegateType = typeof(Func<,>).MakeGenericType(targetType, memberType);
            return dynamicMethod.CreateDelegate(delegateType, null);
        }

        private static readonly Dictionary<Type, Action<ILGenerator>> LdcDictionary = new()
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

        private static Delegate? CreateSetterInternal(PropertyInfo pi, PropertyInfo tpi, bool isValueHolder, Type targetType, Type memberType)
        {
            if (isValueHolder && !pi.CanRead)
            {
                throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
            }

            if (!tpi.CanWrite)
            {
                return null;
            }

            var isStatic = isValueHolder ? pi.GetGetMethod()!.IsStatic : pi.GetSetMethod()!.IsStatic;

            var dynamicMethod = new DynamicMethod(string.Empty, typeof(void), new[] { typeof(object), targetType, memberType }, true);
            var il = dynamicMethod.GetILGenerator();

            if ((memberType == typeof(object)) && tpi.PropertyType.IsValueType)
            {
                var hasValue = il.DefineLabel();

                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Brtrue_S, hasValue);

                // null
                if (!isStatic)
                {
                    il.Emit(OpCodes.Ldarg_1);
                    if (targetType == typeof(object))
                    {
                        il.Emit(OpCodes.Castclass, pi.DeclaringType!);
                    }
                }

                if (isValueHolder)
                {
                    il.EmitCallMethod(pi.GetGetMethod()!);
                }

                var type = tpi.PropertyType.IsEnum ? tpi.PropertyType.GetEnumUnderlyingType() : tpi.PropertyType;
                if (LdcDictionary.TryGetValue(type, out var action))
                {
                    action(il);
                }
                else
                {
                    var local = il.DeclareLocal(tpi.PropertyType);
                    il.Emit(OpCodes.Ldloca_S, local);
                    il.Emit(OpCodes.Initobj, tpi.PropertyType);
                    il.Emit(OpCodes.Ldloc_0);
                }

                il.EmitCallMethod(tpi.GetSetMethod()!);

                il.Emit(OpCodes.Ret);

                // not null
                il.MarkLabel(hasValue);

                if (!isStatic)
                {
                    il.Emit(OpCodes.Ldarg_1);
                    if (targetType == typeof(object))
                    {
                        il.Emit(OpCodes.Castclass, pi.DeclaringType!);
                    }
                }

                if (isValueHolder)
                {
                    il.EmitCallMethod(pi.GetGetMethod()!);
                }

                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Unbox_Any, tpi.PropertyType);

                il.EmitCallMethod(tpi.GetSetMethod()!);

                il.Emit(OpCodes.Ret);
            }
            else
            {
                if (!isStatic)
                {
                    il.Emit(OpCodes.Ldarg_1);
                    if (targetType == typeof(object))
                    {
                        il.Emit(OpCodes.Castclass, pi.DeclaringType!);
                    }
                }

                if (isValueHolder)
                {
                    il.EmitCallMethod(pi.GetGetMethod()!);
                }

                il.Emit(OpCodes.Ldarg_2);
                if (memberType == typeof(object))
                {
                    il.Emit(OpCodes.Castclass, tpi.PropertyType);
                }

                il.EmitCallMethod(tpi.GetSetMethod()!);

                il.Emit(OpCodes.Ret);
            }

            var delegateType = typeof(Action<,>).MakeGenericType(targetType, memberType);
            return dynamicMethod.CreateDelegate(delegateType, null);
        }

        //--------------------------------------------------------------------------------
        // Etc
        //--------------------------------------------------------------------------------

        public Type? GetExtendedPropertyType(PropertyInfo pi)
        {
            var holderType = ValueHolderHelper.FindValueHolderType(pi);
            var tpi = holderType is null ? pi : ValueHolderHelper.GetValueTypeProperty(holderType);
            return tpi?.PropertyType;
        }
    }
}
