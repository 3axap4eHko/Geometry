using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;

namespace Test
{
    [TestClass]
    public class CircleTest
    {
        private Point Center = new Point(0,0);
        private double Radius = 5;
        private Circle circle;

        public CircleTest()
        {
            circle = new Circle(Center, Radius);
        }

        [TestMethod]
        public void TestIsInCircle()
        {
            Assert.IsTrue(circle.IsInCircle(Center));
            Assert.IsTrue(circle.IsInCircle(new Point(Center.X, Center.Y + Radius)));
            Assert.IsTrue(circle.IsInCircle(new Point(Center.X + Radius, Center.Y)));

            Assert.IsFalse(circle.IsInCircle(new Point(Center.X, Center.Y + Radius + 1)));
            Assert.IsFalse(circle.IsInCircle(new Point(Center.X + Radius + 1, Center.Y)));
        }

        [TestMethod]
        public void TestIsIntersectLine()
        {
            Line line1 = new Line(Center, new Point(100, 100));
            Line line2 = new Line(new Point(Radius, Radius), new Point(Radius, -Radius));
            Line line3 = new Line(new Point(Radius + 1, Radius + 1), new Point(Radius + 1, 0));

            //Positive
            Assert.IsTrue(circle.IsIntersectLine(line1));
            Assert.IsTrue(circle.IsIntersectLine(line2));

            //Negative
            Assert.IsFalse(circle.IsIntersectLine(line3));
        }

        [TestMethod]
        public void TestIntersectLinePoints()
        {
            Line line1 = new Line(Center, new Point(100, 100));
            Line line2 = new Line(new Point(Radius, Radius), new Point(Radius, -Radius));
            Line line3 = new Line(new Point(Radius + 1, Radius + 1), new Point(Radius + 1, -(Radius + 1)));


            Point[] points = circle.IntersectLinePoints(line2);
            Assert.AreEqual(points.Length,1);
            Assert.AreEqual(points[0], new Point(5, 0));

            points = circle.IntersectLinePoints(line1);
            Assert.AreEqual(points.Length, 2);

            points = circle.IntersectLinePoints(line3);
            Assert.AreEqual(points.Length, 0);
        }

    }
}
