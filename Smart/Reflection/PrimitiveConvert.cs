#if NET8_0_OR_GREATER
#pragma warning disable IDE0004
#else
// ReSharper disable RedundantCast
#endif
namespace Smart.Reflection;

using System.Reflection;
using System.Runtime.CompilerServices;

#if NET8_0_OR_GREATER
#pragma warning disable CA2020
#endif
public static class PrimitiveConvert
{
    // ReSharper disable NotAccessedPositionalProperty.Local
    private readonly record struct RecordKey(Type ParameterType, Type ReturnType);
    // ReSharper restore NotAccessedPositionalProperty.Local

    private static readonly Dictionary<RecordKey, MethodInfo> Methods;

    static PrimitiveConvert()
    {
        Methods = typeof(PrimitiveConvert).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .ToDictionary(x => new RecordKey(x.GetParameters()[0].ParameterType, x.ReturnType), x => x);
    }

    public static MethodInfo? GetMethod(Type parameterType, Type returnType) =>
        Methods.GetValueOrDefault(new RecordKey(parameterType, returnType));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte ByteToSByte(byte x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ByteToChar(byte x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal ByteToDecimal(byte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ByteToDouble(byte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ByteToSingle(byte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ByteToInt32(byte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint ByteToUInt32(byte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr ByteToIntPtr(byte x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr ByteToUIntPtr(byte x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long ByteToInt64(byte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong ByteToUInt64(byte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short ByteToInt16(byte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort ByteToUInt16(byte x) => x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte SByteToByte(sbyte x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char SByteToChar(sbyte x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal SByteToDecimal(sbyte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double SByteToDouble(sbyte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float SByteToSingle(sbyte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int SByteToInt32(sbyte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint SByteToUInt32(sbyte x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr SByteToIntPtr(sbyte x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr SByteToUIntPtr(sbyte x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long SByteToInt64(sbyte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong SByteToUInt64(sbyte x) => (ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short SByteToInt16(sbyte x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort SByteToUInt16(sbyte x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte CharToByte(char x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte CharToSByte(char x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal CharToDecimal(char x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double CharToDouble(char x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float CharToSingle(char x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CharToInt32(char x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint CharToUInt32(char x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr CharToIntPtr(char x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr CharToUIntPtr(char x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long CharToInt64(char x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong CharToUInt64(char x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short CharToInt16(char x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort CharToUInt16(char x) => x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte Int16ToByte(short x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte Int16ToSByte(short x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char Int16ToChar(short x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal Int16ToDecimal(short x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Int16ToDouble(short x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Int16ToSingle(short x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Int16ToInt32(short x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Int16ToUInt32(short x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr Int16ToIntPtr(short x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr Int16ToUIntPtr(short x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Int16ToInt64(short x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Int16ToUInt64(short x) => (ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort Int16ToUInt16(short x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte UInt16ToByte(ushort x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte UInt16ToSByte(ushort x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char UInt16ToChar(ushort x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal UInt16ToDecimal(ushort x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double UInt16ToDouble(ushort x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float UInt16ToSingle(ushort x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int UInt16ToInt32(ushort x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint UInt16ToUInt32(ushort x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr UInt16ToIntPtr(ushort x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr UInt16ToUIntPtr(ushort x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long UInt16ToInt64(ushort x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong UInt16ToUInt64(ushort x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short UInt16ToInt16(ushort x) => (short)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte Int32ToByte(int x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte Int32ToSByte(int x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char Int32ToChar(int x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal Int32ToDecimal(int x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Int32ToDouble(int x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Int32ToSingle(int x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Int32ToUInt32(int x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr Int32ToIntPtr(int x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr Int32ToUIntPtr(int x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Int32ToInt64(int x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Int32ToUInt64(int x) => (ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short Int32ToInt16(int x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort Int32ToUInt16(int x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte UInt32ToByte(uint x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte UInt32ToSByte(uint x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char UInt32ToChar(uint x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal UInt32ToDecimal(uint x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double UInt32ToDouble(uint x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float UInt32ToSingle(uint x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int UInt32ToInt32(uint x) => (int)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr UInt32ToIntPtr(uint x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr UInt32ToUIntPtr(uint x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long UInt32ToInt64(uint x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong UInt32ToUInt64(uint x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short UInt32ToInt16(uint x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort UInt32ToUInt16(uint x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte Int64ToByte(long x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte Int64ToSByte(long x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char Int64ToChar(long x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal Int64ToDecimal(long x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Int64ToDouble(long x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Int64ToSingle(long x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Int64ToInt32(long x) => (int)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Int64ToUInt32(long x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr Int64ToIntPtr(long x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr Int64ToUIntPtr(long x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Int64ToUInt64(long x) => (ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short Int64ToInt16(long x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort Int64ToUInt16(long x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte UInt64ToByte(ulong x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte UInt64ToSByte(ulong x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char UInt64ToChar(ulong x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal UInt64ToDecimal(ulong x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double UInt64ToDouble(ulong x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float UInt64ToSingle(ulong x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int UInt64ToInt32(ulong x) => (int)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint UInt64ToUInt32(ulong x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr UInt64ToIntPtr(ulong x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr UInt64ToUIntPtr(ulong x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long UInt64ToInt64(ulong x) => (long)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short UInt64ToInt16(ulong x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort UInt64ToUInt16(ulong x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte SingleToByte(float x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte SingleToSByte(float x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char SingleToChar(float x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal SingleToDecimal(float x) => (decimal)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double SingleToDouble(float x) => x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int SingleToInt32(float x) => (int)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint SingleToUInt32(float x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr SingleToIntPtr(float x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr SingleToUIntPtr(float x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long SingleToInt64(float x) => (long)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong SingleToUInt64(float x) => (ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short SingleToInt16(float x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort SingleToUInt16(float x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte DoubleToByte(double x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte DoubleToSByte(double x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char DoubleToChar(double x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal DoubleToDecimal(double x) => (decimal)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float DoubleToSingle(double x) => (float)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DoubleToInt32(double x) => (int)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint DoubleToUInt32(double x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr DoubleToIntPtr(double x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr DoubleToUIntPtr(double x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long DoubleToInt64(double x) => (long)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong DoubleToUInt64(double x) => (ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short DoubleToInt16(double x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort DoubleToUInt16(double x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte DecimalToByte(decimal x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte DecimalToSByte(decimal x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char DecimalToChar(decimal x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double DecimalToDouble(decimal x) => (double)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float DecimalToSingle(decimal x) => (float)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DecimalToInt32(decimal x) => (int)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint DecimalToUInt32(decimal x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr DecimalToIntPtr(decimal x) => (IntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr DecimalToUIntPtr(decimal x) => (UIntPtr)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long DecimalToInt64(decimal x) => (long)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong DecimalToUInt64(decimal x) => (ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short DecimalToInt16(decimal x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort DecimalToUInt16(decimal x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte IntPtrToByte(IntPtr x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte IntPtrToSByte(IntPtr x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char IntPtrToChar(IntPtr x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal IntPtrToDecimal(IntPtr x) => (decimal)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double IntPtrToDouble(IntPtr x) => (double)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float IntPtrToSingle(IntPtr x) => (float)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IntPtrToInt32(IntPtr x) => (int)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint IntPtrToUInt32(IntPtr x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr IntPtrToUIntPtr(IntPtr x) => (UIntPtr)(long)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long IntPtrToInt64(IntPtr x) => (long)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong IntPtrToUInt64(IntPtr x) => (ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short IntPtrToInt16(IntPtr x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort IntPtrToUInt16(IntPtr x) => (ushort)x;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte UIntPtrToByte(UIntPtr x) => (byte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte UIntPtrToSByte(UIntPtr x) => (sbyte)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char UIntPtrToChar(UIntPtr x) => (char)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static decimal UIntPtrToDecimal(UIntPtr x) => (decimal)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double UIntPtrToDouble(UIntPtr x) => (double)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float UIntPtrToSingle(UIntPtr x) => (float)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int UIntPtrToInt32(UIntPtr x) => (int)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint UIntPtrToUInt32(UIntPtr x) => (uint)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr UIntPtrToIntPtr(UIntPtr x) => (IntPtr)(ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long UIntPtrToInt64(UIntPtr x) => (long)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong UIntPtrToUInt64(UIntPtr x) => (ulong)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short UIntPtrToInt16(UIntPtr x) => (short)x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort UIntPtrToUInt16(UIntPtr x) => (ushort)x;
}
#pragma warning restore CA2020
