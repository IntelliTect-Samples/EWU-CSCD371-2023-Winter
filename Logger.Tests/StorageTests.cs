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
        private Storage? TestStorage;
        private Book testBook = new("The Dude Book", "Mr.Man");
        private Student testStudent = new("John", "EWU");
        private Employee testEmployee = new("Jane", "Intellitect");
        [TestInitialize] 
        public void Init() 
        { 
            TestStorage = new Storage();
            TestStorage!.Add(testBook);
            TestStorage!.Add(testStudent);
            TestStorage!.Add(testEmployee);
        }

        [TestMethod]
        public void Storage_AddsEntityBook_ContainsBookTrue()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsTrue(TestStorage!.Contains(testBook));
        }

        [TestMethod]
        public void Storage_AddsEntityStudent_ContainsStudentTrue()
        {
            //Arrange
            
            //Act

            //Assert
            Assert.IsTrue(TestStorage!.Contains(testStudent));
        }

        [TestMethod]
        public void Storage_AddsEntityEmployee_ContainsStudentTrue()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsTrue(TestStorage!.Contains(testEmployee));
        }

        [TestMethod]
        public void Storage_RemovesEntity_ContainsReturnsFalse()
        {
            //Arrange

            //Act
            TestStorage!.Remove(testEmployee);

            //Assert
            Assert.IsFalse(TestStorage.Contains(testEmployee));
        }

        /*[TestMethod]
        public void Storage_GivenEntityID_GetReturnsSameEntity()
        {
            //Arrange

            //Act
            IEntity sameBook = TestStorage!.Get(testBook.ID)!;

            //Assert
            Assert.AreEqual<string>(testBook.Name,sameBook.Name);
        }*/

    }
}
