namespace Smart.Threading
{
    using System.Threading;

    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AtomicReference<T> : IValueHolder<T>
        where T : class
    {
        private T currentValue;

        /// <summary>
        ///
        /// </summary>
        public T Value
        {
            get => Interlocked.Exchange(ref currentValue, currentValue);
            set => Interlocked.Exchange(ref currentValue, value);
        }

        /// <summary>
        ///
        /// </summary>
        public AtomicReference()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initialValue"></param>
        public AtomicReference(T initialValue)
        {
            currentValue = initialValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T GetAndSet(T value)
        {
            return Interlocked.Exchange(ref currentValue, value);
        }
    }
}
