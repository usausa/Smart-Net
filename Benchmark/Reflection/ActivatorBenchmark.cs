namespace Benchmark.Reflection
{
    using System;
    using System.Reflection;

    using BenchmarkDotNet.Attributes;

    using Smart.Reflection;

    /// <summary>
    ///
    /// </summary>
    [Config(typeof(BenchmarkConfig))]
    public class ActivatorBenchmark
    {
        public sealed class NewActivator : IActivator
        {
            public ConstructorInfo Source { get; } = typeof(Class0).GetConstructor(Type.EmptyTypes);

            public object Create(params object[] arguments)
            {
                return new Class0();
            }
        }

        private IActivator newActivator;

        private IActivator codeGenerateActivator;

        private IActivator reflectionActivator;

        [GlobalSetup]
        public void Setup()
        {
            var ctor = typeof(Class0).GetConstructor(Type.EmptyTypes);
            newActivator = new NewActivator();
            codeGenerateActivator = CodeGenerateTypeMetadataFactory.Default.CreateActivator(ctor);
            reflectionActivator = ReflectionTypeMetadataFactory.Default.CreateActivator(ctor);
        }

        [Benchmark(Baseline = true)]
        public object NewRaw()
        {
            return new Class0();
        }

        [Benchmark]
        public object NewWithActivator()
        {
            return newActivator.Create(null);
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
