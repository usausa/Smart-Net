namespace Smart.Reflection
{
    using System;

    /// <summary>
    ///
    /// </summary>
    [Obsolete]
    public static class GeneratorConfig
    {
        /// <summary>
        ///
        /// </summary>
        public static GeneratorMode GeneratorMode { get; set; } = GeneratorMode.Throughput;

        /// <summary>
        ///
        /// </summary>
        public static bool SageMode { get; set; }
    }
}
