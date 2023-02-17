using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_CreateStringNode_Success()
        {
            Node<string> node = new(value: "test data");

            Assert.IsNotNull(node);
        }

        [TestMethod]
        public void ToString_GivenNode_ReturnValue()
        {
            Node<int> node = new(value: 1);

            Assert.AreEqual<string>("1", node.ToString()!);
        }

        [TestMethod]
        public void Next_GivenNode_ReturnSelf()
        {
            Node<string> node = new(value: "test next");

            Assert.AreEqual<Node<string>>(node, node.Next);
        }

        [TestMethod]
        public void Append_GivenValue_CreatesNewNode()
        {
            Node<int> node1 = new(value: 1);

            node1.Append(2);

            Assert.AreEqual<int>(2, node1.Next.Value);
            Assert.AreNotEqual<Node<int>>(node1, node1.Next);
        }

        [TestMethod]
        public void Append_GivenMultipleValues_CreatesNewNodes()
        {
            Node<int> node = new(value: 1);
            node.Append(2);
            node.Append(3);
            node.Append(4);

            Assert.AreEqual<int>(1, node.Value);
            node = node.Next;
            Assert.AreEqual<int>(4, node.Value);
            node = node.Next;
            Assert.AreEqual<int>(3, node.Value);
            node = node.Next;
            Assert.AreEqual<int>(2, node.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Append_GivenDuplicateValue_ThrowsException()
        {
            Node<int> node = new(value: 1);
            node.Append(2);
            node.Append(1);
        }

        [TestMethod]
        public void Clear_GivenNode_Success()
        {
            Node<int> node = new(value: 1);

            node.Append(2);
            node.Clear(node);

            Assert.AreEqual<Node<int>>(node, node.Next);
        }

        [TestMethod]
        public void Exists_GivenValue_ReturnsResult()
        {
            Node<int> node = new(value: 1);

            node.Append(2);
            node.Append(4);
            node.Append(17);
            bool test1 = node.Exists(2);
            bool test2 = node.Exists(356);
            bool test3 = node.Exists(4);

            Assert.IsTrue(test1);
            Assert.IsFalse(test2);
            Assert.IsTrue(test3);
        }
    }
}
