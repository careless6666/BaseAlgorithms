using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class LamaIntervalTreeTests
    {
        [TestMethod]
        public void AddItem()
        {
            var lim = new LamaIntervalTree();
            var res = lim.TryAdd(DateTime.UtcNow, DateTime.Now);
            var res1 = lim.TryAdd(DateTime.UtcNow, DateTime.Now);
            var res2 = lim.TryAdd(DateTime.UtcNow, DateTime.Now);
            Assert.IsTrue(res); 
        }
    }
}
