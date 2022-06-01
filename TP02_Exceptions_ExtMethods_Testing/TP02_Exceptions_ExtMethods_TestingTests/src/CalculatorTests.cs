using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP02_Exceptions_ExtMethods_Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02_Exceptions_ExtMethods_Testing.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void DivideTest()
        {
            var calc = new Calculator();
            double expected = 1.5;
            double dividend = 3.0;
            double divisor = 2.0;

            Assert.AreEqual(expected, calc.Divide(dividend, divisor));
        }

        [TestMethod()]
        public void SquareRootTest()
        {
            var calc = new Calculator();

            double expected = 9d;
            double radicand = 81d;

            Assert.AreEqual(expected, calc.SquareRoot(radicand));
        }

        [TestMethod()]
        public void ParseUserInputTest()
        {
            var calc = new Calculator();
            double expected = 4.86;
            string input = "4.86";

            Assert.AreEqual(expected, calc.ParseUserInput(input));
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            var calc = new Calculator();
            calc.Divide(10, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exceptions.NegataiveRadicandException))]
        public void NegativeRadicandTest()
        {
            var calc = new Calculator();
            calc.SquareRoot(-4);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exceptions.InvalidInputException))]
        public void InvalidInputTest()
        {
            var calc = new Calculator();
            calc.ParseUserInput("a");
        }

    }
}