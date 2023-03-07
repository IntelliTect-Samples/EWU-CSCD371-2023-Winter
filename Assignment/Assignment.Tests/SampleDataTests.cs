using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
            SampleData sampleData = new SampleData();
            string statesCSVList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            IEnumerable<string> sortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().OrderBy(x => x);
            Assert.AreEqual<string>(string.Join(",", sortedStates), statesCSVList);
        }

        [TestMethod]
        public void FilterByEmailAddressTest()
        {
            SampleData sampleData = new SampleData();
            var result = sampleData.FilterByEmailAddress(x => x.Equals("dcroserc@reverbnation.com"));
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(1, result.Count());

            var names = result.First();
            Assert.AreEqual<string>("Daile", names.FirstName);
            Assert.AreEqual<string>("Croser", names.LastName);
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollectionTest()
        {
            SampleData sampleData = new SampleData();
            // Test only people with first name starting with 'A'
            string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People.Where(p => p.FirstName.StartsWith('A')));
            Assert.AreEqual<string>("AL,PA,UT,WV", result);
        }
    }
}