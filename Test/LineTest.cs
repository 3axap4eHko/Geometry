using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;

namespace Test
{
    [TestClass]
    public class LineTest
    {
        Point point1 = new Point(0, 0);
        Point point2 = new Point(0, 5);
        Point point3 = new Point(5, 5);
        Point point4 = new Point(5, 0);

        Line line0, line1, line2, line3, line4;

        public LineTest()
        {
            line0 = new Line(point4, point3);
            line1 = new Line(point1, point2);
            line2 = new Line(point1, point4);
            line3 = new Line(point1, point3);
            line4 = new Line(point2, point4);
        }

        [TestMethod]
        public void TestGeneral()
        {
            Assert.AreEqual(line2.A, 0D);
            Assert.AreEqual(line2.B, 5D);
            Assert.AreEqual(line2.C, 0D);
            Assert.AreEqual(line2.delta, 0D);
            Assert.AreEqual(line2.Tan, 0D);
        }


        [TestMethod]
        public void TestGetXY()
        {
            Assert.AreEqual(line3.GetX(5), 5);
            Assert.AreEqual(line3.GetY(5), 5);
        }

        [TestMethod]
        public void TestIsHorizontal()
        {
            Assert.IsFalse(line1.IsHorizontal());
            Assert.IsTrue(line2.IsHorizontal());
            Assert.IsFalse(line3.IsHorizontal());
        }

        [TestMethod]
        public void TestPointRealtion()
        {
            Assert.AreEqual(line3.PointRelation(0, 5), LineRelation.BottomOrLeft);
            Assert.AreEqual(line3.PointRelation(5, 0), LineRelation.TopOrRight);
            Assert.AreEqual(line3.PointRelation(5, 5), LineRelation.OnLine);
        }

        [TestMethod]
        public void TestIntersectLine()
        {
            Assert.AreEqual(line3.IntersectLinePoints(line4).Length, 1);
            Assert.IsTrue(line3.IntersectLinePoints(line4)[0] == new Point(2.5, 2.5));
            Assert.IsNull(line0.IntersectLinePoints(line1));
            Assert.AreEqual(line3.IntersectLinePoints(line2).Length, 1);
            Assert.IsTrue(line1.IntersectLinePoints(line2)[0] == new Point(0, 0));
        }





    }
}
