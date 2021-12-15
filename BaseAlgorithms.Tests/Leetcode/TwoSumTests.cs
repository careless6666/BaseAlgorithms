using BaseAlgorithms.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Leetcode
{
    [TestClass]
    public class TwoSumTests
    {
        [TestMethod]
        public void Test()
        {
            var res = new TwoSumTask().TwoSum(new int[] {2, 7, 11, 15}, 9);
            Assert.AreEqual(res[0] ,0); 
            Assert.AreEqual(res[1] ,1); 
        }
        
        [TestMethod]
        public void Test1()
        {
            var res = new TwoSumTask().TwoSum(new int[] {3,2,4}, 6);
            Assert.AreEqual(res[0] ,1); 
            Assert.AreEqual(res[1] ,2); 
        }
        
        [TestMethod]
        public void Test2()
        {
            var res = new TwoSumTask().TwoSum(new int[] {3, 3}, 6);
            Assert.AreEqual(res[0] ,0); 
            Assert.AreEqual(res[1] ,1); 
        }
    }
}