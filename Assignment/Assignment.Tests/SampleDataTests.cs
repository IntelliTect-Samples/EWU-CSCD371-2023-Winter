using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    private readonly List<string> hardCodedCSVList = new()
    {
        "1,Priscilla,Jenyns,pjenyns0@state.gov,542 W 27th St,New York,NY,10001",
        "2,Karin,Joder,kjoder1@quantcast.com,181 Fremont St,San Francisco,CA,94105",
        "3,Chadd,Stennine,cstennine2@wired.com,55 E Jackson Blvd,Chicago,IL,60604",
        "4,Fremont,Pallaske,fpallaske3@state.gov,16958 Forster Crossing,Atlanta,AL,10687",
        "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,233 S Wacker Dr,Chicago,IL,60606",
        "6,Darline,Brauner,dbrauner5@biglobe.ne.jp,333 S Hope St,Los Angeles,CA,90071"
    };

    private bool IsEqual((string expected, string actual) args) => args.expected.Equals(args.actual);

    [TestMethod]
    public void CsvRows_GivenCSV_ReadsAllValidRows()
    {
        // Arrange
        SampleData data = new() { CsvRows = hardCodedCSVList };

        // Assert
        Assert.AreEqual<int>(hardCodedCSVList.Count, data.CsvRows.Count());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodedList_Success()
    {
        // Arrange
        SampleData data = new() { CsvRows = hardCodedCSVList };
        List<string> expected = new() { "AL", "CA", "IL", "NY" };

        // Act
        IEnumerable<string> actual = data.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        Assert.AreEqual<int>(expected.Count, expected.Zip(actual).Where(IsEqual).Count());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_Success()
    {
        // Arrange
        SampleData data = new();
        IEnumerable<string> expected = data.CsvRows.Select(item => item.Split(",")[6]).Distinct().OrderBy(state => state);

        // Act
        IEnumerable<string> actual = data.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        Assert.AreEqual<int>(expected.Count(), expected.Zip(actual).Where(IsEqual).Count());
    }


    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_Success()
    {
        // Arrange
        SampleData data = new() { CsvRows = hardCodedCSVList };
        string expected = "AL,CA,IL,NY";

        // Act
        string actual = data.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        Assert.AreEqual<string>(expected, actual);
    }

    [TestMethod]
    public void People_GivenCSVList_CreatesPeople()
    {
        // Arrange
        SampleData data = new() { CsvRows = hardCodedCSVList };

        // Assert
        Assert.AreEqual<int>(6, data.People.Count());
        Assert.AreEqual<string>("Fremont", data.People.First().FirstName);
        Assert.AreEqual<string>("Pallaske", data.People.First().LastName);
        Assert.AreEqual<string>("fpallaske3@state.gov", data.People.First().EmailAddress);
        Assert.AreEqual<string>("AL", data.People.First().Address.State);
        Assert.AreEqual<string>("Atlanta", data.People.First().Address.City);
        Assert.AreEqual<string>("16958 Forster Crossing", data.People.First().Address.StreetAddress);
    }

    [TestMethod]
    public void FilterByEmailAdreess_GivenFilter_ReturnsFiltered()
    {
        // Arrange
        SampleData data = new() { CsvRows = hardCodedCSVList };
        List<string> expected = new() { "Fremont Pallaske", "Priscilla Jenyns" };

        // Act
        IEnumerable<string> actual = data.FilterByEmailAddress(EmailFilter).Select(person => $"{person.FirstName} {person.LastName}");

        // Assert
        static bool EmailFilter(string value) => value.Contains(".gov");
        Assert.AreEqual<int>(expected.Count, expected.Zip(actual).Where(IsEqual).Count());
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_GivenCsvRows_Success()
    {
        // Arrange
        SampleData data = new();

        // Act
        string expected = data.GetUniqueSortedListOfStatesGivenCsvRows().Aggregate((accumulator, states) => $"{accumulator},{states}");
        string actual = data.GetAggregateListOfStatesGivenPeopleCollection(data.People);

        // Assert
        Assert.AreEqual<string>(expected, actual);
    }
}