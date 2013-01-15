using System;

namespace Geometry
{
    public class Band
    {
        public Line Line1, Line2;

        public Band(Line L1, Line L2)
        {
            this.Line1 = L1;
            this.Line2 = L2;
        }

        public bool IsInBand(double X, double Y)
        {
            LineRelation R1 = Line1.PointRelation(X, Y);
            LineRelation R2 = Line2.PointRelation(X, Y);
            return ((R1 == LineRelation.OnLine) || (R2 == LineRelation.OnLine)) || (R1 != R2);
        }

        public bool IsInBand(Point point)
        {
            return this.IsInBand(point.X, point.Y);
        }

    }
}
