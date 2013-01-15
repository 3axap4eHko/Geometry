using System;

namespace Geometry
{
    public class Point
    {
        public double X, Y;

        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public double DistanceTo(double X, double Y)
        {
            return Math.Sqrt(Math.Pow(this.X - X, 2) + Math.Pow(this.Y - Y, 2));
        }

        public double DistanceTo(Point P)
        {
            return this.DistanceTo(P.X, P.Y);
        }

        public override bool Equals(Object obj)
        {
            return obj == null ? false : ((obj as Point).X ==this.X && (obj as Point).Y==this.Y);
        }

        public static bool operator ==(Point a, Point b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

    }
}
