namespace Smart.Reflection
{
    using System;
    using System.Reflection.Emit;

    /// <summary>
    ///
    /// </summary>
    public static class ReflectionHelper
    {
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
            catch (Exception)
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
