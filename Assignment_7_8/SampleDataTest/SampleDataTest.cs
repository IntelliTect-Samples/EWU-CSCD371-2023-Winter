using ClassLibrary;
using InterfaceLibrary;

namespace SampleDataTest;

[TestClass]
public class SampleDataTest
{
    private List<string> newList = new()
    {
        "1,Isabella,Johnson,ijohnson6@amazon.com,1275 Kinnear Rd,Columbus,OH,43212",
        "2,Bryce,Miller,bmiller7@twitter.com,1600 Amphitheatre Pkwy,Mountain View,CA,94043",
        "3,Aiden,Roberts,aroberts8@yelp.com,123 Main St,Philadelphia,PA,19103",
        "4,Abigail,Lee,alee9@google.com,1600 Pennsylvania Ave NW,Washington,DC,20500"
    };

    [TestMethod]
    public void TestCsvRows()
    {
        // Arrange
        ISampleData sampleData = new SampleData();

        // Act
        var rows = sampleData.CsvRows.ToArray();

        // Assert
        Assert.AreEqual(50, rows.Length); // expect 50 rows (excluding header)
        Assert.IsFalse(rows.Contains("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip")); // expect skipped header row
    }

    [TestMethod]
    public void TestUniqueSortedListOfStates()
    {
        // Arrange
        ISampleData sampleData = new SampleData();

        // Act
        var states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();

        // Assert
        Assert.IsTrue(states.SequenceEqual(states.OrderBy(s => s))); // expect the list to be sorted alphabetically
    }

    [TestMethod]
    public void AggregateSortedList()
    {
        // Arrange
        ISampleData sampleData = new SampleData();
        string expected = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";

        // Act
        string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        Assert.AreEqual<string>(expected, actual);
    }

    [TestMethod]
    public void TestPeopleSortedByStateCityZip()
    {
        // Arrange
        var sampleData = new SampleData();
        var expectedZips = sampleData.GetSortedListOfZipsGivenCsvRows().ToArray();
        var expectedCity = sampleData.GetSortedListOfCitiesGivenCsvRows().ToArray();
        var expectedStates = sampleData.GetSortedListOfStatesGivenCsvRows().ToArray();


        // Act
        var people = sampleData.People.ToList();

        var sortedPeople_ByZip = people.OrderBy(person => person.Address.Zip).ToArray();
        var sortedPeople_ByCity = people.OrderBy(person => person.Address.City).ToArray();
        var sortedPeople_ByState = people.OrderBy(person => person.Address.State).ToArray();



        // Assert
        for (int i = 0; i < people.Count; i++)
        {
            Assert.AreEqual(expectedZips[i], sortedPeople_ByZip[i].Address.Zip);
            Assert.AreEqual(expectedCity[i], sortedPeople_ByCity[i].Address.City);
            Assert.AreEqual(expectedStates[i], sortedPeople_ByState[i].Address.State);
        }
    }

    [TestMethod]
    public void TestFilterByEmailAddress()
    {
        // Arrange
        var sampleData = new SampleData();
        var expectedNames = new[] { "Sancho Mahony", "Fayette Dougherty" };

        // Act
        var names = sampleData.FilterByEmailAddress(email => email.EndsWith("@stanford.edu")).ToList();

        // Assert
        for (int i = 0; i < names.Count; i++)
        {
            Assert.AreEqual(expectedNames[i], names[i]);
        }
    }

    [TestMethod]
    public void TestGetAggregateListOfStatesGivenPeopleCollection()
    {
        // Arrange
        var sampleData = new SampleData();
        var expectedStateList = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().OrderBy(state => state).ToList();
        var people = sampleData.People.ToList();

        // Act
        var stateList = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people).Split(',').OrderBy(state => state).ToList();

        // Assert
        for (int i = 0; i < stateList.Count; i++)
        {
            Assert.AreEqual(stateList[i], expectedStateList[i]);
        }
    }


}