using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadLines("..\\..\\..\\..\\Assignment\\People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> states = new();
            foreach(string row in CsvRows)
            {
                states.Add(row.Split(',')[6]);
            }
            states = states.Distinct().Order().ToList();
            return states;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            return string.Join(",", states);
        }

        // 4.
        public IEnumerable<IPerson> People 
        { 
            get {
                List<IPerson> people = new();
                IEnumerable<string> rows = CsvRows.OrderBy((row) => row.Split(",")[6]).ThenBy((row) => row.Split(",")[5]).ThenBy((row) => row.Split(",")[7]);
                foreach(string row in rows)
                {
                    string[] temp = row.Split(",");
                    Address address = new(temp[4], temp[5], temp[6], temp[7]);
                    Person person = new(temp[1], temp[2], address, temp[3]);
                    people.Add(person);
                }
                return people;
            } 
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            List<(string FirstName, string LastName)> people = (List<(string FirstName, string LastName)>)People.Where(p => filter(p.EmailAddress)).Select(p => (p.FirstName, p.LastName));
            return people;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            return people.Select(p => p.Address.State).Distinct().Aggregate((stateA, stateB) => $"{stateA}, {stateB}");
        }
    }
}
