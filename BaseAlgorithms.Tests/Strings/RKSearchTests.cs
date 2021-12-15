using BaseAlgorithms.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Strings
{
    [TestClass]
    public class RKSearchTests
    {
        [TestMethod]
        [DataRow("stringa", 8)]
        [DataRow("ololo", -1)]
        public void TestSearch(string pattern, int expectedIndex)
        {
            var txt = "My test stringa!";
            var resIndex = RKSearch.Search(pattern, txt, 47);
            Assert.AreEqual(expectedIndex, resIndex);
        }
    }
}