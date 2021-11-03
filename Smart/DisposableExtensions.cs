namespace Smart
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class DisposableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AddTo<T>(this T disposable, ICollection<IDisposable> disposables)
            where T : IDisposable
        {
            disposables.Add(disposable);
            return disposable;
        }
    }
}
