using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
namespace Assignment;

[TestClass]
public class SampleDataTests
{
    private string filePath = "People.csv";
    SampleData sampleData = new SampleData();
    [TestMethod]
    public void IEnumerableCsvRows_GetsCSVRows()
    {
        //Arrange
        IEnumerable<string> expected = File.ReadLines(filePath).Skip(1);
       

        //Act
        IEnumerable<string> actual = sampleData.CsvRows;

        //Assert
        Assert.AreEqual<int>(expected.Count(), actual.Count());

        for (int i = 0; i < actual.Count(); i++)
        {
            Assert.AreEqual<string>(actual.ElementAt(i), expected.ElementAt(i));
        }
    }

    [TestMethod]
    public void TestSortedListOfUniqueStatesLINQ()
    {
        //Arrange
        IEnumerable<string> csv = File.ReadLines(filePath).Skip(1);
        IEnumerable<string> expected = csv.Select(row => row.Split(",")[6]).Distinct().ToImmutableSortedSet();
       
        //Act
        IEnumerable<string> actual = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        //Assert
        for (int i = 0; i < actual.Count(); i++)
        {
            Assert.AreEqual<string>(actual.ElementAt(i), expected.ElementAt(i));
        }

    }
    [TestMethod]
    public void TestGetUniqueSortedListOfStatesGivenCsvRows_GivenHardcodedList()
    {
        //Arrange
        List<Address> addresses = new();
        addresses.Add(new Address("12345 E Dude St.", "Spokane", "WA", "99235"));
        addresses.Add(new Address("124", "Boise", "ID", "99943"));
        addresses.Add(new Address("456 Bro Ave", "Seattle", "WA", "89567"));

        List<string> states = new();
        for (int i = 0; i < addresses.Count(); i++) {
            states.Add(addresses[i].State);
        }
        IEnumerable<string> expected = new List<string>() { "ID", "WA" };

        //Act
        IEnumerable<string> statesSorted = states.Distinct().ToImmutableSortedSet();

        //Assert
        for (int i = 0; i < statesSorted.Count(); i++) 
        {
            Assert.AreEqual<string>(statesSorted.ElementAt(i), expected.ElementAt(i));
        }
    }

    [TestMethod]
    public void TestAggregateStateListReturnsProperString()
    {
        //Arrange
        IEnumerable<string> presortedList = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        string expected = string.Join(", ", presortedList);
     
        //Act
        string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
;
        Assert.AreEqual<string>(expected, actual);
    }

    [TestMethod]
    public void ReturnsProperlySortedPeopleList()
    { 
        //Arrange
        IEnumerable<IPerson> actual = sampleData.People;
        List<Person> expected = new();
        expected.Add(new Person("Arthur", "Myles", new Address("4718 Thackeray Pass", "Mobile", "AL", "37308"), "amyles1c@miibeian.gov.cn"));
        expected.Add(new Person("Molly", "Jeannot", new Address("00546 International Alley", "Tucson", "AZ", "94123"), "mjeannotp@google.ca"));
        //Act
        for (int i = 0; i <2; i++)
        {
            Assert.AreEqual<string>(expected.ElementAt(i).FirstName, actual.ElementAt(i).FirstName);
            Assert.AreEqual<string>(expected.ElementAt(i).LastName, actual.ElementAt(i).LastName);
            Assert.AreEqual<string>(expected.ElementAt(i).EmailAddress, actual.ElementAt(i).EmailAddress);
            Assert.AreEqual<string>(expected.ElementAt(i).Address.State, actual.ElementAt(i).Address.State);
            Assert.AreEqual<string>(expected.ElementAt(i).Address.City, actual.ElementAt(i).Address.City);
            Assert.AreEqual<string>(expected.ElementAt(i).Address.Zip, actual.ElementAt(i).Address.Zip);
        }

    }

    [TestMethod]
    public void TestEmailFilterReturnsProperName_GivenExactyEmail()
    {
        //Arrange
        IEnumerable<(string FirstName, string LastName)> people = sampleData.FilterByEmailAddress(email => email == "baspin1a@myspace.com");

        //Act
        Assert.AreEqual<(string, string)>(("Buck", "Aspin"), people.ElementAt(0));
        
    }

    [TestMethod]
    public void TestEmailFilterReturnsProperList_GivenDomain()
    {
        //Arrange
        IEnumerable<(string FirstName, string LastName)> people = sampleData.FilterByEmailAddress(email => email.Contains(".com"));

        //Assert
        Assert.AreEqual<int>(people.Count(), 29);
        
    }

    [TestMethod]
    public void TestStateListGivenPeopleReturnsDistinctList()
    {
        //Arrange
        IEnumerable<IPerson> actual = sampleData.People;

        //Assert
        Assert.AreEqual<string>("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY," +
            " OR, PA, SC, TN, TX, UT, VA, WA, WV", sampleData.GetAggregateListOfStatesGivenPeopleCollection(actual));
    }

}

    
