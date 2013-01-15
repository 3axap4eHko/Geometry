using System;
using System.Collections.Generic;

namespace Geometry
{
    public class Circle
    {
        public Point Center;
        public double Radius;

        public Circle(Point Center, double Radius)
        {
            this.Center = Center;
            this.Radius = Radius;
        }

        public double[] GetX(double Y)
        {
            double a = 1;
            double b = -2 * Center.X;
            double c = Math.Pow(Y - Center.Y, 2) + Math.Pow(Center.X, 2) - Math.Pow(Radius, 2);
            List<double> result = new List<double>();
            foreach (double X in Calculating.QuadraticEquation(a, b, c))
            {
                result.Add(X);
            }
            return result.ToArray();

        }

        public double[] GetY(double X)
        {
            double a = 1;
            double b = -2 * Center.Y;
            double c = Math.Pow(X - Center.X, 2) + Math.Pow(Center.Y, 2) - Math.Pow(Radius, 2);
            List<double> result = new List<double>();
            foreach (double Y in Calculating.QuadraticEquation(a, b, c))
            {
                result.Add(Y);
            }
            return result.ToArray();
        }


        public bool IsInCircle(Point P)
        {
            return P.DistanceTo(this.Center) <= this.Radius;
        }

        public bool IsIntersectLine(Line line)
        {
            return line.DistanceTo(this.Center) <= this.Radius;
        }

        public Point[] IntersectLinePoints(Line line)
        {
            double a = Math.Pow(line.A, 2) + Math.Pow(line.B, 2);
            double b = 2 * (line.A * line.C - Center.X * Math.Pow(line.B, 2) + Center.Y * line.A * line.B);
            double c = Math.Pow(line.B * Center.X, 2) + Math.Pow(line.C, 2) + 2 * Center.Y * line.B * line.C + Math.Pow(Center.Y * line.B, 2) - Math.Pow(Radius * line.B, 2);

            List<Point> result = new List<Point>();
            foreach (double X in Calculating.QuadraticEquation(a, b, c))
            {
                double lineY = line.GetY(X);
                foreach (double Y in this.GetY(X))
                {

                    if (Calculating.DoubleEquals(Y, lineY))
                    {
                        result.Add(new Point(X, Y));
                    }
                }
            }
            return result.ToArray();
        }
    }
}
