using BaseAlgorithms.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Strings
{
    [TestClass]
    public class FiniteAutomataSearchTests
    {
        [TestMethod]
        [DataRow("stringa", 8)]
        [DataRow("ololo", -1)]
        public void TestSearch(string pattern, int expectedIndex)
        {
            var txt = "My test stringa!";
            var resIndex = FiniteAutomataSearch.Search(pattern.ToCharArray(), txt.ToCharArray());
            Assert.AreEqual(expectedIndex, resIndex);
        }
    }
}