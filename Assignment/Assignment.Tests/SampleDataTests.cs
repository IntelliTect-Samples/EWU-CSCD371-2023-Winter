using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        // 1.)
        [TestMethod]
        public void CsvRows_ReadsFileAndSkipsFirstRow_CountReturns50()
        {
            //Arrange
            SampleData data = new();

            //Act
            foreach (string item in data.CsvRows)
            {
                Console.WriteLine(item);
            }

            //Assert
            Assert.AreEqual<int>(50, data.CsvRows.Count());
        }

        // 2.)
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_MakesDistinctSortedList_ReturnsTrue()
        {
            //Arrange
            SampleData data = new();

            //Act
            IEnumerable<string> csvRowsTest = data.CsvRows.Select(row => row.Split(',')[6]).OrderBy(item => item).Distinct();
            IEnumerable<string> states = data.GetUniqueSortedListOfStatesGivenCsvRows();

            //Assert
            Assert.AreEqual<int>(27, states.Count());
            Assert.IsTrue(states.SequenceEqual(csvRowsTest));
        }

        // 2.)
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_MakesDistinctSortedList_PrintsAllStatesToTestConsole()
        {
            //Arrange
            SampleData data = new();

            //Act
            string expected = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
            string states = string.Join(", ", data.GetUniqueSortedListOfStatesGivenCsvRows());
            Console.WriteLine(states);

            //Assert
            Assert.AreEqual<string>(expected, states);
        }

        // 3.)
        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_MakesSingleStringOfDistinctStates_PrintsStringToConsole()
        {
            //Arrange
            SampleData data = new();

            //Act
            string expected = data.GetUniqueSortedListOfStatesGivenCsvRows().Aggregate((a, b) => a + ", " + b);
            string states = data.GetAggregateSortedListOfStatesUsingCsvRows();
            Console.WriteLine(states);

            //Assert
            Assert.AreEqual<string>(expected, states);
        }

        // 4.)
        [TestMethod]
        public void People_MakesListOfPeopleSortedByStateCityZip_ReturnsTrue()
        {
            //Arrange
            SampleData data = new();

            //Act
            IEnumerable<string> csvRowsTest = data.CsvRows.OrderBy(item => item.Split(",")[6])
            .ThenBy(item => item.Split(",")[5])
            .ThenBy(item => item.Split(",")[7])
            .Select(row => row.Split(',')[1]);

            foreach(IPerson person in data.People)
            {
                Console.WriteLine(person.ToString());
            }

            //Assert
            Assert.AreEqual<int>(50, data.People.Count());
            Assert.IsTrue(data.People.Select(person => person.FirstName).SequenceEqual(csvRowsTest));
        }

        // 5.)
        [TestMethod]
        public void FilterByEmailAddress_ReturnsFirstAndLastName_ReturnsAreEqual()
        {
            //Arrange
            SampleData data = new();
            IEnumerable<(string firstName, string lastName)> namesAssociatedWithEmailAddress;

            //Act
            namesAssociatedWithEmailAddress = data.FilterByEmailAddress(email => email == "pjenyns0@state.gov");
            (string first, string last) actual = namesAssociatedWithEmailAddress.First();
            (string fn, string ln) expected = ("Priscilla", "Jenyns");

            //Assert
            Assert.AreEqual<(string, string)>(expected, actual);
        }

        // 6.)
        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_MakesSingleStringOfDistinctStates_PrintsToConsole()
        {
            //Arrange
            SampleData data = new();

            //Act
            string expected = data.GetUniqueSortedListOfStatesGivenCsvRows().Aggregate((a,b) => a + ", " + b);
            string states = data.GetAggregateListOfStatesGivenPeopleCollection(data.People);
            Console.WriteLine(states);

            //Assert
            Assert.AreEqual<string>(expected, states);
        }
    }
}