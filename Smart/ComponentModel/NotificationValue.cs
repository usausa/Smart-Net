namespace Smart.ComponentModel
{
    public class NotificationValue<T> : NotificationObject, IValueHolder<T>
    {
        private T storage;

        public T Value
        {
            get => storage;
            set => SetProperty(ref storage, value);
        }

        public NotificationValue()
        {
        }

        public NotificationValue(T value)
        {
            storage = value;
        }
    }
}
