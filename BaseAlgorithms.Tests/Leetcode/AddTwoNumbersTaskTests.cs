using BaseAlgorithms.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Leetcode
{
    [TestClass]
    public class AddTwoNumbersTaskTests
    {
        [TestMethod]
        public void Test1()
        {
            var res = new AddTwoNumbersTask().AddTwoNumbers(new ListNode(2, new ListNode(4, new ListNode(3))),
                new ListNode(5, new ListNode(6, new ListNode(4))));
            
            Assert.AreEqual(res.val, 7);
            Assert.AreEqual(res.next.val, 0);
            Assert.AreEqual(res.next.next.val, 8);
        }
        
        
        [TestMethod]
        public void Test2()
        {
            var res = new AddTwoNumbersTask().AddTwoNumbers(new ListNode(2, new ListNode(4, new ListNode(9))),
                new ListNode(5, new ListNode(6, new ListNode(4, new ListNode(9)))));
            
            Assert.AreEqual(res.val, 7);
            Assert.AreEqual(res.next.val, 0);
            Assert.AreEqual(res.next.next.val, 4);
            Assert.AreEqual(res.next.next.next.val, 0);
            Assert.AreEqual(res.next.next.next.next.val, 1);
        }
    }
}