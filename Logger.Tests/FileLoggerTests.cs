using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_GivenLog_Success()
        {
            LogFactory testFactory = new();
            testFactory.ConfigureFileLogger("test.txt");
            FileLogger testFileLogger = (FileLogger)testFactory.CreateLogger(nameof(FileLoggerTests));
            testFileLogger.Information("Test message {0}", "42");

            string[] fileText = File.ReadAllLines(testFileLogger.FilePath);
            string newestLine = fileText[^1];

            Assert.AreEqual(string.Format($"{DateTime.Now} {testFileLogger.ClassName} {LogLevel.Information}: Test message 42"), newestLine);

        }
    }
}
