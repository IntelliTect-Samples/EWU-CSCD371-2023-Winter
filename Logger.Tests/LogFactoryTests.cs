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

        }

        [TestMethod]
        public void LogFactoryTest_ConfigureFileLogger()
        {
            LogFactory fact = new LogFactory();
            fact.configureFileLogger("abc123.txt"); 

        }
    }
}
