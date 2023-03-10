using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment.Tests
{
    [TestClass]
    public class Tests
    {
        public class SampleDataTest : SampleData
        {
            public override IEnumerable<string> CsvRows
            {
                get
                {
                    return new string[] { "1,Priscilla,Jenyns,pjenyns0@state.gov,3205 S University Rd #73,Spokane,WA,99206", "2,Karin,Joder,kjoder1@quantcast.com,3214 E Congress Ave,Spokane,WA,99223", "3,Chadd,Stennine,cstennine2@wired.com,3315 W Queen Pl,Spokane,WA,99205", "4,Fremont,Pallaske,fpallaske3@umich.edu,3317 E Jackson Ave,Spokane,WA,99217", "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,3324 S Arthur St,Spokane,WA,99203", "6,Darline,Brauner,dbrauner5@biglobe.ne.jp,3406 E Empire Ave,Spokane,WA,99217", "7,Issiah,Bester,ibester6@psu.edu,2811 S Fiske St,Spokane,WA,99223", "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,2833 W Beacon Ave,Spokane,WA,99208", "9,Swen,Mulvany,smulvany8@surveymonkey.com,3016 E 5th Ave,Spokane,WA,99202", "10,Scarface,Dennington,sdennington9@chron.com,3711 E 32nd Ave,Spokane,WA,99223" };
                }
            }
        }

        [TestMethod]
        public void CsvRows_ReturnsExpectedRows()
        {
            // Arrange
            SampleDataTest sample = new SampleDataTest();
            string[] expectedRows = new string[]
            {
                "1,Priscilla,Jenyns,pjenyns0@state.gov,3205 S University Rd #73,Spokane,WA,99206",
                "2,Karin,Joder,kjoder1@quantcast.com,3214 E Congress Ave,Spokane,WA,99223",
                "3,Chadd,Stennine,cstennine2@wired.com,3315 W Queen Pl,Spokane,WA,99205",
                "4,Fremont,Pallaske,fpallaske3@umich.edu,3317 E Jackson Ave,Spokane,WA,99217",
                "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,3324 S Arthur St,Spokane,WA,99203",
                "6,Darline,Brauner,dbrauner5@biglobe.ne.jp,3406 E Empire Ave,Spokane,WA,99217",
                "7,Issiah,Bester,ibester6@psu.edu,2811 S Fiske St,Spokane,WA,99223",
                "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,2833 W Beacon Ave,Spokane,WA,99208",
                "9,Swen,Mulvany,smulvany8@surveymonkey.com,3016 E 5th Ave,Spokane,WA,99202",
                "10,Scarface,Dennington,sdennington9@chron.com,3711 E 32nd Ave,Spokane,WA,99223"
            };
            IEnumerable<string> actualRows = sample.CsvRows;

            CollectionAssert.AreEqual(expectedRows, actualRows.ToArray());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_Hardcoded_Works()
        {
            SampleDataTest sample = new SampleDataTest();
            string expectedResult = "WA";
            string sampleStates = string.Join(", ", sample.GetUniqueSortedListOfStatesGivenCsvRows());

            Assert.AreEqual(expectedResult, sampleStates);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_NonHarcoded_Works()
        {
            SampleData sample = new SampleData();
            Assert.AreEqual(string.Join(", ", sample.GetUniqueSortedListOfStatesGivenCsvRows()), string.Join(", ", sample.GetUniqueSortedListOfStatesGivenCsvRows().OrderBy(state => state).ToList()));
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_Works()
        {
            //SampleData sample = new SampleData();
            //Assert.AreEqual(string.Join(", ", sample.GetUniqueSortedListOfStatesGivenCsvRows()), sample.GetAggregateListOfStatesGivenPeopleCollection(sample.People));

            var sample = new SampleData();
            var people = new List<IPerson>
            {
                new Person("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "jdoe@example.com"),
                new Person("Jane", "Doe", new Address("456 Elm St", "Othertown", "NY", "67890"), "jane@example.com"),
                new Person("Bob", "Smith", new Address("789 Oak St", "AnotherTown", "TX", "09876"), "bob@example.com"),
                new Person("Alice", "Jones", new Address("456 Pine St", "YetAnotherTown", "CA", "54321"), "alice@example.com"),
            };

            var result = sample.GetAggregateListOfStatesGivenPeopleCollection(people);

            var expectedStates = new[] { "CA", "NY", "TX" }.OrderBy(s => s).ToList();
            CollectionAssert.AreEqual(expectedStates, result.Split(", "));
        }


    }
}
