using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void Address_StreetAddressPropertyGetAndSet_AreEqual()
        {
            //Arrange
            Address address = new("1234 S Somewhere St", "Atlanta", "GA", "44356");

            //Act
            address.StreetAddress = "4321 N SomewhereElse Ave";

            //Assert
            Assert.AreEqual<string>("4321 N SomewhereElse Ave", address.StreetAddress);
        }

        [TestMethod]
        public void Address_CityPropertyGetAndSet_AreEqual()
        {
            //Arrange
            Address address = new("1234 S Somewhere St", "Atlanta", "GA", "44356");

            //Act
            address.City = "Toronto";

            //Assert
            Assert.AreEqual<string>("Toronto", address.City);
        }

        [TestMethod]
        public void Address_StatePropertyGetAndSet_AreEqual()
        {
            //Arrange
            Address address = new("1234 S Somewhere St", "Atlanta", "GA", "44356");

            //Act
            address.State = "Alaska";

            //Assert
            Assert.AreEqual<string>("Alaska", address.State);
        }

        [TestMethod]
        public void Address_ZipPropertyGetAndSet_AreEqual()
        {
            //Arrange
            Address address = new("1234 S Somewhere St", "Atlanta", "GA", "44356");

            //Act
            address.Zip = "99223";

            //Assert
            Assert.AreEqual<string>("99223", address.Zip);
        }
    }
}