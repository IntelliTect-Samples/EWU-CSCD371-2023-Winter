using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 

namespace Assignment
{
    public class SampleDataAsync : IAsyncSampleData
    {
        private static async IAsyncEnumerable<string> ReadFileIntoAsyncEnumerable()
        {
            using StreamReader reader = File.OpenText("../../../../Assignment/People.csv");
            reader.ReadLine(); 
            while (!reader.EndOfStream)
                yield return await reader.ReadLineAsync() ?? throw new ArgumentNullException("File Not Found");
        }

        public IAsyncEnumerable<string> CsvRows
        {
            get
            {
                return ReadFileIntoAsyncEnumerable(); 
            }
        }
        private async IAsyncEnumerable<IPerson> GetPeople() {


            await foreach (string row in CsvRows)
            {

                string[] rowData = row.Split(",");

                if (((rowData[1], rowData[2], rowData[3]) is (string firstName, string lastName, string email)) &&
                     ((rowData[4], rowData[5], rowData[6], rowData[7]) is (string street, string city, string state, string zip)))
                {
                    Address newAddress = new(street, city, state, zip);
                    Person newPerson = new(firstName, lastName, newAddress, email);
                    yield return newPerson;
                }
            }
       
        }
        public IAsyncEnumerable<IPerson> People {
         
                get {
                    return GetPeople().OrderBy(person => person.Address.State).ThenBy(person => person.Address.City).ThenBy(person => person.Address.Zip);  
                }
            

        }

        public IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            return People.Where(person => filter(person.EmailAddress)).Select(person => {
              return (person.FirstName, person.LastName);
          });
        }

        public string GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people)
        {
            //string str = "";
            string allStates = people.AggregateAsync("",
                (result, curr) =>
                    result += result.Contains(curr.Address.State) ? "" : curr.Address.State + ",").Result;

            // Trim the last comma
            return allStates[..(allStates.Length - 1)];
        }

        
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IAsyncEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows();
            string[] statesArray = states.ToArrayAsync().Result;
            return string.Join(",", statesArray);
        }

        public async IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> states = new();
            await foreach (string row in CsvRows)
            {
                states.Add(row.Split(",")[6]);
            }
            await foreach(var x in states.Distinct().OrderBy(x => x).ToAsyncEnumerable<string>()) {
                yield return x; 
            }

        }
    }
}
