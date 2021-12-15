using System.Linq;
using BaseAlgorithms.PopularTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks
{
    [TestClass]
    public class SearchSimpleNumbersTests
    {
        [TestMethod]
        public void TestsSieveEratosthenes()
        {
            var res = SearchSimpleNumbers.SieveEratosthenes(35);
            
            Assert.IsTrue(res.SequenceEqual(new []{2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 }));
        }
    }
}