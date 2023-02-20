using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculateTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Calculator_TryParse_ReturnsTrue()
        {
            //Arrange
            Calculator calc = new();

            //Act
            string equation1 = "42 + 3";
            string equation2 = "42 - 3";
            string equation3 = "42 * 3";
            string equation4 = "42 / 3";

            //Assert
            Assert.IsTrue(calc.TryCalculate(equation1));
            Assert.IsTrue(calc.TryCalculate(equation2));
            Assert.IsTrue(calc.TryCalculate(equation3));
            Assert.IsTrue(calc.TryCalculate(equation4));
        }

        [TestMethod]
        public void Calculator_TryParse_ReturnsFalse()
        {
            //Arrange
            Calculator calc = new();

            //Act
            string equation1 = "42 +! 3";
            string equation2 = "42+3";

            //Assert
            Assert.IsFalse(calc.TryCalculate(equation1));
            Assert.IsFalse(calc.TryCalculate(equation2));
        }
    }
}