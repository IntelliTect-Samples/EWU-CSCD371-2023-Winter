using System.IO;
using InterfaceLibrary;

namespace ClassLibrary;
public class SampleData : ISampleData
{
    public IEnumerable<string> CsvRows => File.ReadLines("People.csv").Skip(1);
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows
            .Select(row => row.Split(',')[6])
            .Distinct()
            .OrderBy(state => state);
    }
    public IEnumerable<string> GetSortedListOfStatesGivenCsvRows()
    {
        return CsvRows
            .Select(row => row.Split(',')[6])
            .OrderBy(state => state);
    }
    public IEnumerable<string> GetSortedListOfCitiesGivenCsvRows()
    {
        return CsvRows
            .Select(row => row.Split(',')[5])
            .OrderBy(city => city);
    }

    public IEnumerable<string> GetSortedListOfZipsGivenCsvRows()
    {
        return CsvRows
            .Select(row => row.Split(',')[7])
            .OrderBy(zip => zip);
    }

    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        var states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();

        return string.Join(",", states);
    }
    public IEnumerable<IPerson> People
    {
        get
        {
            var rows = CsvRows;
            var people = rows.Select(row =>
            {
                var fields = row.Split(',');
                var person = new Person
                {
                    FirstName = fields[1],
                    LastName = fields[2],
                    Email = fields[3],
                    Address = new Address
                    {
                        Street = fields[4],
                        City = fields[5],
                        State = fields[6],
                        Zip = fields[7]
                    }
                };
                return person;
            });

            // Sort by State, City, and Zip
            return people;
        }
    }
    public IEnumerable<string> FilterByEmailAddress(Predicate<string> filter)
    {
        var people = People.ToList(); // get the list of people from the property
        var filteredPeople = people.Where(person => filter(person.Email));
        var names = filteredPeople.Select(person => $"{person.FirstName} {person.LastName}");
        return names;
    }

    public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
    {
        var states = people.Select(person => person.Address.State).Distinct();
        var stateList = states.Aggregate((current, next) => $"{current},{next}");
        return stateList;
    }
}