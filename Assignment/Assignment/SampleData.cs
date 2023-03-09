using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Assignment;

public class SampleData : ISampleData
{
    // 1.
    public IEnumerable<string> CsvRows
        => File.ReadAllLines("People.csv").Skip(1);

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows
            .Select(row => row.Split(',')[6])
            .Distinct()
            .OrderBy(state => state);
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        return string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());
    }

    // 4.
    public IEnumerable<IPerson> People => CsvRows
        .OrderBy(x => x.Split(",")[6])
        .ThenBy(x => x.Split(",")[5])
        .ThenBy(x => x.Split(",")[7])
        .Select(ParsePersonFromRow);

    public static Person ParsePersonFromRow(string row)
    {
        string[] attributes = row.Split(',');
        Address address = new(attributes[4].Trim(), attributes[5].Trim(), attributes[6].Trim(), attributes[7].Trim());

        return new Person(attributes[1].Trim(), attributes[2].Trim(), address, attributes[3].Trim());
    }

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
        Predicate<string> filter) 
    {
        List<IPerson> matches = People.Where(x => filter(x.EmailAddress)).ToList();
        List<(string, string)> nameList = new();
        foreach (IPerson item in matches)
        {
            nameList.Add((item.FirstName, item.LastName));
        }
        return nameList;
    }

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people)
    {
        List<string> states = new();
        foreach (IPerson item in people)
        {
            states.Add(item.Address.State);
        }
        states = states.Distinct().ToList();
        return states.Aggregate((x, y) => x + "," + y);
    }
}