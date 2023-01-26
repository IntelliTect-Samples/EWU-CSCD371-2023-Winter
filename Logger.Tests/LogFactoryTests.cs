using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void LogFactoryTest_ObjectInitializer()
        {
            LogFactory fact = new LogFactory();
            fact.ConfigureFileLogger("abc123.txt");
            FileLogger fil = (FileLogger)fact.CreateLogger(nameof(this.GetType));
            Assert.AreEqual(nameof(this.GetType), fil.ClassName);
        }

        [TestMethod]
        public void LogFactory_InitializeWithoutFilePath_Error()
        {
            LogFactory fact = new LogFactory();
            FileLogger fil = (FileLogger)fact.CreateLogger(nameof(this.GetType));
            Assert.AreEqual(null, fil);
        }

        [TestMethod]
        public void LogFactoryTest_ConfigureFileLogger()
        {
            LogFactory fact = new LogFactory();
            fact.ConfigureFileLogger("abc123.txt");
            FileLogger fil = (FileLogger)fact.CreateLogger(nameof(this.GetType));
            Assert.AreEqual("abc123.txt", fil.getFilePath());
        }
    }
}
