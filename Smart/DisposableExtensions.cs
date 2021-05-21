namespace Smart
{
    using System;
    using System.Collections.Generic;

    public static class DisposableExtensions
    {
        public static T AddTo<T>(this T disposable, ICollection<IDisposable> disposables)
            where T : IDisposable
        {
            disposables.Add(disposable);
            return disposable;
        }
    }
}
