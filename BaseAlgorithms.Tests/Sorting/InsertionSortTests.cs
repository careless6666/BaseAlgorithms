using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void TestSort()
        {
            var arr = new[] { 5, 1, 4, 2, 3 };
            var res = InsertionSort.ReverseSort(arr);
            Assert.IsTrue(res.SequenceEqual(new[] { 5, 4, 3, 2, 1 }));

            arr = new[] { 5, 4, 3, 2, 1};

            res = InsertionSort.ReverseSort(arr);
            Assert.IsTrue(res.SequenceEqual(new[] { 5, 4, 3, 2, 1 }));

            arr = new[] { 1, 2, 3, 4, 5 };

            res = InsertionSort.ReverseSort(arr);
            Assert.IsTrue(res.SequenceEqual(new[] { 5, 4, 3, 2, 1 }));
        }
    }
}
