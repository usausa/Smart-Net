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
                    //var type = Type.GetType("System.Reflection.Emit.DynamicMethod");
                    //if (type == null)
                    //{
                    //    return false;
                    //}

                    //Activator.CreateInstance(type, string.Empty, typeof(object), Type.EmptyTypes, true);

                    // ReSharper disable once ObjectCreationAsStatement
                    new DynamicMethod(
                        string.Empty,
                        typeof(object),
                        Type.EmptyTypes,
                        true);
                    return true;
                }
                catch (PlatformNotSupportedException)
                {
                    return false;
                }
            }
        }
    }
}
