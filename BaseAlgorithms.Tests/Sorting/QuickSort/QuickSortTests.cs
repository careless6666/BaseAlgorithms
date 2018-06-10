using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void TestMethod()
        {
            var arr = new[] { 3, 41, 52, 26, 38, 57, 9, 49 };

            BaseAlgorithms.QuickSort.Sort(arr, 0, arr.Length-1);
            Assert.IsTrue(arr.SequenceEqual(new[] { 3, 9, 26, 38, 41, 49, 52, 57 }));
        }
    }
}
