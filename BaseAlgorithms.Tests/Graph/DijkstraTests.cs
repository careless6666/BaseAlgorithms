using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Graph
{
    [TestClass]
    public class DijkstraTests
    {
        [TestMethod]
        public void TestDijkstra()
        {
            var dij = new Dijkstra(9);

            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            var res = dij.dijkstra(graph, 0);
            Assert.AreEqual(0, res[0]);
            Assert.AreEqual(4, res[1]);
            Assert.AreEqual(12, res[2]);
            Assert.AreEqual(19, res[3]);

        }
    }
}
