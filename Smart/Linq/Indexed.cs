namespace Smart.Linq
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Indexed<T>
    {
        /// <summary>
        ///
        /// </summary>
        public T Item { get;  }

        /// <summary>
        ///
        /// </summary>
        public int Index { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public Indexed(T item, int index)
        {
            Item = item;
            Index = index;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Item.GetHashCode() ^ Index;
        }
    }
}
