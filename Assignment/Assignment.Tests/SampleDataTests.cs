using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_ReadsFileAndSkipsFirstRow_CountReturns50()
        {
            //Arrange
            SampleData data = new();

            //Act
            
            //Assert
            Assert.AreEqual<int>(50, data.CsvRows.Count());
        }

        [TestMethod]
        public void CsvRows_ReadsFileAndSkipsFirstRow_PrintsAllPeopleToTestConsole()
        {
            //Arrange
            SampleData data = new();

            //Act
            foreach(string item in data.CsvRows)
            {
                Console.WriteLine(item);
            }

            //Assert
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_MakesDistinctSortedList_CountReturns27()
        {
            //Arrange
            SampleData data = new();

            //Act
            IEnumerable<string> states = data.GetUniqueSortedListOfStatesGivenCsvRows();

            //Assert
            Assert.AreEqual<int>(27, states.Count());
        }

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

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_MakesSingleStringOfDistinctStates_PrintsStringToConsole()
        {
            //Arrange
            SampleData data = new();

            //Act
            string expected = data.GetUniqueSortedListOfStatesGivenCsvRows().Aggregate((a, b) => a + ", " + b); ;
            string states = data.GetAggregateSortedListOfStatesUsingCsvRows();
            Console.WriteLine(states);

            //Assert
            Assert.AreEqual<string>(expected, states);
        }

        [TestMethod]
        public void People_MakesListOfPeopleSortedByStateCityZip_PrintsListToConsole()
        {
            //Arrange
            SampleData data = new();

            //Act
            foreach(IPerson person in data.People) 
            {
                Console.WriteLine(person.ToString());      
            }

            //Assert
            Assert.AreEqual<int>(50, data.People.Count());
        }

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