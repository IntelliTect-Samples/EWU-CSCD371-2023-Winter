using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
        {
            get => _CsvRows;
            init
            {
                _CsvRows = value;
            }
        }

        private IEnumerable<string> _CsvRows = File.ReadAllLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            return CsvRows.Select(row => row.Split(",")[6]).Distinct().OrderBy(state => state);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            return string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());
        }

        // 4.
        public IEnumerable<IPerson> People { get
            {
                Person MakePersons(string row)
                {
                    string[] elements = row.Split(",");
                    Address address = new Address(elements[4], elements[5], elements[6], elements[7]);
                    return new Person(elements[1], elements[2], address, elements[3]);
                }


                return CsvRows.Select(MakePersons)
                    .OrderBy(person => person.Address.State)
                    .ThenBy(person => person.Address.City)
                    .ThenBy(person => person.Address.StreetAddress); ;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
