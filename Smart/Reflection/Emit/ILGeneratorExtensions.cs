namespace Smart.Reflection.Emit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    public static class ILGeneratorExtensions
    {
        private static readonly Dictionary<Type, OpCode> LdelemDictionary = new Dictionary<Type, OpCode>
        {
            { typeof(bool), OpCodes.Ldelem_U1 },
            { typeof(byte), OpCodes.Ldelem_U1 },
            { typeof(char), OpCodes.Ldelem_U2 },
            { typeof(short), OpCodes.Ldelem_I2 },
            { typeof(int), OpCodes.Ldelem_I4 },
            { typeof(sbyte), OpCodes.Ldelem_I1 },
            { typeof(ushort), OpCodes.Ldelem_U2 },
            { typeof(uint), OpCodes.Ldelem_U4 },
            { typeof(long), OpCodes.Ldelem_I8 },
            { typeof(ulong), OpCodes.Ldelem_I8 },
            { typeof(float), OpCodes.Ldelem_R4 },
            { typeof(double), OpCodes.Ldelem_R8 },
            { typeof(IntPtr), OpCodes.Ldelem_I },
            { typeof(UIntPtr), OpCodes.Ldelem_I }
        };

        private static readonly Dictionary<Type, OpCode> StelemDictionary = new Dictionary<Type, OpCode>
        {
            { typeof(bool), OpCodes.Stelem_I1 },
            { typeof(byte), OpCodes.Stelem_I1 },
            { typeof(char), OpCodes.Stelem_I2 },
            { typeof(short), OpCodes.Stelem_I2 },
            { typeof(int), OpCodes.Stelem_I4 },
            { typeof(sbyte), OpCodes.Stelem_I1 },
            { typeof(ushort), OpCodes.Stelem_I2 },
            { typeof(uint), OpCodes.Stelem_I4 },
            { typeof(long), OpCodes.Stelem_I8 },
            { typeof(ulong), OpCodes.Stelem_I8 },
            { typeof(float), OpCodes.Stelem_R4 },
            { typeof(double), OpCodes.Stelem_R8 },
            { typeof(IntPtr), OpCodes.Stelem_I },
            { typeof(UIntPtr), OpCodes.Stelem_I }
        };

        public static void EmitLdelem(this ILGenerator il, Type type)
        {
            if (LdelemDictionary.TryGetValue(type, out var opCode))
            {
                il.Emit(opCode);
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
            if (StelemDictionary.TryGetValue(type, out var opCode))
            {
                il.Emit(opCode);
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

        public static void EmitCallMethod(this ILGenerator il, MethodInfo method)
        {
            var opCode = (method.IsFinal || !method.IsVirtual) ? OpCodes.Call : OpCodes.Callvirt;
            il.Emit(opCode, method);
        }
    }
}
