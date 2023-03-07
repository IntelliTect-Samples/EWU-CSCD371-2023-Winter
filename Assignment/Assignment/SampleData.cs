using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows { get; set; } = File.ReadAllLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
            => CsvRows.Select(item => item.Split(",")[6]).Distinct().Order();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => String.Join(",", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // 4.
        public IEnumerable<IPerson> People => from entry in CsvRows
                                              orderby entry.Split(",")[6], entry.Split(",")[5], entry.Split(",")[7]
                                              select new Person(entry.Split(",")[1],
                                                                entry.Split(",")[2],
                                                                new Address(entry.Split(",")[4],
                                                                            entry.Split(",")[5],
                                                                            entry.Split(",")[6],
                                                                            entry.Split(",")[7]),
                                                                entry.Split(",")[3]);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(person => filter(person.EmailAddress)).Select(person => (person.FirstName, person.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => people.Select(person => person.Address.State).Distinct().Aggregate((state1, state2) => $"{state1},{state2}");
    }
}
