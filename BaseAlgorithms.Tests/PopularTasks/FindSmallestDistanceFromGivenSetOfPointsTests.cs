using System;
using System.Drawing;
using BaseAlgorithms.PopularTasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseAlgorithms.Tests.PopularTasks
{
    [TestClass]
    public class FindSmallestDistanceFromGivenSetOfPointsTests
    {
        [TestMethod]
        public void TestSearchClosest()
        {
            var points = new[]
            {
                new Point(2, 3),
                new Point(12, 30),
                new Point(40, 50),
                new Point(5, 1),
                new Point(12, 10),
                new Point(3, 4),
            };

            var search = new FindSmallestDistanceFromGivenSetOfPoints();

            var res = FindSmallestDistanceFromGivenSetOfPoints.Closest(points, points.Length);

            Assert.AreEqual(1.414214, Math.Round(res, 6));
        }
    }
}