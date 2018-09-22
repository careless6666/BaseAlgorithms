using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests
{
    [TestClass]
    public class LamaIntervalTreeTests
    {
        [TestMethod]
        public void TestAddItem()
        {
            var dt = DateTime.Now;
            var lim = new LamaIntervalTree(3);
            var res = lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 3, 0,0), new DateTime(dt.Year, dt.Month, dt.Day, 5, 0, 0));
            var res1 = lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 10, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 12, 0, 0));
            var res2 = lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 13, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 17, 0, 0));
            var res3 = lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 10, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 11, 0, 0));
            var res4 = lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 11, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 12, 0, 0));
            var res5 = lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0), new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0));
            Assert.IsTrue(res); 
        }

        [TestMethod]
        public void TestRebuild()
        {
            var lim = new LamaIntervalTree();

            lim.Rebuild();
        }
    }
}
