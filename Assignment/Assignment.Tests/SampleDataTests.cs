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
        addresses.Distinct().ToList().Sort();

        // Assert
        Assert.AreEqual<IEnumerable<string>>(data.GetUniqueSortedListOfStatesGivenCsvRows(), addresses);
    }
}
