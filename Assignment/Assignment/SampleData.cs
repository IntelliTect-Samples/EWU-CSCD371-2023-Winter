namespace Assignment;

public class SampleData : ISampleData
{
    // 1.
    public IEnumerable<string> CsvRows => File.ReadLines(@"People.csv").Skip(1);

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() =>
        CsvRows.Select(x => x.Split(',')[6]).Order().Distinct();

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
        => string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());

    // 4.
    public IEnumerable<IPerson> People => CsvRows.Select(GenPerson).OrderBy(OrderPerson);

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        
        string[] mails = Array.FindAll<string>(People.ToArray().Select(x => x.EmailAddress).ToArray(), filter);
        List<(string, string)> items = new List<(string, string)>();
        foreach (Person i in People)
        {
            items = (List<(string, string)>)items.Append<(string, string)>(new ValueTuple<string, string>(i.FirstName, i.LastName));
        }

        return items;
    }

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people) => string.Join(',', people.Select(x => x.Address.State).Order().Distinct());

    private static IPerson GenPerson(string line)
    {
        string[] items = line.Split(',');
        Address address = new(items[4], items[5], items[6], items[7]);
        return new Person(items[1], items[2], address, items[3]);
    }

    private static string OrderPerson(IPerson person) =>
        person.Address.State + person.Address.City + person.Address.Zip;
}