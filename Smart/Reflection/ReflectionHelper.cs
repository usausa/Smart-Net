namespace Smart.Reflection
{
    using System;
    using System.Reflection.Emit;

    /// <summary>
    ///
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        ///
        /// </summary>
        public static bool IsCodegenAllowed
        {
            get
            {
                try
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new DynamicMethod(
                        string.Empty,
                        typeof(object),
                        Type.EmptyTypes,
                        true);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
