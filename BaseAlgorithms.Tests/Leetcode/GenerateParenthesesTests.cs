using BaseAlgorithms.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Leetcode
{
    [TestClass]
    public class GenerateParenthesesTests
    {
        [TestMethod]
        public void Test()
        {
            var generator = new GenerateParentheses();
            var res = generator.GenerateParenthesis(3);
        }
    }
}