using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_ReturnsRows()
        {
            SampleData sample = new();
            IEnumerable<string> rows = sample.CsvRows;
            Assert.AreEqual<int>(50, rows.Count());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsList()
        {
            string[] testData =
            {
                "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022",
                "15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021",
                "19,Fayette,Dougherty,fdoughertyi@stanford.edu,6487 Pepper Wood Court,Spokane,WA,99021"
            };
            SampleData sample = new()
            {
                CsvRows = testData
            };
            IEnumerable<string> uniqueSortedStates = sample.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> expected = new List<string>() { "WA" };
            Assert.AreEqual<int>(expected.Count(), uniqueSortedStates.Count());
            Assert.AreEqual<string>(expected.First(), uniqueSortedStates.First());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_VerifyCorrect()
        {
            SampleData sample = new();
            IEnumerable<string> uniqueStates = sample.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsFalse(uniqueStates.Zip(uniqueStates.Skip(1), (first, second) => first.CompareTo(second)).Any(x => x > 0));
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsAggregateList()
        {
            SampleData sample = new();
            IEnumerable<string> uniqueStates = sample.GetUniqueSortedListOfStatesGivenCsvRows();
            string[] statesArray = uniqueStates.ToArray();
            string expectedStates = String.Join(",", statesArray);
            Assert.AreEqual<string>(sample.GetAggregateSortedListOfStatesUsingCsvRows(), expectedStates);
        }
    }
}