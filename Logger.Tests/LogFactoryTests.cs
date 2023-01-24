using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void CreateLogger_ClassNameIsNull_ReturnsNull()
    {
        //Arrange

        LogFactory logFactory = new LogFactory();

        //Act

        logFactory.CreateLogger(null!);

        //Assert
    }
}
