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
            Program prog = new()
            {
                WriteLine = Console.WriteLine,
                ReadLine = Console.ReadLine!
            };

            //Act

            //Assert
            
        }

        [TestMethod]
        public void Program_ReadLineProperty_Success()
        {
            //Arrange
            Program prog = new()
            {
                WriteLine = Console.WriteLine,
                ReadLine = Console.ReadLine!
            };

            //Act

            //Assert

        }
    }
}