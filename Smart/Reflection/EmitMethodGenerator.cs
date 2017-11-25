namespace Smart.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    using Smart.Reflection.Emit;

    /// <summary>
    ///
    /// </summary>
    public static class EmitMethodGenerator
    {
        private const string AssemblyName = "SmartDynamicActivatorAssembly";

        private const string ModuleName = "SmartDynamicActivatorModule";

        private static readonly Type ObjectType = typeof(object);

        private static readonly Type VoidType = typeof(void);

        private static readonly Type BoolType = typeof(bool);

        private static readonly Type StringType = typeof(string);

        private static readonly Type CtorType = typeof(ConstructorInfo);

        private static readonly Type TypeType = typeof(Type);

        private static readonly Type PropertyInfoType = typeof(PropertyInfo);

        private static readonly ConstructorInfo ObjectCotor = typeof(object).GetConstructor(Type.EmptyTypes);

        private static readonly ConstructorInfo NotSupportedExceptionCtor = typeof(NotSupportedException).GetConstructor(Type.EmptyTypes);

        private static readonly MethodInfo PropertyInfoNameGetMethod =
            typeof(PropertyInfo).GetProperty(nameof(PropertyInfo.Name)).GetGetMethod();

        private static readonly MethodInfo PropertyInfoPropertyTypeGetMethod =
            typeof(PropertyInfo).GetProperty(nameof(PropertyInfo.PropertyType)).GetGetMethod();

        // Activator

        private static readonly Type ActivatorType = typeof(IActivator);

        private static readonly MethodInfo ActivatorCreateMethodInfo = typeof(IActivator).GetMethod(nameof(IActivator.Create));

        private static readonly Type[] ActivatorConstructorArgumentTypes = { typeof(ConstructorInfo) };

        private static readonly Type[] ActivatorCreateArgumentTypes = { typeof(object[]) };

        // Accessor

        private static readonly Type AccessorType = typeof(IAccessor);

        private static readonly MethodInfo AccessorGetValueMethodInfo = typeof(IAccessor).GetMethod(nameof(IAccessor.GetValue));

        private static readonly MethodInfo AccessorSetValueMethodInfo = typeof(IAccessor).GetMethod(nameof(IAccessor.SetValue));

        private static readonly Type[] AccessorConstructorArgumentTypes = { typeof(PropertyInfo) };

        private static readonly Type[] ValueHolderAccessorConstructorArgumentTypes = { typeof(PropertyInfo), typeof(Type) };

        private static readonly Type[] AccessorGetValueArgumentTypes = { typeof(object) };

        private static readonly Type[] AccessorSetValueArgumentTypes = { typeof(object), typeof(object) };

        // Member

        private static readonly object Sync = new object();

        private static readonly Dictionary<ConstructorInfo, IActivator> ActivatorCache = new Dictionary<ConstructorInfo, IActivator>();

        private static readonly Dictionary<PropertyInfo, IAccessor> AccessorCache = new Dictionary<PropertyInfo, IAccessor>();

        private static readonly Dictionary<PropertyInfo, IAccessor> HolderAccessorCache = new Dictionary<PropertyInfo, IAccessor>();

        private static AssemblyBuilder assemblyBuilder;

        private static ModuleBuilder moduleBuilder;

        /// <summary>
        ///
        /// </summary>
        private static ModuleBuilder ModuleBuilder
        {
            get
            {
                if (moduleBuilder == null)
                {
                    assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                        new AssemblyName(AssemblyName),
                        AssemblyBuilderAccess.Run);
                    moduleBuilder = assemblyBuilder.DefineDynamicModule(
                        ModuleName);
                }
                return moduleBuilder;
            }
        }

        //--------------------------------------------------------------------------------
        // Activator
        //--------------------------------------------------------------------------------

        public static IActivator CreateActivator(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            lock (Sync)
            {
                if (!ActivatorCache.TryGetValue(ci, out var activator))
                {
                    activator = CreateActivatorInternal(ci);
                    ActivatorCache[ci] = activator;
                }

                return activator;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        private static IActivator CreateActivatorInternal(ConstructorInfo ci)
        {
            var typeBuilder = ModuleBuilder.DefineType(
                $"{ci.DeclaringType.FullName}_DynamicActivator",
                TypeAttributes.Public | TypeAttributes.AutoLayout | TypeAttributes.AnsiClass | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);

            typeBuilder.AddInterfaceImplementation(ActivatorType);

            // Field
            var sourceField = typeBuilder.DefineField(
                "source",
                CtorType,
                FieldAttributes.Private | FieldAttributes.InitOnly);

            // Property
            DefineActivatorPropertySource(typeBuilder, sourceField);

            // Constructor
            DefineActivatorConstructor(typeBuilder, sourceField);

            // Method
            DefineActivatorMethodCreate(typeBuilder, ci);

            var typeInfo = typeBuilder.CreateTypeInfo();

            return (IActivator)Activator.CreateInstance(typeInfo.AsType(), ci);
        }

        private static void DefineActivatorPropertySource(TypeBuilder typeBuilder, FieldBuilder sourceField)
        {
            var sourceProperty = typeBuilder.DefineProperty(
                "Source",
                PropertyAttributes.None,
                CtorType,
                null);
            var getSourceProperty = typeBuilder.DefineMethod(
                "get_Source",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.SpecialName | MethodAttributes.Virtual | MethodAttributes.Final,
                CtorType,
                Type.EmptyTypes);
            sourceProperty.SetGetMethod(getSourceProperty);

            var ilGenerator = getSourceProperty.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, sourceField);

            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void DefineActivatorConstructor(TypeBuilder typeBuilder, FieldBuilder sourceField)
        {
            var ctor = typeBuilder.DefineConstructor(
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
                CallingConventions.Standard,
                ActivatorConstructorArgumentTypes);

            var ilGenerator = ctor.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Call, ObjectCotor);

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Stfld, sourceField);

            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void DefineActivatorMethodCreate(TypeBuilder typeBuilder, ConstructorInfo ci)
        {
            var method = typeBuilder.DefineMethod(
                nameof(IActivator.Create),
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final,
                ObjectType,
                ActivatorCreateArgumentTypes);
            typeBuilder.DefineMethodOverride(method, ActivatorCreateMethodInfo);

            var ilGenerator = method.GetILGenerator();

            for (var i = 0; i < ci.GetParameters().Length; i++)
            {
                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.EmitLdcI4(i);
                ilGenerator.Emit(OpCodes.Ldelem_Ref);
                ilGenerator.EmitTypeConversion(ci.GetParameters()[i].ParameterType);
            }

            ilGenerator.Emit(OpCodes.Newobj, ci);

            ilGenerator.Emit(OpCodes.Ret);
        }

        //--------------------------------------------------------------------------------
        // Accessor
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static IAccessor CreateAccessor(PropertyInfo pi, bool extension = true)
        {
            if (pi == null)
            {
                throw new ArgumentNullException(nameof(pi));
            }

            var holderType = !extension ? null : AccessorHelper.FindValueHolderType(pi);

            lock (Sync)
            {
                var cache = holderType == null ? AccessorCache : HolderAccessorCache;
                if (!cache.TryGetValue(pi, out var accessor))
                {
                    accessor = CreateAccessorInternal(pi, holderType);
                    cache[pi] = accessor;
                }

                return accessor;
            }
        }

        private static IAccessor CreateAccessorInternal(PropertyInfo pi, Type holderType)
        {
            var isValueProperty = holderType != null;
            var vpi = isValueProperty ? AccessorHelper.GetValueTypeProperty(holderType) : pi;

            var typeBuilder = ModuleBuilder.DefineType(
                $"{pi.DeclaringType.FullName}_{pi.Name}_DynamicAccsessor",
                TypeAttributes.Public | TypeAttributes.AutoLayout | TypeAttributes.AnsiClass | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);

            typeBuilder.AddInterfaceImplementation(AccessorType);

            // Fields
            var sourceField = typeBuilder.DefineField(
                 "source",
                 PropertyInfoType,
                 FieldAttributes.Private | FieldAttributes.InitOnly);
            var typeField = isValueProperty
                ? typeBuilder.DefineField(
                    "type",
                    TypeType,
                    FieldAttributes.Private | FieldAttributes.InitOnly)
                : null;

            // Property
            DefineAccessorPropertySource(typeBuilder, sourceField);
            DefineAccessorPropertyName(typeBuilder, sourceField);
            DefineAccessorPropertyType(typeBuilder, typeField != null ? typeField : sourceField, !isValueProperty);
            DefineAccessorPropertyAccessibility(typeBuilder, vpi.CanRead, nameof(IAccessor.CanRead));
            DefineAccessorPropertyAccessibility(typeBuilder, vpi.CanWrite, nameof(IAccessor.CanWrite));

            // Constructor
            DefineAccessorConstructor(typeBuilder, sourceField, typeField);

            // Method
            DefineAccessorMethodGetValue(typeBuilder, pi, vpi, isValueProperty);
            DefineAccessorMethodSetValue(typeBuilder, pi, vpi, isValueProperty);

            var type = typeBuilder.CreateTypeInfo().AsType();

            if (isValueProperty)
            {
                return (IAccessor)Activator.CreateInstance(type, pi, vpi.PropertyType);
            }

            return (IAccessor)Activator.CreateInstance(type, pi);
        }

        private static void DefineAccessorPropertySource(TypeBuilder typeBuilder, FieldBuilder sourceField)
        {
            var property = typeBuilder.DefineProperty(
                "Source",
                PropertyAttributes.None,
                PropertyInfoType,
                null);
            var method = typeBuilder.DefineMethod(
                "get_Source",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.SpecialName | MethodAttributes.Virtual | MethodAttributes.Final,
                PropertyInfoType,
                Type.EmptyTypes);
            property.SetGetMethod(method);

            var ilGenerator = method.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, sourceField);

            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void DefineAccessorPropertyName(TypeBuilder typeBuilder, FieldBuilder sourceField)
        {
            var property = typeBuilder.DefineProperty(
                "Name",
                PropertyAttributes.None,
                StringType,
                null);
            var method = typeBuilder.DefineMethod(
                "get_Name",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.SpecialName | MethodAttributes.Virtual | MethodAttributes.Final,
                StringType,
                Type.EmptyTypes);
            property.SetGetMethod(method);

            var ilGenerator = method.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, sourceField);
            ilGenerator.Emit(OpCodes.Callvirt, PropertyInfoNameGetMethod);

            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void DefineAccessorPropertyType(TypeBuilder typeBuilder, FieldBuilder field, bool isProperty)
        {
            var property = typeBuilder.DefineProperty(
                "Type",
                PropertyAttributes.None,
                TypeType,
                null);
            var method = typeBuilder.DefineMethod(
                "get_Type",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.SpecialName | MethodAttributes.Virtual | MethodAttributes.Final,
                TypeType,
                Type.EmptyTypes);
            property.SetGetMethod(method);

            var ilGenerator = method.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, field);
            if (isProperty)
            {
                ilGenerator.Emit(OpCodes.Callvirt, PropertyInfoPropertyTypeGetMethod);
            }

            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void DefineAccessorPropertyAccessibility(TypeBuilder typeBuilder, bool enable, string name)
        {
            var property = typeBuilder.DefineProperty(
                name,
                PropertyAttributes.None,
                BoolType,
                null);
            var method = typeBuilder.DefineMethod(
                $"get_{name}",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.SpecialName | MethodAttributes.Virtual | MethodAttributes.Final,
                BoolType,
                Type.EmptyTypes);
            property.SetGetMethod(method);

            var ilGenerator = method.GetILGenerator();

            ilGenerator.Emit(enable ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void DefineAccessorConstructor(TypeBuilder typeBuilder, FieldBuilder sourceField, FieldBuilder typeField)
        {
            var ctor = typeBuilder.DefineConstructor(
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName |
                MethodAttributes.RTSpecialName,
                CallingConventions.Standard,
                typeField == null ? AccessorConstructorArgumentTypes : ValueHolderAccessorConstructorArgumentTypes);

            var ilGenerator = ctor.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Call, ObjectCotor);

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Stfld, sourceField);

            if (typeField != null)
            {
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Ldarg_2);
                ilGenerator.Emit(OpCodes.Stfld, typeField);
            }

            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void DefineAccessorMethodGetValue(TypeBuilder typeBuilder, PropertyInfo pi, PropertyInfo vpi, bool isValueProperty)
        {
            var method = typeBuilder.DefineMethod(
                nameof(IAccessor.GetValue),
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final,
                ObjectType,
                AccessorGetValueArgumentTypes);
            typeBuilder.DefineMethodOverride(method, AccessorGetValueMethodInfo);

            var ilGenerator = method.GetILGenerator();

            if (!vpi.CanRead)
            {
                ilGenerator.Emit(OpCodes.Newobj, NotSupportedExceptionCtor);
                ilGenerator.Emit(OpCodes.Throw);
                return;
            }

            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Castclass, pi.DeclaringType);
            ilGenerator.Emit(OpCodes.Callvirt, pi.GetGetMethod());
            if (isValueProperty)
            {
                ilGenerator.Emit(OpCodes.Callvirt, vpi.GetGetMethod());
            }
            if (vpi.PropertyType.IsValueType)
            {
                ilGenerator.Emit(OpCodes.Box, vpi.PropertyType);
            }

            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void DefineAccessorMethodSetValue(TypeBuilder typeBuilder, PropertyInfo pi, PropertyInfo vpi, bool isValueProperty)
        {
            var method = typeBuilder.DefineMethod(
                nameof(IAccessor.SetValue),
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final,
                VoidType,
                AccessorSetValueArgumentTypes);
            typeBuilder.DefineMethodOverride(method, AccessorSetValueMethodInfo);

            var ilGenerator = method.GetILGenerator();

            if (!vpi.CanWrite)
            {
                ilGenerator.Emit(OpCodes.Newobj, NotSupportedExceptionCtor);
                ilGenerator.Emit(OpCodes.Throw);
                return;
            }

            if (vpi.PropertyType.IsValueType)
            {
                var hasValue = ilGenerator.DefineLabel();

                ilGenerator.Emit(OpCodes.Ldarg_2);
                ilGenerator.Emit(OpCodes.Brtrue_S, hasValue);

                // null
                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Castclass, pi.DeclaringType);
                if (isValueProperty)
                {
                    ilGenerator.Emit(OpCodes.Callvirt, pi.GetGetMethod());
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

                ilGenerator.Emit(OpCodes.Callvirt, vpi.GetSetMethod());

                ilGenerator.Emit(OpCodes.Ret);

                // not null
                ilGenerator.MarkLabel(hasValue);

                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Castclass, pi.DeclaringType);
                if (isValueProperty)
                {
                    ilGenerator.Emit(OpCodes.Callvirt, pi.GetGetMethod());
                }

                ilGenerator.Emit(OpCodes.Ldarg_2);
                ilGenerator.Emit(OpCodes.Unbox_Any, vpi.PropertyType);

                ilGenerator.Emit(OpCodes.Callvirt, vpi.GetSetMethod());

                ilGenerator.Emit(OpCodes.Ret);
            }
            else
            {
                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Castclass, pi.DeclaringType);
                if (isValueProperty)
                {
                    ilGenerator.Emit(OpCodes.Callvirt, pi.GetGetMethod());
                }

                ilGenerator.Emit(OpCodes.Ldarg_2);
                ilGenerator.Emit(OpCodes.Castclass, vpi.PropertyType);

                ilGenerator.Emit(OpCodes.Callvirt, vpi.GetSetMethod());

                ilGenerator.Emit(OpCodes.Ret);
            }
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