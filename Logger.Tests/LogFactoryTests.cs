using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_ClassNameIsNull_RetrurnsNull()
        {
            // Arrange
            LogFactory logFactory = new();

            // Act

            // Assert
            Assert.IsNull(logFactory.CreateLogger(null!));
        }

        [TestMethod]
        [DataRow(nameof(LogFactoryTests))]
        public void CreateLogger_ClassNameIsNotNull_ReturnsNotNull(string className)
        {
            // Arrange
            LogFactory logFactory = new();
            logFactory.ConfigureFileLogger(Path.GetTempFileName());
            // Act
            BaseLogger logger = logFactory.CreateLogger(className);
            // Assert
            Assert.IsNotNull(logger);
        }
    }
}
