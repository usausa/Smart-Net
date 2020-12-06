namespace Smart.ComponentModel
{
    using System;

    public abstract class DisposableObject : IDisposable
    {
        private readonly object sync = new();

        public bool IsDisposed { get; private set; }

        ~DisposableObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (sync)
            {
                if (disposing && !IsDisposed)
                {
                    IsDisposed = true;
                }
            }
        }
    }
}
