using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests : FileLoggerTestsBase
{
    //TODO: Add assert statement?
    [TestMethod]
    public void ConfigureFileLogger_GivenFilePath_ReturnsFileLoggerWithSetFilePath()
    {
        LogFactory logFactory = new();
        logFactory.ConfigureFileLogger(FilePath);
    }
}