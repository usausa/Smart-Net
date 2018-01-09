namespace Smart.Reflection
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public interface IArrayOperatorFactory
    {
        IArrayOperator CreateArrayOperator(Type type);
    }
}
