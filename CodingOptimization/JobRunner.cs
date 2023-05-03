using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using Perfolizer.Horology;

namespace CodingOptimization;

public class JobRunner : ManualConfig
{
    public JobRunner()
    {
        HideColumns(StatisticColumn.Error, StatisticColumn.StdDev);
        AddColumn(StatisticColumn.Max, StatisticColumn.Min, RankColumn.Arabic);
        AddDiagnoser(MemoryDiagnoser.Default, new InliningDiagnoser(), new EtwProfiler());
        AddJob(CreateJob(Platform.X64, CoreRuntime.Core60));
    }

    private static Job CreateJob(Platform platform, Runtime runtime, int iterationCount = 100)
    {
        return Job.Default
            .WithStrategy(RunStrategy.ColdStart)
            .WithJit(Jit.RyuJit)
            .WithPlatform(platform)
            .WithRuntime(runtime)
            .WithInvocationCount(1)
            .WithIterationCount(iterationCount)
            .WithIterationTime(TimeInterval.Millisecond * 50)
            .WithWarmupCount(5)
            .WithGcServer(true);
    }
}