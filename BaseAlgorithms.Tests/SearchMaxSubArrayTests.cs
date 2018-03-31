using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class SearchMaxSubArrayTests
    {
        [TestMethod]
        public void GetMaxSubArray()
        {
            var arr = new []{ -2, 1, -3, 4, -1, 2, 1, -5, 4};
            var res = SearchMaxSubArray.GetMaxSubArray(arr);
        }
    }
}
