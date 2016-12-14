namespace Smart.Converter
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Smart.Converter.Converters;

    /// <summary>
    ///
    /// </summary>
    public class ObjectConverter
    {
        /// <summary>
        ///
        /// </summary>
        public static ObjectConverter Default { get; } = new ObjectConverter();

        private readonly ConcurrentDictionary<TypePair, Func<TypePair, object, object>> converterCache = new ConcurrentDictionary<TypePair, Func<TypePair, object, object>>();

        private IList<IConverterFactory> factories;

        /// <summary>
        ///
        /// </summary>
        public ObjectConverter()
        {
            ResetFactories();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        public void SetFactories(IList<IConverterFactory> list)
        {
            factories = list;
            converterCache.Clear();
        }

        /// <summary>
        ///
        /// </summary>
        public void ResetFactories()
        {
            factories = DefaultObjectFactories.Create();
            converterCache.Clear();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Convert<T>(object value)
        {
            return (T)Convert(value, typeof(T));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType)
        {
            try
            {
                if (value == null)
                {
                    return targetType.GetDefaultValue();
                }

                var sourceType = value.GetType();
                if (sourceType == (targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType))
                {
                    return value;
                }

                var typePair = new TypePair(sourceType, targetType);
                var converter = converterCache.GetOrAdd(
                    typePair,
                    tp => factories.Select(f => f.GetConverter(tp)).FirstOrDefault(c => c != null));
                if (converter == null)
                {
                    throw new ObjectConverterException(String.Format(CultureInfo.InvariantCulture, "Type {0} can't convert to {1}", value.GetType().ToString(), targetType));
                }

                return converter(typePair, value);
            }
            catch (Exception ex)
            {
                throw new ObjectConverterException("Unknown exception.", ex);
            }
        }
    }
}
