using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void TestGetEnumerator()
        {
            // Arrange
            Node<int> node = new Node<int>(1);
            node.Add(2);
            node.Add(3);

            // Act
            var result = node.GetEnumerator();
            result.MoveNext();
            int firstValue = result.Current;
            result.MoveNext();
            int secondValue = result.Current;
            result.MoveNext();
            int thirdValue = result.Current;

            // Assert
            Assert.AreEqual(1, firstValue);
            Assert.AreEqual(2, secondValue);
            Assert.AreEqual(3, thirdValue);
        }

        [TestMethod]
        public void TestChildItems()
        {
            // Arrange
            Node<int> node = new Node<int>(1);
            node.Add(2);
            node.Add(3);
            node.Add(4);

            // Act
            var result = node.ChildItems(2).ToList();

            // Assert
            CollectionAssert.AreEqual(new List<int> { 2, 3 }, result);
        }

        [TestMethod]
        public void TestChildItemsWithMaximumGreaterThanChildrenCount()
        {
            // Arrange
            Node<int> node = new Node<int>(1);
            node.Add(2);
            node.Add(3);
            node.Add(4);

            // Act
            var result = node.ChildItems(10).ToList();

            // Assert
            CollectionAssert.AreEqual(new List<int> { 2, 3, 4 }, result);
        }

        [TestMethod]
        public void TestChildItemsWithMaximumOfZero()
        {
            // Arrange
            Node<int> node = new Node<int>(1);
            node.Add(2);
            node.Add(3);
            node.Add(4);

            // Act
            var result = node.ChildItems(0).ToList();

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void TestChildItemsWithMaximumLessThanZero()
        {
            // Arrange
            Node<int> node = new Node<int>(1);
            node.Add(2);
            node.Add(3);
            node.Add(4);

            // Act
            var result = node.ChildItems(-1).ToList();

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void TestChildItemsWithNoChildren()
        {
            // Arrange
            Node<int> node = new Node<int>(1);

            // Act
            var result = node.ChildItems(2).ToList();

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result);
        }
    }
}