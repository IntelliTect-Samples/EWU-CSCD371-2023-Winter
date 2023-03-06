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

        [TestMethod]
		public void SampleData_ReadCSV_Success()
		{
			SampleData sampleData = _data;

			Assert.IsNotNull(sampleData);

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
        public void SampleData_HardCodedAddresses_Success()
		{

			List<Address> addresses = new()
			{ 
			new Address("9431 Lotheville Pass", "Washington", "WA", "73484"),
			new Address("662 Rutledge Point", "Spokane", "WA", "99021"),
			new Address("554 Forster Lane", "Lincoln", "NE", "40053"),
            };

			IEnumerable<Address> state = addresses.DistinctBy(address => address.State);
            IEnumerable<Address> zip = addresses.DistinctBy(address => address.Zip);
            IEnumerable<Address> streetAddress = addresses.DistinctBy(address => address.StreetAddress);


            Assert.AreEqual<string>("WA", addresses.ElementAt(0).State);
			Assert.AreEqual <string> ("WA", addresses.ElementAt(1).State);
            Assert.AreEqual<string>("NE", addresses.ElementAt(2).State);

            Assert.AreEqual<string>("73484", addresses.ElementAt(0).Zip);
            Assert.AreEqual<string>("99021", addresses.ElementAt(1).Zip);
            Assert.AreEqual<string>("40053", addresses.ElementAt(2).Zip);

            Assert.AreEqual<string>("9431 Lotheville Pass", addresses.ElementAt(0).StreetAddress);
            Assert.AreEqual<string>("662 Rutledge Point", addresses.ElementAt(1).StreetAddress);
            Assert.AreEqual<string>("554 Forster Lane", addresses.ElementAt(2).StreetAddress);

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
    }
}

