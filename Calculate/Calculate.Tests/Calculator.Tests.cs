namespace Calculate.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        readonly Calculator calculator = new();

        [TestMethod]
        public void Add_Success()
        {
            // Act
            bool isParsed = calculator.TryCalculate("1 + 1", out int actual);
            int expected = 2;

            // Assert
            Assert.IsTrue(isParsed);
            Assert.AreEqual<int>(actual, expected);
        }
        [TestMethod]
        public void Add_Failure()
        {
            // Act
            bool isParsed = calculator.TryCalculate("1+1", out int actual);
            int expected = 2;

            // Assert
            Assert.IsFalse(isParsed);
            Assert.AreNotEqual<int>(actual, expected);
        }

        [TestMethod]
        public void Subtract_Success()
        {
            // Act
            bool isParsed = calculator.TryCalculate("10 - 5", out int actual);
            int expected = 5;

            // Assert
            Assert.IsTrue(isParsed);
            Assert.AreEqual<int>(actual, expected);
        }

        [TestMethod]
        public void Subtract_Failure()
        {
            // Act
            bool isParsed = calculator.TryCalculate("a - 1", out int actual);
            int expected = 5;

            // Assert
            Assert.IsFalse(isParsed);
            Assert.AreNotEqual<int>(actual, expected);
        }

        [TestMethod]
        public void Multiply_Success()
        {
            // Act
            bool isParsed = calculator.TryCalculate("2 * 2", out int actual);
            int expected = 4;

            // Assert
            Assert.IsTrue(isParsed);
            Assert.AreEqual<int>(actual, expected);
        }

        public void Multiply_Failure()
        {
            // Act
            bool isParsed = calculator.TryCalculate("1 *123", out int actual);
            int expected = 4;

            // Assert
            Assert.IsFalse(isParsed);
            Assert.AreNotEqual<int>(actual, expected);
        }

        [TestMethod]
        public void Divide_Success()
        {
            // Act
            bool isParsed = calculator.TryCalculate("10 / 5", out int actual);
            int expected = 2;

            // Assert
            Assert.IsTrue(isParsed);
            Assert.AreEqual<int>(actual, expected);
        }

        public void Divide_Failure()
        {
            // Act
            bool isParsed = calculator.TryCalculate("1 / b", out int actual);
            int expected = 3;

            // Assert
            Assert.IsFalse(isParsed);
            Assert.AreNotEqual<int>(actual, expected);
        }
    }
}
