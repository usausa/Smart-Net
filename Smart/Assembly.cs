[assembly: CLSCompliant(false)]

// ReSharper disable CheckNamespace
#pragma warning disable CA1812
#if !NET5_0_OR_GREATER
namespace System.Runtime.CompilerServices
{
    internal sealed class IsExternalInit
    {
    }
}
#endif
#pragma warning restore CA1812
// ReSharper restore CheckNamespace
