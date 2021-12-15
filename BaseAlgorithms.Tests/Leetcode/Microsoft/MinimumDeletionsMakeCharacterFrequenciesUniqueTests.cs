using BaseAlgorithms.LeetCode.Microsoft;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Leetcode.Microsoft
{
    [TestClass]
    public class MinimumDeletionsMakeCharacterFrequenciesUniqueTests
    {
        private MinimumDeletionsMakeCharacterFrequenciesUnique processor = new();
        
        [TestMethod]
        public void Test()
        {
            var res = processor.MinDeletions("aaabbc");
            Assert.AreEqual(0, res);
        }
        
        [TestMethod]
        public void Test1()
        {
            var res = processor.MinDeletions("aaabbbcc");
            Assert.AreEqual(2, res);
        }
        
        [TestMethod]
        public void Test2()
        {
            var res = processor.MinDeletions("ceabaacb");
            Assert.AreEqual(2, res);
        }
        
        [TestMethod]
        public void Test3()
        {
            var res = processor.MinDeletions("accdcdadddbaadbc");
            Assert.AreEqual(1, res);
        }
    }
}