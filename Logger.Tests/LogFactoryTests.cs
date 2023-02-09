using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests : FileLoggerTestsBase
{
    [TestMethod]
    public void ConfigureFileLoggerGivenFilePathReturnsFileLoggerWithSetFilePath()
    {
        LogFactory logFactory = new();
        logFactory.ConfigureFileLogger(FilePath);
    }
}
