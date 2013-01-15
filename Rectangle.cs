﻿using System;
using System.Collections.Generic;

namespace Geometry
{

    class Rectangle: Shape
    {
        public Band[] Bands = new Band[2];

        public Rectangle(Line L1, Line L2, Line L3, Line L4)
        {
            this.Bands[0] = new Band(L1, L3);
            this.Bands[1] = new Band(L2, L4);
        }

        public Rectangle(Point P1, Point P2, Point P3, Point P4)
        {
            this.Bands[0] = new Band(new Line(P1, P2), new Line(P3, P4));
            this.Bands[0] = new Band(new Line(P2, P3), new Line(P4, P1));
        }


        public override bool IsBelongsTo(double X, double Y)
        {
            return this.Bands[0].IsBelongsTo(X, Y) && this.Bands[0].IsBelongsTo(X, Y);
        }

        public override Point[] IntersectLinePoints(Line intersectline)
        {
            List<Point> result = new List<Point>();
            foreach (Band band in this.Bands)
            {
                foreach (Point point in band.IntersectLinePoints(intersectline))
                {
                    if ((point != null) && this.IsBelongsTo(point))
                    {
                        result.Add(point);
                    }
                }

            }
            return result.ToArray();
        }

        public bool IsIntersectLine(Line line)
        {
            return this.IntersectLinePoints(line).Length > 0;
        }



    }
}
