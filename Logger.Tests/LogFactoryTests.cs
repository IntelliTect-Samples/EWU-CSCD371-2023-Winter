using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_ReturnsNull()
        {
            // Arrange
            LogFactory factory = new LogFactory();

            // Act
            var logger = factory.CreateLogger(factory.GetType().FullName);

            // Assert
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void CreateLogger_ReturnsLogger()
        {
            // Arrange 
            LogFactory factory = new LogFactory();
            factory.ConfigureFileLogger = "output.txt";

            // Act
            var logger = factory.CreateLogger(factory.GetType().FullName);  

            // Assert
            Assert.IsTrue(logger is BaseLogger);
        }
    }
}
