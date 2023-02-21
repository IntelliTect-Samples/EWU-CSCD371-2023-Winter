using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculateTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Calculator_TryCalculateGivenGoodInput_ReturnsTrue()
        {
            //Arrange
            Calculator calc = new();
            float result;

            //Act
            string equation1 = "42 + 3";
            string equation2 = "42 - 3";
            string equation3 = "42 * 3";
            string equation4 = "42 / 3";

            //Assert
            Assert.IsTrue(calc.TryCalculate(equation1, out result));
            Assert.IsTrue(calc.TryCalculate(equation2, out result));
            Assert.IsTrue(calc.TryCalculate(equation3, out result));
            Assert.IsTrue(calc.TryCalculate(equation4, out result));
        }

        [TestMethod]
        public void Calculator_TryCalculateGivenBadInput_ReturnsFalse()
        {
            //Arrange
            Calculator calc = new();
            float result;

            //Act
            string equation1 = "42 +! 3";
            string equation2 = "42+3";
            string equation3 = "Some bad input";
            string equation4 = "";
            string equation5 = "45x + 72b";

            //Assert
            Assert.IsFalse(calc.TryCalculate(equation1, out result));
            Assert.IsFalse(calc.TryCalculate(equation2, out result));
            Assert.IsFalse(calc.TryCalculate(equation3, out result));
            Assert.IsFalse(calc.TryCalculate(equation4, out result));
            Assert.IsFalse(calc.TryCalculate(equation5, out result));
        }

        [TestMethod]
        public void Calculator_Add_Success()
        {
            //Arrange
            Calculator calc = new();
            float result;

            //Act
            string equation = "2 + 2";
            calc.TryCalculate(equation, out result);

            //Assert
            Assert.AreEqual<float>(4f, result);

        }

        [TestMethod]
        public void Calculator_Subract_Success()
        {
            //Arrange
            Calculator calc = new();
            float result;

            //Act
            string equation = "3 - 2";
            calc.TryCalculate(equation, out result);

            //Assert
            Assert.AreEqual<float>(1f, result);

        }

        [TestMethod]
        public void Calculator_Multiply_Success()
        {
            //Arrange
            Calculator calc = new();
            float result;

            //Act
            string equation = "2 * 2";
            calc.TryCalculate(equation, out result);

            //Assert
            Assert.AreEqual<float>(4f, result);

        }

        [TestMethod]
        public void Calculator_Divide_Success()
        {
            //Arrange
            Calculator calc = new();
            float result;

            //Act
            string equation = "4 / 2";
            calc.TryCalculate(equation, out result);

            //Assert
            Assert.AreEqual<float>(2f, result);

        }
    }
}