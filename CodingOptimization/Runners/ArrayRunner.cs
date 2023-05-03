using System.Buffers;
using BenchmarkDotNet.Attributes;

namespace CodingOptimization.Runners;

[Config(typeof(JobRunner))]
public class ArrayRunner
{
    [Benchmark(Baseline = true)]
    public void WithDefault()
    {
        var array = new int[Parameters.HundredMillion];
    }

    [Benchmark]
    public void WithPoolDefined()
    {
        var pool = ArrayPool<int>.Shared;
        var array = pool.Rent(Parameters.HundredMillion);
        pool.Return(array);
    }
}