using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class Equation
    {
        private List<EquationComponent> components = new List<EquationComponent>();
        private double maxPower = 0;

        public Equation()
        {
        }

        public void AddComponent(EquationComponent component)
        {
            maxPower = Math.Max(maxPower, component.power);
            this.components.Add(component);
        }

        public void AddComponents(EquationComponent[] components)
        {
            foreach (EquationComponent component in components)
            {
                this.AddComponent(component);
            }
        }

        public void ClearComponents()
        {
            this.components.Clear();
        }


        public EquationComponent[] GetComponents
        {
            get { return this.components.ToArray(); }
        }

        public double GetComponentsCoefficent(double power)
        {
            double result = 0;
            foreach (EquationComponent component in this.components)
            {
                if (Calculating.DoubleEquals(component.power, power))
                {
                    result += component.coefficient;
                }
            }
            return result;
        }

        public double[] Resolve()
        {
            List<double> result = new List<double>();
            switch (System.Convert.ToByte(maxPower))
            {
                case 1:
                    result.Add(Calculating.LinearEquation(this.GetComponentsCoefficent(1), this.GetComponentsCoefficent(0)));
                    break;
                case 2:
                    result.AddRange(Calculating.QuadraticEquation(this.GetComponentsCoefficent(2), this.GetComponentsCoefficent(1), this.GetComponentsCoefficent(0)));
                    break;
                default:
                    throw new Exception();
            }
            return result.ToArray();
        }

    }
}
