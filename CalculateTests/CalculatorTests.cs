using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculate
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TryCalculate_Addition_Correct()
        {
            // Arrange
            Calculator calculator = new Calculator();
            string input = "2 + 2";
            int expected = 4;

            // Act
            bool success = calculator.TryCalculate(input, out int result);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryCalculate_Subtraction_Correct()
        {
            // Arrange
            Calculator calculator = new Calculator();
            string input = "4 - 2";
            int expected = 2;

            // Act
            bool success = calculator.TryCalculate(input, out int result);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryCalculate_Multiplication_Correct()
        {
            // Arrange
            Calculator calculator = new Calculator();
            string input = "3 * 5";
            int expected = 15;

            // Act
            bool success = calculator.TryCalculate(input, out int result);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryCalculate_Division_Correct()
        {
            // Arrange
            Calculator calculator = new Calculator();
            string input = "10 / 2";
            int expected = 5;

            // Act
            bool success = calculator.TryCalculate(input, out int result);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryCalculate_Division_By_Zero_Throws_Exception()
        {
            // Arrange
            Calculator calculator = new Calculator();
            string input = "10 / 0";

            // Act & Assert
            Assert.ThrowsException<DivideByZeroException>(() => calculator.TryCalculate(input, out int result));
        }

        [TestMethod]
        public void TryCalculate_Invalid_Input_Returns_False()
        {
            // Arrange
            Calculator calculator = new Calculator();
            string input = "invalid input";

            // Act
            bool success = calculator.TryCalculate(input, out int result);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(0, result);
        }
    }
}
