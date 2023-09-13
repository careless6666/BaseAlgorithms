using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.Data_Structures;
using BaseAlgorithms.PopularTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks
{
    [TestClass]
    public class KStatisticSearchTests
    {
        [TestMethod]
        public void TestsQuickSearch()
        {
            var alg = new KStatisticSearchQuickSearch();

            var arr = new int[] { 0, 17, 35, 24, 10 }; //0, 10, 17, 24, 35

            //0, 10, 17, 24, 35

            var result = alg.OrderStatistics(arr, arr.Length, 2);
            Assert.AreEqual(17, result);
        }
        
        [TestMethod]
        public void TestsRedBlack()
        {
            var tree = new RedBlackTree();

            tree.Insert(0);
            tree.Insert(17);
            tree.Insert(35);
            tree.Insert(24);
            tree.Insert(10);

            var kStatistic = new KStatisticSearchReadBackTree(new[] {0, 17, 35, 24, 10});

            //0, 10, 17, 24, 35

            var result = kStatistic.GetStatistic(3);
            Assert.AreEqual(17, result);
        }
    }
}
