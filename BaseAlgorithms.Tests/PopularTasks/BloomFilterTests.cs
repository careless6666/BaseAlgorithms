using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.PopularTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks
{
    [TestClass]
    public class BloomFilterTests
    {
        [TestMethod]
        public void Test()
        {
            var myBloom = new Bloom();
            var data = "Hello Bloom Filter";
            myBloom.AddData(data);

            var data2 = "Hello Bloom Filter";
            Assert.AreEqual(true, myBloom.LookUp(data2));

            myBloom = new Bloom();

            myBloom.AddData("apple");
            myBloom.AddData("orange");
            myBloom.AddData("banana");

            Assert.AreEqual(true, myBloom.LookUp("banana"));
        }
    }
}
