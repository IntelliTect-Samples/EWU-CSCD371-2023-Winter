using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1. Implement the `ISampleData.CsvRows` property, loading the data from the `People.csv`
        //    file and returning each line as a single string. ✔
        //
        // - Change the "Copy to" property on People.csv to "Copy if newer" so that the file is
        //   deployed along with your test project. ✔
        // - Using LINQ, skip the first row in the `People.csv`. ✔
        // - Be sure to appropriately handle resource (`IDisposable`) items correctly if applicable
        //   (and it may not be depending on how you implement it). ✔
        public IEnumerable<string> CsvRows { get; } =
            from string line in File.ReadAllLines("People.csv")
            where !line.Contains("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip")
            select line;

        // 2. Implement `IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()` to return a
        //    **sorted**, **unique** list of states. ❌✔
        //
        // - Use `ISampleData.CsvRows` for your data source. ✔
        // - Don't forget the list should be unique. ✔
        // - Sort the list alphabetically. ✔
        // - Include a test that leverages a hardcoded list of addresses. ❌✔
        // - Include a test that uses LINQ to verify the data is sorted correctly (do not use a
        //   hardcoded list). ✔
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            // QUESTION: What are the advantages of specifying the type as the interface rather than
            //           the implementing class?
            ISampleData sampleData = new SampleData();
            IEnumerator enumerator = sampleData.CsvRows.GetEnumerator();

            // Option 1: Using a `while` loop. Allows the use of `MoveNext()`.
            List<string> uniqueSortedStates = new List<string>();
            while (enumerator.MoveNext())
            {
                // QUESTION: Should I really be using the null-forgiving operator here?
                string[] split = enumerator.Current.ToString()!.Split(',');
                string state = split[6];
                if (!uniqueSortedStates.Contains(state))
                {
                    uniqueSortedStates.Add(state);
                }
            }

            // Option 2: Using a `foreach` loop.
            // List<string> uniqueSortedStates = new List<string>();
            // foreach (string item in sampleData.CsvRows)
            // {
            //     string[] itemArray = item.Split(',');
            //     string state = itemArray[6];
            //     if (!uniqueSortedStates.Contains(state))
            //     {
            //         uniqueSortedStates.Add(state);
            //     }
            // }

            uniqueSortedStates.Sort();

            // TODO: Figure out if this is actually needed...
            IDisposable disposable = (IDisposable)enumerator;
            disposable.Dispose();

            return uniqueSortedStates;
        }

        // 3. Implement `ISampleData.GetAggregateSortedListOfStatesUsingCsvRows()` to return a
        //    `string` that contains a **unique**, comma separated list of states. ❌✔
        //
        // - Use `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows()` for your data source. ❌✔
        // - Consider "selecting" only the states and calling `ToArray()` to retrieve an array of
        //   all the state names. ❌✔
        // - Given the array, consider using `string.Join` to combine the list into a single
        //   string. ❌✔
        public string GetAggregateSortedListOfStatesUsingCsvRows() =>
            string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // 4. Implement the `ISampleData.People` property to return all the items in `People.csv` as
        //    `Person` objects ❌✔
        //
        // - Use `ISampleData.CsvRows` as the source of the data. ❌✔
        // - Sort the list by State, City, and Zip. (Sort the addresses first then select). ❌✔
        // - Be sure that `Person.Address` is also populated. ❌✔
        // - Adding null validation to all the `Person` and `Address` properties is **optional**.
        // - Consider using `ISampleData.CsvRows` in your test to verify your results. ❌✔
        public IEnumerable<IPerson> People =>
            from string line in CsvRows
            let split = line.Split(',')
            orderby split[6], split[5], split[7]
            select new Person(split[1], split[2], new Address(split[4], split[5], split[6], split[7]), split[3]);

        // 5. Implement `ISampleDate.FilterByEmailAddress(Predicate<string> filter)` to return a
        //    list of names where the email address matches the `filter`. ❌✔
        //
        // - Use `ISampleData.People` for your data source. ❌✔
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            IEnumerable<(string FirstName, string LastName)> names =
                from Person line in People
                where filter(line.EmailAddress)
                select (line.FirstName, line.LastName);
            return names;
        }

        // 6. Implement `ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson>
        //    people)` to return a `string` that contains a **unique**, comma-separated list of
        //    states. ❌✔
        //
        // - Use the `people` parameter from `ISampleData.People` property for your data source. ❌✔
        // - At a minimum, use the `System.Linq.Enumerable.`Aggregate` LINQ method to create your
        //   result. ❌✔
        // - Don't forget the list should be unique. ❌✔
        // - It is recommended that, at a minimum, you use
        //   `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows` to validate your result.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
