namespace Smart.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Smart.Converter.Converters;

    public sealed class ObjectConverter : IObjectConverter
    {
        public static ObjectConverter Default { get; } = new();

        private readonly TypePairHashArray converterCache = new();

        private IConverterFactory[] factories;

        public ObjectConverter()
        {
            factories = DefaultObjectFactories.Create();
        }

        public ObjectConverter(IEnumerable<IConverterFactory> converterFactories)
        {
            factories = converterFactories.ToArray();
        }

        public void SetFactories(IEnumerable<IConverterFactory> converterFactories)
        {
            factories = converterFactories.ToArray();
            converterCache.Clear();
        }

        //--------------------------------------------------------------------------------
        // Converter
        //--------------------------------------------------------------------------------

        public void Reset()
        {
            converterCache.Clear();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Func<object, object> FindConverter(Type sourceType, Type targetType)
        {
            for (var i = 0; i < factories.Length; i++)
            {
                var converter = factories[i].GetConverter(this, sourceType, targetType);
                if (converter != null)
                {
                    return converter;
                }
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Func<object, object> GetConverter(Type sourceType, Type targetType)
        {
            if (!converterCache.TryGetValue(sourceType, targetType, out var converter))
            {
                converter = converterCache.AddIfNotExist(sourceType, targetType, FindConverter);
            }

            return converter;
        }

        public bool CanConvert<T>(object value)
        {
            return CanConvert(value, typeof(T));
        }

        public bool CanConvert(object value, Type targetType)
        {
            if (value is null)
            {
                return true;
            }

            var sourceType = value.GetType();
            if (sourceType == (targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType))
            {
                return true;
            }

            return GetConverter(sourceType, targetType) != null;
        }

        public bool CanConvert(Type sourceType, Type targetType)
        {
            return GetConverter(sourceType.IsNullableType() ? Nullable.GetUnderlyingType(sourceType) : sourceType, targetType) != null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Convert<T>(object value)
        {
            return (T)Convert(value, typeof(T));
        }

        public object Convert(object value, Type targetType)
        {
            // Specialized null
            if (value is null)
            {
                return targetType.GetDefaultValue();
            }

            // Specialized same type for performance (Nullable is excluded because operation is slow)
            var sourceType = value.GetType();
            if (sourceType == (targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType))
            {
                return value;
            }

            var converter = GetConverter(sourceType, targetType);
            if (converter is null)
            {
                throw new ObjectConverterException($"Type {sourceType} can't convert to {targetType}");
            }

            return converter(value);
        }

        public Func<object, object> CreateConverter(Type sourceType, Type targetType)
        {
            var converter = GetConverter(sourceType.IsNullableType() ? Nullable.GetUnderlyingType(sourceType) : sourceType, targetType);
            if (converter is null)
            {
                return null;
            }

            return CreateConverter(
                targetType.GetDefaultValue(),
                targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType,
                converter);
        }

        private static Func<object, object> CreateConverter(object defaultValue, Type targetType, Func<object, object> converter)
        {
            return value => value is null
                ? defaultValue
                : value.GetType() == targetType
                    ? value
                    : converter(value);
        }

        //--------------------------------------------------------------------------------
        // Diagnostics
        //--------------------------------------------------------------------------------

        public sealed class DiagnosticsInfo
        {
            public int CacheCount { get; }

            public int CacheWidth { get; }

            public int CacheDepth { get; }

            public DiagnosticsInfo(
                int cacheCount,
                int cacheWidth,
                int cacheDepth)
            {
                CacheCount = cacheCount;
                CacheWidth = cacheWidth;
                CacheDepth = cacheDepth;
            }
        }

        public DiagnosticsInfo Diagnostics
        {
            get
            {
                var cacheDiagnostics = converterCache.Diagnostics;
                return new DiagnosticsInfo(
                    cacheDiagnostics.Count,
                    cacheDiagnostics.Width,
                    cacheDiagnostics.Depth);
            }
        }
    }
}
