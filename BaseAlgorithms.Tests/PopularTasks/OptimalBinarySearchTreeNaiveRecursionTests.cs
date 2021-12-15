using BaseAlgorithms.PopularTasks.OptimalBinarySearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks.OptimalBinarySearchTree
{
    [TestClass]
    public class OptimalBinarySearchTreeNaiveRecursionTests
    {
        [TestMethod]
        public void TestFrequenceRecursive()
        {
            int []keys = {10, 12, 20}; 
            int []freq = {34, 8, 50}; 
            var n = keys.Length;
            var res = OptimalBinarySearchTreeNaiveRecursion.OptimalSearchTree(keys, freq, n);
            Assert.AreEqual(142, res);
            
        }
        
        [TestMethod]
        public void TestFrequence()
        {
            int []keys = {10, 12, 20}; 
            int []freq = {34, 8, 50}; 
            var n = keys.Length;
            var res = OptimalBinarySearchTreeDP.OptimalSearchTree(keys, freq, n);
            Assert.AreEqual(142, res);
        }
    }
}