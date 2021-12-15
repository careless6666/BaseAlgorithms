using BaseAlgorithms.PopularTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks
{
    [TestClass]
    public class LongestCommonSubsequenceTests
    {
        [TestMethod]
        public void Test()
        {
            var a = "AGGTAB";
            var b = "GXTXAYB";

            var res = LongestCommonSubsequence.LCSSimple(a.ToCharArray(), b.ToCharArray(), a.Length, b.Length);
            Assert.AreEqual(4, res);

            res = LongestCommonSubsequence.LCS(a.ToCharArray(), b.ToCharArray(), a.Length, b.Length);
            Assert.AreEqual(4, res);

            
         /*
          *     _____________________________ 
          *     |___|_A_|_G_|_G_|_T_|_A_|_B_|
          *     | G | - | - | 4 | - | - | - | 
          *     | X | - | - | - | - | - | - | 
          *     | T | - | - | - | 3 | - | - |
          *     | X | - | - | - | - | - | - |
          *     | A | - | - | - | - | 2 | - |
          *     | Y | - | - | - | - | - | - |
          *     | B | - | - | - | - | - | 1 |
          *     |____________________________
          */      
        }
    }
}