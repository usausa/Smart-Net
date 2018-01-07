namespace Smart.Reflection
{
    using System;

    public interface IArrayOperator
    {
        Type Source { get; }

        Array Create(int length);

        object GetValue(Array array, int index);

        void SetValue(Array array, int index, object value);
    }
}
