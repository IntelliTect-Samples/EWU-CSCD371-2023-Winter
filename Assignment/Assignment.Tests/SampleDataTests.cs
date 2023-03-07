using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{

    [TestMethod]
    public void CsvRows_GivenCSV_ReadsAllValidRows()
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
        IEnumerable<string> actual = hardCodedList.GetUniqueSortedListOfStatesGivenCsvRows();

        static bool ValidateTuple((string First, string Second) tuple) => tuple.First.Equals(tuple.Second);
        Assert.AreEqual<int>(expected.Count, expected.Zip(actual).Where(ValidateTuple).Count());

    }

    // Not Finished **** 

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_Success()
    {
        // Arrange
        SampleData data = new();

        // Act
        IEnumerable<string> expected = data.CsvRows.Select(item => item.Split(",")[6]).Distinct().OrderBy(state => state);
        IEnumerable<string> actual = data.GetUniqueSortedListOfStatesGivenCsvRows();
        static bool ValidateTuple((string First, string Second) tuple) => tuple.First.Equals(tuple.Second);

        // Assert
        Assert.AreEqual<int>(expected.Count(), expected.Zip(actual).Where(ValidateTuple).Count());
    }


    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_Success()
    {
        SampleData data = new();
        Console.WriteLine(data.GetAggregateSortedListOfStatesUsingCsvRows());

        // TODO
    }

    [TestMethod]
    public void People_GivenCSVList_CreatesPeople()
    {
        // Arrange
        SampleData data = new();

        // Assert
        Assert.AreEqual<int>(50, data.People.Count());
    }

    [TestMethod]
    public void FilterByEmailAdreess_GivenFilter_ReturnsFiltered()
    {
        SampleData data = new()
        {
            CsvRows = new List<string> {
                "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Atlanta,AL,70577",
                "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Atlanta,AL,71961",
                "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Atlanta,AL,59721",
                "4,Fremont,Pallaske,fpallaske3@state.gov,16958 Forster Crossing,Atlanta,AL,10687",
                "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,283 Pawling Parkway,Atlanta,AL,88632",
                "6,Darline,Brauner,dbrauner5@biglobe.ne.jp,33 Menomonie Trail,Atlanta,AL,10687"
            }
        };
        List<string> expected = new() { "Fremont Pallaske", "Priscilla Jenyns" };

        static bool EmailFilter(string value) => value.Contains(".gov");            
        IEnumerable<string> actual = data.FilterByEmailAddress(EmailFilter).Select(person => $"{person.FirstName} {person.LastName}");

        static bool ValidateTuple((string Expected, string Actual) tuple) => tuple.Expected.Equals(tuple.Actual);
        Assert.AreEqual<int>(expected.Count, expected.Zip(actual).Where(ValidateTuple).Count());
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