using BaseAlgorithms.PopularTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks
{
    [TestClass]
    public class NQueenProblemTests
    {
        [TestMethod]
        public void Test()
        {
            int [,]board = {{ 0, 0, 0, 0 },
                                    { 0, 0, 0, 0 },
                                    { 0, 0, 0, 0 },
                                    { 0, 0, 0, 0 }};

            var solver = new NQueenProblem();
            var res = solver.SolveNQUtil(board, 0);
            Assert.AreEqual(true, res);
        }
    }
}