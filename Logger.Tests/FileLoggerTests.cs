using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{ 
    [TestMethod]
    [DataRow(LogLevel.Error, "This is a message")]
    public void Log_VerifyCorrectOutput(LogLevel logLevel, string message)
    {
        // Arrange
        string path = "output.txt";

        LogFactory factory = new LogFactory();
        factory.ConfigureFileLogger(path);
        var logger = factory.CreateLogger("BaseLogger");

        // Act
        logger.Log(LogLevel.Error, "This is a message");
        int count = File.ReadAllLines("output.txt").Length - 1;
        string loggerOutput = File.ReadAllLines(path)[count];
        string expected = $"{DateTime.Now} {logger.ClassName} {logLevel}: {message}";

        // Assert
        Assert.AreEqual(expected, loggerOutput);
    }
}
