using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass]
    public class StorageTests
    {
        Storage? TestStorage;
        Book TestBook = new("The Dude Book", new FullName("Jane", "Doe", "Ashley"));
        Student TestStudent = new(new FullName("John", "Doe", null), "EWU");
        Employee TestEmployee = new(new FullName("John", "Doe", null), "Intellitect");
        [TestInitialize]
        public void Init()
        {
            TestStorage = new Storage();
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestStorage!.Clear();
        }

        [TestMethod]
        public void Storage_AddsEntityBook_ContainsBookTrue()
        {
            //Arrange

            //Act
            TestStorage!.Add(TestBook);

            //Assert
            Assert.IsTrue(TestStorage!.Contains(TestBook));
        }

        [TestMethod]
        public void Storage_AddsEntityStudent_ContainsStudentTrue()
        {
            //Arrange

            //Act
            TestStorage!.Add(TestStudent);

            //Assert
            Assert.IsTrue(TestStorage!.Contains(TestStudent));
        }

        [TestMethod]
        public void Storage_AddsEntityEmployee_ContainsStudentTrue()
        {
            //Arrange

            //Act
            TestStorage!.Add(TestEmployee);

            //Assert
            Assert.IsTrue(TestStorage!.Contains(TestEmployee));
        }

        [TestMethod]
        public void Storage_RemovesEntity_ContainsReturnsFalse()
        {
            //Arrange

            //Act
            TestStorage!.Add(TestEmployee);
            TestStorage!.Remove(TestEmployee);

            //Assert
            Assert.IsFalse(TestStorage.Contains(TestEmployee));
        }

        [TestMethod]
        public void Storage_GivenEntityID_GetReturnsSameEntity()
        {
            //Arrange

            //Act
            TestStorage!.Add(TestBook);
            IEntity sameBook = TestStorage!.Get(TestBook.ID)!;

            //Assert
            Assert.AreEqual(TestBook.Name, sameBook.Name);
        }

        [TestMethod]
        public void Storage_Count_ReturnsCorrectAmount()
        {
            // Arrange

            // Act
            TestStorage!.Add(TestBook);
            TestStorage!.Add(TestEmployee);
            int count = TestStorage.Count;

            Assert.AreEqual<int>(2, count);
        }

        [TestMethod]
        public void Storage_Cleanup_RemovesAllEntities()
        {
            //Arrange

            //Act
            TestStorage!.Add(TestBook);
            TestStorage!.Clear();

            //Assert
            Assert.AreEqual<int>(0, TestStorage.Count);
        }
    }
}
