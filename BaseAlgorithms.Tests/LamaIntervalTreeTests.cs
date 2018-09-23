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
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 10, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 12, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 13, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 17, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 10, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 11, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 11, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 12, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 10, 30, 0), new DateTime(dt.Year, dt.Month, dt.Day, 11, 30, 0));
            Assert.IsTrue(res); 
        }

        [TestMethod]
        public void TestRebuild()
        {
            var dt = DateTime.Now;
            var lim = new LamaIntervalTree();

            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 2, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 3, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 3, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 4, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 4, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 5, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 2, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 8, 30, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 3, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 5, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 6, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 8, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 9, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 17, 0, 0));

            lim.RebuildTree();

            var tree = lim.GetFullTree;
            Assert.AreEqual(2, tree.Childs.Count);
            Assert.AreEqual(3, tree.Childs[0].Childs.Count);
            Assert.AreEqual(null, tree.Childs[1].Childs);
            Assert.AreEqual(2, tree.Childs[0].Childs[0].Childs.Count);
            Assert.AreEqual(null, tree.Childs[0].Childs[0].Childs[0].Childs);
            Assert.AreEqual(null, tree.Childs[0].Childs[0].Childs[1].Childs);
        }

        [TestMethod]
        public void TestGetInterval()
        {
            var dt = DateTime.Now;

            var lim = new LamaIntervalTree( new DateTime(dt.Year, dt.Month, dt.Day, 0, 0 ,0), new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59));
            
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 2, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 3, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 3, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 4, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 4, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 5, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 2, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 8, 30, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 3, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 5, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 6, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 8, 0, 0));
            lim.TryAdd(new DateTime(dt.Year, dt.Month, dt.Day, 9, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 17, 0, 0));

            lim.RebuildTree();

            var intervalList = lim.GetIntervals();
            Assert.AreEqual(3, intervalList.Count);
        }
    }
}
