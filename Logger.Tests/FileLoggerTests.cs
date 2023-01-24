using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void FileLogger_IsNotNull_ReturnsTrue()
    {
        //Arrange
        LogFactory factory = new LogFactory();
        factory.ConfigureLogger("FileLoggerTest.log");
        BaseLogger fileLogger = factory.CreateLogger("FileLogger");

        //Act
        fileLogger.Log(LogLevel.Error, "Test Error Message");

        //Assert
        Assert.IsNotNull(fileLogger);
    }

    [TestMethod]
    public void FileLogger_StoresCallingClass()
    {
        // Arrange
        LogFactory factory = new LogFactory();
        factory.ConfigureLogger("FileLoggerTest.log");
        BaseLogger fileLogger = factory.CreateLogger("FileLogger");

        // Act
        fileLogger.Log(LogLevel.Information, "This should show FileLoggerTests as the calling class");

        // Assert
        Assert.AreEqual("FileLoggerTests", fileLogger.CallingClass);
    }
}
