﻿namespace Smart.Converter.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;

    /// <summary>
    ///
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "Ignore")]
    public class ConvertConverterFactory : IConverterFactory
    {
        private static readonly IReadOnlyDictionary<TypePair, Func<TypePair, object, object>> Converters = new ReadOnlyDictionary<TypePair, Func<TypePair, object, object>>(new Dictionary<TypePair, Func<TypePair, object, object>>
        {
            // bool
            { new TypePair(typeof(bool),     typeof(bool)), (tp, s) => Convert.ToBoolean((byte)s) },
            { new TypePair(typeof(byte),     typeof(bool)), (tp, s) => Convert.ToBoolean((bool)s) },
            { new TypePair(typeof(char),     typeof(bool)), (tp, s) => Convert.ToBoolean((char)s) },
            { new TypePair(typeof(DateTime), typeof(bool)), (tp, s) => Convert.ToBoolean((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(bool)), (tp, s) => Convert.ToBoolean((decimal)s) },
            { new TypePair(typeof(double),   typeof(bool)), (tp, s) => Convert.ToBoolean((double)s) },
            { new TypePair(typeof(short),    typeof(bool)), (tp, s) => Convert.ToBoolean((short)s) },
            { new TypePair(typeof(int),      typeof(bool)), (tp, s) => Convert.ToBoolean((int)s) },
            { new TypePair(typeof(long),     typeof(bool)), (tp, s) => Convert.ToBoolean((long)s) },
            { new TypePair(typeof(sbyte),    typeof(bool)), (tp, s) => Convert.ToBoolean((sbyte)s) },
            { new TypePair(typeof(float),    typeof(bool)), (tp, s) => Convert.ToBoolean((float)s) },
            { new TypePair(typeof(string),   typeof(bool)), (tp, s) => Convert.ToBoolean((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(bool)), (tp, s) => Convert.ToBoolean((ushort)s) },
            { new TypePair(typeof(uint),     typeof(bool)), (tp, s) => Convert.ToBoolean((uint)s) },
            { new TypePair(typeof(ulong),    typeof(bool)), (tp, s) => Convert.ToBoolean((ulong)s) },
            // byte
            { new TypePair(typeof(bool),     typeof(byte)), (tp, s) => Convert.ToByte((byte)s) },
            { new TypePair(typeof(byte),     typeof(byte)), (tp, s) => Convert.ToByte((bool)s) },
            { new TypePair(typeof(char),     typeof(byte)), (tp, s) => Convert.ToByte((char)s) },
            { new TypePair(typeof(DateTime), typeof(byte)), (tp, s) => Convert.ToByte((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(byte)), (tp, s) => Convert.ToByte((decimal)s) },
            { new TypePair(typeof(double),   typeof(byte)), (tp, s) => Convert.ToByte((double)s) },
            { new TypePair(typeof(short),    typeof(byte)), (tp, s) => Convert.ToByte((short)s) },
            { new TypePair(typeof(int),      typeof(byte)), (tp, s) => Convert.ToByte((int)s) },
            { new TypePair(typeof(long),     typeof(byte)), (tp, s) => Convert.ToByte((long)s) },
            { new TypePair(typeof(sbyte),    typeof(byte)), (tp, s) => Convert.ToByte((sbyte)s) },
            { new TypePair(typeof(float),    typeof(byte)), (tp, s) => Convert.ToByte((float)s) },
            { new TypePair(typeof(string),   typeof(byte)), (tp, s) => Convert.ToByte((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(byte)), (tp, s) => Convert.ToByte((ushort)s) },
            { new TypePair(typeof(uint),     typeof(byte)), (tp, s) => Convert.ToByte((uint)s) },
            { new TypePair(typeof(ulong),    typeof(byte)), (tp, s) => Convert.ToByte((ulong)s) },
            // char
            { new TypePair(typeof(bool),     typeof(char)), (tp, s) => Convert.ToChar((byte)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(byte),     typeof(char)), (tp, s) => Convert.ToChar((bool)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(char),     typeof(char)), (tp, s) => Convert.ToChar((char)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(DateTime), typeof(char)), (tp, s) => Convert.ToChar((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(char)), (tp, s) => Convert.ToChar((decimal)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(double),   typeof(char)), (tp, s) => Convert.ToChar((double)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(short),    typeof(char)), (tp, s) => Convert.ToChar((short)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(int),      typeof(char)), (tp, s) => Convert.ToChar((int)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(long),     typeof(char)), (tp, s) => Convert.ToChar((long)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(sbyte),    typeof(char)), (tp, s) => Convert.ToChar((sbyte)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(float),    typeof(char)), (tp, s) => Convert.ToChar((float)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(string),   typeof(char)), (tp, s) => Convert.ToChar((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(char)), (tp, s) => Convert.ToChar((ushort)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(uint),     typeof(char)), (tp, s) => Convert.ToChar((uint)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ulong),    typeof(char)), (tp, s) => Convert.ToChar((ulong)s, CultureInfo.CurrentCulture) },
            // DateTime
            { new TypePair(typeof(bool),     typeof(DateTime)), (tp, s) => Convert.ToDateTime((byte)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(byte),     typeof(DateTime)), (tp, s) => Convert.ToDateTime((bool)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(char),     typeof(DateTime)), (tp, s) => Convert.ToDateTime((char)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(DateTime), typeof(DateTime)), (tp, s) => Convert.ToDateTime((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(DateTime)), (tp, s) => Convert.ToDateTime((decimal)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(double),   typeof(DateTime)), (tp, s) => Convert.ToDateTime((double)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(short),    typeof(DateTime)), (tp, s) => Convert.ToDateTime((short)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(int),      typeof(DateTime)), (tp, s) => Convert.ToDateTime((int)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(long),     typeof(DateTime)), (tp, s) => Convert.ToDateTime((long)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(sbyte),    typeof(DateTime)), (tp, s) => Convert.ToDateTime((sbyte)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(float),    typeof(DateTime)), (tp, s) => Convert.ToDateTime((float)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(string),   typeof(DateTime)), (tp, s) => Convert.ToDateTime((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(DateTime)), (tp, s) => Convert.ToDateTime((ushort)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(uint),     typeof(DateTime)), (tp, s) => Convert.ToDateTime((uint)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ulong),    typeof(DateTime)), (tp, s) => Convert.ToDateTime((ulong)s, CultureInfo.CurrentCulture) },
            // decimal
            { new TypePair(typeof(bool),     typeof(decimal)), (tp, s) => Convert.ToDecimal((byte)s) },
            { new TypePair(typeof(byte),     typeof(decimal)), (tp, s) => Convert.ToDecimal((bool)s) },
            { new TypePair(typeof(char),     typeof(decimal)), (tp, s) => Convert.ToDecimal((char)s) },
            { new TypePair(typeof(DateTime), typeof(decimal)), (tp, s) => Convert.ToDecimal((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(decimal)), (tp, s) => Convert.ToDecimal((decimal)s) },
            { new TypePair(typeof(double),   typeof(decimal)), (tp, s) => Convert.ToDecimal((double)s) },
            { new TypePair(typeof(short),    typeof(decimal)), (tp, s) => Convert.ToDecimal((short)s) },
            { new TypePair(typeof(int),      typeof(decimal)), (tp, s) => Convert.ToDecimal((int)s) },
            { new TypePair(typeof(long),     typeof(decimal)), (tp, s) => Convert.ToDecimal((long)s) },
            { new TypePair(typeof(sbyte),    typeof(decimal)), (tp, s) => Convert.ToDecimal((sbyte)s) },
            { new TypePair(typeof(float),    typeof(decimal)), (tp, s) => Convert.ToDecimal((float)s) },
            { new TypePair(typeof(string),   typeof(decimal)), (tp, s) => Convert.ToDecimal((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(decimal)), (tp, s) => Convert.ToDecimal((ushort)s) },
            { new TypePair(typeof(uint),     typeof(decimal)), (tp, s) => Convert.ToDecimal((uint)s) },
            { new TypePair(typeof(ulong),    typeof(decimal)), (tp, s) => Convert.ToDecimal((ulong)s) },
            // double
            { new TypePair(typeof(bool),     typeof(double)), (tp, s) => Convert.ToDouble((byte)s) },
            { new TypePair(typeof(byte),     typeof(double)), (tp, s) => Convert.ToDouble((bool)s) },
            { new TypePair(typeof(char),     typeof(double)), (tp, s) => Convert.ToDouble((char)s) },
            { new TypePair(typeof(DateTime), typeof(double)), (tp, s) => Convert.ToDouble((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(double)), (tp, s) => Convert.ToDouble((decimal)s) },
            { new TypePair(typeof(double),   typeof(double)), (tp, s) => Convert.ToDouble((double)s) },
            { new TypePair(typeof(short),    typeof(double)), (tp, s) => Convert.ToDouble((short)s) },
            { new TypePair(typeof(int),      typeof(double)), (tp, s) => Convert.ToDouble((int)s) },
            { new TypePair(typeof(long),     typeof(double)), (tp, s) => Convert.ToDouble((long)s) },
            { new TypePair(typeof(sbyte),    typeof(double)), (tp, s) => Convert.ToDouble((sbyte)s) },
            { new TypePair(typeof(float),    typeof(double)), (tp, s) => Convert.ToDouble((float)s) },
            { new TypePair(typeof(string),   typeof(double)), (tp, s) => Convert.ToDouble((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(double)), (tp, s) => Convert.ToDouble((ushort)s) },
            { new TypePair(typeof(uint),     typeof(double)), (tp, s) => Convert.ToDouble((uint)s) },
            { new TypePair(typeof(ulong),    typeof(double)), (tp, s) => Convert.ToDouble((ulong)s) },
            // short
            { new TypePair(typeof(bool),     typeof(short)), (tp, s) => Convert.ToInt16((byte)s) },
            { new TypePair(typeof(byte),     typeof(short)), (tp, s) => Convert.ToInt16((bool)s) },
            { new TypePair(typeof(char),     typeof(short)), (tp, s) => Convert.ToInt16((char)s) },
            { new TypePair(typeof(DateTime), typeof(short)), (tp, s) => Convert.ToInt16((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(short)), (tp, s) => Convert.ToInt16((decimal)s) },
            { new TypePair(typeof(double),   typeof(short)), (tp, s) => Convert.ToInt16((double)s) },
            { new TypePair(typeof(short),    typeof(short)), (tp, s) => Convert.ToInt16((short)s) },
            { new TypePair(typeof(int),      typeof(short)), (tp, s) => Convert.ToInt16((int)s) },
            { new TypePair(typeof(long),     typeof(short)), (tp, s) => Convert.ToInt16((long)s) },
            { new TypePair(typeof(sbyte),    typeof(short)), (tp, s) => Convert.ToInt16((sbyte)s) },
            { new TypePair(typeof(float),    typeof(short)), (tp, s) => Convert.ToInt16((float)s) },
            { new TypePair(typeof(string),   typeof(short)), (tp, s) => Convert.ToInt16((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(short)), (tp, s) => Convert.ToInt16((ushort)s) },
            { new TypePair(typeof(uint),     typeof(short)), (tp, s) => Convert.ToInt16((uint)s) },
            { new TypePair(typeof(ulong),    typeof(short)), (tp, s) => Convert.ToInt16((ulong)s) },
            // int
            { new TypePair(typeof(bool),     typeof(int)), (tp, s) => Convert.ToInt32((byte)s) },
            { new TypePair(typeof(byte),     typeof(int)), (tp, s) => Convert.ToInt32((bool)s) },
            { new TypePair(typeof(char),     typeof(int)), (tp, s) => Convert.ToInt32((char)s) },
            { new TypePair(typeof(DateTime), typeof(int)), (tp, s) => Convert.ToInt32((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(int)), (tp, s) => Convert.ToInt32((decimal)s) },
            { new TypePair(typeof(double),   typeof(int)), (tp, s) => Convert.ToInt32((double)s) },
            { new TypePair(typeof(short),    typeof(int)), (tp, s) => Convert.ToInt32((short)s) },
            { new TypePair(typeof(int),      typeof(int)), (tp, s) => Convert.ToInt32((int)s) },
            { new TypePair(typeof(long),     typeof(int)), (tp, s) => Convert.ToInt32((long)s) },
            { new TypePair(typeof(sbyte),    typeof(int)), (tp, s) => Convert.ToInt32((sbyte)s) },
            { new TypePair(typeof(float),    typeof(int)), (tp, s) => Convert.ToInt32((float)s) },
            { new TypePair(typeof(string),   typeof(int)), (tp, s) => Convert.ToInt32((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(int)), (tp, s) => Convert.ToInt32((ushort)s) },
            { new TypePair(typeof(uint),     typeof(int)), (tp, s) => Convert.ToInt32((uint)s) },
            { new TypePair(typeof(ulong),    typeof(int)), (tp, s) => Convert.ToInt32((ulong)s) },
            // long
            { new TypePair(typeof(bool),     typeof(long)), (tp, s) => Convert.ToInt64((byte)s) },
            { new TypePair(typeof(byte),     typeof(long)), (tp, s) => Convert.ToInt64((bool)s) },
            { new TypePair(typeof(char),     typeof(long)), (tp, s) => Convert.ToInt64((char)s) },
            { new TypePair(typeof(DateTime), typeof(long)), (tp, s) => Convert.ToInt64((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(long)), (tp, s) => Convert.ToInt64((decimal)s) },
            { new TypePair(typeof(double),   typeof(long)), (tp, s) => Convert.ToInt64((double)s) },
            { new TypePair(typeof(short),    typeof(long)), (tp, s) => Convert.ToInt64((short)s) },
            { new TypePair(typeof(int),      typeof(long)), (tp, s) => Convert.ToInt64((int)s) },
            { new TypePair(typeof(long),     typeof(long)), (tp, s) => Convert.ToInt64((long)s) },
            { new TypePair(typeof(sbyte),    typeof(long)), (tp, s) => Convert.ToInt64((sbyte)s) },
            { new TypePair(typeof(float),    typeof(long)), (tp, s) => Convert.ToInt64((float)s) },
            { new TypePair(typeof(string),   typeof(long)), (tp, s) => Convert.ToInt64((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(long)), (tp, s) => Convert.ToInt64((ushort)s) },
            { new TypePair(typeof(uint),     typeof(long)), (tp, s) => Convert.ToInt64((uint)s) },
            { new TypePair(typeof(ulong),    typeof(long)), (tp, s) => Convert.ToInt64((ulong)s) },
            // sbyte
            { new TypePair(typeof(bool),     typeof(sbyte)), (tp, s) => Convert.ToSByte((byte)s) },
            { new TypePair(typeof(byte),     typeof(sbyte)), (tp, s) => Convert.ToSByte((bool)s) },
            { new TypePair(typeof(char),     typeof(sbyte)), (tp, s) => Convert.ToSByte((char)s) },
            { new TypePair(typeof(DateTime), typeof(sbyte)), (tp, s) => Convert.ToSByte((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(sbyte)), (tp, s) => Convert.ToSByte((decimal)s) },
            { new TypePair(typeof(double),   typeof(sbyte)), (tp, s) => Convert.ToSByte((double)s) },
            { new TypePair(typeof(short),    typeof(sbyte)), (tp, s) => Convert.ToSByte((short)s) },
            { new TypePair(typeof(int),      typeof(sbyte)), (tp, s) => Convert.ToSByte((int)s) },
            { new TypePair(typeof(long),     typeof(sbyte)), (tp, s) => Convert.ToSByte((long)s) },
            { new TypePair(typeof(sbyte),    typeof(sbyte)), (tp, s) => Convert.ToSByte((sbyte)s) },
            { new TypePair(typeof(float),    typeof(sbyte)), (tp, s) => Convert.ToSByte((float)s) },
            { new TypePair(typeof(string),   typeof(sbyte)), (tp, s) => Convert.ToSByte((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(sbyte)), (tp, s) => Convert.ToSByte((ushort)s) },
            { new TypePair(typeof(uint),     typeof(sbyte)), (tp, s) => Convert.ToSByte((uint)s) },
            { new TypePair(typeof(ulong),    typeof(sbyte)), (tp, s) => Convert.ToSByte((ulong)s) },
            // float
            { new TypePair(typeof(bool),     typeof(float)), (tp, s) => Convert.ToSingle((byte)s) },
            { new TypePair(typeof(byte),     typeof(float)), (tp, s) => Convert.ToSingle((bool)s) },
            { new TypePair(typeof(char),     typeof(float)), (tp, s) => Convert.ToSingle((char)s) },
            { new TypePair(typeof(DateTime), typeof(float)), (tp, s) => Convert.ToSingle((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(float)), (tp, s) => Convert.ToSingle((decimal)s) },
            { new TypePair(typeof(double),   typeof(float)), (tp, s) => Convert.ToSingle((double)s) },
            { new TypePair(typeof(short),    typeof(float)), (tp, s) => Convert.ToSingle((short)s) },
            { new TypePair(typeof(int),      typeof(float)), (tp, s) => Convert.ToSingle((int)s) },
            { new TypePair(typeof(long),     typeof(float)), (tp, s) => Convert.ToSingle((long)s) },
            { new TypePair(typeof(sbyte),    typeof(float)), (tp, s) => Convert.ToSingle((sbyte)s) },
            { new TypePair(typeof(float),    typeof(float)), (tp, s) => Convert.ToSingle((float)s) },
            { new TypePair(typeof(string),   typeof(float)), (tp, s) => Convert.ToSingle((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(float)), (tp, s) => Convert.ToSingle((ushort)s) },
            { new TypePair(typeof(uint),     typeof(float)), (tp, s) => Convert.ToSingle((uint)s) },
            { new TypePair(typeof(ulong),    typeof(float)), (tp, s) => Convert.ToSingle((ulong)s) },
            // string
            { new TypePair(typeof(bool),     typeof(string)), (tp, s) => Convert.ToString((byte)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(byte),     typeof(string)), (tp, s) => Convert.ToString((bool)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(char),     typeof(string)), (tp, s) => Convert.ToString((char)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(DateTime), typeof(string)), (tp, s) => Convert.ToString((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(string)), (tp, s) => Convert.ToString((decimal)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(double),   typeof(string)), (tp, s) => Convert.ToString((double)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(short),    typeof(string)), (tp, s) => Convert.ToString((short)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(int),      typeof(string)), (tp, s) => Convert.ToString((int)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(long),     typeof(string)), (tp, s) => Convert.ToString((long)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(sbyte),    typeof(string)), (tp, s) => Convert.ToString((sbyte)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(float),    typeof(string)), (tp, s) => Convert.ToString((float)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(string),   typeof(string)), (tp, s) => Convert.ToString((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(string)), (tp, s) => Convert.ToString((ushort)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(uint),     typeof(string)), (tp, s) => Convert.ToString((uint)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ulong),    typeof(string)), (tp, s) => Convert.ToString((ulong)s, CultureInfo.CurrentCulture) },
            // ushort
            { new TypePair(typeof(bool),     typeof(ushort)), (tp, s) => Convert.ToUInt16((byte)s) },
            { new TypePair(typeof(byte),     typeof(ushort)), (tp, s) => Convert.ToUInt16((bool)s) },
            { new TypePair(typeof(char),     typeof(ushort)), (tp, s) => Convert.ToUInt16((char)s) },
            { new TypePair(typeof(DateTime), typeof(ushort)), (tp, s) => Convert.ToUInt16((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(ushort)), (tp, s) => Convert.ToUInt16((decimal)s) },
            { new TypePair(typeof(double),   typeof(ushort)), (tp, s) => Convert.ToUInt16((double)s) },
            { new TypePair(typeof(short),    typeof(ushort)), (tp, s) => Convert.ToUInt16((short)s) },
            { new TypePair(typeof(int),      typeof(ushort)), (tp, s) => Convert.ToUInt16((int)s) },
            { new TypePair(typeof(long),     typeof(ushort)), (tp, s) => Convert.ToUInt16((long)s) },
            { new TypePair(typeof(sbyte),    typeof(ushort)), (tp, s) => Convert.ToUInt16((sbyte)s) },
            { new TypePair(typeof(float),    typeof(ushort)), (tp, s) => Convert.ToUInt16((float)s) },
            { new TypePair(typeof(string),   typeof(ushort)), (tp, s) => Convert.ToUInt16((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(ushort)), (tp, s) => Convert.ToUInt16((ushort)s) },
            { new TypePair(typeof(uint),     typeof(ushort)), (tp, s) => Convert.ToUInt16((uint)s) },
            { new TypePair(typeof(ulong),    typeof(ushort)), (tp, s) => Convert.ToUInt16((ulong)s) },
            // uint
            { new TypePair(typeof(bool),     typeof(uint)), (tp, s) => Convert.ToUInt32((byte)s) },
            { new TypePair(typeof(byte),     typeof(uint)), (tp, s) => Convert.ToUInt32((bool)s) },
            { new TypePair(typeof(char),     typeof(uint)), (tp, s) => Convert.ToUInt32((char)s) },
            { new TypePair(typeof(DateTime), typeof(uint)), (tp, s) => Convert.ToUInt32((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(uint)), (tp, s) => Convert.ToUInt32((decimal)s) },
            { new TypePair(typeof(double),   typeof(uint)), (tp, s) => Convert.ToUInt32((double)s) },
            { new TypePair(typeof(short),    typeof(uint)), (tp, s) => Convert.ToUInt32((short)s) },
            { new TypePair(typeof(int),      typeof(uint)), (tp, s) => Convert.ToUInt32((int)s) },
            { new TypePair(typeof(long),     typeof(uint)), (tp, s) => Convert.ToUInt32((long)s) },
            { new TypePair(typeof(sbyte),    typeof(uint)), (tp, s) => Convert.ToUInt32((sbyte)s) },
            { new TypePair(typeof(float),    typeof(uint)), (tp, s) => Convert.ToUInt32((float)s) },
            { new TypePair(typeof(string),   typeof(uint)), (tp, s) => Convert.ToUInt32((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(uint)), (tp, s) => Convert.ToUInt32((ushort)s) },
            { new TypePair(typeof(uint),     typeof(uint)), (tp, s) => Convert.ToUInt32((uint)s) },
            { new TypePair(typeof(ulong),    typeof(uint)), (tp, s) => Convert.ToUInt32((ulong)s) },
            // ulong
            { new TypePair(typeof(bool),     typeof(ulong)), (tp, s) => Convert.ToUInt64((byte)s) },
            { new TypePair(typeof(byte),     typeof(ulong)), (tp, s) => Convert.ToUInt64((bool)s) },
            { new TypePair(typeof(char),     typeof(ulong)), (tp, s) => Convert.ToUInt64((char)s) },
            { new TypePair(typeof(DateTime), typeof(ulong)), (tp, s) => Convert.ToUInt64((DateTime)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(decimal),  typeof(ulong)), (tp, s) => Convert.ToUInt64((decimal)s) },
            { new TypePair(typeof(double),   typeof(ulong)), (tp, s) => Convert.ToUInt64((double)s) },
            { new TypePair(typeof(short),    typeof(ulong)), (tp, s) => Convert.ToUInt64((short)s) },
            { new TypePair(typeof(int),      typeof(ulong)), (tp, s) => Convert.ToUInt64((int)s) },
            { new TypePair(typeof(long),     typeof(ulong)), (tp, s) => Convert.ToUInt64((long)s) },
            { new TypePair(typeof(sbyte),    typeof(ulong)), (tp, s) => Convert.ToUInt64((sbyte)s) },
            { new TypePair(typeof(float),    typeof(ulong)), (tp, s) => Convert.ToUInt64((float)s) },
            { new TypePair(typeof(string),   typeof(ulong)), (tp, s) => Convert.ToUInt64((string)s, CultureInfo.CurrentCulture) },
            { new TypePair(typeof(ushort),   typeof(ulong)), (tp, s) => Convert.ToUInt64((ushort)s) },
            { new TypePair(typeof(uint),     typeof(ulong)), (tp, s) => Convert.ToUInt64((uint)s) },
            { new TypePair(typeof(ulong),    typeof(ulong)), (tp, s) => Convert.ToUInt64((ulong)s) }
        });

        /// <summary>
        ///
        /// </summary>
        /// <param name="typePair"></param>
        /// <returns></returns>
        public Func<TypePair, object, object> GetConverter(TypePair typePair)
        {
            if (typePair.TargetType.IsNullableType())
            {
                typePair = new TypePair(typePair.SourceType, Nullable.GetUnderlyingType(typePair.TargetType));
            }

            Func<TypePair, object, object> converter;
            Converters.TryGetValue(typePair, out converter);
            return converter;
        }
    }
}
