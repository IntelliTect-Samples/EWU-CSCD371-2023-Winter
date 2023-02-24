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
            List<string> states = new List<string>();
            foreach (var row in CsvRows) 
            {
                states.Add(row.Split(',').ElementAt(6));
            }
            return states.Distinct().OrderBy(state => state);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            string allStates = "";
            foreach(string state in states) 
            {
                
            }
            return allStates;
        }

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
