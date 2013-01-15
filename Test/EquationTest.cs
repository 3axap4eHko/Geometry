using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;

namespace Test
{
    [TestClass]
    public class EquationTest
    {
        EquationComponent[] components = new EquationComponent[]{
            new X(1,2),
            new X(-10,1),
            new X(7)
        };

        [TestMethod]
        public void TestLinear()
        {
            Equation equation = new Equation();

            equation.AddComponent(components[1]);
            equation.AddComponent(components[2]);
            Assert.AreEqual(equation.Resolve().Length, 1);
            Assert.IsTrue(Calculating.DoubleEquals(equation.Resolve()[0], 0.7));

        }

        [TestMethod]
        public void TestQuadratic()
        {
            Equation equation = new Equation();

            equation.AddComponent(components[0]);
            equation.AddComponent(components[2]);
            Assert.AreEqual(equation.Resolve().Length, 0);

            equation.AddComponent(components[1]);
            Assert.AreEqual(equation.Resolve().Length, 2);
            Assert.IsTrue(Calculating.DoubleEquals(equation.Resolve()[0], 9.242640));
            Assert.IsTrue(Calculating.DoubleEquals(equation.Resolve()[1], 0.757359));
        }
    }
}
