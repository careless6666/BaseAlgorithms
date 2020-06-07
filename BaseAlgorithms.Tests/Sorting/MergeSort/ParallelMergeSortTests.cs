using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.MergeSort
{
    [TestClass]
    public class ParallelMergeSortTests
    {
        [TestMethod]
        public void TestParallelMergeSort()
        {
            var arr = new[] { 3, 41, 52, 26, 38, 57, 9, 49 };
            
            var sortEngine = new BaseAlgorithms.MergeSort.ParallelMergeSort();
            sortEngine.Sort(arr);
            Assert.IsTrue(arr.SequenceEqual(new []{3, 9, 26, 38, 41, 49, 52, 57}));
        }
    }
}