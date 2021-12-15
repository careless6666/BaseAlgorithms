using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.Data_Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Data_Structures
{
    [TestClass]
    public class SegmentTreeTests
    {
        [TestMethod]
        public void Tests()
        {
            var st = new SegmentTree();

            st.Insert(10, 30);
            st.Insert(17, 19);
            st.Insert(5, 20);
            st.Insert(12, 15);
            st.Insert(30, 40);

            st.DisplayTree(st.Root);

            var ovelapInterval = st.SearchOverlap(6, 7);
            Assert.IsNotNull(ovelapInterval);
            Assert.AreEqual(ovelapInterval.Low, 5);
        }
    }
}
