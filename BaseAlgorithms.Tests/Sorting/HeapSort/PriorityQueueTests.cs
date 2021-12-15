using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.HeapSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.HeapSort
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void TestPriorityQeue()
        {
            var e1 = new Employee("Aiden", 1.0);
            var e2 = new Employee("Baker", 2.0);
            var e3 = new Employee("Chung", 3.0);
            var e4 = new Employee("Dunne", 4.0);
            var e5 = new Employee("Eason", 5.0);
            var e6 = new Employee("Flynn", 6.0);
            var e7 = new Employee("ololo", 2.5);

            var pq = new PriorityQueue<Employee>();

            pq.Enqueue(e5);
            pq.Enqueue(e3);
            pq.Enqueue(e6);
            pq.Enqueue(e4);
            pq.Enqueue(e1);
            pq.Enqueue(e2);
            pq.Enqueue(e7);

            var res = pq.Dequeue();
            Assert.AreEqual(1, res.Priority);

            res = pq.Dequeue();
            Assert.AreEqual(2, res.Priority);

            res = pq.Dequeue();
            Assert.AreEqual(2.5, res.Priority);

        }
    }
}
