using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void NodeTypeString_Are_Equal()
        {
            Node<string> newNode = new("one");
            Assert.AreEqual<string>("one", newNode.Value);

            Node<string> newNode2 = new("two", newNode);
            Assert.AreEqual<string>("two", newNode2.Value);
        }

        [TestMethod]
        public void NodeIsLast_True()
        {
            Node<string> nodeOne = new("one");
            Assert.IsTrue(nodeOne.Equals(nodeOne.Last));

            Node<string> nodeTwo = new("two", nodeOne);
            Assert.IsTrue(nodeTwo.Equals(nodeTwo.Last));

            Node<string> nodeThree = new("three", nodeTwo);
            Assert.IsTrue(nodeThree.Equals(nodeThree.Last));
        }

        [TestMethod]
        public void NodeExists_True()
        {
            Node<string> newNode = new("23");
            Assert.IsTrue(newNode.Exists("23"));
        }

        [TestMethod]
        public void NodeExists_False()
        {
            Node<string> newNode = new("11");
            Assert.IsFalse(newNode.Exists("12"));
        }

        [TestMethod]
        public void NodeExists_Null_True()
        {
            string empty = null!;
            Node<string> newNode = new("one");
            newNode.Append("two");
            newNode.Append(empty);
            newNode.Append("three");

            Assert.IsTrue(newNode.Exists(null!));
        }

        [TestMethod]
        public void NodeAppend_DuplicateValue_throwsException()
        {
            _ = Assert.ThrowsException<ArgumentException>(() =>
            {
                Node<double> newNode = DoubleNodes();
                newNode.Append(13);
            });
        }

        [TestMethod]
        public void NodeAppend_True()
        {
            Node<string> newNode = new("one");
            newNode.Append("two");
            Assert.IsTrue(newNode.Exists("two"));
        }

        [TestMethod]
        public void NodeLast_IsLast()
        {
            Node<string> newNode = new("one");
            newNode.Append("two");
            newNode.Append("three");
            Node<string> lastNode = newNode.GetLast();
            Assert.AreEqual<string>("three", lastNode.ToString()!);
            Assert.AreEqual<string>(newNode.ToString()!, lastNode.Next.ToString()!);
        }


        [TestMethod]
        public void NodeClear_RemovesAllNodesNotLast()
        {
            Node<double> newNode = DoubleNodes();
            Assert.IsTrue(newNode.Exists(13));
            Assert.IsTrue(newNode.Exists(88));
            Assert.IsTrue(newNode.Exists(99));
            Assert.IsTrue(newNode.Exists(100));
            Assert.IsTrue(newNode.Exists(108));

            newNode.Clear();
            Assert.IsTrue(newNode.Exists(13));
            Assert.IsFalse(newNode.Exists(88));
            Assert.IsFalse(newNode.Exists(99));
            Assert.IsFalse(newNode.Exists(100));
            Assert.IsFalse(newNode.Exists(108));
        }

        public static Node<double> DoubleNodes()
        {
            Node<double> newNode = new(13);
            newNode.Append(88);
            newNode.Append(99);
            newNode.Append(100);
            newNode.Append(108);
            return newNode;
        }
        [TestMethod]
        public void NodeCount_CorrectCount()
        {
            Node<double> newNode = DoubleNodes();
            double[] rightNodes = new[] { 13.0, 88.0, 99.0, 100.0, 108.0};
            double[] nodeTest = new double[5];
            int count = 0;
            foreach (Node<double> item in newNode)
            {
                nodeTest[count] = item.Value;
                count++;
            }
            Assert.IsTrue(nodeTest.SequenceEqual(rightNodes));
        }

        [TestMethod]
        public void ChildItemNodes_ReturnsAllNodes()
        {
            Node<double> newNode = DoubleNodes();
            List<Node<double>> nodeList = newNode.ChildItems(6).ToList();
            Assert.IsTrue(nodeList.Count == 5);
            Assert.IsTrue(nodeList.Contains(newNode));
            Assert.IsTrue(nodeList.Contains(newNode.Next));
            Assert.IsTrue(nodeList.Contains(newNode.Next.Next));
            Assert.IsTrue(nodeList.Contains(newNode.Next.Next.Next));
            Assert.IsTrue(nodeList.Contains(newNode.Next.Next.Next.Next));

        }

        [TestMethod]
        public void ChildItemNodes_ReturnsLessThanMaximum()
        {
            Node<double> newNode = DoubleNodes();
            List<Node<double>> nodeList = newNode.ChildItems(4).ToList();
            Assert.IsTrue(nodeList.Count == 3);
            Assert.IsTrue(nodeList.Contains(newNode));
            Assert.IsTrue(nodeList.Contains(newNode.Next));
            Assert.IsTrue(nodeList.Contains(newNode.Next.Next));
        }


        [TestMethod]
        public void EnumeratorExists_True()
        {
            Node<double> newNode = DoubleNodes();
            var enumerator = newNode.GetEnumerator();
            Assert.IsNotNull(enumerator);
        }


    }
}
