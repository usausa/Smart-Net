namespace Benchmark.Reflection
{
    using System;

    using BenchmarkDotNet.Attributes;

    using Smart.Reflection;

    /// <summary>
    ///
    /// </summary>
    [Config(typeof(BenchmarkConfig))]
    public class ActivatorBenchmark
    {
        private IActivator codeGenerateActivator;

        private IActivator reflectionActivator;

        [GlobalSetup]
        public void Setup()
        {
            var ctor = typeof(Class0).GetConstructor(Type.EmptyTypes);
            codeGenerateActivator = CodeGenerateTypeMetadataFactory.Default.CreateActivator(ctor);
            reflectionActivator = ReflectionTypeMetadataFactory.Default.CreateActivator(ctor);
        }

        [Benchmark]
        public object New()
        {
            return new Class0();
        }

        [Benchmark]
        public object CodeGenerate()
        {
            return codeGenerateActivator.Create(null);
        }

        [Benchmark]
        public object Reflection()
        {
            return reflectionActivator.Create(null);
        }
    }
}
