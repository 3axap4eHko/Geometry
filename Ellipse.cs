using System;

namespace Geometry
{
    class Ellipse
    {
        public Point Center;
        public double a, b, c, e, p;
        
        public Ellipse(Point Center, double a, double b)
        {
            this.Center = Center;
            this.a = a;
            this.b = b;
            this.c = Math.Sqrt(a * a + b * b);
            this.e = a / c;
            this.p = b * b / a;
        }

        public bool IsInEllipse(Point point)
        {
            return Math.Pow(point.X / a, 2) + Math.Pow(point.Y / b, 2) <= 1;
        }

        public bool IsIntersectLine(Line line)
        {
            return Math.Pow(line.Tan * line.delta * a * a, 2) - (Math.Pow(a*line.Tan,2)+b*b)*(Math.Pow(a*line.delta,2) - Math.Pow(a*b,4)) <= 0;
        }
    }
}
