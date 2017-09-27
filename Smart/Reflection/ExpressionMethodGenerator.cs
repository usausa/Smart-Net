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
                var convertExpression = Expression.Convert(parameterIndexExpression, parameterType);
                argumentsExpression[i] = convertExpression;
            }

            return Expression.Lambda<Func<object[], object>>(
                Expression.New(ci, argumentsExpression),
                parametersExpression).Compile();
        }

#if false
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <typeparam name="TMember"></typeparam>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static Func<TTarget, TMember> CreateTypedGetter<TTarget, TMember>(PropertyInfo pi)
        {
            var parameterExpression = Expression.Parameter(typeof(TTarget));
            var propertyExpression = Expression.Property(parameterExpression, pi);
            return Expression.Lambda<Func<TTarget, TMember>>(
                propertyExpression,
                parameterExpression).Compile();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <typeparam name="TMember"></typeparam>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static Action<TTarget, TMember> CreateTypedSetter<TTarget, TMember>(PropertyInfo pi)
        {
            var parameterExpression = Expression.Parameter(typeof(TTarget));
            var parameterExpression2 = Expression.Parameter(typeof(TMember));
            var propertyExpression = Expression.Property(parameterExpression, pi);
            return Expression.Lambda<Action<TTarget, TMember>>(
                Expression.Assign(propertyExpression, parameterExpression2),
                parameterExpression,
                parameterExpression2).Compile();
        }
#endif
    }
}
