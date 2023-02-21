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

            calculator.TryCalculate("1 + 2", out int result1);
            calculator.TryCalculate("1 - 2", out int result2);
            calculator.TryCalculate("1 * 2", out int result3);
            calculator.TryCalculate("4 / 2", out int result4);

            Assert.AreEqual<int>(3, result1);
            Assert.AreEqual<int>(-1, result2);
            Assert.AreEqual<int>(2, result3);
            Assert.AreEqual<int>(2, result4);
        }

        [TestMethod]
        public void TryCalculate_GivenInvalidExpression_ReturnsFalse()
        {
            Calculator calculator = new();

            bool bool1 = calculator.TryCalculate("1 ) 2", out int result1);
            bool bool2 = calculator.TryCalculate("1 -2", out int result2);
            bool bool3 = calculator.TryCalculate("1 - Q", out int result3);

            Assert.IsFalse(bool1);
            Assert.AreEqual<int>(0, result1);
            Assert.IsFalse(bool2);
            Assert.AreEqual<int>(0, result2);
            Assert.IsFalse(bool3);
            Assert.AreEqual<int>(0, result3);
        }
    }
}