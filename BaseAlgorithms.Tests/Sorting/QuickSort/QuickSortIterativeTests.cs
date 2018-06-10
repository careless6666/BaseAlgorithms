using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.QuickSort
{
    [TestClass]
    public class QuickSortIterativeTests
    {
        [TestMethod]
        public void Sort()
        {
            var arr = new[] { 3, 41, 52, 26, 38, 57, 9, 49 };

            QuickSortIterative.Sort(ref arr);
            Assert.IsTrue(arr.SequenceEqual(new[] { 3, 9, 26, 38, 41, 49, 52, 57 }));
        }
    }
}
