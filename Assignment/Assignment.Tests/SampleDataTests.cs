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
            Assert.AreEqual(27, states.Count());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_MakesDistinctSortedList_PrintsAllStatesToTestConsole()
        {
            //Arrange
            SampleData data = new();

            //Act
            IEnumerable<string> states = data.GetUniqueSortedListOfStatesGivenCsvRows();
            foreach (string state in states)
            {
                Console.WriteLine(state);
            }

            //Assert
        }
    }
}