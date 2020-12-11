namespace Benchmark.Text
{
    using System;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    using Smart.Text;

    [Config(typeof(BenchmarkConfig))]
    public class InflectorBenchmark
    {
        [Benchmark]
        public string Pascalize() => Inflector.Pascalize("aaa_bbb_ccc_ddd");

        [Benchmark]
        public string Camelize() => Inflector.Camelize("aaa_bbb_ccc_ddd");

        [Benchmark]
        public string Underscore() => Inflector.Underscore("aaaBbbCccDdd");
    }
}
