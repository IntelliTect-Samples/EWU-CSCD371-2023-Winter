using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record class Employee(Guid Id, FullName EmployeeName) : Person(Id, EmployeeName)
    {
    }
}
