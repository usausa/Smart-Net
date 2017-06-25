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
            get => currentValue;
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparand"></param>
        /// <returns></returns>
        public bool TrySet(T value, T comparand)
        {
            return Interlocked.CompareExchange(ref currentValue, value, comparand) == comparand;
        }
    }
}
