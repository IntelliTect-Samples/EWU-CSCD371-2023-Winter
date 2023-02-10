using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FullNameTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FullName_NullFirstName_NullException()
        {
            string? name = null;
            Student studnetOne = new()
            {
                Id = Guid.NewGuid(),
                FullName = new FullName(name!, "Ayanami"),
                StudentID = 00
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FullName_NullLastName_NullException()
        {
            string? name = null;
            Student studnetTwo = new()
            {
                Id = Guid.NewGuid(),
                FullName = new FullName("Rei", name!),
                StudentID = 000
            };
        }

        [TestMethod]
        public void FullName_ReturnsName()
        {
            string? name = "Asuka Langley Soryu";

            Employee employeeOne = new Employee()
            {
                Id = Guid.NewGuid(),

                FullName = new FullName("Asuka", "Soryu","Langley"),
                Employer = "Nerv"
            };
            
            Assert.AreEqual(name, employeeOne.FullName.Name);
        }
    }
}
