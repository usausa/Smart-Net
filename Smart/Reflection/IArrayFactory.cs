namespace Smart.Reflection
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public interface IArrayFactory
    {
        ArrayMetadata CreateArray(Type type);
    }
}
