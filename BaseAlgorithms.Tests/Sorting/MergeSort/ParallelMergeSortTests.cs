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
            Assert.IsTrue(arr.SequenceEqual(new []{ 3, 9, 26, 38, 41, 49, 52, 57 }));
        }

        [TestMethod]
        public void TestMergeBlocks()
        {
            var arr = new[] { 1, 5, 6, 7, 2, 3, 4, 8 };
            var sortEngine = new BaseAlgorithms.MergeSort.ParallelMergeSort();
            var dstArr = new int [8];
            sortEngine.MergeTwoBlocks(arr, dstArr, 0, 3, 4, 7);
            Assert.IsTrue(dstArr.SequenceEqual(new [] { 1,2,3,4,5,6,7,8 }));
        }
        
        [TestMethod]
        public void TestMergeBlocks2()
        {
            var arr = new[] { 1, 2, 5, 6, 3, 4, 7, 8 };
            var sortEngine = new BaseAlgorithms.MergeSort.ParallelMergeSort();
            var dstArr = new int [8];
            sortEngine.MergeTwoBlocks(arr, dstArr, 0, 3, 4, 7);
            Assert.IsTrue(dstArr.SequenceEqual(new [] { 1,2,3,4,5,6,7,8 }));
        }
        
        [TestMethod]
        public void TestMergeBlocks3()
        {
            var arr = new[] { 3, 41, 52, 26, 38, 4, 7, 8 };
            var sortEngine = new BaseAlgorithms.MergeSort.ParallelMergeSort();
            var dstArr = new int [8];
            sortEngine.MergeTwoBlocks(arr, dstArr, 0, 0, 1, 1);
            Assert.IsTrue(dstArr.SequenceEqual(new [] { 3, 41, 0, 0, 0, 0, 0, 0 }));
        }
        
        [TestMethod]
        public void TestMergeBlocks4()
        {
            var arr = new[] { 1, 3, 2, 0, 0, 0, 0, 0 };
            var sortEngine = new BaseAlgorithms.MergeSort.ParallelMergeSort();
            var dstArr = new int [8];
            sortEngine.MergeTwoBlocks(arr, dstArr, 0, 1, 2, 2);
            Assert.IsTrue(dstArr.SequenceEqual(new [] { 1, 2, 3, 0, 0, 0, 0, 0 }));
        }
        
        [TestMethod]
        public void TestMergeBlocks5()
        {
            var arr = new[] { 1, 2, 3, 0, 0, 0, 0, 0 };
            var sortEngine = new BaseAlgorithms.MergeSort.ParallelMergeSort();
            var dstArr = new int [8];
            sortEngine.MergeTwoBlocks(arr, dstArr, 0, 1, 2, 2);
            Assert.IsTrue(dstArr.SequenceEqual(new [] { 1, 2, 3, 0, 0, 0, 0, 0 }));
        }
        
        [TestMethod]
        public void TestMergeBlocks6()
        {
            var arr = new[] { 0, 0, 1, 2, 3, 0, 0, 0 };
            var sortEngine = new BaseAlgorithms.MergeSort.ParallelMergeSort();
            var dstArr = new int [8];
            sortEngine.MergeTwoBlocks(arr, dstArr, 2, 3, 4, 4);
            Assert.IsTrue(dstArr.SequenceEqual(new [] { 0, 0, 1, 2, 3, 0, 0, 0 }));
        }
    }
}