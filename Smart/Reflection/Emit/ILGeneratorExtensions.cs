namespace Smart.Reflection.Emit
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;

    public static class ILGeneratorExtensions
    {
        //--------------------------------------------------------------------------------
        // Load/Store
        //--------------------------------------------------------------------------------

        public static void EmitLdelem(this ILGenerator il, Type type)
        {
            if (type == typeof(bool))
            {
                il.Emit(OpCodes.Ldelem_U1);
            }
            else if (type == typeof(byte))
            {
                il.Emit(OpCodes.Ldelem_U1);
            }
            else if (type == typeof(sbyte))
            {
                il.Emit(OpCodes.Ldelem_I1);
            }
            else if (type == typeof(char))
            {
                il.Emit(OpCodes.Ldelem_U2);
            }
            else if (type == typeof(short))
            {
                il.Emit(OpCodes.Ldelem_I2);
            }
            else if (type == typeof(ushort))
            {
                il.Emit(OpCodes.Ldelem_U2);
            }
            else if (type == typeof(int))
            {
                il.Emit(OpCodes.Ldelem_I4);
            }
            else if (type == typeof(uint))
            {
                il.Emit(OpCodes.Ldelem_U4);
            }
            else if (type == typeof(long))
            {
                il.Emit(OpCodes.Ldelem_I8);
            }
            else if (type == typeof(ulong))
            {
                il.Emit(OpCodes.Ldelem_I8);
            }
            else if (type == typeof(float))
            {
                il.Emit(OpCodes.Ldelem_R4);
            }
            else if (type == typeof(double))
            {
                il.Emit(OpCodes.Ldelem_R8);
            }
            else if (type == typeof(IntPtr))
            {
                il.Emit(OpCodes.Ldelem_I);
            }
            else if (type == typeof(UIntPtr))
            {
                il.Emit(OpCodes.Ldelem_I);
            }
            else if (type.IsValueType || type.IsGenericParameter)
            {
                il.Emit(OpCodes.Ldelem, type);
            }
            else
            {
                il.Emit(OpCodes.Ldelem_Ref);
            }
        }

        public static void EmitStelem(this ILGenerator il, Type type)
        {
            if (type == typeof(bool))
            {
                il.Emit(OpCodes.Stelem_I1);
            }
            else if (type == typeof(byte))
            {
                il.Emit(OpCodes.Stelem_I1);
            }
            else if (type == typeof(sbyte))
            {
                il.Emit(OpCodes.Stelem_I1);
            }
            else if (type == typeof(char))
            {
                il.Emit(OpCodes.Stelem_I2);
            }
            else if (type == typeof(short))
            {
                il.Emit(OpCodes.Stelem_I2);
            }
            else if (type == typeof(ushort))
            {
                il.Emit(OpCodes.Stelem_I2);
            }
            else if (type == typeof(int))
            {
                il.Emit(OpCodes.Stelem_I4);
            }
            else if (type == typeof(uint))
            {
                il.Emit(OpCodes.Stelem_I4);
            }
            else if (type == typeof(long))
            {
                il.Emit(OpCodes.Stelem_I8);
            }
            else if (type == typeof(ulong))
            {
                il.Emit(OpCodes.Stelem_I8);
            }
            else if (type == typeof(float))
            {
                il.Emit(OpCodes.Stelem_R4);
            }
            else if (type == typeof(double))
            {
                il.Emit(OpCodes.Stelem_R8);
            }
            else if (type == typeof(IntPtr))
            {
                il.Emit(OpCodes.Stelem_I);
            }
            else if (type == typeof(UIntPtr))
            {
                il.Emit(OpCodes.Stelem_I);
            }
            else if (type.IsValueType || type.IsGenericParameter)
            {
                il.Emit(OpCodes.Stelem, type);
            }
            else
            {
                il.Emit(OpCodes.Stelem_Ref);
            }
        }

        public static void EmitStloc(this ILGenerator il, LocalBuilder local)
        {
            if (local.LocalIndex == 0)
            {
                il.Emit(OpCodes.Stloc_0, local);
            }
            else if (local.LocalIndex == 1)
            {
                il.Emit(OpCodes.Stloc_1, local);
            }
            else if (local.LocalIndex == 2)
            {
                il.Emit(OpCodes.Stloc_2, local);
            }
            else if (local.LocalIndex == 3)
            {
                il.Emit(OpCodes.Stloc_3, local);
            }
            else if (local.LocalIndex < 256)
            {
                il.Emit(OpCodes.Stloc_S, local);
            }
            else
            {
                il.Emit(OpCodes.Stloc, local);
            }
        }

        public static void EmitLdloc(this ILGenerator il, LocalBuilder local)
        {
            if (local.LocalIndex == 0)
            {
                il.Emit(OpCodes.Ldloc_0, local);
            }
            else if (local.LocalIndex == 1)
            {
                il.Emit(OpCodes.Ldloc_1, local);
            }
            else if (local.LocalIndex == 2)
            {
                il.Emit(OpCodes.Ldloc_2, local);
            }
            else if (local.LocalIndex == 3)
            {
                il.Emit(OpCodes.Ldloc_3, local);
            }
            else if (local.LocalIndex < 256)
            {
                il.Emit(OpCodes.Ldloc_S, local);
            }
            else
            {
                il.Emit(OpCodes.Ldloc, local);
            }
        }

        public static void EmitLdloca(this ILGenerator il, LocalBuilder local)
        {
            il.Emit(local.LocalIndex < 256 ? OpCodes.Ldloca_S : OpCodes.Ldloca, local);
        }

        public static void EmitLdcI4(this ILGenerator il, int i)
        {
            switch (i)
            {
                case 0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    break;
                case 1:
                    il.Emit(OpCodes.Ldc_I4_1);
                    break;
                case 2:
                    il.Emit(OpCodes.Ldc_I4_2);
                    break;
                case 3:
                    il.Emit(OpCodes.Ldc_I4_3);
                    break;
                case 4:
                    il.Emit(OpCodes.Ldc_I4_4);
                    break;
                case 5:
                    il.Emit(OpCodes.Ldc_I4_5);
                    break;
                case 6:
                    il.Emit(OpCodes.Ldc_I4_6);
                    break;
                case 7:
                    il.Emit(OpCodes.Ldc_I4_7);
                    break;
                case 8:
                    il.Emit(OpCodes.Ldc_I4_8);
                    break;
                default:
                    if ((i >= -128) && (i <= 127))
                    {
                        il.Emit(OpCodes.Ldc_I4_S, (sbyte)i);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldc_I4, i);
                    }
                    break;
            }
        }

        public static void EmitLdarg(this ILGenerator il, int i)
        {
            switch (i)
            {
                case 0:
                    il.Emit(OpCodes.Ldarg_0);
                    break;
                case 1:
                    il.Emit(OpCodes.Ldarg_1);
                    break;
                case 2:
                    il.Emit(OpCodes.Ldarg_2);
                    break;
                case 3:
                    il.Emit(OpCodes.Ldarg_3);
                    break;
                default:
                    if (i <= 255)
                    {
                        il.Emit(OpCodes.Ldarg_S, (sbyte)i);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldarg, i);
                    }
                    break;
            }
        }

        //--------------------------------------------------------------------------------
        // Conversion
        //--------------------------------------------------------------------------------

        public static void EmitTypeConversion(this ILGenerator il, Type type)
        {
            if (type.IsValueType)
            {
                il.Emit(OpCodes.Unbox_Any, type);
            }
            else if (type != typeof(object))
            {
                il.Emit(OpCodes.Castclass, type);
            }
        }

        //--------------------------------------------------------------------------------
        // Call
        //--------------------------------------------------------------------------------

        public static void EmitCallMethod(this ILGenerator il, MethodInfo method)
        {
            var opCode = (method.IsFinal || !method.IsVirtual) ? OpCodes.Call : OpCodes.Callvirt;
            il.Emit(opCode, method);
        }

        //--------------------------------------------------------------------------------
        // Default
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T GetDefaultValue<T>() => default!;

        public static void EmitStackDefaultValue(this ILGenerator il, Type type)
        {
            if (type.IsClass)
            {
                il.Emit(OpCodes.Ldnull);
            }
            else
            {
                var method = typeof(ILGeneratorExtensions).GetMethod(nameof(GetDefaultValue), BindingFlags.NonPublic | BindingFlags.Static)!.MakeGenericMethod(type);
                il.Emit(OpCodes.Call, method);
            }
        }

        //--------------------------------------------------------------------------------
        // Nullable
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasValue<T>(T? value)
            where T : struct
            => value.HasValue;

        public static void EmitNullableHasValue(this ILGenerator il, Type underlyingType)
        {
            var method = typeof(ILGeneratorExtensions).GetMethod(nameof(HasValue), BindingFlags.NonPublic | BindingFlags.Static)!.MakeGenericMethod(underlyingType);
            il.Emit(OpCodes.Call, method);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T GetValue<T>(T? value)
            where T : struct
            => value!.Value;

        public static void EmitNullableGetValue(this ILGenerator il, Type underlyingType)
        {
            var method = typeof(ILGeneratorExtensions).GetMethod(nameof(GetValue), BindingFlags.NonPublic | BindingFlags.Static)!.MakeGenericMethod(underlyingType);
            il.Emit(OpCodes.Call, method);
        }

        //--------------------------------------------------------------------------------
        // Primitive convert
        //--------------------------------------------------------------------------------

        private static MethodInfo ResolveImplicitMethod(Type targetType, Type parameterType, Type returnType)
        {
            return targetType.GetMethods()
                .First(x => x.IsPublic &&
                            x.IsStatic &&
                            x.Name == "op_Implicit" &&
                            x.ReturnParameter.ParameterType == returnType &&
                            x.GetParameters().Length == 1 &&
                            x.GetParameters()[0].ParameterType == parameterType);
        }

        private static MethodInfo ResolveExplicitMethod(Type targetType, Type parameterType, Type returnType)
        {
            return targetType.GetMethods()
                .First(x => x.IsPublic &&
                            x.IsStatic &&
                            x.Name == "op_Explicit" &&
                            x.ReturnParameter.ParameterType == returnType &&
                            x.GetParameters().Length == 1 &&
                            x.GetParameters()[0].ParameterType == parameterType);
        }

        public static bool EmitPrimitiveConvert(this ILGenerator ilGenerator, Type sourceType, Type destinationType)
        {
            if (sourceType == typeof(byte))
            {
                if (destinationType == typeof(byte))
                {
                    // Nop same
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(short))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(ushort))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(int))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(uint))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(long))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(ulong))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(float))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(byte), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(int), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(uint), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(sbyte))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    // Nop same
                }
                else if (destinationType == typeof(char))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(ushort))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(uint))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(long))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
                else if (destinationType == typeof(ulong))
                {
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
                else if (destinationType == typeof(float))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(sbyte), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(int), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Conv_I8);
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(ulong), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(char))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    // Nop same
                }
                else if (destinationType == typeof(short))
                {
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(int))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(uint))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(long))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(ulong))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(float))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(char), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(int), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(uint), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(short))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    // Nop same
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(ushort))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(uint))
                {
                    // Nop
                }
                else if (destinationType == typeof(long))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
                else if (destinationType == typeof(ulong))
                {
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
                else if (destinationType == typeof(float))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(short), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(int), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Conv_I8);
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(ulong), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(ushort))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    // Nop
                }
                else if (destinationType == typeof(short))
                {
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    // Nop same
                }
                else if (destinationType == typeof(int))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(uint))
                {
                    // Nop implicit
                }
                else if (destinationType == typeof(long))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(ulong))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(float))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(ushort), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(int), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(uint), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(int))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    // Nop same
                }
                else if (destinationType == typeof(uint))
                {
                    // Nop
                }
                else if (destinationType == typeof(long))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
                else if (destinationType == typeof(ulong))
                {
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
                else if (destinationType == typeof(float))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(int), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(int), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Conv_I8);
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(ulong), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(uint))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    // Nop
                }
                else if (destinationType == typeof(uint))
                {
                    // Nop same
                }
                else if (destinationType == typeof(long))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(ulong))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(float))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R_Un);
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R_Un);
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(uint), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(long), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(uint), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(long))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    ilGenerator.Emit(OpCodes.Conv_I4);
                }
                else if (destinationType == typeof(uint))
                {
                    ilGenerator.Emit(OpCodes.Conv_U4);
                }
                else if (destinationType == typeof(long))
                {
                    // Nop same
                }
                else if (destinationType == typeof(ulong))
                {
                    // Nop
                }
                else if (destinationType == typeof(float))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(long), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(long), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(ulong), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(ulong))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    ilGenerator.Emit(OpCodes.Conv_I4);
                }
                else if (destinationType == typeof(uint))
                {
                    ilGenerator.Emit(OpCodes.Conv_U4);
                }
                else if (destinationType == typeof(long))
                {
                    // Nop
                }
                else if (destinationType == typeof(ulong))
                {
                    // Nop same
                }
                else if (destinationType == typeof(float))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R_Un);
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Conv_R_Un);
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // implicit
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(ulong), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(long), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(ulong), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(float))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    ilGenerator.Emit(OpCodes.Conv_I4);
                }
                else if (destinationType == typeof(uint))
                {
                    ilGenerator.Emit(OpCodes.Conv_U4);
                }
                else if (destinationType == typeof(long))
                {
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
                else if (destinationType == typeof(ulong))
                {
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(float))
                {
                    // Nop same
                }
                else if (destinationType == typeof(double))
                {
                    // Implicit
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(float), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Conv_I8);
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(long), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(ulong), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(double))
            {
                if (destinationType == typeof(byte))
                {
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    ilGenerator.Emit(OpCodes.Conv_I4);
                }
                else if (destinationType == typeof(uint))
                {
                    ilGenerator.Emit(OpCodes.Conv_U4);
                }
                else if (destinationType == typeof(long))
                {
                    ilGenerator.Emit(OpCodes.Conv_I8);
                }
                else if (destinationType == typeof(ulong))
                {
                    ilGenerator.Emit(OpCodes.Conv_U8);
                }
                else if (destinationType == typeof(float))
                {
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // Nop same
                }
                else if (destinationType == typeof(decimal))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(double), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Conv_I8);
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(long), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Conv_U8);
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(ulong), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(decimal))
            {
                if (destinationType == typeof(byte))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(byte)));
                }
                else if (destinationType == typeof(sbyte))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(sbyte)));
                }
                else if (destinationType == typeof(char))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(char)));
                }
                else if (destinationType == typeof(short))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(short)));
                }
                else if (destinationType == typeof(ushort))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(ushort)));
                }
                else if (destinationType == typeof(int))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(int)));
                }
                else if (destinationType == typeof(uint))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(uint)));
                }
                else if (destinationType == typeof(long))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(long)));
                }
                else if (destinationType == typeof(ulong))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(ulong)));
                }
                else if (destinationType == typeof(float))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(float)));
                }
                else if (destinationType == typeof(double))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(double)));
                }
                else if (destinationType == typeof(decimal))
                {
                    // Nop same
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(long)));
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(long), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(decimal), typeof(decimal), typeof(ulong)));
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(ulong), typeof(UIntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(IntPtr))
            {
                if (destinationType == typeof(byte))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(int)));
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(int)));
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(int)));
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(int)));
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(int)));
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(int)));
                }
                else if (destinationType == typeof(uint))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(int)));
                }
                else if (destinationType == typeof(long))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(long)));
                }
                else if (destinationType == typeof(ulong))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(long)));
                }
                else if (destinationType == typeof(float))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(long)));
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(long)));
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(long)));
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(long), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // Nop same
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // Special
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(IntPtr), typeof(long)));
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(long), typeof(IntPtr)));
                }
                else
                {
                    return false;
                }
            }
            else if (sourceType == typeof(UIntPtr))
            {
                if (destinationType == typeof(byte))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(uint)));
                    ilGenerator.Emit(OpCodes.Conv_U1);
                }
                else if (destinationType == typeof(sbyte))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(uint)));
                    ilGenerator.Emit(OpCodes.Conv_I1);
                }
                else if (destinationType == typeof(char))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(uint)));
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(short))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(uint)));
                    ilGenerator.Emit(OpCodes.Conv_I2);
                }
                else if (destinationType == typeof(ushort))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(uint)));
                    ilGenerator.Emit(OpCodes.Conv_U2);
                }
                else if (destinationType == typeof(int))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(uint)));
                }
                else if (destinationType == typeof(uint))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(uint)));
                }
                else if (destinationType == typeof(long))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(ulong)));
                }
                else if (destinationType == typeof(ulong))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(ulong)));
                }
                else if (destinationType == typeof(float))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(ulong)));
                    ilGenerator.Emit(OpCodes.Conv_R_Un);
                    ilGenerator.Emit(OpCodes.Conv_R4);
                }
                else if (destinationType == typeof(double))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(ulong)));
                    ilGenerator.Emit(OpCodes.Conv_R_Un);
                    ilGenerator.Emit(OpCodes.Conv_R8);
                }
                else if (destinationType == typeof(decimal))
                {
                    // explicit
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(ulong)));
                    ilGenerator.Emit(OpCodes.Call, ResolveImplicitMethod(typeof(decimal), typeof(ulong), typeof(decimal)));
                }
                else if (destinationType == typeof(IntPtr))
                {
                    // Special
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(UIntPtr), typeof(UIntPtr), typeof(ulong)));
                    ilGenerator.Emit(OpCodes.Call, ResolveExplicitMethod(typeof(IntPtr), typeof(long), typeof(IntPtr)));
                }
                else if (destinationType == typeof(UIntPtr))
                {
                    // Nop same
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
