using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {

        [TestMethod]
        public void CsvRows_GetsAllRows_Success()
        {
            SampleData data = new();

            Assert.AreEqual<int>(50, data.CsvRows.Count());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodedList_Success()
        {

            SampleData hardCodedList = new()
            {
                CsvRows = new List<string> {
                "1,First,Last,example@example.com,542 W 27th St,New York,NY,10001",
                "1,First,Last,example@example.com,181 Fremont St,San Francisco,CA,94105",
                "1,First,Last,example@example.com,55 E Jackson Blvd,Chicago,IL,60604",
                "1,First,Last,example@example.com,233 S Wacker Dr,Chicago,IL,60606",
                "1,First,Last,example@example.com,333 S Hope St,Los Angeles,CA,90071"
                }
            };

            List<string> expected = new() { "CA", "IL", "NY" };
            bool isEqual = true;

            List<string> actual = new();

            foreach (string state in hardCodedList.GetUniqueSortedListOfStatesGivenCsvRows())
            {
                actual.Add(state);
            }

            for (int i = 0, j = 0; i < expected.Count && j < actual.Count; i++, j++)
            {
                if (expected[i] != actual[j]) isEqual = false;
            }

            Assert.IsTrue(isEqual);

        }

        // Not Finished **** 

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_Success()
        {
            SampleData data = new();
            foreach (string state in data.GetUniqueSortedListOfStatesGivenCsvRows())
            {
                Console.WriteLine(state);
            }

            Assert.AreEqual<int>(27, data.GetUniqueSortedListOfStatesGivenCsvRows().Count());
        }
    }



}