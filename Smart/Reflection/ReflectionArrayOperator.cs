namespace Smart.Reflection
{
    using System;

    public class ReflectionArrayOperator : IArrayOperator
    {
        public Type Type { get; }

        public ReflectionArrayOperator(Type type)
        {
            Type = type;
        }

        public Array Create(int length)
        {
            return Array.CreateInstance(Type, length);
        }

        public object GetValue(Array array, int index)
        {
            return array.GetValue(index);
        }

        public void SetValue(Array array, int index, object value)
        {
            array.SetValue(value, index);
        }
    }
}
