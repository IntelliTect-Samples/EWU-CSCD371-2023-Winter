using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void CreateLogger_GivenFileLogger_ReturnFileLogger()
    {
        // Arrange
        LogFactory testFactory = new();
        testFactory.ConfigureFileLogger(filePath: "testPath");
        FileLogger testFileLogger = (FileLogger)testFactory.CreateLogger(nameof(LogFactoryTests));

        // Act

        // Assert
        Assert.AreEqual(nameof(LogFactoryTests), testFileLogger.ClassName);
    }

    [TestMethod]
    public void CreateLogger_GivenNoConfigure_ReturnNull()
    {
        // Arrange
        LogFactory testFactory = new();
        FileLogger testFileLogger = (FileLogger)testFactory.CreateLogger(nameof(LogFactoryTests));

        // Act

        // Assert
        Assert.IsNull(testFileLogger);
    }

    [TestMethod]
    public void ConfigureFileLogger_GivenFilePath_Success()
    {
        // Arrange
        LogFactory testFactory = new();
        testFactory.ConfigureFileLogger(filePath: "testPath");

        // Act

        // Assert
        Assert.AreEqual("testPath", testFactory.FileLoggerPath);
    }
}
