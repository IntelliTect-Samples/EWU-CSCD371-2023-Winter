using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private List<string>? _CsvRows;

        public SampleData()
        {
            IEnumerable<string> CSV = File.ReadAllLines("E:/CSCD371/Assignment/Assignment/People.csv");
            CsvRows = CSV;
        }
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                return _CsvRows ?? throw new ArgumentNullException();
            }
            set
            {
                _CsvRows = value.Where(x => x != null).Skip(1).ToList();
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> split = CsvRows.Select(x => x.Split(',')[6]).Distinct().ToList();
            split.Sort();

            return split;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<Person> people = from person in CsvRows.OrderBy(state => state.Split(',')[6])
                                             .ThenBy(city => city.Split(',')[5]).ThenBy(zip => zip.Split(',')[7]).ToList()

                let personAttribute = person.Split(',')
                select new Person(personAttribute[1], personAttribute[2],
                new Address(personAttribute[4], personAttribute[5], personAttribute[6], personAttribute[7]),
                personAttribute[3]);

                return people;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName, item.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => people.Select(person => person.Address.State).Distinct().Aggregate((s1, s2) => s1 + ", " + s2);
    }
}
