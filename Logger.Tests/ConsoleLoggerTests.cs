using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class ConsoleLoggerTests
{
    [TestMethod]
    public void ConsoleLogger_IsNotNull_ReturnsTrue()
    {
        //Arrange
        LogFactory factory = new LogFactory();
        BaseLogger consoleLogger = factory.CreateLogger("ConsoleLogger");

        //Act
        consoleLogger.Log(LogLevel.Error, "Test Error Message");

        //Assert
        Assert.AreEqual("ConsoleLogger", consoleLogger.ClassName);
    }

    [TestMethod]
    public void ConsoleLogger_ClassNameIsConsoleLogger()
    {
        //Arrange
        LogFactory factory = new LogFactory();
        BaseLogger consoleLogger = factory.CreateLogger("ConsoleLogger");

        //Act
        consoleLogger.Log(LogLevel.Error, "Test Error Message");

        //Assert
        Assert.AreEqual("ConsoleLogger", consoleLogger.ClassName);
    }
}
