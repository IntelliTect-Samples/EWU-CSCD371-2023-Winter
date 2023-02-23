using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculate.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        readonly Calculator calc = new();
        [TestMethod]
        public void MathematicalOperations_ContainsValidEntires()
        {
            Func<int, int, double> addition = Calculator.Add;
            Func<int, int, double> subtraction = Calculator.Subtract;
            Func<int, int, double> multiplication = Calculator.Multiply;
            Func<int, int, double> division = Calculator.Divide;
            Assert.AreEqual<Func<int, int, double>>(addition, calc.MathematicalOperations['+']);
            Assert.AreEqual<Func<int, int, double>>(subtraction, calc.MathematicalOperations['-']);
            Assert.AreEqual<Func<int, int, double>>(multiplication, calc.MathematicalOperations['*']);
            Assert.AreEqual<Func<int, int, double>>(division, calc.MathematicalOperations['/']);
        }

        [TestMethod]
        public void AddMethod_PerformsAsExpected()
        {
            double testAddAct = Calculator.Add(1, 2);
            double testAddExp = 3;
            Assert.AreEqual<double>(testAddExp, testAddAct);
        }

        [TestMethod]
        public void SubtractMethod_PerformsAsExpected()
        {
            double testSubtractAct = Calculator.Subtract(1, 2);
            double testSubtractExp = -1;
            Assert.AreEqual<double>(testSubtractExp, testSubtractAct);
        }

        [TestMethod]
        public void MultiplyMethod_PerformsAsExpected()
        {
            double testMultiplyAct = Calculator.Multiply(3, 5);
            double testMultiplyExp = 15;
            Assert.AreEqual<double>(testMultiplyExp, testMultiplyAct);
        }

        [TestMethod]
        public void DivideMethod_PerformsAsExpected()
        {
            double testDivideAct = Calculator.Divide(5, 2);
            double testDivideExp = 2.5;
            Assert.AreEqual<double>(testDivideExp, testDivideAct);
        }

        [TestMethod]
        public void TryCalculate_AddMethod_PerformsAsExpected()
        {
            string testCalcInput = "3 + 5";
            double testCalcOutput;
            double testCalcExp = 8;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsTrue(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TryCalculate_SubtractMethod_PerformsAsExpected()
        {
            string testCalcInput = "5 - 2";
            double testCalcOutput;
            double testCalcExp = 3;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsTrue(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TryCalculate_MultiplyMethod_PerformsAsExpected()
        {
            string testCalcInput = "3 * 5";
            double testCalcOutput;
            double testCalcExp = 15;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsTrue(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TryCalculate_DivideMethod_PerformsAsExpected()
        {
            string testCalcInput = "5 / 2";
            double testCalcOutput;
            double testCalcExp = 2.5;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsTrue(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TryCalculate_InvalidInputNoSpace_Fails()
        {
            string testCalcInput = "3+5";
            double testCalcOutput;
            double testCalcExp = 0;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsFalse(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TryCalculate_InvalidInputBadOp_Fails()
        {
            string testCalcInput = "3 > 5";
            double testCalcOutput;
            double testCalcExp = 0;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsFalse(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }

        [TestMethod]
        public void TryCalculate_InvalidInputNonInt_Fails()
        {
            string testCalcInput = "3.4325 + 5.2";
            double testCalcOutput;
            double testCalcExp = 0;
            bool testCalcBool = Calculator.TryCalculate(testCalcInput, out testCalcOutput);
            Assert.IsFalse(testCalcBool);
            Assert.AreEqual<double>(testCalcExp, testCalcOutput);
        }
    }
}
