using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class LargestSumContiguousSubarrayTests
    {
        [TestMethod]
        public void TestMaxSubArraySum()
        {
            int[] arr = { -2, -3, 4, -1, -2, 1, 5, -3 };
            var max = LargestSumContiguousSubarray.MaxSubArraySum(arr);

            Assert.AreEqual(7, max);
        }
    }
}
