using BaseAlgorithms.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Strings
{
    [TestClass]
    public class KMPSearchTests
    {
        [TestMethod]
        [DataRow("ABABDABACDABABCABAB", "ABABCABAB", 10)]
        [DataRow("ABFABC", "ABC", 3)]
        [DataRow("ABABC", "ABC", 2)]
        [DataRow("ABABAAABBA", "AAABBA", 4)]
        public void TestSearch(string txt, string pat, int index)
        {
            var res = new KMPSearch().Search(pat, txt);
            Assert.AreEqual(index,res);
        }
    }
}