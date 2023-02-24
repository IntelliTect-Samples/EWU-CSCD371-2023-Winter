using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_FirstNamePropertyGetAndSet_AreEqual()
        {
            //Arrange
            Address address = new("1234 S Somewhere St", "Atlanta", "GA", "44356");
            Person person = new("John", "Doe", address, "someGuy@yahoo.com");

            //Act
            person.FirstName = "Jane";

            //Assert
            Assert.AreEqual<string>("Jane", person.FirstName);
        }

        [TestMethod]
        public void Person_LastNamePropertyGetAndSet_AreEqual()
        {
            //Arrange
            Address address = new("1234 S Somewhere St", "Atlanta", "GA", "44356");
            Person person = new("John", "Doe", address, "someGuy@yahoo.com");

            //Act
            person.LastName = "McDonald";

            //Assert
            Assert.AreEqual<string>("McDonald", person.LastName);
        }

        [TestMethod]
        public void Person_AddressPropertyGetAndSet_AreEqual()
        {
            //Arrange
            Address address = new("1234 S Somewhere St", "Atlanta", "GA", "44356");
            Person person = new("John", "Doe", address, "someGuy@yahoo.com");

            //Act
            Address newAddress = new("4321 N SomewhereElse Ave", "Portland", "OR", "66574");
            person.Address = newAddress;

            //Assert
            Assert.AreEqual<IAddress>(newAddress, person.Address);
        }

        [TestMethod]
        public void Person_EmailPropertyGetAndSet_AreEqual()
        {
            //Arrange
            Address address = new("1234 S Somewhere St", "Atlanta", "GA", "44356");
            Person person = new("John", "Doe", address, "someGuy@yahoo.com");

            //Act
            person.EmailAddress = "AnotherGuy@Gmail.com";
            //Assert
            Assert.AreEqual<string>("AnotherGuy@Gmail.com", person.EmailAddress);
        }
    }
}