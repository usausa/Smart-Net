namespace Smart.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Smart.Converter.Converters;

    public sealed class TestObjectConverter : IObjectConverter
    {
        private readonly TestConverterFactory[] converterFactories;

        private readonly ObjectConverter objectConverter;

        public TestObjectConverter()
            : this(x => x)
        {
        }

        public TestObjectConverter(Func<IConverterFactory[], IEnumerable<IConverterFactory>> func)
        {
            converterFactories = func(DefaultObjectFactories.Create()).Select(x => new TestConverterFactory(x)).ToArray();
            objectConverter = new ObjectConverter(converterFactories);
        }

        public bool NotUsed()
        {
            return !converterFactories.Any(x => x.Used);
        }

        public bool UsedOnly<T>()
            where T : IConverterFactory
        {
            foreach (var factory in converterFactories)
            {
                if (factory.Factory.GetType() == typeof(T))
                {
                    if (!factory.Used)
                    {
                        return false;
                    }
                }
                else
                {
                    if (factory.Used)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool UsedIn(params Type[] types)
        {
            foreach (var factory in converterFactories)
            {
                if (factory.Used)
                {
                    if (!types.Contains(factory.Factory.GetType()))
                    {
                        return false;
                    }
                }
                else
                {
                    if (types.Contains(factory.Factory.GetType()))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CanConvert<T>(object value)
        {
            return objectConverter.CanConvert<T>(value);
        }

        public bool CanConvert(object value, Type targetType)
        {
            return objectConverter.CanConvert(value, targetType);
        }

        public bool CanConvert(Type sourceType, Type targetType)
        {
            return objectConverter.CanConvert(sourceType, targetType);
        }

        public T Convert<T>(object value)
        {
            return objectConverter.Convert<T>(value);
        }

        public object Convert(object value, Type targetType)
        {
            return objectConverter.Convert(value, targetType);
        }

        public Func<object, object> CreateConverter(Type sourceType, Type targetType)
        {
            return objectConverter.CreateConverter(sourceType, targetType);
        }
    }
}
