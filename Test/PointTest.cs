using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;

namespace Test
{
    [TestClass]
    public class PointTest
    {
        Point point1, point2, point3;


        public PointTest()
        {
            point1 = new Point(0, 0);
            point2 = new Point(3, 4);
            point3 = new Point(0, 0);
        }

        [TestMethod]
        public void TestDistance()
        {
            Assert.AreEqual(5, point1.DistanceTo(point2));
            point2.X = -3;
            Assert.AreEqual(5, point1.DistanceTo(point2));
        }

        [TestMethod]
        public void TestEquals()
        {
            Assert.IsTrue(point1.Equals(point3));
            Assert.IsFalse(point1.Equals(point2));
        }
    }
}