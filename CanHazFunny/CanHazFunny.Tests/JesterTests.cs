using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(ArgumentNullException)]
        public void JesterInitialize_TestNullPrintService()
        {
            
        }
    }
}
