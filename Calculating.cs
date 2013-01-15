using System;
using System.Collections.Generic;

namespace Geometry
{
    public class Calculating
    {
        public const double tolerance = 0.0001;

        public static bool DoubleEquals(double double1, double double2)
        {
            return Math.Abs(double1 - double2) < tolerance;
        }

        public static double[] QuadraticEquation(double a, double b, double c)
        {
            List<double> resolves = new List<double>();
            double discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant >= 0)
            {
                double X = (-b + Math.Sqrt(discriminant)) / (2 * a);
                resolves.Add(X);
                if (discriminant > 0)
                {
                    X = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    resolves.Add(X);
                }
            }
            return resolves.ToArray();
        }

        public static double LinearEquation(double a, double b)
        {
            return -b / a;
        }
    }
}
