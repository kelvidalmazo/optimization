using BenchmarkDotNet.Attributes;

namespace CodingOptimization.Runners;

[Config(typeof(JobRunner))]
public class StructRunner
{
    [Benchmark]
    public void WithClass()
    {
        var vectors = new VectorClass[Parameters.TenMillion];

        for (var i = 0; i < Parameters.TenMillion; i++)
            vectors[i] = new VectorClass
            {
                X = 5,
                Y = 10
            };
    }

    [Benchmark]
    public void WithStruct()
    {
        var vectors = new VectorStruct[Parameters.TenMillion];

        for (var i = 0; i < Parameters.TenMillion; i++)
        {
            vectors[i].X = 5;
            vectors[i].Y = 10;
        }
    }

    private class VectorClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    private struct VectorStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}