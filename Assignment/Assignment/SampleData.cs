using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows { get; init; } = File.ReadLines("./People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> list = new List<string>();
            string[] rowItems;

            foreach (string row in CsvRows)
            {
                rowItems = row.Split(',');
                list.Add(rowItems[6]);
            }

            return list.Distinct().OrderBy(item => item);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // 4.
        public IEnumerable<IPerson> People 
        {
            get
            {
                List<IPerson> persons = new List<IPerson>();
                string[] rowItems;

                foreach (string row in CsvRows)
                {
                    rowItems = row.Split(',');
                    persons.Add(
                        new Person(rowItems[1], rowItems[2], new Address(rowItems[4], rowItems[5], rowItems[6], rowItems[7]), rowItems[3])
                        );
                }

                return persons.OrderBy(item => item.Address);
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
