using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_GivenNodeList_IteratesNode()
        {
            Node<int> node = new(1);

            node.Append(2);
            node.Append(3);
            node.Append(4);
            node.Append(5);
            node.Append(6);

            List<int> list = new() {1, 6, 5, 4, 3, 2 };
            List<int> actual = new();
            foreach(int i in node)
            {
                actual.Add(i);
            }

            Assert.AreEqual<int>(actual.Except(list).Count(), 0);
        }

        [TestMethod]
        public void ChildItems_GivenMaximum_ReturnsChildItems()
        {
            Node<int> node = new(1);

            node.Append(2);
            node.Append(3);
            node.Append(4);
            node.Append(5);
            node.Append(6);

            List<int> list = new() { 6, 5, 4, 3 };
            List<int> actual = new();
            foreach (int i in node.ChildItems(4))
            {
                actual.Add(i);
            }

            Assert.AreEqual<int>(actual.Except(list).Count(), 0);
        }

        [TestMethod]
        public void ChildItems_GivenMaximumPastEnd_ReturnsChildItems()
        {
            Node<int> node = new(1);

            node.Append(2);
            node.Append(3);
            node.Append(4);

            List<int> list = new() { 4, 3, 2 };
            List<int> actual = new();
            foreach (int i in node.ChildItems(6))
            {
                actual.Add(i);
            }

            Assert.AreEqual<int>(actual.Except(list).Count(), 0);
        }

        [TestMethod]
        public void ChildItems_GivenMaximumAtEnd_ReturnsChildItems()
        {
            Node<int> node = new(1);

            node.Append(2);
            node.Append(3);
            node.Append(4);
            node = node.Next.Next.Next;

            List<int> list = new() { 1, 4, 3 };
            List<int> actual = new();
            foreach (int i in node.ChildItems(5))
            {
                actual.Add(i);
            }

            Assert.AreEqual<int>(actual.Except(list).Count(), 0);
        }
    }
}