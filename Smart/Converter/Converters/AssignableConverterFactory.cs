namespace Smart.Converter.Converters
{
    using System;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public sealed class AssignableConverterFactory : IConverterFactory
    {
        private static readonly Func<TypePair, object, object> Converter = (typePair, source) => source;

        /// <summary>
        ///
        /// </summary>
        /// <param name="typePair"></param>
        /// <returns></returns>
        public Func<TypePair, object, object> GetConverter(TypePair typePair)
        {
            return typePair.TargetType.GetTypeInfo().IsAssignableFrom(typePair.SourceType.GetTypeInfo()) ? Converter : null;
        }
    }
}
