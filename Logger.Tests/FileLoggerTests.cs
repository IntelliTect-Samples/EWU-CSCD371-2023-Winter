using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        [DataRow("example.txt")]
        public void Log_PathNotNull_Success(string filePath)
        {
            // Arrange
            var logger = new FileLogger(filePath);
            // Assert
            Assert.IsNotNull(logger);
        }

    }
}