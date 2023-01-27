using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        [DataRow("example.txt")]
        public void Log_PathNotNull_Success(string filePath)
        {
            var logger = new FileLogger(filePath);
            Assert.IsNotNull(logger);
        }

        public void Create_Success()
        {
            FileLogger logger = new(nameof(FileLoggerTests), "myfile.txt");

            return logger;
        }

    }
}