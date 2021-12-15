using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.Data_Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Data_Structures
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void TestTree()
        {
            var bstHelper = new BinarySearchTree();

            var bst = bstHelper.Insert(null,50);
            bstHelper.Insert(bst, 30);
            bstHelper.Insert(bst, 20);
            bstHelper.Insert(bst, 40);
            bstHelper.Insert(bst, 70);
            bstHelper.Insert(bst, 60);
            bstHelper.Insert(bst, 80);

            /* Let us create following BST 
                  50 
               /     \ 
              30      70 
             /  \    /  \ 
           20   40  60   80 */

            Assert.AreEqual(bst.Data, 50);
            Assert.AreEqual(bst.Left.Data, 30);
            Assert.AreEqual(bst.Right.Data, 70);

            var searchResult = bstHelper.Search(bst,70);
            Assert.AreEqual(searchResult.Left.Data, 60);
            Assert.AreEqual(searchResult.Right.Data, 80);

            bstHelper.Delete(bst, 30);
            searchResult = bstHelper.Search(bst, 30);
            Assert.AreEqual(searchResult, null);
        }
    }
}
