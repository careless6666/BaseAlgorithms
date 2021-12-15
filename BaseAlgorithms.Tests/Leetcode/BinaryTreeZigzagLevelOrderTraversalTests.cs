using BaseAlgorithms.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Leetcode
{
    [TestClass]
    public class BinaryTreeZigzagLevelOrderTraversalTests
    {
        [TestMethod]
        public void Test1()
        {
            var res = new BinaryTreeZigzagLevelOrderTraversal().ZigzagLevelOrder(
                new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))));
            
            Assert.AreEqual(res.Count, 3);
            Assert.AreEqual(res[0][0], 3);
        }
        
        [TestMethod]
        public void Test2()
        {
            var res = new BinaryTreeZigzagLevelOrderTraversal().ZigzagLevelOrder(
                new TreeNode(1));
            
            Assert.AreEqual(res.Count, 1);
            
        }
        
        [TestMethod]
        public void Test3()
        {
            var res = new BinaryTreeZigzagLevelOrderTraversal().ZigzagLevelOrder(null);
            
            Assert.AreEqual(res.Count, 0);
            
        }
        
    }
}