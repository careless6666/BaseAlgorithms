using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.Data_Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Data_Structures
{
    [TestClass]
    public class AVLTreeTests
    {
        [TestMethod]
        public void Tests()
        {
            var tree = new AVLTree();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);

            Assert.IsTrue(tree.Find(7));

            tree.Delete(7);

            Assert.IsFalse(tree.Find(7));
        }
    }
}
