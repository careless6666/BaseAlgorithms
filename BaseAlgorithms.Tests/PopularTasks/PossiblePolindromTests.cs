using BaseAlgorithms.PopularTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks
{
    [TestClass]
    public class PossiblePolindromTests
    {
        [TestMethod]
        [DataRow("aabbbbaa", true)]
        [DataRow("aa", true)]
        [DataRow("ab", true)]
        [DataRow("aabbcbaa", true)]
        [DataRow("aabbccdd", false)]
        [DataRow("xyxyyyxyx", true)]
        [DataRow("xyxyyxyyx", false)]
        public void Test(string str, bool expected)
        {
            var res = PossiblePolindrom.IsPossiblePolindrom(str);
            Assert.AreEqual(expected, res);
        }
    }
}