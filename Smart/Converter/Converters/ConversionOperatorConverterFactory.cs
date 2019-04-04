namespace Smart.Converter.Converters
{
    using System;
    using System.Linq;
    using System.Reflection;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Ignore")]
    public sealed class ConversionOperatorConverterFactory : IConverterFactory
    {
        public Func<object, object> GetConverter(IObjectConverter context, Type sourceType, Type targetType)
        {
            var underlyingTargetType = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;

            var methodInfo = GetImplicitConversionOperator(sourceType, underlyingTargetType);
            if (methodInfo != null)
            {
                return ((IConverterBuilder)Activator.CreateInstance(
                    typeof(MethodConverterBuilder<,>).MakeGenericType(methodInfo.GetParameters()[0].ParameterType, methodInfo.ReturnType), methodInfo)).Build();
            }

            if (underlyingTargetType != targetType)
            {
                methodInfo = GetImplicitConversionOperator(sourceType, targetType);
                if (methodInfo != null)
                {
                    return ((IConverterBuilder)Activator.CreateInstance(
                        typeof(MethodConverterBuilder<,>).MakeGenericType(methodInfo.GetParameters()[0].ParameterType, methodInfo.ReturnType), methodInfo)).Build();
                }
            }

            methodInfo = GetExplicitConversionOperator(sourceType, underlyingTargetType);
            if (methodInfo != null)
            {
                return ((IConverterBuilder)Activator.CreateInstance(
                    typeof(MethodConverterBuilder<,>).MakeGenericType(methodInfo.GetParameters()[0].ParameterType, methodInfo.ReturnType), methodInfo)).Build();
            }

            if (underlyingTargetType != targetType)
            {
                methodInfo = GetExplicitConversionOperator(sourceType, targetType);
                if (methodInfo != null)
                {
                    return ((IConverterBuilder)Activator.CreateInstance(
                        typeof(MethodConverterBuilder<,>).MakeGenericType(methodInfo.GetParameters()[0].ParameterType, methodInfo.ReturnType), methodInfo)).Build();
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

        private sealed class MethodConverterBuilder<TSource, TDestination> : IConverterBuilder
        {
            private readonly MethodInfo mi;

            public MethodConverterBuilder(MethodInfo mi)
            {
                this.mi = mi;
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Ignore")]
            public Func<object, object> Build()
            {
                var func = (Func<TSource, TDestination>)Delegate.CreateDelegate(typeof(Func<TSource, TDestination>), mi);
                return source =>
                {
                    try
                    {
                        return func((TSource)source);
                    }
                    catch
                    {
                        return default(TDestination);
                    }
                };
            }
        }
    }
}
