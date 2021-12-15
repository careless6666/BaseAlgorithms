using BaseAlgorithms.PopularTasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BaseAlgorithms.BenchMark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class PermutationBenchmark
    {
        [Benchmark]
        public void GenerateRecursiveMutations()
        {
            var mutations = new PermutaionRecursion();
            var res = mutations.GenerateRecursive("ABC");    
        }
        
        [Benchmark]
        public void GenerateLinearMutations()
        {
            var mutations = new PermutaionsLinear();
            var res = mutations.Generate(4);
        }
        
    }
}