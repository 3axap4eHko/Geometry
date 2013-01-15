using System;
using System.Collections.Generic;

namespace Geometry
{
    public class Band : Shape
    {
        public Line[] Lines = new Line[2];

        public Band(Line L1, Line L2)
        {
            this.Lines[0] = L1;
            this.Lines[1] = L2;
        }

        public override bool IsBelongsTo(double X, double Y)
        {
            LineRelation R1 = this.Lines[0].PointRelation(X, Y);
            LineRelation R2 = this.Lines[1].PointRelation(X, Y);
            return ((R1 == LineRelation.OnLine) || (R2 == LineRelation.OnLine)) || (R1 != R2);
        }

        public override Point[] IntersectLinePoints(Line intersectline)
        {
            List<Point> result = new List<Point>();
            foreach(Line line in this.Lines)
            {
                Point[] points = line.IntersectLinePoints(intersectline);
                if (points.Length > 0)
                {
                    result.AddRange(points);
                }
            }
            return result.ToArray();
        }

    }
}
