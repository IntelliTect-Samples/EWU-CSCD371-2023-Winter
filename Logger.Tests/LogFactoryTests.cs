using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Error_WithNoConfiguration_ReturnsNull()
        {
            LogFactory factory = new LogFactory();
            BaseLogger log = factory.CreateLogger("FileLogger");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Error_WithUnrecognizedClassname_ThrowsArgumentException()
        {
            LogFactory factory = new LogFactory();
            factory.ConfigureLogger("log.log");
            BaseLogger log = factory.CreateLogger("NonexistentLogger");
        }
    }
}
