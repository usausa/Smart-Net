namespace Smart.ComponentModel
{
    using System.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class NotificationValue<T> : IValueHolder<T>, INotifyPropertyChanged
    {
        /// <summary>
        ///
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private T storage;

        /// <summary>
        ///
        /// </summary>
        public T Value
        {
            get
            {
                return storage;
            }
            set
            {
                if (Equals(storage, value))
                {
                    return;
                }

                storage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
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
