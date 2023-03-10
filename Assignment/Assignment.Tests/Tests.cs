global using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class Tests
{
    [TestMethod]
    public void CsvRowsSkipsFirstLine()
    {
        SampleData sampleData = new();
        Assert.AreEqual<string>(sampleData.CsvRows.First(),
            "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577");
    }

    [TestMethod]
    public void GetUniqueStateSortedRowsViaHardcode()
    {
        List<string> data = new()
        {
            "AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY",
            "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV"
        };
        List<string> sampleData = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        foreach (int i in Enumerable.Range(0, sampleData.Count)) Assert.AreEqual(data[i], sampleData[i]);
    }

    [TestMethod]
    public void GetUniqueStateSortedRowsViaLinq()
    {
        List<string> sampleData = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        List<string> data = new SampleData().CsvRows.Select(x => x.Split(',')[6]).Order().Distinct().ToList();
        foreach (int i in Enumerable.Range(0, sampleData.Count)) Assert.AreEqual(sampleData[i], data[i]);
    }

    [TestMethod]
    public void GetCommaSeperatedListOfStatesViaHardcode()
    {
        string data = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
        Assert.AreEqual(data, new SampleData().GetAggregateSortedListOfStatesUsingCsvRows());
    }
}