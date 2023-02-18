using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_Constuctor_Success()
        {
            Node<int> node = new(10);
            Assert.IsNotNull(node);
            Assert.AreEqual<Node<int>>(node, node.Next);
        }

        [TestMethod]
        public void Node_ToString_Success()
        {
            string testValue = "Test String";
            Node<string> node = new(testValue);
            Assert.AreEqual<string>(testValue, node.ToString());
        }

        // Test Clear with only one node in the circular list
        // It is testing that node.Next continue to point to self instead of setting to null
        [TestMethod]
        public void Node_ClearOneNode_Success()
        {
            Node<int> node = new(15);
            node.Clear();
            Assert.AreEqual<Node<int>>(node, node.Next);
        }

        // Test Clear with multiple nodes in the list to make sure
        // all nodes are traversed and .Next is set to itself
        [TestMethod]
        public void Node_ClearTwoNodes_Success()
        {
            Node<int> node = new(1);
            node.Append(2); // Create a second node
            var node2 = node.Next;

            node.Clear();
            // Check if all nodes point to themself
            Assert.AreEqual<Node<int>>(node, node.Next);
            Assert.AreEqual<Node<int>>(node2, node2.Next);
        }

        [TestMethod]
        public void Node_Append_Success()
        {
            Node<int> node = new(1);
            node.Append(2); // Create a second node
            var node2 = node.Next;

            Assert.AreEqual<Node<int>>(node2, node.Next);
            Assert.AreEqual<Node<int>>(node, node2.Next);
        }

        [TestMethod]
        public void Node_AppendValueExist_Exception()
        {
            Node<int> node = new(1);
            node.Append(2); // Create a second node
            var node2 = node.Next;
            Assert.ThrowsException<ArgumentException>(() => node2.Append(1),
                "Value already exists in the list");
        }

        [TestMethod]
        public void Node_Exists_Success()
        {
            Node<int> node = new(1);
            node.Append(2); // Create a second node
            var node2 = node.Next;

            Assert.IsTrue(node.Exists(1));
            Assert.IsTrue(node.Exists(2));
            Assert.IsFalse(node.Exists(3));
        }

        // Extra credit: Tests
        [TestMethod]
        public void Node_Count_Success()
        {
            Node<int> node = new(1);
            node.Append(2); // Create a second node
            Assert.AreEqual(2, node.Count());
        }

        [TestMethod()]
        public void Node_IsReadOnly_False()
        {
            Node<int> node = new(1);
            Assert.IsFalse(node.IsReadOnly);
        }

        [TestMethod()]
        public void AddTest()
        {
            Node<int> node = new(1);
            node.Add(2);
            var node2 = node.Next;
            Assert.AreEqual<Node<int>>(node2, node.Next);
            Assert.AreEqual<Node<int>>(node, node2.Next);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Node<int> node = new(1);
            Assert.IsTrue(node.Contains(1));
            Assert.IsFalse(node.Contains(2));
        }

        [TestMethod()]
        public void CopyToTest()
        {
            Node<int> node = new(1);
            node.Add(2);
            node.Add(3);
            int[] array = new int[3];
            node.CopyTo(array, 0);
            CollectionAssert.AreEqual(array, new int[] {1,3,2});   
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Node<int> node = new(1);
            node.Add(2);
            node.Add(3);
            Assert.IsTrue(node.Remove(2));
            Assert.IsFalse(node.Remove(2));
            Assert.IsFalse(node.Remove(1)); // Cannot remove head of the list
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Node<int> node = new(1);
            node.Add(2);
            node.Add(3);
            string items = "";
            foreach(int item in node)
            {
                items += item.ToString() + " ";
            }
            Assert.AreEqual("1 3 2 ", items);
        }
    }
}