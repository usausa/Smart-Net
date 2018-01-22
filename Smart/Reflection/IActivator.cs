namespace Smart.Reflection
{
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public interface IActivator
    {
        /// <summary>
        ///
        /// </summary>
        ConstructorInfo Source { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        object Create(params object[] arguments);
    }

    /// <summary>
    ///
    /// </summary>
    public interface IActivator0 : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        object Create();
    }

    /// <summary>
    ///
    /// </summary>
    public interface IActivator1 : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="artument1"></param>
        /// <returns></returns>
        object Create(
            object artument1);
    }

    /// <summary>
    ///
    /// </summary>
    public interface IActivator2 : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="artument1"></param>
        /// <param name="artument2"></param>
        /// <returns></returns>
        object Create(
            object artument1,
            object artument2);
    }

    /// <summary>
    ///
    /// </summary>
    public interface IActivator3 : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="artument1"></param>
        /// <param name="artument2"></param>
        /// <param name="artument3"></param>
        /// <returns></returns>
        object Create(
            object artument1,
            object artument2,
            object artument3);
    }

    /// <summary>
    ///
    /// </summary>
    public interface IActivator4 : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="artument1"></param>
        /// <param name="artument2"></param>
        /// <param name="artument3"></param>
        /// <param name="artument4"></param>
        /// <returns></returns>
        object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4);
    }

    /// <summary>
    ///
    /// </summary>
    public interface IActivator5 : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="artument1"></param>
        /// <param name="artument2"></param>
        /// <param name="artument3"></param>
        /// <param name="artument4"></param>
        /// <param name="artument5"></param>
        /// <returns></returns>
        object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4,
            object artument5);
    }

    /// <summary>
    ///
    /// </summary>
    public interface IActivator6 : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="artument1"></param>
        /// <param name="artument2"></param>
        /// <param name="artument3"></param>
        /// <param name="artument4"></param>
        /// <param name="artument5"></param>
        /// <param name="artument6"></param>
        /// <returns></returns>
        object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4,
            object artument5,
            object artument6);
    }

    /// <summary>
    ///
    /// </summary>
    public interface IActivator7 : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="artument1"></param>
        /// <param name="artument2"></param>
        /// <param name="artument3"></param>
        /// <param name="artument4"></param>
        /// <param name="artument5"></param>
        /// <param name="artument6"></param>
        /// <param name="artument7"></param>
        /// <returns></returns>
        object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4,
            object artument5,
            object artument6,
            object artument7);
    }

    /// <summary>
    ///
    /// </summary>
    public interface IActivator8 : IActivator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="artument1"></param>
        /// <param name="artument2"></param>
        /// <param name="artument3"></param>
        /// <param name="artument4"></param>
        /// <param name="artument5"></param>
        /// <param name="artument6"></param>
        /// <param name="artument7"></param>
        /// <param name="artument8"></param>
        /// <returns></returns>
        object Create(
            object artument1,
            object artument2,
            object artument3,
            object artument4,
            object artument5,
            object artument6,
            object artument7,
            object artument8);
    }
}
