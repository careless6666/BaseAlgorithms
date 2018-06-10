using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class MaximumSubarraySumRecursiveTests
    {
        [TestMethod]
        public void TestMaxSubArraySum()
        {
            int[] arr = { 2, 3, -4, 5, 7 };
            var res = MaximumSubarraySumRecursive.MaxSubArraySum(arr, 0, arr.Length - 1);
            Assert.AreEqual(13, res);
        }
    }
}
