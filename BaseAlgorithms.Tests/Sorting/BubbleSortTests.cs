using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Sorting
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void Test()
        {
            var arr = new []{64, 34, 25, 12, 22, 11, 90};
            new BubbleSort().Sort(arr);

            Assert.AreEqual(11, arr[0]);
            Assert.AreEqual(90, arr[6]);
        }
    }
}
