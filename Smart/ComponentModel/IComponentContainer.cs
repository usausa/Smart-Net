namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Ignore")]
    public interface IComponentContainer : IDisposable, IServiceProvider
    {
        T Get<T>();

        T TryGet<T>();

        IEnumerable<T> GetAll<T>();

        object Get(Type componentType);

        object TryGet(Type componentType);

        object TryGet(Type componentType, out bool result);

        /// <summary>
        ///
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns></returns>
        IEnumerable<object> GetAll(Type componentType);
    }
}
