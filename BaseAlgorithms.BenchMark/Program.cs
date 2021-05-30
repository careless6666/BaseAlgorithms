using BenchmarkDotNet.Running;

namespace BaseAlgorithms.BenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<PermutationBenchmark>();
        }
    }
}