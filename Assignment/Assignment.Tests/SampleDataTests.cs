using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Assignment.Tests
{
	[TestClass]
	public class SampleDataTests
	{
        private readonly SampleData _data = new("./People.csv");
        private readonly SampleData _dataSpokane = new("./spokaneaddresses.csv");

        [TestMethod]
		public void SampleData_ReadCSV_Success()
		{
			SampleData sampleData = _data;
            SampleData spokaneData = _dataSpokane;

            Assert.IsNotNull(sampleData);
            Assert.IsNotNull(spokaneData);

        }
        [TestMethod]
        public void SampleData_SkipsFirstLine_Success()
        {
            SampleData sampleData = _data;

            int actual = sampleData.CsvRows.Count();
            int expected = 50;
            Assert.AreEqual<int>(expected, actual);
        }
        [TestMethod]
        public void SampleData_FillListCsvRows_Success()
        {

            SampleData sampleData = _data;

            var people = sampleData.People;

            Assert.AreEqual(50, people.Count());
        }
        [TestMethod]
		public void SampleData_GetUniqueSortedListOfStates_Success()
		{
            SampleData sampleData = _data;

            IEnumerable<string> state = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

			Assert.AreEqual<string>("AL", state.First());
			Assert.AreEqual<string>("WV", state.Last());

        }
        [TestMethod]
        public void SampleData_GetUniqueStatesSpokaneAddresses_Success()
        {
            SampleData sampleData = _dataSpokane;
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            int actual = 1;
            int expected = states.Count();
            Assert.AreEqual<int>(expected, actual);
        }
        [TestMethod]
        public void SampleData_GetUniqueSortedListUsingCsvRows_Success()
        {
            SampleData sampleData = _data;
            IEnumerable<string> uniqueSortedListOfStates = _data.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.AreEqual<int>(27, uniqueSortedListOfStates.Count());
        }

        [TestMethod]
        public void SampleData_ReturnsCorrectCountAndPeople_Success()
        { 
            SampleData sampleData = _data;

            var people = sampleData.People;

            Assert.AreEqual(50, people.Count());
            Assert.IsTrue(people.All(p => p is Person));
        }
        [TestMethod]
        public void SampleData_GetAggregatedListOfStates_Success()
        {
            SampleData sampleData = _data;

            IEnumerable<IPerson> people = sampleData.People;

            string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void FilterByEmailAddress()
        {
            SampleData sampleData = _data;

            var email = sampleData.FilterByEmailAddress(email => email == "cstennine2@wired.com");
            var value = email as (string FirstName, string LastName)[] ?? email.ToArray();

            foreach (var person in value)
            {
                Assert.IsTrue(person.FirstName == "Chadd");
            }

            Assert.AreEqual(1, value.Count());
        }
        [TestMethod]
        public void People_ReturnsValidListOfIPerson()
        {
            SampleData data = new("./People.csv");
            IEnumerable<string> rowsOrdered = data.CsvRows
                .OrderBy(row => row.Split(',')[6])
                .ThenBy(row => row.Split(',')[5])
                .ThenBy(row => row.Split(',')[7]);
            IEnumerable<IPerson> people = data.People;

            var zip = rowsOrdered.Zip(people, (row, person) =>
            {
                string[] split = row.Split(",");
                Assert.AreEqual(split[1], person.FirstName);
                Assert.AreEqual(split[2], person.LastName);
                Assert.AreEqual(split[3], person.EmailAddress);
                Assert.AreEqual(split[4], person.Address.StreetAddress);
                Assert.AreEqual(split[5], person.Address.City);
                Assert.AreEqual(split[6], person.Address.State);
                Assert.AreEqual(split[7], person.Address.Zip);
                return true;
            });

            Assert.AreEqual(rowsOrdered.Count(), zip.Count());
        }
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_IsSorted()
        {
            SampleData data = new SampleData("./People.csv");

            IEnumerable<string> states = data.GetUniqueSortedListOfStatesGivenCsvRows();
            List<string> sortedStates = states.OrderBy(s => s).ToList();

            CollectionAssert.AreEqual(sortedStates, (System.Collections.ICollection)states);
        }

    }
}

