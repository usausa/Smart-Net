namespace Smart.Reflection
{
    using System;
    using System.Reflection.Emit;

    public static class ReflectionHelper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Ignore")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1806:DoNotIgnoreMethodResults", Justification = "Ignore")]
        static ReflectionHelper()
        {
            try
            {
                // ReSharper disable once ObjectCreationAsStatement
                new DynamicMethod(
                    string.Empty,
                    typeof(object),
                    Type.EmptyTypes,
                    true);
                IsCodegenAllowed = true;
            }
            catch
            {
                IsCodegenAllowed = false;
            }
        }

        public static bool IsCodegenAllowed { get; }
    }
}
