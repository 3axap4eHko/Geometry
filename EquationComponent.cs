using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public abstract class EquationComponent
    {
        public readonly double coefficient;
        public readonly double power;

        public EquationComponent(double coefficient, double power)
        {
            this.coefficient = coefficient;
            this.power = power;
        }
    }

    public class X : EquationComponent
    {
        public X(double coefficient, double power = 0) :
            base(coefficient, power)
        {
        }
    }

    public class Y : EquationComponent
    {
        public Y(double coefficient, double power) :
            base(coefficient, power)
        {
        }

    }
}
