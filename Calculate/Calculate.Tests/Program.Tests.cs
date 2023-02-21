namespace Calculate.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CreateProgram_WriteLineExpectedBehavior()
        {
            // Arrange 
            const string expected = "Test";
            string? actual = null;

            // Act
            Program program = new()
            {
                WriteLine = (str) => actual = str,
            };
            
            program.WriteLine(expected);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void CreateProgram_ReadLineExpectedBehavior()
        {
            // Arrange 
            const string expected = "Test";
            string? actual = null;

            // Act
            Program program = new()
            {
                ReadLine = () => expected,
            };

            actual = program.ReadLine();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual<string>(expected, actual);
        }
    }
}