namespace Smart.Reflection
{
    using System;
    using System.Linq;
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

        private static readonly Type CtorType = typeof(ConstructorInfo);

        private static readonly object Sync = new object();

        private static ModuleBuilder moduleBuilder;

        /// <summary>
        ///
        /// </summary>
        private static ModuleBuilder ModuleBuilder
        {
            get
            {
                lock (Sync)
                {
                    if (moduleBuilder == null)
                    {
                        var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                            new AssemblyName(AssemblyName),
                            AssemblyBuilderAccess.Run);
                        moduleBuilder = assemblyBuilder.DefineDynamicModule(
                            ModuleName);
                    }
                    return moduleBuilder;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public static IActivator CreateActivator(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            var typeBuilder = ModuleBuilder.DefineType(
                ci.DeclaringType.FullName + "_DynamicActivator",
                TypeAttributes.Public | TypeAttributes.AutoLayout | TypeAttributes.AnsiClass | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);

            typeBuilder.AddInterfaceImplementation(typeof(IActivator));

            // Source
            var sourceField = typeBuilder.DefineField(
                "_source",
                CtorType,
                FieldAttributes.Private | FieldAttributes.InitOnly);
            var sourceProperty = typeBuilder.DefineProperty(
                "Source",
                PropertyAttributes.HasDefault,
                CtorType,
                null);
            var getSourceProperty = typeBuilder.DefineMethod(
                "get_Source",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.SpecialName | MethodAttributes.Virtual | MethodAttributes.Final,
                CtorType,
                Type.EmptyTypes);
            sourceProperty.SetGetMethod(getSourceProperty);

            var getSourceIl = getSourceProperty.GetILGenerator();

            getSourceIl.Emit(OpCodes.Ldarg_0);
            getSourceIl.Emit(OpCodes.Ldfld, sourceField);
            getSourceIl.Emit(OpCodes.Ret);

            // Constructor
            var ctor = typeBuilder.DefineConstructor(
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
                CallingConventions.Standard,
                new[] { CtorType });
            var superCtor = typeof(object).GetConstructors().First();

            var ctorIl = ctor.GetILGenerator();
            ctorIl.Emit(OpCodes.Ldarg_0);
            ctorIl.Emit(OpCodes.Call, superCtor);
            ctorIl.Emit(OpCodes.Ldarg_0);
            ctorIl.Emit(OpCodes.Ldarg_1);
            ctorIl.Emit(OpCodes.Stfld, sourceField);
            ctorIl.Emit(OpCodes.Ret);

            // Create
            var createMethod = typeBuilder.DefineMethod(
                nameof(IActivator.Create),
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final,
                typeof(object),
                new[] { typeof(object[]) });
            typeBuilder.DefineMethodOverride(createMethod, typeof(IActivator).GetMethod(nameof(IActivator.Create)));

            var createIl = createMethod.GetILGenerator();

            for (var i = 0; i < ci.GetParameters().Length; i++)
            {
                createIl.Emit(OpCodes.Ldarg_1);
                createIl.EmitLdcI4(i);
                createIl.Emit(OpCodes.Ldelem_Ref);
                createIl.EmitTypeConversion(ci.GetParameters()[i].ParameterType);
            }

            createIl.Emit(OpCodes.Newobj, ci);
            createIl.Emit(OpCodes.Ret);

            var typeInfo = typeBuilder.CreateTypeInfo();

            return (IActivator)Activator.CreateInstance(typeInfo.AsType(), ci);
        }
    }
}
