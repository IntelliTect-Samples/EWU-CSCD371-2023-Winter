using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericsHomework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class VennDiagramTests
    {
        [TestMethod]
        public void VennDiagram_Create_Success()
        {
            VennDiagram<string> vennDiagram = new(3);
            Assert.IsNotNull(vennDiagram);
        }

        [TestMethod]
        public void AddItem_Circle_Success()
        {
            VennDiagram<string> vennDiagram = new(3);
            Assert.IsTrue(vennDiagram.AddItem(0, "Item 1"));
            Assert.IsTrue(vennDiagram.AddItem(1, "Item 2"));
            Assert.IsTrue(vennDiagram.AddItem(2, "Item 3"));
            Assert.IsFalse(vennDiagram.AddItem(2, "Item 3"));
        }

        [TestMethod]
        public void AddItem_Circle_Exception()
        {
            VennDiagram<string> vennDiagram = new(3);
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>vennDiagram.AddItem(10,"item"));
        }

        [TestMethod]
        public void RemoveItem_Circle_Success()
        {
            VennDiagram<string> vennDiagram = new(3);
            vennDiagram.AddItem(0, "Item 1");
            Assert.IsTrue(vennDiagram.RemoveItem(0, "Item 1"));
            Assert.IsFalse(vennDiagram.RemoveItem(0, "Item 1"));
        }

        [TestMethod]
        public void RemoveItem_Circle_Exception()
        {
            VennDiagram<string> vennDiagram = new(3);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => vennDiagram.RemoveItem(10, "item"));
        }

        [TestMethod]
        public void Contains_Circle_Success()
        {
            VennDiagram<string> vennDiagram = new(3);
            vennDiagram.AddItem(0, "Item 1");
            Assert.IsTrue(vennDiagram.Contains(0, "Item 1"));
            Assert.IsFalse(vennDiagram.Contains(0, "Item 2"));
        }

        [TestMethod]
        public void Contains_Circle_Exception()
        {
            VennDiagram<string> vennDiagram = new(3);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => vennDiagram.Contains(10, "item"));
        }
    }
}