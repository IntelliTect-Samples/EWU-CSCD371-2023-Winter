using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void HasValue()
        {
            Node<int> node = new(1);
            Assert.AreEqual(1, node.Value);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Node<int> node1 = new(1);
            Assert.AreEqual("1", node1.ToString());
            Node<string> node2 = new("Inigo");
            Assert.AreEqual("Inigo", node2.ToString());
        }


        [TestMethod]
        public void SingleNext()
        {
            Node<int> node1 = new(1);
            Assert.AreEqual(node1, node1.Next);
        }

        [TestMethod]
        public void Insert1()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            Assert.AreEqual(node2, node1.Next);
            Assert.AreEqual(node1, node2.Next);
        }

        [TestMethod]
        public void Insert2()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);
            Assert.AreEqual(node2, node1.Next);
            Assert.AreEqual(node3, node2.Next);
            Assert.AreEqual(node1, node3.Next);
        }


        [TestMethod]
        public void Clear()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);
            Assert.AreEqual(node1, node3.Next);
            node1.Clear();
            Assert.AreEqual(node1, node1.Next);
            Assert.AreEqual(node2, node3.Next);
        }

        [TestMethod]
        public void ClearOnly1()
        {
            Node<int> node1 = new(1);
            Assert.AreEqual(node1, node1.Next);
            node1.Clear();
            Assert.AreEqual(node1, node1.Next);
        }


        [TestMethod]
        public void NullTest()
        {
            Node<string?> node1 = new(null);
            Assert.AreEqual(null, node1.ToString());
        }


        [TestMethod]
        public void Duplicate()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);
            Assert.IsTrue(node1.Exists(1));
            Assert.IsTrue(node1.Exists(2));
            Assert.IsTrue(node1.Exists(3));
            Assert.IsTrue(node2.Exists(3));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Duplicate")]
        public void DuplicateException()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);
            var node4 = node3.Append(2);
        }

        // Test methods after this point are added to test IEnumerable:

        [TestMethod]
        public void ChildItems_ReturnsIEnumerableWithNumberOfItemsLessThanMaximum_AreEqual()
        {
            //Arrange
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);

            //Act
            int expected = 2;
            int actual = node1.ChildItems(3).Count();

            //Assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void GetAllItems_ReturnsIEnumerableContainingAllItems_AreEqual()
        {
            //Arrange
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);

            //Act
            int expected = 3;
            int actual = node1.GetAllItems().Count();
            foreach (int item in node1.GetAllItems()) 
            {
                Console.WriteLine(item);
            }

            //Assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void InternalCollections_RemovesNodesFromListOnceClearIsCalled_AreEqual()
        {
            //Arrange
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);
            var node4 = node3.Append(4);
            var node5 = node4.Append(5);

            //Act
            node3.Clear();
            int expected = 1;
            int actual = node3.GetAllItems().Count();
            foreach (int item in node3.GetAllItems()) 
            {
                Console.WriteLine(item);
            }

            //Assert
            Assert.AreEqual<int>(expected, actual);
        }
    }
}