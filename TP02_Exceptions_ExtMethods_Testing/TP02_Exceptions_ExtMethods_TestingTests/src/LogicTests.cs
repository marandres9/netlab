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
    public class LogicTests
    {
         [TestMethod()]
        public void DivideTest()
        {
            double expected = 1.5;
            double dividend = 3.0;
            double divisor = 2.0;

            Assert.AreEqual(expected, Logic.Divide(dividend, divisor));
        }

        [TestMethod()]
        public void SquareRootTest()
        {

            double expected = 9d;
            double radicand = 81d;

            Assert.AreEqual(expected, Logic.SquareRoot(radicand));
        }

        [TestMethod()]
        public void ParseUserInputTest()
        {
            double expected = 4.86;
            string input = "4.86";

            Assert.AreEqual(expected, Logic.ParseUserInput(input));
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            Logic.Divide(10, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exceptions.NegataiveRadicandException))]
        public void NegativeRadicandTest()
        {
            Logic.SquareRoot(-4);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exceptions.InvalidInputException))]
        public void InvalidInputTest()
        {
            Logic.ParseUserInput("a");
        }
    }
}