using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class OrderStatisticsTests
    {
        [TestMethod]
        public void TestGetStatistics()
        {
            var arr = new[] { 3, 41, 52, 26, 38, 57, 9, 49 };

            var res = OrderStatistics.GetStatistics(arr, 3);
            Assert.AreEqual(38, res);
        }
    }
}
