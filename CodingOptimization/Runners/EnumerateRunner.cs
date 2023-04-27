using BenchmarkDotNet.Attributes;

namespace CodingOptimization.Runners;

[Config(typeof(JobRunner))]
public class EnumerateRunner
{
    [Benchmark]
    public void WithNoCapacity()
    {
        var list = new List<int>();

        for (var i = 0; i < Parameters.HundredMillion; i++)
            list.Add(i);
    }

    [Benchmark]
    public void WithCapacity()
    {
        var list = new List<int>(Parameters.HundredMillion);

        for (var i = 0; i < Parameters.HundredMillion; i++)
            list.Add(i);
    }
}