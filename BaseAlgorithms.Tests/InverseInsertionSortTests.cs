using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class InverseInsertionSortTests
    {
        [TestMethod]
        public void TestSort()
        {
            var arr = new[] { 5, 1, 4, 2, 3 };
            var res = InverseInsertionSort.Sort(arr);
            Assert.IsTrue(res.SequenceEqual(new[] { 5, 4, 3, 2, 1 }));

            arr = new[] { 5, 4, 3, 2, 1};

            res = InverseInsertionSort.Sort(arr);
            Assert.IsTrue(res.SequenceEqual(new[] { 5, 4, 3, 2, 1 }));

            arr = new[] { 1, 2, 3, 4, 5 };

            res = InverseInsertionSort.Sort(arr);
            Assert.IsTrue(res.SequenceEqual(new[] { 5, 4, 3, 2, 1 }));
        }
    }
}
