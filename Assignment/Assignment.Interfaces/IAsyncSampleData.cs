namespace Assignment;

public interface IAsyncSampleData
{
    // 1.
    IAsyncEnumerable<string> CsvRows { get; }

    // 4.
    IAsyncEnumerable<IPerson> People { get; }

    // 2.
    IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows();

    // 3.
    string GetAggregateSortedListOfStatesUsingCsvRows();

    // 5.
    IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter);

    // 6.
    string GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people);
}