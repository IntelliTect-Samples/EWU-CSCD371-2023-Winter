using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void Error_WithNoConfiguration_ReturnsNull()
        {
            LogFactory factory = new();
            BaseLogger log = factory.CreateLogger("FileLogger", nameof(LogFactoryTests));
            Assert.IsNull(log);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Error_WithUnrecognizedClassname_ThrowsArgumentException()
        {
            LogFactory factory = new();
            factory.ConfigureLogger("log.log");
            BaseLogger log = factory.CreateLogger("NonexistentLogger", nameof(LogFactoryTests));
        }
    }
}
