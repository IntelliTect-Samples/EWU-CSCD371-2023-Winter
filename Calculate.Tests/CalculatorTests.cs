using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculate.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TryCalculate_GivenExpression_ReturnsTrueResult()
        {
            Calculator calculator = new();

            calculator.TryCalculate("1 + 2", out double result1);
            calculator.TryCalculate("1 - 2", out double result2);
            calculator.TryCalculate("1 * 2", out double result3);
            calculator.TryCalculate("3 / 2", out double result4);

            Assert.AreEqual<double>(3, result1);
            Assert.AreEqual<double>(-1, result2);
            Assert.AreEqual<double>(2, result3);
            Assert.AreEqual<double>(1.5, result4);
        }

        [TestMethod]
        public void TryCalculate_GivenInvalidExpression_ReturnsFalse()
        {
            Calculator calculator = new();

            bool bool1 = calculator.TryCalculate("1 ) 2", out double result1);
            bool bool2 = calculator.TryCalculate("1 -2", out double result2);
            bool bool3 = calculator.TryCalculate("1 - Q", out double result3);

            Assert.IsFalse(bool1);
            Assert.AreEqual<double>(0, result1);
            Assert.IsFalse(bool2);
            Assert.AreEqual<double>(0, result2);
            Assert.IsFalse(bool3);
            Assert.AreEqual<double>(0, result3);
        }

        [TestMethod]
        public void TryCalculate_GivenDivideByZero_ReturnFalse()
        {
            Calculator calculator = new();
            bool bool1 = calculator.TryCalculate("3 / 0", out double result1);

            Assert.IsFalse(bool1);
            Assert.AreEqual<double>(0, result1);
        }
    }
}