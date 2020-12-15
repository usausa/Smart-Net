#nullable disable
namespace Smart.Converter.Converters
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Smart.Reflection;

    public sealed class ConstructorConverterFactory : IConverterFactory
    {
        private static readonly MethodInfo CreateMethod = typeof(ConstructorConverterFactory).GetMethod(nameof(CreateConverter), BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly MethodInfo CreateWithConvertMethod = typeof(ConstructorConverterFactory).GetMethod(nameof(CreateConverterWithConvert), BindingFlags.NonPublic | BindingFlags.Static);

        private readonly IDelegateFactory delegateFactory;

        public ConstructorConverterFactory()
            : this(DelegateFactory.Default)
        {
        }

        public ConstructorConverterFactory(IDelegateFactory delegateFactory)
        {
            this.delegateFactory = delegateFactory;
        }

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            var ci = targetType.GetConstructor(new[] { sourceType });
            if (ci is not null)
            {
                var method = CreateMethod.MakeGenericMethod(sourceType, targetType);
                return (Func<object, object>)method.Invoke(null, new object[] { delegateFactory });
            }

            var pair = targetType.GetConstructors()
                .Where(x => x.GetParameters().Length == 1)
                .Select(x => new
                {
                    Constructor = x,
                    Converter = context.CreateConverter(sourceType, x.GetParameters()[0].ParameterType)
                })
                .FirstOrDefault(x => x.Converter is not null);
            if (pair is not null)
            {
                var method = CreateWithConvertMethod.MakeGenericMethod(pair.Constructor.GetParameters()[0].ParameterType, targetType);
                return (Func<object, object>)method.Invoke(null, new object[] { delegateFactory, pair.Converter });
            }

            return null;
        }

        private static Func<object, object> CreateConverter<TParameter, TTarget>(IDelegateFactory delegateFactory)
        {
            var factory = delegateFactory.CreateFactory<TParameter, TTarget>();
            return x => factory((TParameter)x);
        }

        private static Func<object, object> CreateConverterWithConvert<TParameter, TTarget>(IDelegateFactory delegateFactory, Func<object, object> converter)
        {
            var factory = delegateFactory.CreateFactory<TParameter, TTarget>();
            return x => factory((TParameter)converter(x));
        }
    }
}
