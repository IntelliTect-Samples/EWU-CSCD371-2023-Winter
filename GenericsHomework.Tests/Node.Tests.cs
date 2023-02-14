using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void Append_WithNotNullValue_AppendsNode()
        {
            Node<int> node = new(4);
            node.Append(0);

            Assert.IsTrue(node.Exists(0));
        }

        [TestMethod]
        public void Append_WithNullValue_DoesNotAppend()
        {
            Node<string> node = new("testString");
            node.Append(null!);

            Assert.IsFalse(node.Exists(null!));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Append_WithDuplicateValue_ThrowsException()
        {
            Node<double> node = new(20.2);
            node.Append(20.2);
        }

        [TestMethod]
        public void Clear_RemovesAllButCurrentNode()
        {
            Node<char> node = new('a');
            node.Append('b');
            node.Append('c');
            node.Append('d');
            node.Clear();

            Assert.IsTrue(node.Exists('a'));
            Assert.IsFalse(node.Exists('b'));
            Assert.IsFalse(node.Exists('c'));
            Assert.IsFalse(node.Exists('d'));
        }
    }
}