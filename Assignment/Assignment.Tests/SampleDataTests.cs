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
        Assert.IsTrue(actual.SequenceEqual(expected));
    }
}
