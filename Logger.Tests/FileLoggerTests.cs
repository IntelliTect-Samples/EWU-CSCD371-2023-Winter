using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLoggerTest_GetSet()
        {
            var log = new FileLogger("123Test.txt");
            Assert.AreEqual("123Test.txt", log.getFilePath());
        }
    }
    
}
