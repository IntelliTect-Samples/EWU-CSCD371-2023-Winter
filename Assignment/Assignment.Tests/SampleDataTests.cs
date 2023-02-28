using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void TestGetUniqueSortedListOfStatesGivenCsvRows()
        {
            // Arrange
            //Must change the filePath to match your path to the people.csv
            string filePath = "C:\\Users\\bhopk\\OneDrive\\Documents\\.next\\EWU-CSCD371-2023-Winter\\Assignment\\Assignment\\People.csv";
            SampleData sampleData = new SampleData(filePath);

            // Act
            var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}