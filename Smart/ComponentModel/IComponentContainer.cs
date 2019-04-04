namespace Smart.ComponentModel
{
    using System;
    using System.Collections.Generic;

    public interface IComponentContainer : IDisposable, IServiceProvider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Ignore")]
        T Get<T>();

        T TryGet<T>();

        IEnumerable<T> GetAll<T>();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Ignore")]
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
