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
            var root = new STNode()
            {
                Interval = new BaseAlgorithms.Data_Structures.Interval(15,20)
            };

            var st = new SegmentTree();

            st.Insert(root, new BaseAlgorithms.Data_Structures.Interval(10, 30));
            st.Insert(root, new BaseAlgorithms.Data_Structures.Interval(17, 19));
            st.Insert(root, new BaseAlgorithms.Data_Structures.Interval(5, 20));
            st.Insert(root, new BaseAlgorithms.Data_Structures.Interval(12, 15));
            st.Insert(root, new BaseAlgorithms.Data_Structures.Interval(30, 40));

            st.InOrder(root);

            var ovelapInterval = st.OverlapSearch(root, new BaseAlgorithms.Data_Structures.Interval(6, 7));
            Assert.IsNotNull(ovelapInterval);
        }
    }
}
