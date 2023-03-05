using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv")
            .Skip(1)
            .Where(row => row.Length > 0);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> states = new();
            foreach (var row in CsvRows)
            {
                states.Add(row.Split(',').ElementAt(6));
            }
            return states.Distinct().OrderBy(state => state);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string states = string.Join(", ",GetUniqueSortedListOfStatesGivenCsvRows());
            return states;
        }

        // 4.
        public IEnumerable<IPerson> People => CsvRows.SelectMany(row =>
            {
                List<IPerson> people = new();
                string[] personInfo = row.Split(",");
                Address address = new(personInfo[4], personInfo[5], personInfo[6], personInfo[7]);
                Person person = new(personInfo[1], personInfo[2], address, personInfo[3]);
                people.Add(person);
                return people; 
            })
            .OrderBy(item => item.Address.State)
            .ThenBy(item => item.Address.City)
            .ThenBy(item => item.Address.Zip);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            string states = people.Select(person => person.Address.State)
                .Distinct()
                .Aggregate((state1, state2) => state1 + ", " + state2);
            return states;
        }
    }
}
