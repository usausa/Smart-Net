namespace Smart.Converter.Converters
{
    using System;
    using System.Linq;
    using System.Reflection;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Ignore")]
    public sealed class ConversionOperatorConverterFactory : IConverterFactory
    {
        private static readonly MethodInfo CreateMethod = typeof(ConversionOperatorConverterFactory).GetMethod(nameof(CreateConverter), BindingFlags.NonPublic | BindingFlags.Static);

        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            var underlyingTargetType = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;

            var methodInfo = GetImplicitConversionOperator(sourceType, underlyingTargetType);
            if (methodInfo != null)
            {
                return BuildConverter(methodInfo);
            }

            if (underlyingTargetType != targetType)
            {
                methodInfo = GetImplicitConversionOperator(sourceType, targetType);
                if (methodInfo != null)
                {
                    return BuildConverter(methodInfo);
                }
            }

            methodInfo = GetExplicitConversionOperator(sourceType, underlyingTargetType);
            if (methodInfo != null)
            {
                return BuildConverter(methodInfo);
            }

            if (underlyingTargetType != targetType)
            {
                methodInfo = GetExplicitConversionOperator(sourceType, targetType);
                if (methodInfo != null)
                {
                    return BuildConverter(methodInfo);
                }
            }

            return null;
        }

        private static MethodInfo GetImplicitConversionOperator(Type sourceType, Type targetType)
        {
            var sourceTypeMethod = sourceType
                .GetMethods()
                .FirstOrDefault(mi =>
                    mi.IsPublic &&
                    mi.IsStatic &&
                    mi.Name == "op_Implicit" &&
                    mi.ReturnType == targetType);
            return sourceTypeMethod ?? targetType
                       .GetMethods()
                       .FirstOrDefault(mi =>
                           mi.IsPublic &&
                           mi.IsStatic &&
                           mi.Name == "op_Implicit" &&
                           mi.GetParameters().Length == 1 &&
                           IsMatchParameterType(mi.GetParameters()[0].ParameterType, sourceType));
        }

        private static MethodInfo GetExplicitConversionOperator(Type sourceType, Type targetType)
        {
            var sourceTypeMethod = sourceType
                .GetMethods()
                .FirstOrDefault(mi =>
                    mi.IsPublic &&
                    mi.IsStatic &&
                    mi.Name == "op_Explicit" &&
                    mi.ReturnType == targetType);
            return sourceTypeMethod ?? targetType
                .GetMethods()
                .FirstOrDefault(mi =>
                           mi.IsPublic &&
                           mi.IsStatic &&
                           mi.Name == "op_Explicit" &&
                           mi.GetParameters().Length == 1 &&
                           IsMatchParameterType(mi.GetParameters()[0].ParameterType, sourceType));
        }

        private static bool IsMatchParameterType(Type parameterType, Type sourceType)
        {
            return parameterType.IsNullableType()
                ? Nullable.GetUnderlyingType(parameterType) == sourceType
                : parameterType == sourceType;
        }

        private static Func<object, object> BuildConverter(MethodInfo mi)
        {
            var method = CreateMethod.MakeGenericMethod(mi.ReturnType);
            return (Func<object, object>)method.Invoke(null, new object[] { mi });
        }

        private static Func<object, object> CreateConverter<TDestination>(MethodInfo mi)
        {
            return source =>
            {
                try
                {
                    return (TDestination)mi.Invoke(null, new[] { source });
                }
                catch
                {
                    return default(TDestination);
                }
            };
        }
    }
}
