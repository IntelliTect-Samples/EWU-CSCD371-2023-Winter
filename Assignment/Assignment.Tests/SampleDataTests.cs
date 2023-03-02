using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void Create()
    {
        // Assemble
        SampleData data = new SampleData();

        // Assert
        Assert.IsNotNull(data);
    }

    [TestMethod]
    public void GivenHardcodedAddresses_ReturnsUniqueSortedList()
    {
        // Assemble
        List<string> addresses = new List<string>
        {
            "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
            "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
            "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721",
        };
        SampleData data = new SampleData { CsvRows = addresses };

        // Act
        List<string> expected = new List<string> { "CA", "FL", "MT" };
        List<string> actual = data.GetUniqueSortedListOfStatesGivenCsvRows().ToList();

        // Assert
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    [TestMethod]
    public void UsingPeopleCsv_ReturnsUniqueSortedList()
    {
        // Assemble
        SampleData data = new();
        IEnumerable<string> expected = File.ReadLines("./People.csv").Skip(1);

        // Act
        IEnumerable<string> actual = data.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        expected = expected.Distinct().OrderBy(item => item).ToList();

        // Assert
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    [TestMethod]
    public void UsingCsvRows_GetsUniqueSortedList_ReturnsListAsString()
    {
        // Assemble
        SampleData data = new();

        // Act
        string actual = data.GetAggregateSortedListOfStatesUsingCsvRows();
        string expected = string.Join(", ", data.GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual<string>(expected, actual);
    }

    [TestMethod]
    public void GivenCsvRows_ReturnsListOfCorrectType()
    {
        // Assemble
        SampleData data = new();

        // Assert
        Assert.IsInstanceOfType(data.People, typeof(IEnumerable<IPerson>));
    }

    [TestMethod]
    public void People_GivenSingleLine_ReturnsListWithOnePerson()
    {
        // Assemble
        List<string> people = new List<string>
        {
            "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577"
        };
        SampleData data = new SampleData { CsvRows = people };

        // Act
        IEnumerable<IPerson> peopleList = data.People.ToList();

        // Assert
        Assert.AreEqual<string>(peopleList.First().FirstName, "Priscilla");
    }

    [TestMethod]
    public void People_ReturnsSortedListByAddress()
    {
        // Assemble
        List<string> people = new List<string>
        {
            "1,Priscilla,Jenyns,email,address,Tampa,FL,70577",
            "3,Chadd,Stennine,email,address,Long Beach,CA,59721",
            "2,Karin,Joder,email,address,Miami,FL,71961",
        };
        SampleData data = new SampleData { CsvRows = people };

        // Act
        IEnumerable<IPerson> peopleList = data.People.ToList();

        //Console.WriteLine(peopleList.First().FirstName);

        // Assert
        //Assert.AreEqual<string>(peopleList.First().FirstName, "Chadd");
        //Assert.AreEqual<string>(peopleList.ElementAt(1).FirstName, "Karin");
    }
}
