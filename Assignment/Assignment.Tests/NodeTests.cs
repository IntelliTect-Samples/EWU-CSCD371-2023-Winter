using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {
        private Node<string>? TestNode { get; set; } = null;

        [TestInitialize]
        public void InstantiateNode()
        {
            TestNode = new("myString");
        }
        [TestMethod]
        public void ValidateListWithSizeOneNextEqualsThis()
        {
            Assert.IsNotNull(TestNode);
            Assert.AreEqual<int>(TestNode!.Count, 1);
            Assert.AreEqual<Node<string>>(TestNode, TestNode.Next);

        }
        [TestMethod]
        public void ValidateListWithSizeTwoNextEqualsThis()
        {
            // Arrange
            Assert.IsNotNull(TestNode);

            // Act
            TestNode!.Append("any ol' string");

            // Assert
            Assert.AreEqual<int>(TestNode.Count, 2);
            Assert.AreEqual<Node<string>>(TestNode, TestNode.Next.Next);

        }
        [TestMethod]
        public void AppendNodeTest()
        {
            Assert.IsNotNull(TestNode);
            TestNode!.Append("Test Node");
            Assert.IsTrue(TestNode.Exists("Test Node"));
        }
        [TestMethod]
        public void ValidateToArray()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            TestNode!.Append("1");
            TestNode.Append("2");
            TestNode.Append("3");
            TestNode.Append("4");
            TestNode.Append("5");
            TestNode.Append("6");
            TestNode.Append("7");
            // Collection assert does not have a generic override
            CollectionAssert.AreEqual(new string[] { "myString", "7", "6", "5", "4", "3", "2", "1" }, TestNode.ToArray());
        }
        [TestMethod]
        public void ClearNodes()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            TestNode!.Append("1");
            TestNode.Append("2");
            TestNode.Append("3");
            TestNode.Append("4");
            TestNode.Append("5");
            TestNode.Append("6");
            TestNode.Append("7");
            CollectionAssert.AreEqual(new string[] { "myString", "7", "6", "5", "4", "3", "2", "1" }, TestNode.ToArray());
            // Act
            TestNode.Clear();
            // Assert
            CollectionAssert.AreEqual(new string[] { "myString" }, TestNode.ToArray());
        }
        [TestMethod]
        public void AssertContainsReturnsFalse()
        {
            Assert.IsNotNull(TestNode);
            Assert.IsFalse(TestNode!.Contains("1"));
            Assert.IsFalse(TestNode!.Exists("1"));

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AssertDuplicatesCannotBeAddedNode()
        {
            Assert.IsNotNull(TestNode);
            TestNode!.Append("1");
            TestNode.Append("1");
        }

        [TestMethod]
        public void ContainsLinkedListTestHead()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            Assert.IsTrue(TestNode!.Exists("myString"));
        }
        [TestMethod]
        public void ExistsNodeTestBody()
        {
            // Arrange
            Assert.IsNotNull(TestNode);

            TestNode!.Append("1");
            TestNode.Append("2");
            TestNode.Append("3");
            Assert.IsTrue(TestNode.Exists("2"));

        }

        [TestMethod]
        public void ContainsNodeTestBody()
        {
            // Arrange
            Assert.IsNotNull(TestNode);

            TestNode!.Add("1");
            TestNode.Add("2");
            TestNode.Add("3");
            Assert.IsTrue(TestNode.Contains("2"));
        }

        [TestMethod]
        public void ValidateNodeToString()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            string expected = "myString";
            // Assert
            Assert.AreEqual<string>(expected, TestNode!.ToString());
        }
        [TestMethod]
        public void ValidateCountReturnsNumberOfItems()
        {
            Assert.IsNotNull(TestNode);
            Assert.AreEqual<int>(TestNode!.Count(), 1);
            TestNode!.Append("1");
            Assert.AreEqual<int>(TestNode.Count(), 2);
            TestNode.Append("2");
            Assert.AreEqual<int>(TestNode.Count(), 3);
            TestNode.Append("3");
            Assert.AreEqual<int>(TestNode.Count(), 4);
            TestNode.Append("4");
            Assert.AreEqual<int>(TestNode.Count(), 5);
            TestNode.Clear();
            Assert.AreEqual<int>(TestNode.Count(), 1);
        }
        [TestMethod]
        public void ConvertLinkedListToArray_StartAt0()
        {
            Assert.IsNotNull(TestNode);
            TestNode!.Add("1");
            TestNode.Add("2");
            string[] arr = { "3", "4", "5" };
            TestNode.CopyTo(arr, 0);
            CollectionAssert.AreEqual(arr, TestNode.ToArray());
        }
        [TestMethod]
        public void ConvertLinkedListToArray_StartAt1()
        {
            Assert.IsNotNull(TestNode);
            TestNode!.Add("1");
            TestNode.Add("2");
            string[] arr = { "3", "4", "5" };
            TestNode.CopyTo(arr, 1);
            CollectionAssert.AreEqual(new string[] { "3", "myString", "2" }, arr);
        }
        [TestMethod]
        public void ConvertLinkedListToArray_StartAt2()
        {
            Assert.IsNotNull(TestNode);
            TestNode!.Add("1");
            TestNode.Add("2");
            string[] arr = { "3", "4", "5" };
            TestNode.CopyTo(arr, 2);
            Assert.AreEqual<string>("3 4 myString", string.Join(" ", arr));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateCopyToThrowNullException()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            string[] nullArray = null!;
            // Act
            TestNode!.CopyTo(nullArray, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateCopyToThrowOutofRangeException()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            string[] nullArray = { "1", "2" };
            // Act
            TestNode!.CopyTo(nullArray, 3);
        }
        [TestMethod]
        public void TestEnumerator_ReturnTrueIfOutputIntoString()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            // Act
            TestNode!.Append("0");
            TestNode.Append("1");
            TestNode.Append("2");
            TestNode.Append("3");

            string actual = "";
            // Assert
            foreach (string value in TestNode)
            {
                actual += value;
            }
            string expected = "myString3210";
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void TestRemoveFromLinkedList()
        {
            // Arrange
            Assert.IsNotNull(TestNode);
            TestNode!.Append("1");
            TestNode.Append("2");
            TestNode.Append("3");
            CollectionAssert.AreEqual(new string[] { "myString", "3", "2", "1" }, TestNode.ToArray());

            // Act
            Assert.IsTrue(TestNode.Remove("2"));

            // Assert
            CollectionAssert.AreEqual(new string[] { "myString", "3", "1" }, TestNode.ToArray());

            // Act
            Assert.IsTrue(TestNode.Remove("3"));

            // Assert
            CollectionAssert.AreEqual(new string[] { "myString", "1" }, TestNode.ToArray());

            Assert.IsFalse(TestNode.Remove("myString"));

            Assert.IsFalse(TestNode.Remove("2"));
        }

        [TestMethod]
        public void Test_NodeImplementsIEnumerator()
        {
            TestNode!.Append("1");
            TestNode!.Append("2");
            Assert.AreEqual<int>(3, TestNode.Count);
            Assert.IsNotNull(TestNode);
            TestNode?.Any(element => element is not null);

        }

        [TestMethod]
        public void Test_ChildItems_MaxIsLessThanTotal()
        {
            
            // Arrange
            TestNode!.Append("1");
            TestNode!.Append("2");
            TestNode!.Append("3");
            TestNode!.Append("4");
            TestNode!.Append("5");

            Node<string> ExpectedNode = new("myString")
            {
                  "4",
                  "5"
            };
 
            // Act
            IEnumerable<string> subsetOfList = TestNode.ChildItems(3);

            // Assert
            string expected = string.Join(",", ExpectedNode);
            string actual = string.Join(",", subsetOfList); 
            Assert.AreEqual<string>(expected, actual);

        }

        [TestMethod]
        public void Test_ChildItems_MaxIsGreaterThanTotal()
        {
            // Arrange
            TestNode!.Append("1");
            TestNode!.Append("2");

            // Act
            IEnumerable<string> subsetOfList = TestNode.ChildItems(8);


            // Assert
            string expected = string.Join(",", TestNode);
            string actual = string.Join(",", subsetOfList);
            Assert.AreEqual<string>(expected, actual);


        }
    }
}
