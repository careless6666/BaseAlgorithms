using System.Linq;
using BaseAlgorithms.PopularTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks
{
    [TestClass]
    public class PermutaionsTests
    {
        [TestMethod]
        public void TestUnique()
        {
            var mutations = new PermutaionsLinear();
            var res = mutations.Generate(4);
            Assert.IsTrue(res.First().SequenceEqual(new []{ 1, 2, 3, 4}));
            Assert.IsTrue(res.Last().SequenceEqual(new []{ 4, 3, 2, 1}));
        }

        [TestMethod]
        public void TestRecursive()
        {
            var mutations = new PermutaionRecursion();
            var res = mutations.GenerateRecursive("ABC");
            Assert.IsTrue(res.First() == "ABC");
            Assert.IsTrue(res.Last() == "CAB");
        }
        
        [TestMethod]
        public void TestBackTracking()
        {
            var mutations = new PermutationBackTracking();
            var res = mutations.Permute(new []{1,2,3});
            Assert.IsTrue(res.Count == 6);
            //123
            //132
            //213
            //231
            //312
            //321
        }
        
        [TestMethod]
        public void TestBackTrackingUniqCombinations()
        {
            var mutations = new PermutationBackTrackingDifferentSubset();
            var res = mutations.Subsets(new []{1,2,3});
            Assert.IsTrue(res.Count == 8);
            //123
            //132
            //213
            //231
            //312
            //321
        }
    }
}
