namespace Smart.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    using Smart.ComponentModel;
    using Smart.Reflection.Emit;

    /// <summary>
    ///
    /// </summary>
    public class EmitTypeMetadataFactory : IActivatorFactory, IAccessorFactory, IArrayFactory
    {
        private static readonly ConstructorInfo NotSupportedExceptionCtor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);

        // Member

        private readonly object sync = new object();

        private readonly Dictionary<ConstructorInfo, ActivatorMetadata> activatorCache = new Dictionary<ConstructorInfo, ActivatorMetadata>();

        private readonly Dictionary<PropertyInfo, AccessorMetadata> accessorCache = new Dictionary<PropertyInfo, AccessorMetadata>();

        private readonly Dictionary<PropertyInfo, AccessorMetadata> extensionAccessorCache = new Dictionary<PropertyInfo, AccessorMetadata>();

        private readonly Dictionary<Type, ArrayMetadata> arrayCache = new Dictionary<Type, ArrayMetadata>();

        /// <summary>
        ///
        /// </summary>
        public static EmitTypeMetadataFactory Default { get; } = new EmitTypeMetadataFactory();

        //--------------------------------------------------------------------------------
        // Activator
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public ActivatorMetadata CreateActivator(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            lock (sync)
            {
                if (!activatorCache.TryGetValue(ci, out var activator))
                {
                    activator = CreateActivatorInternal(ci);
                    activatorCache[ci] = activator;
                }

                return activator;
            }
        }

        private ActivatorMetadata CreateActivatorInternal(ConstructorInfo ci)
        {
            var method = new DynamicMethod("Create", typeof(object), new[] { typeof(object[]) });
            var ilGenerator = method.GetILGenerator();

            // Create
            for (var i = 0; i < ci.GetParameters().Length; i++)
            {
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.EmitLdcI4(i);
                ilGenerator.Emit(OpCodes.Ldelem_Ref);
                ilGenerator.EmitTypeConversion(ci.GetParameters()[i].ParameterType);
            }

            ilGenerator.Emit(OpCodes.Newobj, ci);

            ilGenerator.Emit(OpCodes.Ret);

            return new ActivatorMetadata(
                ci,
                (Func<object[], object>)method.CreateDelegate(typeof(Func<object[], object>)));
        }

        //--------------------------------------------------------------------------------
        // Accessor
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public AccessorMetadata CreateAccessor(PropertyInfo pi)
        {
            return CreateAccessor(pi, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public AccessorMetadata CreateAccessor(PropertyInfo pi, bool extension)
        {
            if (pi == null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            lock (sync)
            {
                var cache = extension ? extensionAccessorCache : accessorCache;
                if (!cache.TryGetValue(pi, out var accessor))
                {
                    var holderType = extension ? ValueHolderHelper.FindValueHolderType(pi) : null;
                    accessor = CreateAccessorInternal(pi, holderType);
                    cache[pi] = accessor;
                }

                return accessor;
            }
        }

        private AccessorMetadata CreateAccessorInternal(PropertyInfo pi, Type holderType)
        {
            var isValueProperty = holderType != null;
            var vpi = isValueProperty ? ValueHolderHelper.GetValueTypeProperty(holderType) : pi;

            return new AccessorMetadata(
                pi,
                pi.Name,
                vpi.PropertyType,
                vpi.CanRead,
                vpi.CanWrite,
                CreateGetter(pi, vpi, isValueProperty),
                CreateSetter(pi, vpi, isValueProperty));
        }

        private static Func<object, object> CreateGetter(PropertyInfo pi, PropertyInfo vpi, bool isValueProperty)
        {
            var method = new DynamicMethod("GetValue", typeof(object), new[] { typeof(object) });
            var ilGenerator = method.GetILGenerator();

            if (!vpi.CanRead)
            {
                ilGenerator.Emit(OpCodes.Newobj, NotSupportedExceptionCtor);
                ilGenerator.Emit(OpCodes.Throw);
                return (Func<object, object>)method.CreateDelegate(typeof(Func<object, object>));
            }

            if (!pi.GetGetMethod().IsStatic)
            {
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Castclass, pi.DeclaringType);
            }

            ilGenerator.Emit(pi.GetGetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, pi.GetGetMethod());

            if (isValueProperty)
            {
                ilGenerator.Emit(OpCodes.Callvirt, vpi.GetGetMethod());
            }
            if (vpi.PropertyType.IsValueType)
            {
                ilGenerator.Emit(OpCodes.Box, vpi.PropertyType);
            }

            ilGenerator.Emit(OpCodes.Ret);

            return (Func<object, object>)method.CreateDelegate(typeof(Func<object, object>));
        }

        private static Action<object, object> CreateSetter(PropertyInfo pi, PropertyInfo vpi, bool isValueProperty)
        {
            var method = new DynamicMethod("GetValue", typeof(void), new[] { typeof(object), typeof(object) });
            var ilGenerator = method.GetILGenerator();

            if (!vpi.CanWrite)
            {
                ilGenerator.Emit(OpCodes.Newobj, NotSupportedExceptionCtor);
                ilGenerator.Emit(OpCodes.Throw);
                return (Action<object, object>)method.CreateDelegate(typeof(Action<object, object>));
            }

            if (vpi.PropertyType.IsValueType)
            {
                var hasValue = ilGenerator.DefineLabel();

                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Brtrue_S, hasValue);

                // null
                if (!pi.GetGetMethod().IsStatic)
                {
                    ilGenerator.Emit(OpCodes.Ldarg_0);
                    ilGenerator.Emit(OpCodes.Castclass, pi.DeclaringType);
                }

                if (isValueProperty)
                {
                    ilGenerator.Emit(pi.GetGetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, pi.GetGetMethod());
                }

                var type = vpi.PropertyType.IsEnum ? vpi.PropertyType.GetEnumUnderlyingType() : vpi.PropertyType;
                if (LdcDictionary.TryGetValue(type, out var action))
                {
                    action(ilGenerator);
                }
                else
                {
                    var local = ilGenerator.DeclareLocal(vpi.PropertyType);
                    ilGenerator.Emit(OpCodes.Ldloca_S, local);
                    ilGenerator.Emit(OpCodes.Initobj, vpi.PropertyType);
                    ilGenerator.Emit(OpCodes.Ldloc_0);
                }

                ilGenerator.Emit(vpi.GetSetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, vpi.GetSetMethod());

                ilGenerator.Emit(OpCodes.Ret);

                // not null
                ilGenerator.MarkLabel(hasValue);

                if (!pi.GetGetMethod().IsStatic)
                {
                    ilGenerator.Emit(OpCodes.Ldarg_0);
                    ilGenerator.Emit(OpCodes.Castclass, pi.DeclaringType);
                }

                if (isValueProperty)
                {
                    ilGenerator.Emit(pi.GetGetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, pi.GetGetMethod());
                }

                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Unbox_Any, vpi.PropertyType);

                ilGenerator.Emit(vpi.GetSetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, vpi.GetSetMethod());

                ilGenerator.Emit(OpCodes.Ret);
            }
            else
            {
                if (!pi.GetGetMethod().IsStatic)
                {
                    ilGenerator.Emit(OpCodes.Ldarg_0);
                    ilGenerator.Emit(OpCodes.Castclass, pi.DeclaringType);
                }

                if (isValueProperty)
                {
                    ilGenerator.Emit(pi.GetGetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, pi.GetGetMethod());
                }

                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Castclass, vpi.PropertyType);

                ilGenerator.Emit(vpi.GetSetMethod().IsStatic ? OpCodes.Call : OpCodes.Callvirt, vpi.GetSetMethod());

                ilGenerator.Emit(OpCodes.Ret);
            }

            return (Action<object, object>)method.CreateDelegate(typeof(Action<object, object>));
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

        //--------------------------------------------------------------------------------
        // Array
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ArrayMetadata CreateArray(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            lock (sync)
            {
                if (!arrayCache.TryGetValue(type, out var array))
                {
                    array = CreateArrayInternal(type);
                    arrayCache[type] = array;
                }

                return array;
            }
        }

        private ArrayMetadata CreateArrayInternal(Type type)
        {
            var method = new DynamicMethod("Create", typeof(Array), new[] { typeof(int) });
            var ilGenerator = method.GetILGenerator();

            // Create
            ilGenerator.Emit(OpCodes.Ldarg_0);

            ilGenerator.Emit(OpCodes.Newarr, type);

            ilGenerator.Emit(OpCodes.Ret);

            return new ArrayMetadata(
                type,
                (Func<int, Array>)method.CreateDelegate(typeof(Func<int, Array>)));
        }
    }
}
