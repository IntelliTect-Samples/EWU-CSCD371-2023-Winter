using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record class Student(Guid Id, FullName StudentName) : Person(Id, StudentName)
    {
    }
}
