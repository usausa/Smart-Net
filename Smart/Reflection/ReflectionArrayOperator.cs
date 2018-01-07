namespace Smart.Reflection
{
    using System;

    public class ReflectionArrayOperator : IArrayOperator
    {
        public Type Source { get; }

        public ReflectionArrayOperator(Type source)
        {
            Source = source;
        }

        public Array Create(int length)
        {
            return Array.CreateInstance(Source, length);
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
