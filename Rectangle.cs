using System;

namespace Geometry
{

    class Rectangle
    {
        public Band Band1, Band2;

        public Rectangle(Line L1, Line L2, Line L3, Line L4)
        {
            this.Band1 = new Band(L1, L3);
            this.Band2 = new Band(L2, L4);
        }

        public Rectangle(Point P1, Point P2, Point P3, Point P4)
        {
            this.Band1 = new Band(new Line(P1, P2), new Line(P3, P4));
            this.Band2 = new Band(new Line(P2, P3), new Line(P4, P1));
        }


        public bool IsInRectangle(Point point)
        {
            return this.Band1.IsInBand(point) && this.Band2.IsInBand(point);
        }

        public bool IntersectLine(Line line)
        {
            Point[] intersects = {
                                 this.Band1.Line1.IntersectLine(line),
                                 this.Band1.Line2.IntersectLine(line),
                                 this.Band2.Line1.IntersectLine(line),
                                 this.Band2.Line2.IntersectLine(line)
                                 };
            foreach (Point point in intersects)
            {
                if ( (point != null) && this.IsInRectangle(point))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
