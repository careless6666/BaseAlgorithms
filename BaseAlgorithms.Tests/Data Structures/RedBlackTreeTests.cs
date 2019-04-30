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

        [TestMethod]
        public void TestWithDelete()
        {
            var tree = new RedBlackTree();

            tree.Insert( 5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(-1);
            tree.Insert(11);
            tree.Insert(6);
            tree.DisplayTree(tree.Root);

            Assert.AreEqual(tree.Root.Left.Left.Data, -1);

            DeleteWithCheck(tree, -1);
            DeleteWithCheck(tree, 9);
            DeleteWithCheck(tree, 5);

            //Console.ReadLine();

            //Assert.AreEqual();
            //tree
        }

        private void DeleteWithCheck(RedBlackTree tree, int item)
        {
            Assert.IsNotNull(tree.Search(tree.Root, item));

            tree.Delete(tree.Root, item);
            //tree.DisplayTree(tree.Root);
            Assert.IsNull(tree.Search(tree.Root, item));
        }
    }
}
