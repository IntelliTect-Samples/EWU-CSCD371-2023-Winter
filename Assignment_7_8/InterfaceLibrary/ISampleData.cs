namespace InterfaceLibrary;
public interface ISampleData
{
    IEnumerable<string> CsvRows { get; }
    IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows();
    string GetAggregateSortedListOfStatesUsingCsvRows();
    IEnumerable<IPerson> People { get; }
    public IEnumerable<string> FilterByEmailAddress(Predicate<string> filter);
    public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people);
    
}