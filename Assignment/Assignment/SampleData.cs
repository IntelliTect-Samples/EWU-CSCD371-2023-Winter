using Assignment;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private IEnumerable<string> rows;

        public SampleData() {
            this.rows = File.ReadAllLines("People.csv").Skip(1);
        }

        // 1.
        public IEnumerable<string> CsvRows => rows;

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            return CsvRows.Select(x => x.Split(',')[6]).Distinct().OrderBy(x => x);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // 4.
        public IEnumerable<IPerson> People => from string temp in CsvRows
                                              let split = temp.Split(",")
                                              orderby split[6], temp[5], temp[7]
                                              select new Person(split[1], split[2], new Address(split[4], split[5], split[6], split[7]), split[3]);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(person => filter(person.EmailAddress)).Select(person => (person.FirstName, person.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => people.Select(person => person.Address.State).Distinct().OrderBy(state => state).Aggregate((all, state) => $"{all},{state}");
    }
}
