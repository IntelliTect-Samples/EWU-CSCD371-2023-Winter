
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTest
{

    [TestMethod]
    public void CsvRows_SkipsFirstLine()
    {
        SampleData data = new ("./People.csv");

        int actual = data.CsvRows.Count();
        int expected = 50;
        Assert.AreEqual<int>(expected, actual);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_IsUniqueStates()
    {
        SampleData data = new("./SpokaneAddresses.csv");
        IEnumerable<string> states = data.GetUniqueSortedListOfStatesGivenCsvRows();
        
        int actual = 1;
        int expected = states.Count();
        Assert.AreEqual<int>(expected, actual);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_IsUniqueStates_Alternative()
    {
        SampleData data = new("./People.csv");
        IEnumerable<string> states = data.GetUniqueSortedListOfStatesGivenCsvRows();
        HashSet<string> hash = states.ToHashSet();

        int expected = hash.Count;
        int actual = states.Count();

        Assert.AreEqual<int>(expected, actual);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_IsSorted()
    {
        SampleData data = new("./People.csv");
        IEnumerable<string> states = data.GetUniqueSortedListOfStatesGivenCsvRows();

        IEnumerable<bool> offsetComparisons = states.Zip(states.Skip(1), (current, next) => current.CompareTo(next) <= 0);
        bool isSorted = offsetComparisons.All(comparison => comparison == true);
        Assert.IsTrue(isSorted);
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
    public void FilterByEmail_Exact_FirstNameIsPriscilla()
    {
        SampleData data = new("./People.csv");
        var people = data.FilterByEmailAddress(email => email == "pjenyns0@state.gov");
        foreach (var person in people)
        {
            Assert.IsTrue(person.FirstName == "Priscilla");
        }

        Assert.AreEqual<int>(1, people.Count());
    }

    [TestMethod]
    public void FilterByEmail_DotEdu_Count5()
    {
        SampleData data = new("./People.csv");
        var people = data.FilterByEmailAddress(email => email.ToLower().Contains(".edu"));

        int expected = 5;
        int actual = people.Count();

        Assert.AreEqual<int>(expected, actual);
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection()
    {
        SampleData data = new("./People.csv");

        var expected = data.GetAggregateSortedListOfStatesUsingCsvRows();
        var actual = data.GetAggregateListOfStatesGivenPeopleCollection(data.People);

        Assert.AreEqual(expected, actual);
    }
}
