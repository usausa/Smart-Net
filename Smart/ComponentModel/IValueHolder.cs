namespace Smart.ComponentModel
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValueHolder<T>
    {
        /// <summary>
        ///
        /// </summary>
        T Value { get; set; }
    }
}
