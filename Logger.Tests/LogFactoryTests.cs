using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void Create_ConfigureNull_NotSuccess()
        {
            //Assert
            Assert.IsNull(new LogFactory().CreateLogger("test"));
        }
        [TestMethod]
        [DataRow("example.txt")]
        public void Create_ConfigureNotNull_Success(string filePath)
        {
            //Arrange
            LogFactory factory = new LogFactory();
            factory.ConfigureFileLogger(filePath);
            //Act
            var fileLogger = factory.CreateLogger(nameof(LogFactoryTests));
            //Assert
            Assert.IsNotNull(fileLogger);
        }
    }
}