using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Collections.Generic;

namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Error_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act
        BaseLoggerMixins.Error(null, "");

        // Assert
    }

    [TestMethod]
    public void Error_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger();


        // Act
        BaseLoggerMixins.Error(logger, "Message {0}", 42);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Warning_WithNullLogger_ThrowsException()
    {
        BaseLoggerMixins.Warning(null, "");
    }

    [TestMethod]
    public void Warning_WithData_LogsMessage()
    {
        //Arrange
        var logger = new TestLogger();

        //Act
        BaseLoggerMixins.Warning(logger, "Message {0}", 42);

        //Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Info_WithNullLogger_ThrowsException()
    {
        BaseLoggerMixins.Info(null, "");
    }

    [TestMethod]
    public void Info_WithData_LogsMessage()
    {
        //Arrange
        var logger = new TestLogger();

        //Act
        BaseLoggerMixins.Info(logger, "Message {0}", 42);

        //Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Debug_WithNullLogger_ThrowsException()
    {
        BaseLoggerMixins.Debug(null, "");
    }

    [TestMethod]
    public void Debug_WithData_LogsMessage()
    {
        //Arrange
        var logger = new TestLogger();

        //Act
        BaseLoggerMixins.Debug(logger, "Message {0}", 42);

        //Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }
}

 

public class TestLogger : BaseLogger
{
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
    }
}