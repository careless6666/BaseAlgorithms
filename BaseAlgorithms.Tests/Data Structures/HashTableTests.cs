using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.Data_Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Data_Structures
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void Tests()
        {
            var ht = new HastTable();

            ht.Insert(13,25);
            ht.Insert(64,92);
            ht.Insert(30,81);
            ht.Insert(99,43);

            var item = ht.Search(64);

            Assert.IsNotNull(item);
            Assert.AreEqual(item.Value.Data, 92);

            ht.Delete(item.Value);

            item = ht.Search(64);
            Assert.IsNull(item);
        }
    }
}
