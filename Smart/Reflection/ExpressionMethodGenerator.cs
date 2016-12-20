namespace Smart.Reflection
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public static class ExpressionMethodGenerator
    {
        private static readonly Type ObjectArrayType = typeof(object[]);

        private static readonly Type ObjectType = typeof(object);

        private static readonly Type ConvertType = typeof(Convert);

        /// <summary>
        ///
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public static Func<object[], object> CreateActivator(ConstructorInfo ci)
        {
            if (ci == null)
            {
                throw new ArgumentNullException(nameof(ci));
            }

            var parameters = ci.GetParameters();

            var parametersExpression = Expression.Parameter(ObjectArrayType, "args");
            var argumentsExpression = new Expression[parameters.Length];

            for (var i = 0; i < parameters.Length; i++)
            {
                var parameterType = parameters[i].ParameterType;

                var parameterIndexExpression = Expression.ArrayIndex(parametersExpression, Expression.Constant(i));
                var convertExpression = parameterType.GetTypeInfo().IsPrimitive
                    ? Expression.Convert(MakeCallConvertExpression(parameterIndexExpression, parameterType), parameterType)
                    : Expression.Convert(parameterIndexExpression, parameterType);
                if (parameterType.GetTypeInfo().IsValueType)
                {
                    argumentsExpression[i] = Expression.Condition(
                        Expression.Equal(parameterIndexExpression, Expression.Constant(null)),
                        Expression.Default(parameterType),
                        convertExpression);
                }
                else
                {
                    argumentsExpression[i] = convertExpression;
                }
            }

            return Expression.Lambda<Func<object[], object>>(
                Expression.New(ci, argumentsExpression),
                parametersExpression).Compile();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="valueExpression"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        private static MethodCallExpression MakeCallConvertExpression(Expression valueExpression, Type conversionType)
        {
            return Expression.Call(
                ConvertType.GetRuntimeMethod(nameof(Convert.ChangeType), new[] { ObjectType, typeof(Type) }),
                valueExpression,
                Expression.Constant(conversionType));
        }
    }
}
