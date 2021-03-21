using BaseAlgorithms.PopularTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks
{
    [TestClass]
    public class LevenshteinDistanceTests
    {
        [TestMethod]
        [DataRow("aaa", "aaa", 0)]
        [DataRow("aaa", "baa", 1)]
        [DataRow("aaa", "aba", 1)]
        [DataRow("aaa", "aab", 1)]
        [DataRow("aaa", "bbb", 3)]
        [DataRow("aaa", "aaaa", 1)]
        [DataRow("aaa", "aaaab", 2)]
        public void TestCalculate(string a, string b, int distance)
        {
            var result = LevenshteinDistance.Calculate(a, b);
            Assert.AreEqual(distance, result);
        }
    }
}