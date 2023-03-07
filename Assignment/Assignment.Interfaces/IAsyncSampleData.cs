using System;
using System.Collections.Generic;

namespace Assignment;

public interface IAsyncSampleData
{
    // 1.
    IAsyncEnumerable<string> CsvRows { get; }
    
    // 2.
    IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows();

    // 3.
    string GetAggregateSortedListOfStatesUsingCsvRows();

    // 4.
    IAsyncEnumerable<IPerson> People { get; }

    // 5.
    IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter);

    // 6.
    string GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people);

}
