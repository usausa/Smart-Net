namespace Smart.Converter
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ObjectConverterException : Exception
    {
        public ObjectConverterException()
        {
        }

        public ObjectConverterException(string message)
            : base(message)
        {
        }

        public ObjectConverterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ObjectConverterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
