namespace Smart.Converter
{
    using System;
#if !PCL
    using System.Runtime.Serialization;
#endif

    /// <summary>
    ///
    /// </summary>
#if !PCL
    [Serializable]
#endif
    public class ObjectConverterException : Exception
    {
        /// <summary>
        ///
        /// </summary>
        public ObjectConverterException()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        public ObjectConverterException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ObjectConverterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if !PCL
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ObjectConverterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
