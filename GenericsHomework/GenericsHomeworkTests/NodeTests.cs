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
            Node<int> node = new Node<int>(10);
            Assert.IsNotNull(node);
            Assert.AreEqual<Node<int>>(node, node.Next);
        }

        [TestMethod]
        public void Node_ToString_Success()
        {
            string testValue = "Test String";
            Node<string> node = new Node<string>(testValue);
            Assert.AreEqual<string>(testValue, node.ToString());
        }

        [TestMethod]
        public void Node_ClearOneNode_Success()
        {
            Node<int> node = new(15);
            node.Clear();
            Assert.AreEqual<Node<int>>(node, node.Next);
        }

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
            Assert.ThrowsException<ArgumentException>(()=>node2.Append(1),
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
    }
}