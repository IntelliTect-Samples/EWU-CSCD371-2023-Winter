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

        private readonly SampleData data = new SampleData();

        [TestMethod]
        public void CsvRows_ReturnNotNull()
        {
            Assert.IsNotNull(data.CsvRows);
        }

        [TestMethod]
        public void CsvRows_SkipFirstRow_ReturnCount()
        {
            IEnumerable<string> row = data.CsvRows;
            Assert.AreEqual<int>(50, row.Count());
        }

        [TestMethod]
        public void GetUniqueSortedStates_IsEqual()
        {
            List<string> peoplesAddress = data.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            List<string> spokaneAddress = data.CsvRows.ToList();
            spokaneAddress.Add(",,,,990, 11114 E Sprague AV, Spokane, WA, 99206");
            spokaneAddress.Add(",,,,819 W Riverside Ave, Spokane, WA, 99201");
            List<string> addresses = data.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            Assert.IsTrue(peoplesAddress.SequenceEqual(addresses));
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ToStringSuccess()
        {
            string expected = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            string actual = data.GetAggregateSortedListOfStatesUsingCsvRows();
            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void CreateAddress_NotNull()
        {
            Assert.IsNotNull(data.People.First().Address);
        }

        [TestMethod]
        public void CreatePeople_NotNull()
        {
            Assert.IsNotNull(data.People);
        }

        [TestMethod]
        public void CreatedAddressObject_NotNull()
        {
            Assert.IsNotNull(data.People.First().Address);
        }

        [TestMethod]
        public void PeopleObject_EqualTo_CsvRowsSorted_IsTrue()
        {
            IEnumerable<string> peopleData = data.People
                .Select(attribute => $"{attribute.FirstName},{attribute.LastName},{attribute.EmailAddress},{attribute.Address.StreetAddress}" +
                $",{attribute.Address.City},{attribute.Address.State},{attribute.Address.Zip}");

            IEnumerable<string> sortedList = data.CsvRows.Select(line => line.Split(','))
                .Select(attributes => new {
                    FirstName = attributes[1],
                    LastName = attributes[2],
                    Email = attributes[3],
                    StreetAddress = attributes[4],
                    City = attributes[5],
                    State = attributes[6],
                    ZipCode = attributes[7],
                }).OrderBy(item => item.State).ThenBy(item => item.City).ThenBy(item => item.ZipCode)
                .Select(items => $"{items.FirstName},{items.LastName},{items.Email},{items.StreetAddress}" +
                $",{items.City},{items.State},{items.ZipCode}");
            Assert.IsTrue(peopleData.SequenceEqual(sortedList));
        }

        [TestMethod]
        public void EmailAddress_ReturnFirstLastName()
        {
            Predicate<string> sorting = email;
            static bool email(string email) => email.Contains("pjenyns0@state.gov");
            IEnumerable<(string, string)> result = data.FilterByEmailAddress(sorting);

            var name = ("Priscilla", "Jenyns");
            Assert.AreEqual(name, (result.First().Item1, result.First().Item2));
        }
    }
}
