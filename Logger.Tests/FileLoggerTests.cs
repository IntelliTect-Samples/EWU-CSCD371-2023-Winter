
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{ 

        [TestMethod]
        public void FileLogger_LoggingLines()
        {
            // Arrange
            string filePath = Path.GetTempFileName();
            var logger = new FileLogger(filePath) {ClassName = nameof(FileLoggerTests)};

            // Act
            logger.Log(LogLevel.Error, "Error");
            logger.Log(LogLevel.Warning, "Warning");
            logger.Log(LogLevel.Information, "Logging Info");
            logger.Log(LogLevel.Debug, "Debugging!");

            // Assert
            string[] content = File.ReadAllLines(filePath);
            Assert.AreEqual(4, content.Length);
            File.Delete(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyFilePath_FileLogger_ThrowsExceptions()
        {
            // Arrange
            FileLogger testLogger = new FileLogger("");

            // Act
            testLogger.Log(LogLevel.Error, "This is an Error");

            // Assert


        }

        [TestMethod]
        public void Success_FileLogger_LogsError()
        {
            // Arrange
            var testLogger = new FileLogger("file.txt");

            // Act
            testLogger.Log(LogLevel.Error, "This is an Error");

            // Assert


        }
    

}
