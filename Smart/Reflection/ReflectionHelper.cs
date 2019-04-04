namespace Smart.Reflection
{
    using System;
    using System.Reflection.Emit;

    /// <summary>
    ///
    /// </summary>
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

        /// <summary>
        ///
        /// </summary>
        public static bool IsCodegenAllowed { get; }
    }
}
