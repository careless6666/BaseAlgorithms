using System.Linq;
using BaseAlgorithms.MergeSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.MergeSort
{
    [TestClass]
    public class InPlaceMergeSortTests
    {
        [TestMethod]
        public void TestSort()
        {
            var arr = new[] { 3, 41, 52, 26, 38, 57, 9, 49 };

            var res = InPlaceMergeSort.Sort(arr);
            Assert.IsTrue(res.SequenceEqual(new[] { 3, 9, 26, 38, 41, 49, 52, 57 }));
        }
    }
}
