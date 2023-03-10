using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Instruction.Tests
{
    [TestClass]
    public class CsvRowsTests
    {
        string file = "People.csv";
        [TestMethod]
        public void MyTestMethod()
        {
            SampleData testData = new();
            int lineCount = 0;
            using (StreamReader input = new StreamReader(file))
            {
                string? line = input.ReadLine();
                Assert.AreNotEqual<string>(line!, testData.CsvRows.First());
                while ((line = input.ReadLine()) != null)
                {
                    Assert.AreEqual<string>(line, testData.CsvRows.ElementAt(lineCount));
                    lineCount++;
                }
            }

            Assert.AreEqual<int>(lineCount, testData.CsvRows.Count());
        }
    }
    [TestClass]
    public class GetUniqueSortedListOfStatesGivenCsvRowsTests
    {
        [TestMethod]
        public void CsvRowList_isUnique_Pass()
        {
            SampleData testData = new();
            IEnumerable<string> uniqueStates = testData.GetUniqueSortedListOfStatesGivenCsvRows();
            foreach (string item in uniqueStates)
            {
                Assert.AreEqual<int>(1, uniqueStates.Where(state => state == item).Count());
            }
        }
        [TestMethod]
        public void CsvRowList_isSorted_Pass()
        {
            SampleData testData = new();
            IEnumerable<string> sortedStates = testData.GetUniqueSortedListOfStatesGivenCsvRows();
            string prev = sortedStates.First();
            foreach (string item in sortedStates)
            {
                if (prev != item)
                {
                    Assert.IsTrue(prev.CompareTo(item) < 0);
                }
                prev = item;
            }
        }
        [TestMethod]
        public void CsvRowList_AccuratetoAddresses_Hardcoded_Pass()
        {
            Assert.IsFalse(true);
        }
        [TestMethod]
        public void CsvRowList_AccuratetoAddresses_LINQ_Pass()
        {
            Assert.IsFalse(true);
        }

    }



    [TestClass]
    public class GetAggregateSortedListOfStatesUsingCsvRowsTests
    {
        [TestMethod]
        public void GetAggregate_CommaSeperatedListString_Pass()
        {
            SampleData testData = new();
            string states = testData.GetAggregateSortedListOfStatesUsingCsvRows();
            string[] statesArr = states.Split(',');
            for (int i = 0; i < statesArr.Length - 2; i++)
            {
                Assert.IsTrue(statesArr[i].CompareTo(statesArr[i + 1]) < 0);
            }
        }
    }

    [TestClass]
    public class PeopleTests
    {
        [TestMethod]
        public void People_ReturnsMultiplePersons_Pass()
        {
            SampleData testData = new();
            IEnumerable<IPerson> people = testData.People;
            foreach (IPerson item in people)
            {
                Assert.IsNotNull(item);
                Assert.AreEqual<Type>(typeof(Person), item.GetType());
            }
        }
        [TestMethod]
        public void People_Sorted_Pass()
        {
            SampleData testData = new();
            IEnumerable<IPerson> sortedPeople = testData.People;
            IPerson prev = sortedPeople.First();
            foreach (IPerson item in sortedPeople)
            {
                if (prev != item)
                {
                    bool isLess = true;
                    if (prev.Address.State.CompareTo(item.Address.State) > 0)
                    {
                        if (prev.Address.City.CompareTo(item.Address.City) > 0)
                        {
                            if (prev.Address.Zip.CompareTo(item.Address.Zip) > 0)
                            {
                                isLess = false;
                            }
                        }
                    }
                    Assert.IsTrue(isLess);
                }
                prev = item;
            }
        }
        [TestMethod]
        public void People_AddressesPopulated_Pass()
        {
            SampleData testData = new();
            IEnumerable<IPerson> people = testData.People;
            foreach (IPerson item in people)
            {
                Assert.IsNotNull(item.Address);
                Assert.AreEqual<Type>(typeof(Address), item.Address.GetType());
            }
        }

    }

    [TestClass]
    public class FilterByEmailAddressTests
    {
        [TestMethod]
        public void Filter_ReturnsListThatMatchEmail_Pass()
        {
            SampleData testData = new();
            IEnumerable<(string first, string last)> names = testData.FilterByEmailAddress(email => email.Equals("eloseked@posterous.com"));

            foreach (IPerson item in testData.People)
            {
                if (item.EmailAddress.Equals("eloseked@posterous.com"))
                {
                    Assert.IsTrue(names.Contains((item.FirstName, item.LastName)));
                }
            }
        }
    }

    [TestClass]
    public class GetAggregateListOfStatesGivenPeopleCollectionTests
    {
        [TestMethod]
        public void GetAggregateFromPeople_CommaSeperatedListString_Pass()
        {
            SampleData testData = new();
            string states = testData.GetAggregateListOfStatesGivenPeopleCollection(testData.People);
            string[] statesArr = states.Split(',');
            for (int i = 0; i < statesArr.Length - 2; i++)
            {
                Assert.IsTrue(statesArr[i].CompareTo(statesArr[i + 1]) < 0);
            }
        }

        [TestMethod]
        public void GetAggregateFromPeople_UniqueElements_Pass()
        {
            SampleData testData = new();
            string states = testData.GetAggregateListOfStatesGivenPeopleCollection(testData.People);
            string[] statesArr = states.Split(',');
            List<string> unique = new List<string>();
            foreach (string state in statesArr)
            {
                Assert.IsTrue(!(unique.Contains(state)));
                unique.Add(state);
            }
        }
    }

    [TestClass]
    public class NodeEnumerableTests
    {
        [TestMethod]
        public void IEnumerable_ReturnsAllItemsInCircle_Pass()
        {
            Node<int> nodeOne = new Node<int>(10);
            Node<int> nodeTwo = new Node<int>(20);
            Node<int> nodeThree = new Node<int>(30);

            nodeOne.Append(nodeTwo);
            nodeTwo.Append(nodeThree);
            nodeThree.Append(nodeOne);

            List<Node<int>> nodes = nodeOne.ChildItems(3).ToList();

            Assert.IsTrue(nodes.Contains<Node<int>>(nodeOne));
            Assert.IsTrue(nodes.Contains<Node<int>>(nodeOne.Next));
            Assert.IsTrue(nodes.Contains<Node<int>>(nodeOne.Next.Next));
        }
    }
}

