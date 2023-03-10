using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows 
        {
            get
            {
                IEnumerable<string> lines =
                    from line in File.ReadLines("People.csv")
                    select line;
                return lines.Skip(1);
            } 
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> states = new List<string>();
            foreach(string item in CsvRows) 
            {
                string[] Csvs  = item.Split(',');
                states.Add(Csvs[6]);
            } 
            IEnumerable<string> uniqueStates = states.Distinct().OrderBy(state => state);
            return uniqueStates;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows() 
        {
            IEnumerable<string> states = this.GetUniqueSortedListOfStatesGivenCsvRows();
            

            return string.Join(',', states.ToArray());
        }

        // 4.
        public IEnumerable<IPerson> People
        { 
            get 
            {
                List<Person> people = new List<Person>();
                List<Address> addresses = new List<Address>();
                foreach (string item in CsvRows)
                {
                    string[] Csvs = item.Split(',');
                    people.Add(new (Csvs[1], Csvs[2], new Address(Csvs[4], Csvs[5], Csvs[6], Csvs[7]), Csvs[3]));
                    addresses.Add(new (Csvs[4], Csvs[5], Csvs[6], Csvs[7]));
                }
                IEnumerable<Person> sortedPeople = people.OrderBy(person => person.Address.State).ThenBy(person => person.Address.City).ThenBy(person => person.Address.Zip);
                return sortedPeople;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            List<(string first, string last)> names = new();

            foreach (Person item in People) 
            {
                if (filter(item.EmailAddress)) 
                {
                    names.Add((item.FirstName, item.LastName));
                }
            }
            return names;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            List<string> states = new List<string>();
            foreach (IPerson item in people)
            {
                states.Add(item.Address.State);
            }
            IEnumerable<string> uniqueStates = states.Distinct();


            return string.Join(',', uniqueStates.ToArray());
        }
    }
}
