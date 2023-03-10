# Assignment

The purpose of this assignment is to solidify your learning of:

- Lambda expressions
- LINQ with Standard Query Operators
  - Selecting (projection)
  - Filtering
  - Aggregation
  - Sorting
  - Unit testing collections.
- Implementing IEnumerable

Given the amount of material (reading and assignment), **the homework will span two weeks of class with the final submission on Thursday 2/25**. (No assignment is due Thu 2/17)

## Reading

### Due 2/20

Chapter 13: Delegates and Lambda Expressions
Chapter 15: Collection Interfaces with Standard Query Operators

### Due 2/27

https://essentialcsharp.com/pattern-matching#pattern-matching (Added)
https://essentialcsharp.com/record-class-inheritance#record-class-inheritance (Added)
https://essentialcsharp.com/customizing-record-behavior#customizing-record-behavior (Added)
Chapter 17: Building Custom Collections
Chapter 20: Programming with Task-Based Asynchronous Pattern
Chapter 22: Thread Synchronization

### Due 3/06

Chapter 19: Introducing Multithreading
Chapter 21: Iterating in Parallel

### Recommended But Not Required (in order of priority)

Chapter 19: Introducing Multithreading
Chapter 21: Iterating in Parallel
Chapter 18: Reflection, Attributes, and Dynamic Programming
Chapter 16: LINQ with Query Expressions
Chapter 14: Events

## Instructions

**Throughout, consider using the `System.Linq.Enumerable` methods `Zip`, `Count`, `Sort` and `Contains` methods for testing collections.**. (Preferably avoid using `Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert` although that might be easier, to get a firmer grasp on additional LINQ API.)

1. Implement the `ISampleData.CsvRows` property, loading the data from the `People.csv` file and returning each line as a single string. ❌✔

   - Change the "Copy to" property on People.csv to "Copy if newer" so that the file is deployed along with your test project. ❌✔
   - Using LINQ, skip the first row in the `People.csv`. ❌✔
   - Be sure to appropriately handle resource (`IDisposable`) items correctly if applicable (and it may not be depending on how you implement it). ❌✔

2. Implement `IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()` to return a **sorted**, **unique** list of states. ❌✔

   - Use `ISampleData.CsvRows` for your data source. ❌✔
   - Don't forget the list should be unique. ❌✔
   - Sort the list alphabetically. ❌✔
   - Include a test that leverages a hardcoded list of addresses. ❌✔
   - Include a test that uses LINQ to verify the data is sorted correctly (do not use a hardcoded list). ❌✔

3. Implement `ISampleData.GetAggregateSortedListOfStatesUsingCsvRows()` to return a `string` that contains a **unique**, comma separated list of states. ❌✔

   - Use `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows()` for your data source. ❌✔
   - Consider "selecting" only the states and calling `ToArray()` to retrieve an array of all the state names. ❌✔
   - Given the array, consider using `string.Join` to combine the list into a single string. ❌✔

4. Implement the `ISampleData.People` property to return all the items in `People.csv` as `Person` objects ❌✔

   - Use `ISampleData.CsvRows` as the source of the data. ❌✔
   - Sort the list by State, City, and Zip. (Sort the addresses first then select). ❌✔
   - Be sure that `Person.Address` is also populated. ❌✔
   - Adding null validation to all the `Person` and `Address` properties is **optional**.
   - Consider using `ISampleData.CsvRows` in your test to verify your results. ❌✔

5. Implement `ISampleDate.FilterByEmailAddress(Predicate<string> filter)` to return a list of names where the email address matches the `filter`. ❌✔

   - Use `ISampleData.People` for your data source. ❌✔

6. Implement `ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)` to return a `string` that contains a **unique**, comma-separated list of states. ❌✔

   - Use the `people` parameter from `ISampleData.People` property for your data source. ❌✔
   - At a minimum, use the `System.Linq.Enumerable.`Aggregate LINQ method to create your result. ❌✔
   - Don't forget the list should be unique. ❌✔
   - It is recommended that, at a minimum, you use `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows` to validate your result.

7. Given the implementation of `Node` in Assignment5

- Implement `IEnumerable<T>` to return all the items in the "circle" of items. ❌✔
- Add an `IEnumberable<T> ChildItems(int maximum)` method to `Node` that returns the remaining items with a maximum number of items returned less than `maximum`.  

## Extra Credit

- Implement the homework using async/await and multi-threading by defining a new `SampleDataAsync` class that implements `IAsyncSampleData`). Refactor your `SampleData` and `SampleDataAsync` classes with minimal duplication. Be sure to refactor your tests to re-use a significant amount of the test code for both implementations. ❌✔

## Fundamentals

- Place all shared project properties into a `Directory.Build.Props` file.
- Place all shared project items into a `Directory.Build.targets` file.
- Ensure nullable reference types is enabled  ❌✔
- Ensure that you turn on code analysis for all projects(EnableNETAnalyzers)  ❌✔
- Set `LangVersion` and the `TargetFramework` to the latest released versions available (preview versions optional)   ❌✔
- and enabled .NET analyzers for both projects ❌✔
- For this assignment, consider using `Assert.AreEqual<T>()` (the generic version)  ❌✔
- All of the above should be unit tested ❌✔
- Choose simplicity over complexity ❌✔

## See [Docs](Docs)
