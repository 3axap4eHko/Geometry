using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public abstract class Shape
    {
        public abstract bool IsBelongsTo(double X, double Y);

        public bool IsBelongsTo(Point point)
        {
            return this.IsBelongsTo(point.X, point.Y);
        }

        public abstract Point[] IntersectLinePoints(Line intersectline);
    }

    


}
