using System;

namespace Geometry
{
    public enum LineRelation
    {
        TopOrRight,
        BottomOrLeft,
        OnLine
    }

    public class Line
    {

        public double A, B, C, Tan, delta;

        public Line(double A, double B, double C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.Tan = -A / B;
            this.delta = C / -B;
        }

        public Line(Point P1, Point P2)
        {
            this.A = P1.Y - P2.Y;
            this.B = P2.X - P1.X;
            this.C = P1.X * P2.Y - P2.X * P1.Y;
            this.Tan = -A / B;
            this.delta = C / -B;
        }

        public Line(Point P, double Angle)
        {
            this.A = -Math.Tan(Angle);
            this.B = 1;
            this.C = -A * P.X - B * P.Y;
            this.Tan = Math.Tan(Angle);
            this.delta = C / -B;
        }

        public double DistanceTo(double X, double Y)
        {
            return Math.Abs(this.A * X + this.B * Y + this.C) / Math.Sqrt(Math.Pow(this.A, 2) + Math.Pow(this.B, 2));
        }

        public double DistanceTo(Point P)
        {
            return this.DistanceTo(P.X, P.Y);
        }

        public double GetX(double Y)
        {
            return A==0 ? 0 : -(B * Y + C) / A;
        }

        public double GetY(double X)
        {
            return B==0 ? 0 : -(A * X + C) / B;
        }

        public bool IsHorizontal()
        {
            return Math.Abs(this.A / this.B) < 0.5;
        }

        public LineRelation PointRelation(double X, double Y)
        {
            double Line;
            double Point;
            if ( !this.IsHorizontal() )
            {
                Line = -(this.C + this.A * X) / this.B;
                Point = Y;
            }
            else
            {
                Line = -(this.C + this.B * Y) / this.A;
                Point = X;
            }
            return Line == Point ? LineRelation.OnLine : (Line > Point ? LineRelation.TopOrRight : LineRelation.BottomOrLeft);
        }

        public LineRelation PointRelation(Point point)
        {
            return this.PointRelation(point.X, point.Y);
        }

        public Point IntersectLine(Line line)
        {
            double dividend = (C * line.B - line.C * B);
            double devisor = (B * line.A - line.B * A);
            if (devisor == 0)
            {
                return null;
            }
            else
            {
                double X = dividend/devisor;
                double Y = this.GetY(X);
                return new Point(X, Y);
            }
            
        }
    }
}
