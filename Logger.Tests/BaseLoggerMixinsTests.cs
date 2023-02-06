﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

[assembly: CLSCompliant(true)]
namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ErrorWithNullLoggerThrowsException()
    {
        BaseLoggerMixins.Error(null!, "");
    }

    [TestMethod]
    public void ErrorWithDataLogsMessage()
    {
        // Arrange
        var logger = new TestLogger<ILoggerConfiguration>(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Error("Message 42");

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

}
