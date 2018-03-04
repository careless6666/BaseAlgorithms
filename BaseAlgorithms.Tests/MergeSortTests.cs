using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void TestSorts()
        {
            var arr = new[] { 3, 41, 52, 26, 38, 57, 9, 49 };

            var res = MergeSort.Sort(arr);
            Assert.IsTrue(res.SequenceEqual(new []{3, 9, 26, 38, 41, 49, 52, 57}));
        }
    }
}
