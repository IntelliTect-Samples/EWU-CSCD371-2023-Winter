using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void TestAppendMethod()
        {
            Node<int> node = new Node<int>(10);
            node.Append(20);
            node.Append(30);

            Assert.AreEqual<int>(20, node.Next.Data);
            Assert.AreEqual<int>(30, node.Next.Next.Data);
        }

        [TestMethod]
        public void TestClearMethod()
        {
            Node<int> node = new Node<int>(10);
            node.Append(20);
            node.Append(30);
            node.Clear();

            Assert.AreSame(node, node.Next);
        }

        [TestMethod]
        public void TestExistingMethod()
        {
            Node<int> node = new Node<int>(10);
            node.Append(20);
            node.Append(30);

            Assert.IsTrue(node.existing(20));
            Assert.IsFalse(node.existing(40));
        }

        [TestMethod]
        public void TestAppendThrowsArgumentExceptionIfDataAlreadyExists()
        {
            // Arrange
            var list = new Node<int>(20);
            list.Append(30);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                list.Append(30);
            });
        }

        [TestMethod]
        public void TestToStringMethod()
        {
            Node<int> node = new Node<int>(10);

            Assert.AreEqual<string>("10", node.ToString());
        }
    }
}
