using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseAlgorithms.HeapSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.HeapSort
{
    [TestClass]
    public class HeapSortTest
    {
        [TestMethod]
        public void TestSort()
        {
            var arr = new[] { 3, 41, 52, 26, 38, 57, 9, 49 };

            var myComparer = new IntComparer();//Класс, реализующий сравнение
            var heap = new HeapSort<int>(arr, myComparer);
            heap.Sort();

            Assert.IsTrue(arr.SequenceEqual(new[] { 3, 9, 26, 38, 41, 49, 52, 57 }));
        }
    }
}
