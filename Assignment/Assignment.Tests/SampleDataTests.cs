using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void SampleDataTest()
        {
            SampleData sampleData = new SampleData();
            Assert.IsNotNull(sampleData);
            Assert.AreEqual<int>(50, sampleData.CsvRows.Count());
            Assert.AreEqual<string>("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", sampleData.CsvRows.First());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRowsTest()
        {
            string expectedStates = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            SampleData sampleData = new SampleData();
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsNotNull(states);
            Assert.AreEqual<int>(27, states.Count());
            // Use hardcoded list to verify result
            Assert.AreEqual<string>(expectedStates, string.Join(",", states));

            // uses LINQ to verify the data is sorted correctly (do not use a hardcoded list)
            IEnumerable<string> sortedStates = states.OrderBy(x => x);
            Assert.AreEqual<string>(string.Join(",", sortedStates), string.Join(",", states));
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRowsTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void FilterByEmailAddressTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollectionTest()
        {
            Assert.Fail();
        }
    }
}