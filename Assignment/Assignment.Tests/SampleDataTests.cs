using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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
            "Washington",
            "Georgia",
            "Virginia",
            "South Carolina",
            "North Carolina",
        };
        SampleData data = new SampleData { CsvRows = addresses };

        // Act
        List<string> expected = addresses.Distinct().ToList();
        expected.Sort();
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
        Assert.AreEqual(expected, actual);
    }
}
