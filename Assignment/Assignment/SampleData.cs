﻿using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows { get => _CsvRows; init { _CsvRows = value; } }

        private IEnumerable<string> _CsvRows = File.ReadAllLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            return CsvRows.Select(row => row.Split(",")[6]).Distinct().OrderBy(state => state);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            return string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                static Person MakePersons(string row)
                {
                    string[] elements = row.Split(",");
                    Address address = new(elements[4], elements[5], elements[6], elements[7]);
                    return new Person(elements[1], elements[2], address, elements[3]);
                }

                return CsvRows.Select(MakePersons)
                    .OrderBy(person => person.Address.State)
                    .ThenBy(person => person.Address.City)
                    .ThenBy(person => person.Address.StreetAddress);
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            return People.Where(person => filter(person.EmailAddress))
                .Select(person => (person.FirstName, person.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            return People.Select(person => person.Address.State).Distinct().Aggregate((accumulator, state) => $"{accumulator},{state}");
        }
    }
}
