// We really tried to implement testers for writeline and readline but could not get to function correctly.
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;

//namespace CalculatorTests
//{
//    [TestClass]
//    public class ProgramTests
//    {
//        [TestMethod]
//        public void TestConsoleInteraction()
//        {
//            string expectedInput = "1 + 2";
//           string expectedOutput = "3";

//            string input = null;
//            string output = null;

//            Action<string> writeLine = (string line) => output = line;
//            Func<string> readLine = () => input;

//            var program = new Program();
//            program.SetUpInput(writeLine, readLine);

 
//            input = expectedInput;

//            program.Run(new Calculator());

            // Check that the expected output was written to the console
//            Assert.AreEqual(expectedOutput, output);
//        }
//    }
//}
