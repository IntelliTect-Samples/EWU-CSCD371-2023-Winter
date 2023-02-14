# Assignment

The purpose of this assignment is to learn how to write a generic class and a generic method. To accomplish this you will write a linked list that circles back on itself. We will also look at exception throwing and handling.

## Reading

Chapters 11, 12

## Instructions

- Create a *class library* project called "GenericsHomework.". ❌✔
- Create a node class that can contain a value of any type and points to the next node and traversing the next node points back to the first item.
  - Define the `Node` class
  - The values should be homogeneous.
  - Include a constructor that takes a value.  (No validation is necessary on the value). ❌✔
  - Add a `ToString()` override that writes out the value's `ToString()` result. ❌✔
  - Add a `Next` property that references the next node or else refers back to itself if there are no other nodes in the list. ❌✔
    - The `Next` property should be non-nullable (careful to follow the non-nullable property guidelines) ❌✔
    - The `Next` property setter should be private. ❌✔
  - Add an `Append` method that takes a value and appends a new `Node` instance after the current node (by invoking the `Next` property). ❌✔
  - Add a Clear method that effectively removes all items from a list except the current node. Pay attention as to whether you should be concerned with the following:
    - Whether it is sufficient to only set Next to itself ❌✔
    - Whether to set the removed items to circle back on themselves. In other words, whether to close the loop of the removed items. (Provide a test to show why this is required if it is required). ❌✔
    - Given there is a circular list of items, provide a comment to indicate whether you need to worry about garbage collection because all the items point to each other and therefore may never be garbage collected. ❌✔
  - Create an Exists method to test to see if a value exists in the list. ❌✔
  - Throw an error on an attempt to Append a duplicate value. (Make sure you test for this case) ❌✔
- You should not rely on any BCL generic classes for your implementation. ❌✔

## Extra Credit

Do one of the following two options (or both if you want extra, extra credit) :)

1. Implement a `VennDiagram` structure that contains `n` `Circle`s that only contains homogenous **reference types** of any type. ❌✔

- Each circle contains n items and each item can belong to one or more `Circle` instances.
- You are not required to use a `Node` from earlier in the homework for your Venn diagram implementation.
- You are welcome to use existing BCL generic classes for the extra credit.

1. Implement `System.Collections.Generic.ICollection<T>` on the `Node` class ❌✔

## Fundamentals

- Place all shared project properties into a `Directory.Build.Props` file.
- Place all shared project items into a `Directory.Build.targets` file.
- nullable reference types is enabled  ❌✔
- Ensure that you turn on code analysis for all projects(EnableNETAnalyzers)  ❌✔
- Set LangVersion and the TargetFramework to the latest released versions available (preview versions optional)   ❌✔
- and enabled .NET analyzers for both projects ❌✔
- For this assignment, always use `Assert.AreEqual<T>()` (the generic version)  ❌✔
- All of the above should be unit tested ❌✔
- Choose simplicity over complexity ❌✔

## See [Docs](Docs)