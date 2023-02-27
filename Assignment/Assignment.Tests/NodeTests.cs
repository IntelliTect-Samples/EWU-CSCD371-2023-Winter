using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void ReturnsChildItemsGivenMax()
        {
            Node<string> node = testHelp();

            IEnumerable<Node<string>> node2 = node.ChildItems(10);

            Assert.AreEqual<int>(10, node2.Count());
        }

        public static Node<string> testHelp()
        {
            Node<string> node = new("Value");
            node.Append("Second");
            node.Next.Append("Third");
            node.Next.Next.Append("Fourth");
            return node;
        }
    }
}
