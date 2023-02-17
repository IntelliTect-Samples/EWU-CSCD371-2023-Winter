namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        Node<int> node = new(1, null!);

        [TestMethod]
        public void CreateNode_ReturnsNode()
        {
            // Assert
            Assert.AreEqual<Node<int>>(node, node.Next);
            Assert.AreEqual<int>(node.Value, 1);
        }

        [TestMethod]
        public void ToString_ReturnsString()
        {
            // Act
            string expected = "1";

            // Assert
            Assert.AreEqual<string>(expected, node.ToString());
        }

        [TestMethod]
        public void Append_Success()
        {
            node.Append(2);
            Assert.AreEqual<Node<int>>(node, node.Next.Next);
            Assert.AreEqual<int>(node.Next.Value, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Append_Failure()
        {
            node.Append(2);
            node.Append(2);
        }

        [TestMethod]
        public void Clear_CutsAllLinks()
        {
            // Act
            node.Append(2);
            node.Append(3);
            node.Clear();

            // Assert
            Assert.AreEqual<Node<int>>(node, node.Next);
        }

        [TestMethod]
        public void Exists_ReturnsTrue()
        {
            node.Append(2);
            Assert.IsTrue(node.Exists(2));
        }

        [TestMethod]
        public void Exists_ReturnsFalse()
        {
            node.Append(2);
            Assert.IsFalse(node.Exists(3));
        }
    }
}