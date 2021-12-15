using BaseAlgorithms.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.Graph
{
    [TestClass]
    public class MaxFlowFordFulkersonTests
    {
        [TestMethod]
        public void Test()
        {
            // Let us create a graph shown in the above example 
            var graph =new[,] { {0, 16, 13, 0, 0, 0}, 
                {0, 0, 10, 12, 0, 0}, 
                {0, 4, 0, 0, 14, 0}, 
                {0, 0, 9, 0, 0, 20}, 
                {0, 0, 0, 7, 0, 4}, 
                {0, 0, 0, 0, 0, 0} 
            }; 
            var m = new MaxFlowFordFulkerson();
            var res = m.FordFulkerson(graph, 0, 5);
            
            Assert.AreEqual(23, res);
        }
    }
}