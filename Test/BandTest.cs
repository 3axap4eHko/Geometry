using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;

namespace Test
{
    [TestClass]
    public class BandTest
    {
        private Line line1, line2;
        private Band band;

        public BandTest()
        {
            line1 = new Line(new Point(-5, 0), new Point(0, 5));
            line2 = new Line(new Point(0, 0), new Point(5, 5));
            band = new Band(line1, line2);
        }

        [TestMethod]
        public void TestInBand()
        {
            //Positive
            Assert.IsTrue(band.IsBelongsTo(new Point(0, 2)));
            Assert.IsTrue(band.IsBelongsTo(new Point(0, 5)));
            Assert.IsTrue(band.IsBelongsTo(new Point(0, 0)));

            //Negative
            Assert.IsFalse(band.IsBelongsTo(new Point(-6, 0)));
            Assert.IsFalse(band.IsBelongsTo(new Point(1, 0)));
        }
    }
}
