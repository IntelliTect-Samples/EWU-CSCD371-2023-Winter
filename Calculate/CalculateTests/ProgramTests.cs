using Calculate;

namespace CalculateTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Program_WriteLineProperty_Success()
        {
            //Arrange
            Program prog = new();
            StringWriter testWriteLine = new();

            //Act
            Console.SetOut(testWriteLine);
            prog.WriteLine("This is a test of the WriteLine property");
            string actual = testWriteLine.ToString();

            //Assert
            Assert.AreEqual<string>("This is a test of the WriteLine property\r\n", actual);
        }

        [TestMethod]
        public void Program_ReadLineProperty_Success()
        {
            //Arrange
            Program prog = new();
            StringReader testReadLine = new("This is a test of the ReadLine property");

            //Act
            Console.SetIn(testReadLine);
            string actual = prog.ReadLine!();

            //Assert
            Assert.AreEqual<string>("This is a test of the ReadLine property", actual);
        }
    }
}