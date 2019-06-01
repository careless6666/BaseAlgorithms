using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var mutations = new Permutaions();
            var res = mutations.Generate(4);
            Assert.IsTrue(res.First().SequenceEqual(new []{ 1, 2, 3, 4}));
            Assert.IsTrue(res.Last().SequenceEqual(new []{ 4, 3, 2, 1}));
        }

        [TestMethod]
        public void TestRecursive()
        {
            var mutations = new Permutaions();
            var res = mutations.GenerateRecursive("ABC");
            Assert.IsTrue(res.First() == "ABC");
            Assert.IsTrue(res.Last() == "CAB");
        }

    }
}
