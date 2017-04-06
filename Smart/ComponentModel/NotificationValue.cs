namespace Smart.ComponentModel
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NotificationValue<T> : NotificationObject, IValueHolder<T>
    {
        private T storage;

        /// <summary>
        ///
        /// </summary>
        public T Value
        {
            get => storage;
            set => SetProperty(ref storage, value);
        }

        /// <summary>
        ///
        /// </summary>
        public NotificationValue()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        public NotificationValue(T value)
        {
            storage = value;
        }
    }
}
