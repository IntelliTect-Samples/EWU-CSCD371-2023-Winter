using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void ChildItemsTest()
        {
            Node<int> node = new(1);
            node.Add(2);
            node.Add(3);
            Assert.AreEqual<string>("1,3", string.Join(",", node.ChildItems(2)));
        }
    }
}