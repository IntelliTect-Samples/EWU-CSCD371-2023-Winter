using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void TestGetUniqueSortedListOfStatesGivenCsvRows()
        {
            // Arrange
            //Must change the filePath to match your path to the people.csv
            string filePath = "C:\\Users\\bhopk\\OneDrive\\Documents\\.next\\EWU-CSCD371-2023-Winter\\Assignment\\Assignment\\People.csv";
            SampleData sampleData = new SampleData(filePath);
            // Act
            var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestPeopleAreSortedCorrectly()
        {
            // Arrange
            string filePath = "C:\\Users\\bhopk\\OneDrive\\Documents\\.next\\EWU-CSCD371-2023-Winter\\Assignment\\Assignment\\People.csv";
            SampleData sampleData = new SampleData(filePath);
            // Act
            var result = sampleData.People.ToList();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Arthur", result[0].FirstName);
            Assert.AreEqual("Myles", result[0].LastName);
            Assert.AreEqual("Mobile", result[0].Address.City);
            Assert.AreEqual("AL", result[0].Address.State);
            Assert.AreEqual("Molly", result[1].FirstName);
            Assert.AreEqual("Jeannot", result[1].LastName);
            Assert.AreEqual("Tucson", result[1].Address.City);
            Assert.AreEqual("AZ", result[1].Address.State);
            
        }
        [TestMethod]
        public void TestPeopleSorting()
        {
            // Arrange
            // Must change the filePath to match your path to the people.csv
            string filePath = "C:\\Users\\bhopk\\OneDrive\\Documents\\.next\\EWU-CSCD371-2023-Winter\\Assignment\\Assignment\\People.csv";
            SampleData sampleData = new SampleData(filePath);

            // Act
            List<IPerson> sortedPeople = sampleData.People.ToList();
            sortedPeople.Sort((p1, p2) => {
                int stateComparison = string.Compare(p1.Address.State, p2.Address.State, StringComparison.Ordinal);
                if (stateComparison != 0) return stateComparison;
                int cityComparison = string.Compare(p1.Address.City, p2.Address.City, StringComparison.Ordinal);
                if (cityComparison != 0) return cityComparison;
                return string.Compare(p1.Address.Zip, p2.Address.Zip, StringComparison.Ordinal);
            });
            // Assert
            // Verify that the list is sorted correctly by comparing adjacent pairs of elements
            for (int i = 0; i < sortedPeople.Count - 1; i++)
            {
                IPerson currentPerson = sortedPeople[i];
                IPerson nextPerson = sortedPeople[i + 1];
                int comparison = string.Compare(currentPerson.Address.State, nextPerson.Address.State, StringComparison.Ordinal);
                Assert.IsTrue(comparison <= 0, $"Expected {currentPerson.Address.State} to be before {nextPerson.Address.State} in the list");
                if (comparison == 0)
                {
                    comparison = string.Compare(currentPerson.Address.City, nextPerson.Address.City, StringComparison.Ordinal);
                    Assert.IsTrue(comparison <= 0, $"Expected {currentPerson.Address.City} to be before {nextPerson.Address.City} in the list");
                    if (comparison == 0)
                    {
                        comparison = string.Compare(currentPerson.Address.Zip, nextPerson.Address.Zip, StringComparison.Ordinal);
                        Assert.IsTrue(comparison <= 0, $"Expected {currentPerson.Address.Zip} to be before {nextPerson.Address.Zip} in the list");
                    }
                }
            }
        }

    }

}