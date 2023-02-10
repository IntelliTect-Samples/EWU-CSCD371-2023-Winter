using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class StorageTest
    {
        [TestMethod]
        public void Add_Book_Entity()
        {
            Storage storageOne = new();
            FullName author = new FullName("Stephen", "King");
            Book bookOne = new()
            {
                Id = Guid.NewGuid(),
                Title = "It",
                Author = author,
                ISBN = "9780340951453"
            };

            storageOne.Add(bookOne);
            Assert.IsTrue(storageOne.Contains(bookOne));
        }

        [TestMethod]
        public void Add_Student_Entity()
        {
            Storage storageTwo = new();
            Student studentOne = new()
            {
                Id = Guid.NewGuid(),
                FullName = new FullName("Kensuke", "Aida"),

                StudentID = 010           
            };

            storageTwo.Add(studentOne);
            Assert.IsTrue(storageTwo.Contains(studentOne));
        }

        [TestMethod]
        public void Add_Employee_Entity()
        {
            Storage storageThree = new();
            Employee employeeOne = new()
            {
                Id = Guid.NewGuid(),
                FullName = new FullName("Ritsuko", "Akagi"),
                Employer = "Nerv"
            };

            storageThree.Add(employeeOne);
            Assert.IsTrue(storageThree.Contains(employeeOne));
        }

        [TestMethod]

        public void Remove_Student_Entity() { 

            Storage storageOne = new();
            Student studentTwo = new()
            {
                Id = Guid.NewGuid(),
                FullName = new FullName("Toji", "Suzuhara"),
                StudentID = 03
            };
            storageOne.Add(studentTwo);
            storageOne.Remove(studentTwo);

            Assert.IsFalse(storageOne.Contains(studentTwo));
        }
    }

}

