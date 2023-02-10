using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class BaseEntityTest
    {
        [TestMethod]
        public void Students_SameProperties_AreEqual()
        {
            Student studentOne = new()
            {
                Id = Guid.NewGuid(),
                FullName = new FullName("Shinji", "Ikari"),
                StudentID = 01

            };

            Student studentTwo = new()
            {
                Id = studentOne.Id,
                FullName = studentOne.FullName,
                StudentID = studentOne.StudentID
            };

            Assert.AreEqual(studentOne, studentTwo);
            
        }

        [TestMethod]
        public void Book_SameProperties_AreEqual()
        {
            FullName author = new FullName("Hideaki", "Anno");

            Book bookOne = new()
            {
                Id = Guid.NewGuid(),
                Title = "Neon Genesis Evangelion",
                Author = author,
                ISBN = "9781591163909"
            };
            
            Book bookTwo = new()
            {
                Id = bookOne.Id,
                Title = bookOne.Title,
                Author = bookOne.Author,
                ISBN = bookOne.ISBN
            };

            Assert.AreEqual(bookOne, bookTwo);
        }

        [TestMethod]
        public void Employee_SameProperties_AreEqual()
        {
            Employee employeeOne = new()
            {
                Id = Guid.NewGuid(),
                FullName = new FullName("Gendo", "Ikari"),
                Employer = "Nerv"
            };

            Employee employeeTwo = new()
            {
                Id = employeeOne.Id,
                FullName = employeeOne.FullName,
                Employer = employeeOne.Employer
            };

            Assert.AreEqual(employeeOne, employeeTwo);
        }

    }
}
