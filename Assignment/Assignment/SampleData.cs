using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        //public IEnumerable<string> CsvRows => throw new NotImplementedException();
        public virtual IEnumerable<string> CsvRows 
        {
            get
            {
                var CSVFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "People.csv");
                var CSVRows = File.ReadAllLines(CSVFilePath).Skip(1);
                return CSVRows;
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            //var StateList = new List<string>();
            var uniqueStates = CsvRows.Select(row => row.Split(',')[6]).Distinct().OrderBy(state => state).ToList();

            return uniqueStates;
        }
            
        // 3.

        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            var uniqueStates = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();

            return string.Join(",", uniqueStates);
        }


        // 4.
        public IEnumerable<IPerson> People => CsvRows.Skip(1)
            .Select(row => row.Split(','))
            .Select(data => new Person(
                data[1],
                data[2],
                new Address(data[4], data[5], data[6], data[7]),
                data[3]
            ))
            .OrderBy(person => person.Address.State)
            .ThenBy(person => person.Address.City)
            .ThenBy(person => person.Address.Zip)
            .ToList();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            var matchingPeople = People.Where(email => filter(email.EmailAddress));
            var matchingNames = matchingPeople.Select(x => (x.FirstName, x.LastName));

            return matchingNames;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            IEnumerable<string> states = new string[] { };
            foreach (var person in people)
            {
                states = states.Concat(new[] { person.Address.State });
            }
            states.Distinct();
            return string.Join(", ", states.ToArray());
        }
    }
}
