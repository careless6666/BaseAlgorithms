using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class RadixSortingTests
    {
        [TestMethod]
        public void TestSort()
        {
            var arr = new[] { 3, 41, 52, 26, 38, 57, 9, 49 };

            RadixSorting.Sort(arr, arr.Length);
            Assert.IsTrue(arr.SequenceEqual(new[] { 3, 9, 26, 38, 41, 49, 52, 57 }));
        }
    }
}
