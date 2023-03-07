using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    readonly SampleData sample = new();
    [TestMethod]
    public void CsvRowsCountTest()
    {
        int act = sample.CsvRows.Count();
        int exp = 50;
        Assert.AreEqual<int>(exp, act);
    }
    [TestMethod]
    public void CsvRowsFirstLineTest()
    {
        string act = sample.CsvRows.First();
        string exp = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";
        Assert.AreEqual<string>(exp, act);
    }
    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_HardcodedTest()
    {
        //TODO: Figure out what's going wrong here
        string[] act = sample.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
        string[] exp = { "AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC", 
            "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV" };
        Assert.AreEqual<string[]>(exp, act);
    }
    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_NotHardcodedTest()
    {
        IEnumerable<string> states = sample.GetUniqueSortedListOfStatesGivenCsvRows();
        foreach(string state in states)
        {
            states = states.Skip(1);
            Assert.IsFalse(states.Contains(state));
        }
    }
    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_StringTest()
    {
        string[] states = { "AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC",
            "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV" };
        string exp = string.Join(",", states);
        string act = sample.GetAggregateSortedListOfStatesUsingCsvRows();
        Assert.AreEqual<string>(exp, act);
    }
    [TestMethod]
    public void People_CsvRowsTest()
    {
        IEnumerable<string> rows = sample.CsvRows.OrderBy((row) => row.Split(",")[6]).ThenBy((row) => row.Split(",")[5]).ThenBy((row) => row.Split(",")[7]);
        IEnumerable<IPerson> people = sample.People;
        foreach (string row in rows)
        {
            Assert.AreEqual<string>(people.First().FirstName, row.Split(',')[1]);
            Assert.AreEqual<string>(people.First().LastName, row.Split(',')[2]);
            Assert.AreEqual<string>(people.First().EmailAddress, row.Split(',')[3]);
            Assert.AreEqual<string>(people.First().Address.StreetAddress, row.Split(',')[4]);
            Assert.AreEqual<string>(people.First().Address.City, row.Split(',')[5]);
            Assert.AreEqual<string>(people.First().Address.State, row.Split(',')[6]);
            Assert.AreEqual<string>(people.First().Address.Zip, row.Split(',')[7]);
            people = people.Skip(1);
        }
    }
    [TestMethod]
    public void FilterByEmailAddress_Test()
    {
        //TODO: Figure out how to test this adequately
    }
    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_MainTest()
    {
        string[] states = sample.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
        string exp = string.Join(", ", states);
        string act = sample.GetAggregateListOfStatesGivenPeopleCollection(sample.People);
        Assert.AreEqual<string>(exp, act);
    }
}
