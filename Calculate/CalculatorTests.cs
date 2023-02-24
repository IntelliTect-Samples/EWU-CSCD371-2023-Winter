using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculate.Tests
{
    [TestClass]
    public class CalculatorTests
    {

        [TestMethod]
        [DataRow("1 + 2", 3)]
        [DataRow("3 - 2", 1)]
        [DataRow("1 * 2", 2)]
        [DataRow("6 / 2", 3)]
        public void TryCalculate_Valid_Success(string calculation, int expected)
        {
            Calculator calculator = new();

            bool isSuccess = calculator.TryCalculate(calculation, out int result);

            Assert.AreEqual<int>(expected, result);
            Assert.AreEqual<bool>(true, isSuccess);
        }
        [TestMethod]
        [DataRow("1 + 2", 0)]
        [DataRow("3 - 2", 0)]
        [DataRow("1 * 2", 0)]
        [DataRow("6 / 2", 0)]
        [DataRow("6 + 2 + 2", 0)]
        [DataRow(" 6 + 2", 0)]
        [DataRow("3 -- 2", 0)]
        [DataRow("3 -2", 0)]
        [DataRow("6 / / 2", 0)]
        [DataRow("g / h", 0)]
        [DataRow(" ", 0)]
        public void TryCalculate_Invalid_NotSuccess(string calculation, int expected)
        {
            Calculator calculator = new();

            bool isSuccess = calculator.TryCalculate(calculation, out int result);

            Assert.AreEqual<int>(expected, result);
            Assert.AreEqual<bool>(false, isSuccess);
        }
    }
}