using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void MyTestMethod()
        {

        }

        [TestMethod]
        public void ToString_NodeToStringMethodUsesStoredDataTypeToStringMethod_ReturnsTrue()
        {
            //Arrange
            CircularSinglyLinkedList<int> list = new();

            //Act
            list.Append(5);

            //Assert
            Assert.AreEqual<string>("5", list.Get(0).ToString());
        }
    }
}
