using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTest
{
    #pragma warning disable CS8618
    private SampleData sampleData { get; set; }
    #pragma warning restore CS8618

    [TestInitialize]
    public void TestInitialize()
    {
        TestCleanup();
        sampleData = new SampleData();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        sampleData = null !;
    }

    [TestMethod]
    public void SampleData_CountCsvRows_AreEqualIsTrue()
    {
        int expected = 50;
        int actual = sampleData.CsvRows.Count();

        Assert.AreEqual<int>(expected, actual);
    }

    [TestMethod]
    public void SampleData_GetUniqueSortedListOfStatesGivenCsvRows_Hardcoded_AreEqualIsTrue()
    {
        string expected =
            "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
        string actual = string.Join(", ", sampleData.GetUniqueSortedListOfStatesGivenCsvRows());

        Assert.AreEqual<string>(expected, actual);
    }

    [TestMethod]
    public void SampleData_GetUniqueSortedListOfStatesGivenCsvRows_AreEqualIsTrue()
    {
        string actual = string.Join(", ", sampleData.GetUniqueSortedListOfStatesGivenCsvRows());
        string expected = string.Join(", ", sampleData.CsvRows
                                                      .Select(line => line.Split(',')[6])
                                                      .Distinct()
                                                      .OrderBy(state => state));

        Assert.AreEqual<string>(expected, actual);
    }

    [TestMethod]
    public void SampleData_FirstRowOfCsvRowsIsOmitted_IsTrue()
    {
        Assert.IsFalse(sampleData.CsvRows.ElementAt(0)
                       .Contains("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip"));
    }

    [TestMethod]
    public void SampleData_RetrieveFirstRow_AreEqualIsTrue()
    {
        string expected = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";
        string actual = sampleData.CsvRows.ElementAt(0);

        Assert.AreEqual<string>(expected, actual);
    }

    [TestMethod]
    public void SampleData_GetAggregateSortedListOfStatesUsingCsvRows_AreEqualIsTrue()
    {
        string expected =
            "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
        string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        Assert.AreEqual<string>(expected, actual);
    }
    
    [TestMethod]
    public void FilterByEmailAddress_AreEqualIsTrue()
    {
        bool Filter(string s) => s.Contains(".com");
        string expected = "Karin, Joder";
        string notExpected = "Priscilla Jenyns";

        IEnumerable<(string FirstName, string LastName)> filteredList =
            sampleData.FilterByEmailAddress(Filter);

        string data = string.Join(", ", filteredList);

        Assert.IsTrue(data.Contains(expected));
        Assert.IsFalse(data.Contains(notExpected));
    }

    [TestMethod]
    public void GetPeople_AreEqualIsTrue()
    {
        Assert.AreEqual<int>(sampleData.CsvRows.Count(), sampleData.People.Count());
        Assert.IsTrue(sampleData.People.ElementAt(0).GetType() == typeof(Person));
        Person person = (Person)sampleData.People.ElementAt(0);

        bool found = false;
        for (int i = 0; i < sampleData.CsvRows.Count(); i++)
        {
            if (sampleData.CsvRows.ElementAt(i).Contains(person.FirstName) &&
                sampleData.CsvRows.ElementAt(i).Contains(person.LastName))
            {
                found = true;
                break;
            }
        }
        Assert.IsTrue(found);
    }

    [TestMethod]
    public void SampleDataTest_GetAggregateListOfStatesGivenPeopleCollection_AreEqualIsTrue()
    {
        string expected = string.Join(", ", sampleData.GetUniqueSortedListOfStatesGivenCsvRows());
        string actual = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

        Assert.AreEqual<string>(expected, actual);
    }
}
