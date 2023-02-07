using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record class Person(Guid Id, FullName FullName) : IEntity
    {
        //Implemented implicitly because there is no need for explicit implementation
        public string Name => $"{FullName.FirstName} {FullName.LastName}";
    }
}
