using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculate.Tests
{
    [TestClass]
    public class CalculateTests
    {
        [TestMethod]
        public void TestAddition()
        {
            int results = Calculator.Add(5, 5);
            Assert.AreEqual(10, results);
        }
        [TestMethod]
        public void TestSubtraction()
        {
            int results = Calculator.Subtract(10, 2);
            Assert.AreEqual(8, results);
        }
        [TestMethod]
        public void TestMultiply()
        {
            int results = Calculator.Multiply(4, 4);
            Assert.AreEqual(16, results);
        }
        [TestMethod]
        public void TestDivision()
        {
            int results = Calculator.Divide(8, 4);
            Assert.AreEqual(2, results);
        }
        [TestMethod]
        public void TryCalculateTrue()
        {
            bool results = Calculator.TryCalculate("8 + 8", out int output );
            Assert.AreEqual(results, true);
            Assert.AreEqual(16, output);
        }
        [TestMethod]
        public void TryCalculateFalse()
        {
            bool output = Calculator.TryCalculate("8+8", out int result);
            Assert.AreEqual(output, false);
        }
    }
}