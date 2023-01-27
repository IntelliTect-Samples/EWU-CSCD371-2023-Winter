using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]

        public void FileLogger_WithNullFilePath_ThrowsException()
        {
            // Arrange

            // Act
            FileLogger fileLogger = new FileLogger(null!);

            // Assert
        }
    }
}
