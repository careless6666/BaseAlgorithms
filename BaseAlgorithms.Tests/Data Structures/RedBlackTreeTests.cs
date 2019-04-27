using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.Data_Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Data_Structures
{
    [TestClass]
    public class RedBlackTreeTests
    {
        [TestMethod]
        public void Test()
        {
            var tree = new RedBlackTree();

            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(18);
            tree.Insert(10);
            tree.Insert(22);
            tree.Insert(8);
            tree.Insert(11);
            tree.Insert(26);


            /*
             *                      7 b
             *                    /     \
             *                3 b         18 r
             *               /   \       /     \
             *             null  null  10 b    22 b  
             *                        /   \        \ 
             *                      8 r   11 r     26 r 
             */ 




            Assert.AreEqual(7, tree.Root.Data);
            Assert.AreEqual(3, tree.Root.Left.Data);
            Assert.AreEqual(18, tree.Root.Right.Data);
        }
    }
}
