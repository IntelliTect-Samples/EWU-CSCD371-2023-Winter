using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Assignment;
using System.Linq;
using System.Transactions;
using System.Globalization;
using System.Xml.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {

        [TestMethod]
        public void TestReadCSV_ReturnTrueCSVRowsMethodMatchesReadInString()
        {
            // Act
            IEnumerable<string> csvRows = new SampleData().CsvRows;
            IEnumerator<string> csvEnumerator = csvRows.GetEnumerator();

            using StreamReader sr = new("../../../../Assignment/People.csv");
            string line;
            _ = sr.ReadLine()!;

            // Assert
            while ((line = sr.ReadLine()!) != null && csvEnumerator.MoveNext())
            {
                Assert.AreEqual<string>(line, csvEnumerator.Current);
            
            }
        }

        [TestMethod]
        public void ValidateUnique_UsingHardcodedListOfSpokaneAddresses_ReturnTrueIfMatchesHardcodedExample()
        {          
            // Arrange
            List<Address> listOfAddresses = new() {
                new Address("44 W. Riverside Ave.", "Spokane", "WA", "99201"),
                new Address("2111 W. Wellesley Ave", "Spokane", "WA", "99205"),
                new Address("2304 E. Mallon", "Spokane", "WA", "99202"),
                new Address("1720 W 4th Ave Unit B", "Spokane", "WA", "99201"),
                new Address("5124 N. Market St.", "Spokane", "WA", "99217")
                
            };

            // Act
            IEnumerable<Address> state = listOfAddresses.DistinctBy(address => address.State);

            // Assert
            Assert.AreEqual<int>(1, state.Count());
            Assert.AreEqual<string>("WA", state.ElementAt(0).State); 

        }

        [TestMethod]
        public void TestGetUniqueSortedListOfStatesGivenCsvRows_AssertTrueIfStatesAreOrdered()
        {
            IEnumerable<string> uniqueSortedListOfStates = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsTrue(uniqueSortedListOfStates.Zip(uniqueSortedListOfStates.Skip(1), (curr, next) => string.Compare(curr, next) < 0).All(x => x));
            Assert.AreEqual<int>(27, uniqueSortedListOfStates.Count());
        }

        [TestMethod]
        public void Test_GetAggregateSortedListOfStatesUsingCsvRows_ReturnTrueIfMatchesHardcodedListofStrings()
        {
            // Arrange
            string expected = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            // Act
            string actual = new SampleData().GetAggregateSortedListOfStatesUsingCsvRows();
            // Assert
            Assert.AreEqual<string>(expected, actual); 
        }

        [TestMethod]
        public void Test_PersonObject_ReturnTrueIfFirstPersonMatchesHardcodedPerson()
        {
            // Arrange
            //49,Arthur,Myles,amyles1c@miibeian.gov.cn,4718 Thackeray Pass,Mobile,AL,37308

            Person expected = new("Arthur", "Myles", new Address("4718 Thackeray Pass", "Mobile", "AL", "37308"), "amyles1c@miibeian.gov.cn");
            // Act
            IEnumerable<IPerson> people = new SampleData().People;
            Person actual = (Person)people.ElementAt(0);
            // Assert
            Assert.IsTrue(expected == actual);

        }

        private static bool ContainsDotGov(string str) {
            return str.Contains(".gov");
        }

        [TestMethod]
        public void Test_FilterByEmail_ReturnsTrueIfMatchesReadInExampleDataSet() {
            // Arrange
            Predicate<string> predicate = ContainsDotGov;
            SampleData data = new();
            IEnumerable<IPerson> people = data.People;
            List<Person> expected = new();
            foreach (Person person in people.Cast<Person>()) {
                if (predicate(person.EmailAddress))
                {
                    expected.Add(person);
                }
                
            }

            Assert.IsTrue(expected.All(person => predicate(person.EmailAddress)));

            // Act 
            IEnumerable<(string FirstName, string LastName)> actual = data.FilterByEmailAddress(predicate);

            // Assert
            Assert.AreEqual<int>(actual.Count(), expected.Count);

            var expectedAndActual = actual.Zip(expected, (a, e) => new { Name = a, Person = e});
            
            foreach (var curr in expectedAndActual) {
                Assert.AreEqual<string>(curr.Person.FirstName, curr.Name.FirstName); 
                Assert.AreEqual<string>(curr.Person.LastName, curr.Name.LastName);
                Assert.IsTrue(predicate(curr.Person.EmailAddress));

            }

        
        }

        [TestMethod]
        public void Test_GetAggregateListOfStatesGivenPeopleCollectionReturnTrueIfMatchesCSVVariant()
        {
            // Arrange
            SampleData data = new();

            // This function calls the GivenCsvRows function
            string expected = data.GetAggregateSortedListOfStatesUsingCsvRows(); 

            // Act
            string actual = data.GetAggregateListOfStatesGivenPeopleCollection(data.People);

            // Assert
            Assert.AreEqual<string>(expected, actual);


        }

        [TestMethod]
        public void ValidateEqualsOperatorReturnsTrue_AddressAndPerson()
        {

            Address addr1 = new("1", "2", "3", "4");
            Address addr2 = new("1", "2", "3", "4");
            Person p1 = new("A", "B", addr1, "C");
            Person p2 = new("A", "B", addr2, "C");
            Assert.IsTrue(addr1 == addr2);
            Assert.IsTrue(p1 == p2);

        }
        [TestMethod]
        public void ValidateEqualsOperatorReturnsFalse_Person()
        {
            Address addr1 = new("1", "2", "3", "4");
            Address addr2 = new("1", "2", "3", "4");
            Person p1 = new("A", "", addr1, "C");
            Person p2 = new("A", "", addr2, "");
            Assert.IsTrue(addr1 == addr2);
            Assert.IsFalse(p1 == p2);


        }
        [TestMethod]
        public void ValidateNotEqualsOperatorReturnsTrue_Person()
        {
            Address addr1 = new("1", "2", "3", "4");
            Address addr2 = new("1", "2", "3", "4");
            Person p1 = new("A", "", addr1, "C");
            Person p2 = new("A", "", addr2, "");
            Assert.IsTrue(addr1 == addr2);
            Assert.IsTrue(p1 != p2);

        }
        [TestMethod]
        public void ValidateNotEqualsOperatorReturnsFalse_Address()
        {
            Address addr1 = new("1", "2", "3", "4");
            Address addr2 = new("1", "2", "3", "4");
            Person p1 = new("A", "", addr1, "C");
            Person p2 = new("A", "", addr2, "");
            Assert.IsFalse(addr1 != addr2);
            Assert.IsTrue(p1 != p2);

        }
    }
}
