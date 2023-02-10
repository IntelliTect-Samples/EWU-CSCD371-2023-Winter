using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract record class BasePerson : BaseEntity
    {
        public BasePerson(Guid id, FullName fullName)
        {
            Id = id;
            PersonFullName = fullName;
        }
        public FullName PersonFullName { get; }

        // Name is implemented implicitly because a name is something that obviously applies to a person.
        public override string Name
        {
            get
            {
                return PersonFullName.MiddleName is null
                    ? string.Format($"{PersonFullName.FirstName} {PersonFullName.LastName}")
                    : string.Format($"{PersonFullName.FirstName} {PersonFullName.MiddleName} {PersonFullName.LastName}");
            }
        }
    }
}
