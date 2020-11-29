namespace Smart
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public sealed unsafe class NativeArray<T> : IDisposable
        where T : unmanaged
    {
        private readonly int length;

        private IntPtr pointer;

        public static NativeArray<T> Empty => new NativeArray<T>();

        public int Length => length;

        public IntPtr Pointer => pointer;

        public T this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => GetReference(i);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => GetReference(i) = value;
        }

        private NativeArray()
        {
        }

        public NativeArray(int length)
        {
            this.length = length;
            var size = sizeof(T) * length;
            pointer = Marshal.AllocHGlobal(size);
        }

        public NativeArray(Span<T> span)
        {
            length = span.Length;
            var size = sizeof(T) * length;
            pointer = Marshal.AllocHGlobal(size);
            span.CopyTo(new Span<T>((void*)pointer, length));
        }

        public void Dispose()
        {
            if (pointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pointer);
                pointer = IntPtr.Zero;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T GetReference(int i) => ref Unsafe.AsRef<T>((T*)pointer + i);

        public Span<T> AsSpan() => new Span<T>((T*)pointer, length);
    }
}
