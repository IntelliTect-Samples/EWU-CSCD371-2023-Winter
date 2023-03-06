using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private List<string>? CsvRows1;
        // 1.
        public SampleData(string filepath)
        {
            IEnumerable<string> csv = File.ReadAllLines(filepath);
            CsvRows = csv;
        }

        public IEnumerable<string> CsvRows
        {
            get
            {
                return CsvRows1 ?? throw new ArgumentNullException();
            }
            set
            {
                CsvRows1 = value.Where(x => x != null).Skip(1).ToList();
            }
  
        }    

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            return CsvRows.Select(row => row.Split(',')[6]).Distinct().OrderBy(state => state).ToList();

        }
        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            var uniqueStates = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();

            return string.Join(",", uniqueStates);
        }
        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<Person> people = from person in CsvRows
                .OrderBy(state => state.Split(',')[6])
                .ThenBy(city => city.Split(',')[5])
                .ThenBy(zip => zip.Split(',')[7])
                .ToList()

                let personAttribute = person.Split(',')
                select new Person(personAttribute[1], personAttribute[2],
                new Address(personAttribute[4], personAttribute[5], personAttribute[6], personAttribute[7]),
                personAttribute[3]);

                return people;
             }
         }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            List<IPerson> matches = People.Where(x => filter(x.EmailAddress)).ToList();
            List<(string, string)> nameList = new();
            foreach(IPerson item in matches)
            {
                nameList.Add((item.FirstName, item.LastName));
            }
            return nameList;
        }
        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
            => people.Select(person => person.Address.State).Distinct().OrderBy(state => state).Aggregate((all, state) => $"{all}, {state}");
    }
}
